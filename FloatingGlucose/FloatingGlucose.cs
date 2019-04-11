using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using FloatingGlucose.Classes.Extensions;
using FloatingGlucose.Classes.Utils;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static FloatingGlucose.Properties.Settings;
using FormSettings = FloatingGlucose.Properties.FormSettings;

namespace FloatingGlucose
{
    public partial class FloatingGlucose : Form
    {
        //nightscout URL, will be used to create a pebble endpoint to fetch data from
        private NameValueCollection datasourceLocation
        {
            get
            {
                // With raw glucose display we need to have two
                // data points to calculate raw glucose diff
                var count = Default.EnableRawGlucoseDisplay ? 2 : 1;
                var units = Default.GlucoseUnits;
                var urlstripped = Default.DataPathLocation.TrimEnd('/');
                return new NameValueCollection()
                {
                    { "raw", Default.DataPathLocation },
                    { "location", $"{urlstripped}/pebble?count={count}&units={units}"}
                };
            }
        }

        private int refreshTime => Default.RefreshIntervalInSeconds * 1000;//converted to milliseconds
                                                                           //private System.Windows.Forms.Timer refreshGlucoseTimer;

        private FormGlucoseSettings _settingsForm;

        private FormGlucoseSettings settingsForm
        {
            get
            {
                if (this._settingsForm == null || this._settingsForm.IsDisposed)
                {
                    this._settingsForm = new FormGlucoseSettings();
                }
                return this._settingsForm;
            }
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void setScaling(float scale)
        {
            if ((float)scale == 1.0)
            {
                return;
            }
            var ratio = new SizeF(scale, scale);
            this.Scale(ratio);
            //this is a hack. Scale() doesn't change font sizes
            // as this is a simple form with only labels, set new font sizes for these controls
            // based on the scaling factor used above
            var controls = this.Controls.OfType<Label>().ToList();
            controls.ForEach(x =>
            {
                x.Font = new Font(x.Font.Name, x.Font.SizeInPoints * scale);
            });
        }

        public FloatingGlucose()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;

            // check if the saved bounds are nonzero and visible on any screen
            if (FormSettings.Default.WindowPosition != Rectangle.Empty &&
                IsVisibleOnAnyScreen(FormSettings.Default.WindowPosition))
            {
                // first set the bounds
                var pos = FormSettings.Default.WindowPosition;

                this.Location = pos.Location;
            }
            else
            {
                //position at bottom right per FormSettings.Default
                var r = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(r.Width - this.Width, r.Height - this.Height);
            }
            //draws round corners
            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(Width, Height, Width, Height, 20, 20));
        }

        private void setFormSize()
        {
            // This is a nasty and ugly hack. It adjusts the size of the main form
            // Based on predicted max widths of it's contained elements
            // This must be set dynamically because the font sizes might change
            // if the scaling factor changes
            // Also is used the labels own font size to determine the widths
            // So the formula doesn't have to be updated if the label fonts are changed
            // during design-time.

            var rawbg = TextRenderer.MeasureText("999.0", this.lblRawBG.Font);
            var rawbgdiff = TextRenderer.MeasureText("+999.0", this.lblRawDelta.Font);

            var bg = TextRenderer.MeasureText("999.0 ⇈", this.lblGlucoseValue.Font);
            var diff = TextRenderer.MeasureText("+999.0", this.lblDelta.Font);
            var update = TextRenderer.MeasureText("59 minutes ago", this.lblLastUpdate.Font);

            float size = new[] { bg.Width, diff.Width, update.Width }.Max() * 1.09F;

            //raw glucose will not always be displayed
            if (Default.EnableRawGlucoseDisplay)
            {
                size += Math.Max(rawbg.Width, rawbgdiff.Width);
            }

            this.Width = (int)Math.Ceiling(size);
        }

