using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using FloatingGlucose.Classes;
using Newtonsoft.Json;
using System.Globalization;
using FloatingGlucose.Classes.Pebble;
using static FloatingGlucose.Properties.Settings;
using FloatingGlucose.Properties;
using FloatingGlucose.Classes.Extensions;

namespace FloatingGlucose
{

    public partial class FloatingGlucose : AutoPositionedForm
    {

        //nightscout URL, will be used to create a pebble endpoint to fetch data from
        private string nsURL {
            get {
                //AlarmUrgentLow
                // With raw glucose display we need to have two 
                // data points to calculate raw glucose diff
                var count = Default.EnableRawGlucoseDisplay ? 2 : 1;
                var units = Default.GlucoseUnits;
                return $"{Default.NightscoutSite}/pebble?count={count}&units={units}";
                
            }
        }


        private int refreshTime => Default.RefreshIntervalInSeconds * 1000;//converted to milliseconds
      
        
        
#if DEBUG
        private bool isDebuggingBuild = true;
#else
        private bool isDebuggingBuild = false; 
#endif

        private Form _settingsForm;
        private Form settingsForm {
            get {
                if (this._settingsForm == null || this._settingsForm.IsDisposed)
                {
                    this._settingsForm = new FormGlucoseSettings();
                }
                return this._settingsForm;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        private void setScaling(float scale) {
            if ((float)scale == 1.0) {
                return;
            }
            var ratio = new SizeF(scale, scale);
            this.Scale(ratio);
            //this is a hack. Scale() doesn't change font sizes
            // as this is a simple form with onlt labels, set new font sizes for these controls
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
            

        }

        private void setFormSize() {
            // This is a nasy and ugly hack. It adjusts the size of the main form
            // Based on predicted max widths of it's contained elements
            // This must be set dynamically because the font sizes might change
            // if the scaling factor changes
            // Also is used the labels own font size to determine the widths
            // So the formula doesn't have to be updated if the label fonts are changed
            // during design-time.

           

            var rawbg = TextRenderer.MeasureText("999.0"  ,  this.lblRawBG.Font);
            var rawbgdiff = TextRenderer.MeasureText("+999.0", this.lblRawDelta.Font);

            var bg = TextRenderer.MeasureText("999.0 ⇈", this.lblGlucoseValue.Font);
            var diff = TextRenderer.MeasureText("+999.0", this.lblDelta.Font);
            var update = TextRenderer.MeasureText("59 minutes ago", this.lblLastUpdate.Font);

            float size = new[] { bg.Width, diff.Width, update.Width }.Max() * 1.09F;
            
            //raw glucose will not always be displayed
            if (Default.EnableRawGlucoseDisplay) {
                size += Math.Max(rawbg.Width, rawbgdiff.Width);
            }

            
            this.Width = (int)Math.Ceiling(size);


        }


        private void SetErrorState(Exception ex=null) {

            this.lblRawBG.Text = "0";
            this.lblRawDelta.Text = "-";

            this.lblGlucoseValue.Text =
            this.lblDelta.Text =
            this.lblLastUpdate.Text = "N/A";
            if (ex != null && Default.EnableExceptionLoggingToStderr) {
                if (this.isDebuggingBuild) {
                    Console.Out.WriteLine(ex);
                }
                else
                {
                    Console.Error.WriteLine(ex);
                }
                
            }
            
        }
        private void SetSuccessState() {
            
            //this.lblGlucoseValue.Visible = true;
        
        }

        private void setLabelsColor(Color color) {
            this.lblGlucoseValue.ForeColor = color;
            //this.lblClickToCloseApp.ForeColor = color;


        } 

        //
        // Main loop. This will be called each 60s and also when the settings are reloaded
        //
        private async void LoadGlucoseValue() 
        {
            if (!Validators.IsUrl(this.nsURL)) {   
                MessageBox.Show("The nightscout_site setting is not specifed or invalid. Please update it from the settings!",
                    AppShared.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            PebbleData data = null;

            var alarmManger = SoundAlarm.Instance;
            var now = DateTime.Now;
            var alarmsPostponed = alarmManger.GetPostponedUntil();

            //cleanup context menu
            if (alarmsPostponed != null && alarmsPostponed < now) {
                this.postponedUntilFooToolStripMenuItem.Visible = 
                this.reenableAlarmsToolStripMenuItem.Visible = false;
            }


            try
            {
                WriteDebug("Trying to refresh data");

                data = await PebbleData.GetNightscoutPebbleDataAsync(this.nsURL);


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

                        return;
                    }
                }

                string arrow = data.DirectionArrow;

                //mgdl values are always reported in whole numbers
                this.lblGlucoseValue.Text = Default.GlucoseUnits == "mmol" ?
                    $"{data.Glucose:N1} {arrow}" : $"{data.Glucose:N0} {arrow}";

                this.notifyIcon1.Text = "BG: " + this.lblGlucoseValue.Text;
                var status = GlucoseStatus.GetGlucoseStatus((decimal) data.Glucose);


                this.lblDelta.Text = data.FormattedDelta + " " + (Default.GlucoseUnits == "mmol" ? "mmol/L" : "mg/dL");



                if (Default.EnableRawGlucoseDisplay)
                {
                    this.lblRawBG.Text = $"{data.RawGlucose:N1}";
                }

                this.SetSuccessState();


                switch (status)
                {
                    case GlucoseStatusEnum.UrgentHigh:
                    case GlucoseStatusEnum.UrgentLow:
                        setLabelsColor(Color.Red);
                        alarmManger.PlayGlucoseAlarm();
                        break;
                    case GlucoseStatusEnum.Low:
                    case GlucoseStatusEnum.High:
                        setLabelsColor(Color.Yellow);
                        alarmManger.PlayGlucoseAlarm();
                        break;

                    case GlucoseStatusEnum.Unknown:
                    case GlucoseStatusEnum.Normal:
                    default:
                        alarmManger.StopAlarm();
                        setLabelsColor(Color.Green);
                        break;

                }


            }
            catch (IOException ex)
            {
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
            catch (JsonSerializationException ex) {
                //typically happens during azure site restarts
                this.SetErrorState(ex);
            }
            catch (InvalidJsonDataException ex)
            {
                this.SetErrorState(ex);
                MessageBox.Show(ex.Message, AppShared.AppName, MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                AppShared.SettingsFormShouldFocusAdvancedSettings = true;

                this.settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                var msg = "An unknown error occured of type " + ex.GetType().ToString() + ": " + ex.Message;
                MessageBox.Show(msg, AppShared.AppName, MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                Application.Exit();
            }

            try {
                if (Default.EnableRawGlucoseDisplay && data != null) {
                    this.lblRawDelta.Text = data.FormattedRawDelta;
                }
            }
            catch (InvalidJsonDataException) {
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





        }

        private void setChildrenOnMouseDown() {

            var controls = this.Controls.OfType<Label>().ToList();
            controls.ForEach(x =>
            {
                x.MouseDown += (asender, ev) => {
                    this.OnMouseDown(ev);
                    
                };
            });
            
        }
        
        private void FloatingGlucose_Load(object sender, EventArgs e)
        {
            // We want all data values to be formatted with a dot, not comma, as some cultures do
            // as this messes up the gui a bit
            // we avoid this: double foo=7.0; foo.toString() => "7,0" in the nb-NO culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            this.notifyIcon1.Icon = Properties.Resources.noun_335372_cc;


            this.lblRawDelta.Visible =
            this.lblRawBG.Visible = Default.EnableRawGlucoseDisplay;

            // Manual scaling for now with values from config file
            // how to figure out the dpi:
            // this.CreateGraphics().DpiX > 96
            setScaling(Default.GuiScalingRatio);
            setChildrenOnMouseDown();


            notifyIcon1.BalloonTipClosed += (asender, ev) =>{
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
            };

            // Enable special label only for debugging, 
            // This is very handy when devloping with a Release binary running alongside a dev version
            if (this.isDebuggingBuild)
            {
                this.lblDebugModeOn.Visible = true;
            }


            AppShared.RegisterSettingsChangedCallback(Settings_Changed_Event);


            if (!Validators.IsUrl(this.nsURL)) {
                this.settingsForm.ShowDialog();

            }
            this.setFormSize();


            this.LoadGlucoseValue();
            
            var refreshGlucoseTimer = new System.Windows.Forms.Timer();
            //auto refresh data once every x seconds
            refreshGlucoseTimer.Interval = this.refreshTime;
            //every 60s (default) reload the glucose numbers from the nightscout pebble endpoint
            refreshGlucoseTimer.Tick += new EventHandler((asender, ev)=> LoadGlucoseValue());
            refreshGlucoseTimer.Start();



        }
        private bool Settings_Changed_Event() {

            //we got notified via the appshared proxy that settings have been changed
            //try to load glucose values anew straight away
            this.setFormSize();
            this.lblRawDelta.Visible =
            this.lblRawBG.Visible = Default.EnableRawGlucoseDisplay;

            this.LoadGlucoseValue();
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

        private void WriteDebug(string line) { 
            var now = DateTime.Now.ToUniversalTime();
            Debug.WriteLine(now + ":" + line);
        }


        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.settingsForm.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        private void Exit() {
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
            
            this.postponedUntilFooToolStripMenuItem.Text = $"Postponed until {untilDate.ToShortTimeString()}";

            this.reenableAlarmsToolStripMenuItem.Visible = 
            this.postponedUntilFooToolStripMenuItem.Visible = true;
            
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
    }
}
