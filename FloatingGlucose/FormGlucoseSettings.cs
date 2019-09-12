﻿using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using FloatingGlucose.Classes.Extensions;
using FloatingGlucose.Classes.Utils;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static FloatingGlucose.Properties.Settings;

namespace FloatingGlucose
{
    public partial class FormGlucoseSettings : Form
    {
        public FormGlucoseSettings()
        {
            InitializeComponent();
        }

        private void updateAlarmSettingsEnabled(bool enabled = true)
        {
            var controls = this.grpAlarmSettings.Controls.OfType<NumericUpDown>().ToList();
            controls.ForEach(x =>
            {
                x.Enabled = enabled;
            });
            this.chkEnableSoundAlarms.Enabled = enabled;
        }

        private void updateFormControlsFromSettings()
        {
            var enableAlarms = Default.EnableAlarms;
            var alarmUrgentHigh = Default.AlarmUrgentHigh;
            var alarmHigh = Default.AlarmHigh;
            var alarmLow = Default.AlarmLow;
            var alarmUrgentLow = Default.AlarmUrgentLow;
            var nsurl = Default.DataPathLocation;

            var staleWarning = Default.AlarmStaleDataWarning;
            var staleUrgent = Default.AlarmStaleDataUrgent;

            this.numUrgentHigh.Value = alarmUrgentHigh;
            this.numHigh.Value = alarmHigh;
            this.numLow.Value = alarmLow;
            this.numUrgentLow.Value = alarmUrgentLow;

            this.numStaleWarning.Value = staleWarning;
            this.numStaleUrgent.Value = staleUrgent;

            this.chkEnableSoundAlarms.Checked = Default.EnableSoundAlarms;

            this.btnUnitsMMOL.Checked = Default.GlucoseUnits == "mmol";
            this.btnUnitsMGDL.Checked = Default.GlucoseUnits == "mgdl";

            //advanced settings
            this.numScaling.Value = (decimal)Default.GuiScalingRatio;
            this.numOpacity.Value = Default.GuiOpacity;
            this.numRefreshInterval.Value = Default.RefreshIntervalInSeconds;
            this.chkEnableExceptions.Checked = Default.EnableExceptionLoggingToStderr;
            this.chkEnableRAWGlucose.Checked = Default.EnableRawGlucoseDisplay;

            this.chkDisableSoundOnWorkstationLock.Checked = Default.DisableSoundAlarmsOnWorkstationLock;

            this.radioBtnBackgroundImage.Checked = Default.EnableBackgroundImage;
            this.txtBackColor.Text = Default.BackgroundColorHex;
            this.txtBackImage.Text = Default.BackgroundImage;
            this.cbImageLayouts.SelectedItem = Default.BackgroundImageLayout;

            this.chkEnableInvertedTrayIcon.Checked = Default.EnableInvertedTrayIcon;

            //this is the default in the settings file
            //override it so it makes sense
            if (nsurl == "https://...")
            {
                this.txtDataSourceLocation.Text = "https://mysite.azurewebsites.net";
            }
            else
            {
                this.txtDataSourceLocation.Text = nsurl;
            }

            this.txtUserName.Text = Default.UserName;

            var pass = Default.HashedPassword?.Text ?? "";
            if (pass.Length > 0)
            {
                this.txtPassword.Text = pass;
            }

            this.updateAlarmSettingsEnabled(enableAlarms);
            this.btnEnableAlarms.Checked = enableAlarms;
        }