        private void SetErrorState(Exception ex = null)
        {
            //if an error occurred in fetching data,
            //alarms shall be discontinued.
            var manager = SoundAlarm.Instance;
            manager.StopAlarm();

            this.lblRawBG.Text = "0";
            this.lblRawDelta.Text = "-";

            this.lblGlucoseValue.Text =
            this.lblDelta.Text =
            this.lblLastUpdate.Text = "N/A";
            if (ex != null && Default.EnableExceptionLoggingToStderr)
            {
                if (AppShared.isDebuggingBuild)
                {
                    Console.Out.WriteLine(ex);
                }
                else
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }

        private void SetSuccessState()
        {
            //this.lblGlucoseValue.Visible = true;
        }

        private void setLabelsColor(Color color)
        {
            this.lblGlucoseValue.ForeColor = color;
            //this.lblClickToCloseApp.ForeColor = color;
        }

        //
        // Main loop. This will be called each 60s and also when the settings are reloaded
        //
        private async void LoadGlucoseValue()
        {
            IDataSourcePlugin data = null;

            var alarmManger = SoundAlarm.Instance;
            var now = DateTime.Now;
            var alarmsPostponed = alarmManger.GetPostponedUntil();

            //cleanup context menu
            if (alarmsPostponed != null && alarmsPostponed < now)
            {
                this.postponedUntilFooToolStripMenuItem.Visible =
                this.reenableAlarmsToolStripMenuItem.Visible = false;
            }

            try
            {
                WriteDebug("Start Trying to refresh data");

                var endpoint = PluginLoader.Instance.GetActivePlugin();
                var name = endpoint.DataSourceShortName;

                WriteDebug($"Data will be fetched via plugin: {name}");

                if (AppShared.IsShowingSettings)
                {
                    //avoid further loading of glucose values if the user has settings view open
                    // the user will probably select new settings anyway..
                    WriteDebug("Could not refresh data, settingsform is modally open..!");
                    return;
                }

                endpoint.VerifyConfig(Default);

                data = await endpoint.GetDataSourceDataAsync(this.datasourceLocation);

                var glucoseDate = data.LocalDate;

                this.lblLastUpdate.Text = glucoseDate.ToTimeAgo();

                //
                // even if we have glucose data, don't display them if it's considered stale
                //
                if (Default.EnableAlarms)
                {
                    var urgentTime = now.AddMinutes(-Default.AlarmStaleDataUrgent);
                    var warningTime = now.AddMinutes(-Default.AlarmStaleDataWarning);
                    var isUrgent = glucoseDate <= urgentTime;
                    var isWarning = glucoseDate <= warningTime;
                    if (isUrgent || isWarning)
                    {
                        this.lblGlucoseValue.Text = "Stale";
                        this.lblDelta.Text = "data";
                        this.notifyIcon1.Text = "Stale data";

                        alarmManger.PlayStaleAlarm();

                        if (isUrgent)
                        {
                            setLabelsColor(Color.Red);
                        }
                        else
                        {
                            setLabelsColor(Color.Yellow);
                        }
                        WriteDebug("Refreshed, but got stale data");
                        return;
                    }
                }

                string arrow = data.DirectionArrow();

                if (endpoint.PluginHandlesFormatting)
                {
                    var result = endpoint.HandleFormatting();
                    this.lblGlucoseValue.Text = result[0];
                    this.lblLastUpdate.Text = result[1];
                    this.lblDelta.Text = result[2];
                    this.notifyIcon1.Text = result[3];
                }
                else
                {
                    //mgdl values are always reported in whole numbers
                    this.lblGlucoseValue.Text = Default.GlucoseUnits == "mmol" ?
                        $"{data.Glucose:N1} {arrow}" : $"{data.Glucose:N0} {arrow}";

                    this.notifyIcon1.Text = "BG: " + this.lblGlucoseValue.Text;
                    var status = GlucoseMath.GetGlucoseAlarmStatus((decimal)data.Glucose);

                    this.lblDelta.Text = data.FormattedDelta() + " " + (Default.GlucoseUnits == "mmol" ? "mmol/L" : "mg/dL");

                    if (Default.EnableRawGlucoseDisplay)
                    {
                        this.lblRawBG.Text = $"{data.RawGlucose:N1}";
                    }

                    this.SetSuccessState();

                    switch (status)
                    {
                        case GlucoseAlarmStatusEnum.UrgentHigh:
                        case GlucoseAlarmStatusEnum.UrgentLow:
                            setLabelsColor(Color.Red);
                            alarmManger.PlayGlucoseAlarm();
                            break;

                        case GlucoseAlarmStatusEnum.Low:
                        case GlucoseAlarmStatusEnum.High:
                            setLabelsColor(Color.Yellow);
                            alarmManger.PlayGlucoseAlarm();
                            break;

                        case GlucoseAlarmStatusEnum.Unknown:
                        case GlucoseAlarmStatusEnum.Normal:
                        default:
                            alarmManger.StopAlarm();
                            setLabelsColor(Color.Green);
                            break;
                    }

                    //this.BackgroundImage = this.renderGlucoseChart(Color.Black, Color.DarkCyan);
                }
            }
            catch (FileNotFoundException ex)
            {
                this.SetErrorState(ex);
                //will only happen during debugging, when the allow file:/// scheme is set
                this.showErrorMessage($"Could not find file '{ex.FileName}'!");

                return;
            }
            catch (IOException ex)
            {
                this.SetErrorState(ex);
            }
            catch(System.Threading.Tasks.TaskCanceledException ex)
            {
                // This might happen when a datasource attempts to get data from a remote location,
                // but for some reason that fails
                this.SetErrorState(ex);
            }
            catch (HttpRequestException ex)
            {
                this.SetErrorState(ex);
            }
            catch (JsonReaderException ex)
            {
                this.SetErrorState(ex);
            }
            catch (MissingDataException ex)
            {
                //typically happens during azure site restarts
                this.SetErrorState(ex);
            }
            catch (InvalidOperationException ex)
            {
                //might happen if json structure is correectly formed, but is missing data elements
                this.SetErrorState(ex);
            }
            catch (JsonSerializationException ex)
            {
                //typically happens during azure site restarts
                this.SetErrorState(ex);
            }
            catch (InvalidJsonDataException ex)
            {
                this.SetErrorState(ex);
                this.showErrorMessage(ex.Message);
                AppShared.SettingsFormShouldFocusAdvancedSettings = true;
                this.settingsForm.Visible = false;
                this.settingsForm.ShowDialogIfNonVisible();
            }
            catch (NoPluginChosenException)
            {
                //this will happen on first run, as there is no default set plugin anymore
                this.WriteDebug("No plugin is chosen");
                this.settingsForm.ShowDialogIfNonVisible();
            }
            catch (NoSuchPluginException ex)
            {
                var msg = "A datasource plugin was chosen that is no longer available, please choose another datasource: " + ex.Message;

                this.showErrorMessage(msg);
                this.settingsForm.ShowDialogIfNonVisible();
            }
            catch (ConfigValidationException ex)
            {
                this.SetErrorState(ex);
                this.showErrorMessage(ex.Message);
                this.settingsForm.ShowDialogIfNonVisible();
            }

            /* catch (Exception ex)
             {
                 var msg = "An unknown error occurred of type " + ex.GetType().ToString() + ": " + ex.Message;
                 this.showErrorMessage(msg);
                 Application.Exit();
             }*/

            try
            {
                if (Default.EnableRawGlucoseDisplay && data != null)
                {
                    this.lblRawDelta.Text = data.FormattedRawDelta();
                }
            }
            catch (InvalidJsonDataException)
            {
                // No data available.
                // This can happen even if raw glucose is enabled
                // as it required two data points to be available
                this.lblRawDelta.Text = "-";
            }

            //these are just for layout tests
            //this.lblGlucoseValue.Text = "+500.0";
            //this.lblRawBG.Text = "+489.5";
            //this.lblRawDelta.Text = "+50.0";
            //this.lblDelta.Text = "-50.0";

            WriteDebug("End Trying to refresh data");
        }

        private void setChildrenOnMouseDown()
        {
            var controls = this.Controls.OfType<Label>().ToList();
            controls.ForEach(x =>
            {
                x.MouseDown += (asender, ev) =>
                {
                    this.OnMouseDown(ev);
                };
            });
        }

        private static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            var manager = SoundAlarm.Instance;
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                AppShared.IsWorkStationLocked = true;
                if (Default.DisableSoundAlarmsOnWorkstationLock)
                {
                    manager.StopAlarm();
                }
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                AppShared.IsWorkStationLocked = false;
            }
            // Add your session lock "handling" code here
        }

        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }

            return false;
        }

        public void SaveWindowPosition()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                FormSettings.Default.WindowPosition = this.DesktopBounds;
            }
            else
            {
                FormSettings.Default.WindowPosition = this.RestoreBounds;
            }

            FormSettings.Default.Save();
        }

        private void setBackgroundImage()
        {
            var path = Default.BackgroundImage;
            if (path != "" && File.Exists(path))
            {
                try
                {
                    this.BackgroundImage = Image.FromFile(path);

                    if (Enum.TryParse(Default.BackgroundImageLayout, out ImageLayout choice))
                    {
                        this.BackgroundImageLayout = (ImageLayout)choice;
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

        private void FloatingGlucose_Load(object sender, EventArgs e)
        {
            // We want all data values to be formatted with a dot, not comma, as some cultures do
            // as this messes up the gui a bit
            // we avoid this: double foo=7.0; foo.toString() => "7,0" in the nb-NO culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            this.notifyIcon1.Icon = Properties.Resources.noun_335372_cc_v2;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            this.lblRawDelta.Visible =
            this.lblRawBG.Visible = Default.EnableRawGlucoseDisplay;

            // Manual scaling for now with values from config file
            // how to figure out the dpi:
            // this.CreateGraphics().DpiX > 96
            setScaling(Default.GuiScalingRatio);
            setChildrenOnMouseDown();

            notifyIcon1.BalloonTipClosed += (asender, ev) =>
            {
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
            };

            // Enable special color for  debugging,
            // This is very handy when developing with a Release binary running alongside a dev version
            /*if (AppShared.isDebuggingBuild)
            {
                this.BackColor = Color.LightBlue;
            }*/

            this.BackColor = Default.BackgroundColorHex.FromHexStringToColor();
            this.setBackgroundImage();

            AppShared.RegisterSettingsChangedCallback(Settings_Changed_Event);

            this.setFormSize();

            this.SetOpacity();

            this.LoadGlucoseValue();

            AppShared.refreshGlucoseTimer = new System.Windows.Forms.Timer();
            //auto refresh data once every x seconds
            AppShared.refreshGlucoseTimer.Interval = this.refreshTime;
            //every 60s (default) reload the glucose numbers from the Nightscout pebble endpoint
            AppShared.refreshGlucoseTimer.Tick += new EventHandler((asender, ev) => LoadGlucoseValue());
            AppShared.refreshGlucoseTimer.Start();
        }

        private Bitmap renderGlucoseChart(Color backColor, Color foreColor)
        {
            var w = this.Width;
            var h = this.Height;

            var chart = new Chart { Name = "chart2", Text = "chart2", Location = this.Location, TabIndex = 11, Visible = false };
            var chartArea1 = new ChartArea { Name = "ChartArea1" };
            var legend1 = new Legend { Name = "Legend1" };
            var series1 = new Series { ChartArea = "ChartArea1", Legend = "Legend1", Name = "Series1" };

            chart.ChartAreas.Add(chartArea1);

            chart.Legends.Add(legend1);
            chart.Series.Add(series1);
            chart.Size = new System.Drawing.Size(w, h);

            chart.BackColor = backColor;
            var area = chart.ChartAreas.ElementAt(0);

            area.BackColor = backColor;

            area.AxisX.MajorGrid.Enabled =
            area.AxisX.MinorGrid.Enabled =
            area.AxisY.MajorGrid.Enabled =
            area.AxisY.MinorGrid.Enabled =
            area.AxisX.LabelStyle.Enabled =
            area.AxisY.LabelStyle.Enabled = false;

            area.AxisX.Enabled =
            area.AxisY.Enabled = AxisEnabled.False;

            var dotseries = chart.Series.First();
            dotseries.MarkerSize = 5;
            dotseries.MarkerStyle = MarkerStyle.Circle;
            dotseries.IsVisibleInLegend = false;
            dotseries.ChartType = SeriesChartType.Point;
            dotseries.Color = foreColor;

            var lineseries = chart.Series.Add("Line");

            lineseries.ChartType = SeriesChartType.Line;
            lineseries.IsVisibleInLegend = false;
            lineseries.Color = foreColor;
            lineseries.MarkerSize = 1;

            //datetime, glucose
            //draws line between dots first
            lineseries.Points.AddXY(1800, 9.5);
            lineseries.Points.AddXY(1807, 10.4);
            lineseries.Points.AddXY(1815, 10.2);
            lineseries.Points.AddXY(1830, 4.5);

            //draws dots ontop of line
            dotseries.Points.AddXY(1800, 9.5);
            dotseries.Points.AddXY(1807, 10.4);
            dotseries.Points.AddXY(1815, 10.2);
            dotseries.Points.AddXY(1830, 4.5);

            //add 30% to maximum value and show it as max in the graph
            area.AxisY.Maximum = (10.4 * 1.30);
            area.AxisX.Maximum = (1830);

            chart.Visible = true;

            var bmp = new Bitmap(w, h);
            chart.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));
            return bmp;
        }

        private void SetOpacity()
        {
            if (this.Opacity != Default.GuiOpacity / 100D)
            {
                WriteDebug($"Setting opacity to {Default.GuiOpacity}%");
                this.Opacity = Default.GuiOpacity / 100D;
            }
        }

        private bool Settings_Changed_Event()
        {
            //we got notified via the appshared proxy that settings have been changed
            //try to load glucose values anew straight away
            this.setFormSize();

            this.BackColor = Default.BackgroundColorHex.FromHexStringToColor();
            this.setBackgroundImage();
            this.lblRawDelta.Visible =
            this.lblRawBG.Visible = Default.EnableRawGlucoseDisplay;

            this.SetOpacity();

            this.LoadGlucoseValue();

            //refreshTime => Default.RefreshIntervalInSeconds * 1000;

            if (AppShared.refreshGlucoseTimer?.Interval != this.refreshTime)
            {
                WriteDebug($"Resetting the refresh interval to {Default.RefreshIntervalInSeconds} seconds");
                AppShared.refreshGlucoseTimer?.Stop();
                if (AppShared.refreshGlucoseTimer != null)
                {
                    AppShared.refreshGlucoseTimer.Interval = this.refreshTime;
                }
            }

            //
            // The timer can be and will be stopped every time we're entering the settings
            // even if the refresh interval isn't changed
            //
            if (AppShared.refreshGlucoseTimer?.Enabled == false)
            {
                WriteDebug("Starting timer again");
                AppShared.refreshGlucoseTimer?.Start();
            }

            return false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //This enables dragging the floating window around the screen
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void WriteDebug(string line)
        {
            var now = DateTime.Now.ToUniversalTime();
            Debug.WriteLine(now + ":" + line);
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.settingsForm.ShowDialogIfNonVisible();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        private void Exit()
        {
            this.SaveWindowPosition();
            this.notifyIcon1.Icon = null;
            this.notifyIcon1.Dispose();
            this.notifyIcon1 = null;
            Application.Exit();
        }

        private void postponeAlarms(int minutes)
        {
            var manager = SoundAlarm.Instance;
            manager.PostponeAlarm(minutes);
            DateTime untilDate = (DateTime)manager.GetPostponedUntil();

            this.postponedUntilFooToolStripMenuItem.Text = $"Snoozing until {untilDate.ToShortTimeString()}";

            this.reenableAlarmsToolStripMenuItem.Visible =
            this.postponedUntilFooToolStripMenuItem.Visible = true;
        }

        private void showErrorMessage(string error)
        {
            MessageBox.Show(error, AppShared.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void postponeFor30MinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.postponeAlarms(30);
        }

        private void postponeFor90MinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.postponeAlarms(90);
        }

        private void reenableAlarmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manager = SoundAlarm.Instance;
            manager.RemovePostpone();

            this.reenableAlarmsToolStripMenuItem.Visible =
            this.postponedUntilFooToolStripMenuItem.Visible = false;
        }

        private void openNightscoutSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var url = Default.DataPathLocation;
            if (Validators.IsUrl(url))
            {
                try
                {
                    Process.Start(url);
                }
                catch (Win32Exception ex)
                {
                    this.showErrorMessage($"Could not open your nightscout site in the system default browser! {ex.Message}");
                }
            }
            else
            {
                this.showErrorMessage("The Nightscout url is not configured!");
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadGlucoseValue();
        }
    }
}