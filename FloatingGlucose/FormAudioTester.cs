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
    public partial class FormAudioTester : Form
    {
        private SoundAlarm instance = new SoundAlarm();
        public FormAudioTester()
        {
            InitializeComponent();
        }

        private void FormAudioTester_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btnPlayStaleAlarm_Click(object sender, EventArgs e)
        {
            instance.PlayStaleAlarm();
        }

        private void btnPlayGlucoseAlarm_Click(object sender, EventArgs e)
        {
            instance.PlayGlucoseAlarm();
        }

        private void btnStopPlayback_Click(object sender, EventArgs e)
        {
            instance.StopAlarm();
        }
    }
}
