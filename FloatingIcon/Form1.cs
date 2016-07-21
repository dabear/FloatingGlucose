using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
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
        private string path = @"E:\Kode\python\glucose\glucose.log";

        // Displays this text next to the glucose value
        // note that no conversion to/from mmol
        // is done on the values fetched from glucose.log
        private string glucoseUnitText = "mmol";

        private string appname = "FloatingGlucose";

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            //position at bottom right per default
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(r.Width - this.Width, r.Height - this.Height);

        }
        private void SetErrorState() {
            this.lblGlucoseNotAvailable.Visible = true;
            this.lblGlucoseValue.Visible = false;
        }
        private void SetSuccessState() {
            this.lblGlucoseNotAvailable.Visible = false;
            this.lblGlucoseValue.Visible = true;
        
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
            fileSystemWatcher.SynchronizingObject = this.lblLastUpdate;

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
                var glucose = split.Last();

                this.lblGlucoseValue.Text = glucose + this.glucoseUnitText;
                this.lblLastUpdate.Text = date;
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
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        void glucoseLogSystemWatcher_event(object sender, FileSystemEventArgs e)
        {
            LoadGlucoseValue();
            
        }

        
    }
}
