using FloatingGlucose.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FloatingGlucose
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormGlucoseSettings());
            //Application.Run(new FormAudioTester());
            //Application.Run(new AutoPositionedForm());
            //return;
            try
            {
                Application.Run(new FloatingGlucose());
                var manager = SoundAlarm.Instance;
                manager.StopAlarm();
            }
            catch (ObjectDisposedException)
            {
                // this happens when application.exit() is called when the form has a modal dialog open
                // ignore for now
            }
        }
    }
}