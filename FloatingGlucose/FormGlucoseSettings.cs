using FloatingGlucose.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingGlucose
{
    public partial class FormGlucoseSettings : Form
    {
        private string appname = AppDefaults.appName;
        private bool settingsUpdatedSucessfully = false;
        public FormGlucoseSettings()
        {
            InitializeComponent();
        }

        private void txtNSURL_GotFocus(object sender, EventArgs e)
        {
            var colonPartPos = this.txtNSURL.Text.IndexOf("://");
            var azurePartPos = this.txtNSURL.Text.IndexOf(".azurewebsites.net");
            if(colonPartPos != -1 && azurePartPos != -1 && colonPartPos < azurePartPos)
            {
                this.txtNSURL.Select(colonPartPos+3, azurePartPos-colonPartPos-3);
            } 

        }
        private void txtNSURL_LostFocus(object sender, EventArgs e)
        {
            if (this.txtNSURL.Text == "")
            {
                this.txtNSURL.Text = "https://mysite.azurewebsites.net";
            }

        }

        private void txtNSURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void updateAlarmSettingsEnabled(bool enabled=true) {
            
            var controls = this.grpAlarmSettings.Controls.OfType<NumericUpDown>().ToList();
            controls.ForEach(x =>
            {
                x.Enabled = enabled;
            });
        }

        private void updateFormControlsFromSettings() {

            var enableAlarms = Properties.Settings.Default.enable_alarms;
            var alarmUrgentHigh = Properties.Settings.Default.alarm_urgent_high;
            var alarmHigh = Properties.Settings.Default.alarm_high;
            var alarmLow = Properties.Settings.Default.alarm_low;
            var alarmUrgentLow = Properties.Settings.Default.alarm_urgent_low;
            var nsurl = Properties.Settings.Default.nightscout_site;
            var showAppsettingsAndExitButton = Properties.Settings.Default.on_startup_show_buttons;

            this.numUrgentHigh.Value = alarmUrgentHigh;
            this.numHigh.Value = alarmHigh;
            this.numLow.Value = alarmLow;
            this.numUrgentLow.Value = alarmUrgentLow;

            //this is the default in the settings file
            //override it so it makes sense
            if (nsurl == "https://...")
            {
                this.txtNSURL.Text = "https://mysite.azurewebsites.net";
            }
            else
            {
                this.txtNSURL.Text = nsurl;
            }

            this.chkShowAppSettingsAndExit.Checked = showAppsettingsAndExitButton;

            this.updateAlarmSettingsEnabled(enableAlarms);
            this.btnEnableAlarms.Checked = enableAlarms;

        }


        private void FormGlucoseSettings_Load(object sender, EventArgs e)
        {
            this.updateFormControlsFromSettings();
            this.FormClosing += this.OnClosing;


        }

        void OnClosing(object sender, FormClosingEventArgs e)
        {

            if (this.settingsUpdatedSucessfully) {
                base.OnClosing(e);
                settingsUpdatedSucessfully = false;
                return;

            }
            // If shown modal, it means the initial setup is not complete
            // Close the app
            if (this.Modal)
            {
                Application.Exit();
            }

            base.OnClosing(e);
            
        }

        private void btnEnableAlarms_CheckedChanged(object sender, EventArgs e)
        {
            this.updateAlarmSettingsEnabled(this.btnEnableAlarms.Checked);
            
        }

        private void btnVerifySubmit_Click(object sender, EventArgs e)
        {
            if (!Validators.isUrl(this.txtNSURL.Text) || this.txtNSURL.Text == "https://mysite.azurewebsites.net") {
                MessageBox.Show("You have entered an invalid nightscout site URL", this.appname, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.nightscout_site = this.txtNSURL.Text;
            Properties.Settings.Default.enable_alarms = this.btnEnableAlarms.Checked;
            Properties.Settings.Default.alarm_urgent_high = this.numUrgentHigh.Value;
            Properties.Settings.Default.alarm_high = this.numHigh.Value;
            Properties.Settings.Default.alarm_low = this.numLow.Value;
            Properties.Settings.Default.alarm_urgent_low = this.numUrgentLow.Value;
            Properties.Settings.Default.on_startup_show_buttons = this.chkShowAppSettingsAndExit.Checked;
            Properties.Settings.Default.Save();

            this.settingsUpdatedSucessfully = true;
            MessageBox.Show("Settings have been saved! Please note: some settings might require a restart to take effect!", this.appname, MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            this.Close();
        }
    }
}