        private void FormGlucoseSettings_Load(object sender, EventArgs e)
        {
            this.updateFormControlsFromSettings();
            this.FormClosing += this.OnClosing;

            this.lblVersionInfo.Text = "Version: " + AppShared.AppVersion;
            this.lblVersionInfo.Enabled = true;

            /*this.btnBrowse.Image = Properties.Resources.browse_file.ToBitmap();
            this.btnBrowse.Size = new Size(32,32);
            this.btnBrowse.Text = "";*/

            //browse button control visibility logic
            //this.tblpDataSourceLocations.GetControlFromPosition(1, 0).Visible = false;
            this.btnBrowse.Visible = false;
            // Fill the list of plugins, these are fairly static and won't change during runtime
            var allPlugins = PluginLoader.Instance.GetAllPlugins().OrderBy(x => x.Instance.SortOrder).ToList();
            IDataSourcePlugin activePlugin;
            try
            {
                activePlugin = PluginLoader.Instance.GetActivePlugin();
            }
            catch (NoSuchPluginException)
            {
                activePlugin = null;
            }
            catch (NoPluginChosenException)
            {
                activePlugin = null;
            }
            this.cbDataSource.Items.Clear();

            foreach (DataSourceInfo plugin in allPlugins)
            {
                this.cbDataSource.Items.Add(plugin);
                if (activePlugin != null && plugin.DataSourceShortName == activePlugin.DataSourceShortName)
                {
                    this.cbDataSource.SelectedItem = plugin;
                    plugin.Instance.OnPluginSelected(this);

                    this.lblAck.Text = activePlugin.Acknowledgment;
                    this.btnBrowse.Visible = activePlugin.RequiresBrowseButton;
                    this.lblDataSourceLocation.Enabled = txtDataSourceLocation.Enabled = activePlugin.RequiresDataSource;
                    this.paneUserNamePassword.Enabled = activePlugin.RequiresUserNameAndPassword;
                }
            }

            this.cbImageLayouts.Items.Clear();

            foreach (var layout in Enum.GetNames(typeof(ImageLayout)))
            {
                this.cbImageLayouts.Items.Add(layout);

                if (Default.BackgroundImageLayout == layout)
                {
                    this.cbImageLayouts.SelectedItem = layout;
                }
            }

            if (this.cbImageLayouts.SelectedIndex == -1)
            {
                this.cbImageLayouts.SelectedIndex = 0;
            }

            //de-uglify glucosesettings by setting a default plugin even if there was none selected
            //or a previously included plugin was selected that has been renamed or removed
            if (activePlugin == null)
            {
                this.cbDataSource.SelectedIndex = 0;
            }

            var selectedInstance = this.cbDataSource.SelectedItem;

            //different increments for mmol/L and mg/dL
            var controls = this.grpAlarmSettings.Controls.OfType<NumericUpDown>()
                .Where(x => x.DecimalPlaces == 1).ToList();
            controls.ForEach(x =>
            {
                x.Increment = x.Value >= 36 ? 1.0M : 0.1M;
                x.ValueChanged += new System.EventHandler(this.NumericUpDowns_Value_Changed);
            });

            if (AppShared.SettingsFormShouldFocusAdvancedSettings)
            {
                AppShared.SettingsFormShouldFocusAdvancedSettings = false;
                this.tabSettings.SelectTab(this.tabPageAdvanced);
            }
            else
            {
                this.tabSettings.SelectTab(this.tabPageBasic);
                this.txtDataSourceLocation.Select();
            }

            //disable BackgroundImage inputs, when BackgroundColor is selected
            if (radioBtnBackgroundColor.Checked == true)
            {
                txtBackImage.Enabled = false;
                btnBrowseBackImage.Enabled = false;
                cbImageLayouts.Enabled = false;
            }
            else
            {
                txtBackColor.Enabled = false;
            }

        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            AppShared.IsShowingSettings = false;

            if (AppShared.SettingsUpdatedSuccessfully)
            {
                base.OnClosing(e);
                AppShared.SettingsUpdatedSuccessfully = false;

                return;
            }

            Debug.WriteLine("No settings changed; Restarting timer, as it was previously stopped");
            AppShared.refreshGlucoseTimer?.Start();

            //reload to settings stored in file
            //user has aborted the changes
            //made in the gui
            Debug.WriteLine("Resetting defaults values");

            Default.Reload();
            base.OnClosing(e);
        }

        private void btnEnableAlarms_CheckedChanged(object sender, EventArgs e)
        {
            this.updateAlarmSettingsEnabled(this.btnEnableAlarms.Checked);
        }

