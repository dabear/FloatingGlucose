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


namespace FloatingIcon
{


    public partial class Form1 : Form
    {

        //log file where glucose values are stored
        //the file can have multiple lines, but only the last line
        //will be considered.
        //format: date|glucose
        //example contents:
        // 21.07.2016 14:16|6.3
        // 21.07.2016 14:26|6.8
        private string path = Properties.Settings.Default.LogFilePath;

        // Displays this text next to the glucose value
        // note that no conversion to/from mmol
        // is done on the values fetched from glucose.log
        private string glucoseUnitText = Properties.Settings.Default.GlucoseUnitText;

        private string appname = "FloatingGlucose";

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

        private DateTime lastGlucoseUpdate;
        private int glucoseLabelClickedCount = 0;

        public Form1()
        {
            InitializeComponent();
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
        private void SetErrorState() {
            this.lblGlucoseNotAvailable.Visible = true;
            this.lblGlucoseValue.Visible = false;
        }
        private void SetSuccessState() {
            this.lblGlucoseNotAvailable.Visible = false;
            this.lblGlucoseValue.Visible = true;
        
        }

        private string DirectyionToArrow(string direction) {

            switch (direction) {
                case "DoubleUp":
                    return "⇈";
                case "SingleUp":
                    return "↑";
                case "FortyFiveUp":
                    return "↗";
                case "Flat":
                    return "→";
                case "FortyFiveDown":
                    return "↘";
                case "SingleDown":
                    return "↓";
                case "DoubleDown":
                    return "⇊";
                case "NOT COMPUTABLE":
                    return "-";
                case "RATE OUT OF RANGE":
                    return "⇕";
                default:
                case "None":
                    return "⇼";

            
            }
        
        }

        private void StartFileSystemWatcher()
        {
            string folderPath = Path.GetDirectoryName(this.path);

            // If there is no folder selected, to nothing
            if (string.IsNullOrWhiteSpace(folderPath))
                return;

            System.IO.FileSystemWatcher fileSystemWatcher = new System.IO.FileSystemWatcher();

            // Set folder path to watch
            fileSystemWatcher.Path = folderPath;
            //hack to make file system events pop up on the main thread
            fileSystemWatcher.SynchronizingObject = this.labelDoNotEverRemoveThisLabel;

            // Gets or sets the type of changes to watch for.
            // In this case we will watch change of filename, last modified time, size and directory name
            fileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.FileName |
                System.IO.NotifyFilters.LastWrite |
                System.IO.NotifyFilters.Size |
                System.IO.NotifyFilters.DirectoryName;


            // Event handlers that are watching for specific event
            fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(glucoseLogSystemWatcher_event);
            fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(glucoseLogSystemWatcher_event);
            fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(glucoseLogSystemWatcher_event);
            fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(glucoseLogSystemWatcher_event);

            // NOTE: If you want to monitor specified files in folder, you can use this filter
            fileSystemWatcher.Filter = Path.GetFileName(path);

            // START watching
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        


        private void LoadGlucoseValue() 
        {
            
            
            try
            {
                var split = File.ReadAllLines(path).Last().Split('|');
                var date = split.First();
                var glucose = split.ElementAt(1);
                var direction = split.Last();
                var directionArrow = this.DirectyionToArrow(direction);

                this.lblGlucoseValue.Text = String.Format("{0} {1} {2}", glucose, this.glucoseUnitText, directionArrow);
                this.lblLastUpdate.Text = date;

                this.lastGlucoseUpdate = DateTime.Now;

                this.SetSuccessState();
                StartFileSystemWatcher();
                
            }
            catch (IOException ex)
            {
                this.SetErrorState();

            }
            catch(Exception ex)
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

        private async void glucoseLogSystemWatcher_event(object sender, FileSystemEventArgs e)
        {
            WriteDebug("Got filesystem event, waiting 7 seconds..");
            // delays the event up to seven seconds (to make sure the file is fully written before loading new values)
            
            await Task.Delay(7000);

            // makes sure that only one event is handled
            // every 5 seconds. Multiple fired change events will in effect be cancelled.
            if (DateTime.Now.AddSeconds(-5) > this.lastGlucoseUpdate)
            {
                LoadGlucoseValue();
                WriteDebug("Got file system event and called LoadClucoseValue()");
            }
            else {
                WriteDebug("Got file system event, but did not load glucose! Less than 5 seconds has passed since last event");
            }
            
            
        }

        private void lblGlucose_Click(object sender, EventArgs e)
        {
            WriteDebug("Clicked BS-label!");
            this.glucoseLabelClickedCount += 1;

            //User has clicked the "BS" text five times already, must be intentional.
            //let him have access to the exit button
            if (this.glucoseLabelClickedCount % 5 == 0) {
                this.lblClickToCloseApp.Visible = !this.lblClickToCloseApp.Visible;
            }
          
        }

        private void lblClickToCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
