using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using FloatingGlucose.Classes.DataSources.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void txtDataSouceLocation_GotFocus(object sender, EventArgs e)
        {
            var colonPartPos = this.txtDataSourceLocation.Text.IndexOf("://");
            var azurePartPos = this.txtDataSourceLocation.Text.IndexOf(".azurewebsites.net");
            if(colonPartPos != -1 && azurePartPos != -1 && colonPartPos < azurePartPos)
            {
                this.txtDataSourceLocation.Select(colonPartPos+3, azurePartPos-colonPartPos-3);
            } 

        }
        private void txtDataSouceLocation_LostFocus(object sender, EventArgs e)
        {
            if (this.txtDataSourceLocation.Text == "")
            {
                this.txtDataSourceLocation.Text = "https://mysite.azurewebsites.net";
            }

        }


        private void updateAlarmSettingsEnabled(bool enabled=true) {
            
            var controls = this.grpAlarmSettings.Controls.OfType<NumericUpDown>().ToList();
            controls.ForEach(x =>
            {
                x.Enabled = enabled;
            });
            this.chkEnableSoundAlarms.Enabled = enabled;
        }

        private void updateFormControlsFromSettings() {

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
            var allPlugins = PluginLoader.Instance.GetAllPlugins();
            IDataSourcePlugin activePlugin;
            try
            {
                activePlugin = PluginLoader.Instance.GetActivePlugin();
            }
            catch(NoSuchPluginException)
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
                if(activePlugin != null && plugin.DataSourceShortName == activePlugin.DataSourceShortName)
                {
                    this.cbDataSource.SelectedItem = plugin;
                    plugin.Instance.OnPluginSelected(this);
                    this.btnBrowse.Visible = activePlugin.RequiresBrowseButton;
                }
                


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
                .Where(x=> x.DecimalPlaces == 1).ToList();
            controls.ForEach( x => {
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

        }

        void OnClosing(object sender, FormClosingEventArgs e)
        {
            AppShared.IsShowingSettings = false;
            if (AppShared.SettingsUpdatedSuccessfully) {
                base.OnClosing(e);
                AppShared.SettingsUpdatedSuccessfully = false;
                return;

            }
            // If shown modal, it means the initial setup is not complete
            // Close the app
            if (this.Modal)
            {
                //ignore for now
                // this was causing race conditions when multiple onclosing events would trigger in a short
                // time. The first event would set settingsupdatedsuccessfully=false nad reutnr
                // the next event would happen just a millisecond later and would see settingsupdatedsuccessfully==false
                // and exit
                //Application.Exit();
            }
            //reload to settings stored in file
            //user has aborted the changes
            //made in the gui
            Default.Reload();
            base.OnClosing(e);
            
        }

        private void btnEnableAlarms_CheckedChanged(object sender, EventArgs e)
        {
            this.updateAlarmSettingsEnabled(this.btnEnableAlarms.Checked);
            
        }

        private void btnVerifySubmit_Click(object sender, EventArgs e)
        {
            /*if (!Validators.IsUrl(this.txtDataSouceLocation.Text) || this.txtDataSouceLocation.Text == "https://mysite.azurewebsites.net") {
                MessageBox.Show("You have entered an invalid nightscout site URL", AppShared.AppName, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }*/

            

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
            Default.GuiOpacity = (int) this.numOpacity.Value;
            Default.RefreshIntervalInSeconds = (int)this.numRefreshInterval.Value;
            Default.EnableExceptionLoggingToStderr = this.chkEnableExceptions.Checked;

            Default.DisableSoundAlarmsOnWorkstationLock = this.chkDisableSoundOnWorkstationLock.Checked;
            Default.EnableRawGlucoseDisplay = this.chkEnableRAWGlucose.Checked;

            //Save plugin type based on the selected fullname
            Default.DataSourceFullName = (this.cbDataSource.SelectedItem as DataSourceInfo).FullName;


            DataSourceInfo plugin;

            try
            {
                plugin = (DataSourceInfo)this.cbDataSource.SelectedItem;
                plugin.Instance.VerifyConfig(Default);
            }
            catch (ConfigValidationError ce)
            {
                MessageBox.Show(ce.Message, AppShared.AppName, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            Default.DataSourceFullName = plugin.FullName;
            //this is here for a purpose
            //only save if validation succeeded.
            Default.Save();

            if (!this.chkEnableSoundAlarms.Checked)
            {
                var manager = SoundAlarm.Instance;
                manager.StopAlarm();
            }


            AppShared.SettingsUpdatedSuccessfully = true;
            MessageBox.Show("Settings have been saved! Please note: some settings might require a restart to take effect!",
                AppShared.AppName, MessageBoxButtons.OK,MessageBoxIcon.Information);
            AppShared.IsShowingSettings = false;
            AppShared.NotifyFormSettingsHaveChanged();

            
            this.Close();
        }

        private void NumericUpDowns_Value_Changed(object sender, EventArgs e)
        {
            if (sender == null) {
                return;
            }

            var button = sender as NumericUpDown;

            //if above 36,assume this is a mg/dl value rather than mmol/L
            button.Increment = button.Value >= 36 ? 1.0M : 0.1M;


            

        }

        private void GlucoseUnit_Changed(object sender, EventArgs e)
        {
            var isMmol = this.btnUnitsMMOL.Checked;
            
            if (isMmol) {
                if (this.numUrgentHigh.Value >= 36)
                {
                    this.numUrgentHigh.Value = GlucoseStatus.ToMmol(this.numUrgentHigh.Value);
                }
                if (this.numHigh.Value >= 36)
                {
                    this.numHigh.Value = GlucoseStatus.ToMmol(this.numHigh.Value);
                }

                if (this.numLow.Value >= 36)
                {
                    this.numLow.Value = GlucoseStatus.ToMmol(this.numLow.Value);
                }

                if (this.numUrgentLow.Value >= 36)
                {
                    this.numUrgentLow.Value = GlucoseStatus.ToMmol(this.numUrgentLow.Value);
                }

            }

            else 
            {
                if (this.numUrgentHigh.Value < 36)
                {
                    this.numUrgentHigh.Value = GlucoseStatus.ToMgdl(this.numUrgentHigh.Value);
                }
                if (this.numHigh.Value < 36)
                {
                    this.numHigh.Value = GlucoseStatus.ToMgdl(this.numHigh.Value);
                }

                if (this.numLow.Value < 36)
                {
                    this.numLow.Value = GlucoseStatus.ToMgdl(this.numLow.Value);
                }

                if (this.numUrgentLow.Value < 36)
                {
                    this.numUrgentLow.Value = GlucoseStatus.ToMgdl(this.numUrgentLow.Value);
                }

            }


        }

        private void cbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPlugin = (this.cbDataSource.SelectedItem as DataSourceInfo);
            PluginLoader.Instance.SetActivePlugin(selectedPlugin.FullName);
            selectedPlugin.Instance.OnPluginSelected(this);

            this.btnBrowse.Visible = selectedPlugin.Instance.RequiresBrowseButton;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var selectedPlugin = (this.cbDataSource.SelectedItem as DataSourceInfo);

            dialog.Filter = selectedPlugin.Instance.BrowseDialogFileFilter;
            dialog.InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory);
            dialog.Title = "Select a file for the plugin to handle";
            
            if (dialog.ShowDialog() == DialogResult.OK) {
                this.txtDataSourceLocation.Text = dialog.FileName;
            }
            dialog.Dispose();
            dialog = null;
        }

        private void txtDataSouceLocation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