        private void btnVerifySubmit_Click(object sender, EventArgs e)
        {
            /*if (!Validators.IsUrl(this.txtDataSourceLocation.Text) || this.txtDataSourceLocation.Text == "https://mysite.azurewebsites.net") {
                MessageBox.Show("You have entered an invalid Nightscout site URL", AppShared.AppName, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }*/

            Default.UserName = this.txtUserName.Text;

            Default.HashedPassword = new DataProtector(this.txtPassword.Text);

            Default.DataPathLocation = this.txtDataSourceLocation.Text;
            Default.EnableAlarms = this.btnEnableAlarms.Checked;
            Default.AlarmUrgentHigh = this.numUrgentHigh.Value;
            Default.AlarmHigh = this.numHigh.Value;
            Default.AlarmLow = this.numLow.Value;
            Default.AlarmUrgentLow = this.numUrgentLow.Value;
            Default.GlucoseUnits = this.btnUnitsMMOL.Checked ? "mmol" : "mgdl";

            Default.AlarmStaleDataUrgent = (int)this.numStaleUrgent.Value;
            Default.AlarmStaleDataWarning = (int)this.numStaleWarning.Value;
            Default.EnableSoundAlarms = this.chkEnableSoundAlarms.Checked;

            //advanced settings
            Default.GuiScalingRatio = (float)this.numScaling.Value;
            Default.GuiOpacity = (int)this.numOpacity.Value;
            Default.RefreshIntervalInSeconds = (int)this.numRefreshInterval.Value;
            Default.EnableExceptionLoggingToStderr = this.chkEnableExceptions.Checked;

            Default.DisableSoundAlarmsOnWorkstationLock = this.chkDisableSoundOnWorkstationLock.Checked;
            Default.EnableRawGlucoseDisplay = this.chkEnableRAWGlucose.Checked;


            Default.EnableBackgroundImage = this.radioBtnBackgroundImage.Checked;
            Default.BackgroundColorHex = this.txtBackColor.Text;
            Default.BackgroundImage = this.txtBackImage.Text;
            Default.EnableInvertedTrayIcon = this.chkEnableInvertedTrayIcon.Checked;

            //Save plugin type based on the selected fullname
            Default.DataSourceFullName = (this.cbDataSource.SelectedItem as DataSourceInfo).FullName;

            Default.BackgroundImageLayout = (cbImageLayouts.SelectedItem as String) ?? "Stretch";

            DataSourceInfo plugin;

            try
            {
                plugin = (DataSourceInfo)this.cbDataSource.SelectedItem;
                plugin.Instance.VerifyConfig(Default);
            }
            catch (ConfigValidationException ce)
            {
                MessageBox.Show(ce.Message, AppShared.AppName, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            Default.DataSourceFullName = plugin.FullName;
            //this is here for a purpose

            var selectedPlugin = (this.cbDataSource.SelectedItem as DataSourceInfo);
            PluginLoader.Instance.SetActivePlugin(selectedPlugin.FullName);

            //only save if validation succeeded.
            Default.Save();

            if (!this.chkEnableSoundAlarms.Checked)
            {
                var manager = SoundAlarm.Instance;
                manager.StopAlarm();
            }

            AppShared.SettingsUpdatedSuccessfully = true;
            MessageBox.Show("Settings have been saved! Please note: some settings might require a restart to take effect!",
                AppShared.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            AppShared.IsShowingSettings = false;

            AppShared.NotifyFormSettingsHaveChanged();

            this.Close();
        }

        private void NumericUpDowns_Value_Changed(object sender, EventArgs e)
        {
            var button = sender as NumericUpDown;

            if (button != null)
            {
                var above = button.Value >= 36;
                if (above)
                {
                    //if above 36,assume this is a mg/dl value rather than mmol/L
                    //for mgdl we really never want decimals..
                    button.Increment = 1.0M;
                    button.Value = Math.Round(button.Value, 1);
                }
                else
                {
                    button.Increment = 0.1M;
                }
            }
        }

        private void GlucoseUnit_Changed(object sender, EventArgs e)
        {
            var isMmol = this.btnUnitsMMOL.Checked;

            if (isMmol)
            {
                if (this.numUrgentHigh.Value >= 36)
                {
                    this.numUrgentHigh.Value = GlucoseMath.ToMmol(this.numUrgentHigh.Value);
                }
                if (this.numHigh.Value >= 36)
                {
                    this.numHigh.Value = GlucoseMath.ToMmol(this.numHigh.Value);
                }

                if (this.numLow.Value >= 36)
                {
                    this.numLow.Value = GlucoseMath.ToMmol(this.numLow.Value);
                }

                if (this.numUrgentLow.Value >= 36)
                {
                    this.numUrgentLow.Value = GlucoseMath.ToMmol(this.numUrgentLow.Value);
                }
            }
            else
            {
                if (this.numUrgentHigh.Value < 36)
                {
                    this.numUrgentHigh.Value = GlucoseMath.ToMgdl(this.numUrgentHigh.Value);
                }
                if (this.numHigh.Value < 36)
                {
                    this.numHigh.Value = GlucoseMath.ToMgdl(this.numHigh.Value);
                }

                if (this.numLow.Value < 36)
                {
                    this.numLow.Value = GlucoseMath.ToMgdl(this.numLow.Value);
                }

                if (this.numUrgentLow.Value < 36)
                {
                    this.numUrgentLow.Value = GlucoseMath.ToMgdl(this.numUrgentLow.Value);
                }
            }
        }

        private void cbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPlugin = (this.cbDataSource.SelectedItem as DataSourceInfo);
            //PluginLoader.Instance.SetActivePlugin(selectedPlugin.FullName);
            selectedPlugin.Instance.OnPluginSelected(this);
            this.lblAck.Text = selectedPlugin.Instance.Acknowledgment;
            this.paneUserNamePassword.Enabled = selectedPlugin.Instance.RequiresUserNameAndPassword;
            this.lblDataSourceLocation.Enabled = txtDataSourceLocation.Enabled = selectedPlugin.Instance.RequiresDataSource;
            this.btnBrowse.Visible = selectedPlugin.Instance.RequiresBrowseButton;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var selectedPlugin = (this.cbDataSource.SelectedItem as DataSourceInfo);

            var file = this.txtDataSourceLocation.Text;
            var ext = (file.Split('.')?.Last() ?? "").ToLower();

            dialog.Filter = selectedPlugin.Instance.BrowseDialogFileFilter;
            dialog.InitialDirectory = ext.Length > 0 && File.Exists(file) ? Path.GetDirectoryName(file) : Path.GetPathRoot(Environment.SystemDirectory);
            dialog.Title = "Select a file for the plugin to handle";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtDataSourceLocation.Text = dialog.FileName;
            }
            dialog.Dispose();
            dialog = null;
        }

        private void btnBrowseBackImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            var codecs = ImageCodecInfo.GetImageEncoders();
            var sep = "";

            var i = 0;

            var file = this.txtBackImage.Text;
            var ext = (file.Split('.')?.Last() ?? "").ToLower();

            foreach (var c in codecs)
            {
                i++;
                var codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dialog.Filter = String.Format("{0}{1}{2} ({3})|{3}", dialog.Filter, sep, codecName, c.FilenameExtension);

                //if an image is previously set, set that image extension as selected
                if (ext.Length > 0 && c.FilenameExtension.ToLower().IndexOf(ext) != -1)
                {
                    dialog.FilterIndex = i;
                }

                sep = "|";
            }

            dialog.InitialDirectory = ext.Length > 0 && File.Exists(file) ? Path.GetDirectoryName(file) : Path.GetPathRoot(Environment.SystemDirectory);
            dialog.Title = "Select a background image";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtBackImage.Text = dialog.FileName;
            }
            dialog.Dispose();
            dialog = null;
        }

        private void RadioBtnBackgroundImage_CheckedChanged(object sender, EventArgs e)
        {
            //disable BackgroundColor inputs, when BackgroundImage is selected
            txtBackImage.Enabled = true;
            btnBrowseBackImage.Enabled = true;
            cbImageLayouts.Enabled = true;
            txtBackColor.Enabled = false;
            btnBrowseBackColor.Enabled = false;
        }

        private void RadioBtnBackgroundColor_CheckedChanged(object sender, EventArgs e)
        {
            //disable BackgroundImage inputs, when BackgroundColor is selected
            txtBackImage.Enabled = false;
            btnBrowseBackImage.Enabled = false;
            cbImageLayouts.Enabled = false;
            txtBackColor.Enabled = true;
            btnBrowseBackColor.Enabled = true;
        }

        private void btnBrowseBackColor_Click(object sender, EventArgs e)
        {
            this.clrBack.AnyColor = false;
            this.clrBack.ShowDialog();
            this.txtBackColor.Text = this.clrBack.Color.ToHexString();
        }
    }
}