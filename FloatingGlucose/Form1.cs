using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using FloatingGlucose.Classes;
using Newtonsoft.Json;

namespace FloatingGlucose
{


    public partial class Form1 : Form
    {

        //nightscout URL, will be used to create a pebble endpoint to fetch data from
        private string nsURL = Properties.Settings.Default.nightscout_site;
        private bool loggingEnabled = Properties.Settings.Default.enable_exception_logging_to_stderr;
        private string appname = "FloatingGlucose";

        
        private int refreshTime = Properties.Settings.Default.refresh_interval_in_seconds * 1000;//milliseconds
#if DEBUG
        private bool isDebuggingBuild = true;
#else
        private bool isDebuggingBuild = false; 
#endif

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /*[return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        static extern bool AllowSetForegroundWindow(int procID);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);
        private uint SW_SHOWNORMAL = 1;*/
        private int glucoseLabelClickedCount = 0;
        

        public Form1()
        {
            InitializeComponent();

            //bug in newer .net frameworks? Means gotta set these properties as well
            //this.TopLevel = true;
            //this.TopMost = true;

           /* AllowSetForegroundWindow((int)Process.GetCurrentProcess().Id);
            SetForegroundWindow(Handle);
            ShowWindow(Handle, SW_SHOWNORMAL);*/

           


            //position at bottom right per default
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(r.Width - this.Width, r.Height - this.Height);

            // Enable special label only for debugging, 
            // This is very handy when devloping with a Release binary running alongside a dev version
            if (this.isDebuggingBuild) {
                this.lblDebugModeOn.Visible = true;
            }

        }
        private void SetErrorState(Exception ex=null) {

            this.lblGlucoseValue.Text = "N/A";
            this.lblLastUpdate.Text = "N/A";
            if (ex != null && this.loggingEnabled) {
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

        private async void LoadGlucoseValue() 
        {
            if (this.nsURL == null || !Uri.IsWellFormedUriString(nsURL, UriKind.RelativeOrAbsolute)) {
                MessageBox.Show("The nightscout_site setting is not specifed or invalid, will now Exit", this.appname, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Application.Exit();

            }

            try
            {
                WriteDebug("Trying to refresh data");
                //var data = await this.GetNightscoutPebbleDataAsync(nsURL + "/pebble");
                var data = await PebbleData.GetNightscoutPebbleDataAsync(nsURL + "/pebble");
                this.lblGlucoseValue.Text = String.Format("{0} {1}", data.glucose, data.directionArrow);
                this.lblLastUpdate.Text = data.localDate.ToTimeAgo();

                this.SetSuccessState();


            }
            catch (IOException ex)
            {
                this.SetErrorState(ex);

            }
            catch (HttpRequestException ex)
            {
                this.SetErrorState(ex);
            }
            catch (JsonReaderException ex) {
                this.SetErrorState(ex);
            }
            catch (Exception ex)
            {
                var msg = "An unknown error occured of type " + ex.GetType().ToString() + ": " + ex.Message;
                MessageBox.Show(msg, this.appname, MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                Application.Exit();
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadGlucoseValue();
            var refreshGlucoseTimer = new System.Windows.Forms.Timer();
            //auto refresh data once every x seconds
            
            refreshGlucoseTimer.Interval = this.refreshTime; 
            refreshGlucoseTimer.Tick += new EventHandler(Glucose_Tick);
            refreshGlucoseTimer.Start();
        }
        private void Glucose_Tick(object sender, EventArgs e)
        {
            LoadGlucoseValue();
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

        

        private void lblGlucose_Click(object sender, EventArgs e)
        {
            WriteDebug("Clicked BS-label!");
            this.glucoseLabelClickedCount += 1;

            //User has clicked the "BS" text five times already, must be intentional.
            //let him have access to the exit button
            if (this.glucoseLabelClickedCount % 4 == 0) {
                this.lblClickToCloseApp.Visible = !this.lblClickToCloseApp.Visible;
            }
          
        }

        private void lblClickToCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelDoNotEverRemoveThisLabel_Click(object sender, EventArgs e)
        {

        }

 



    }
}
