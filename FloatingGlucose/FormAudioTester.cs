using FloatingGlucose.Classes;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FloatingGlucose
{
    public partial class FormAudioTester : Form
    {
        private SoundAlarm instance = SoundAlarm.Instance;

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