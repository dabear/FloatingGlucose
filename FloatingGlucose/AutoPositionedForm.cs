using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FloatingGlucose.WindowPositionSettings;

namespace FloatingGlucose
{
    public class AutoPositionedForm : Form
    {
        private bool windowInitialized;

        public void SaveWindowPosition()
        {
            Default.Save();
        }


        public AutoPositionedForm()
        {
            InitializeComponent();

            // this is the default
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.WindowsDefaultBounds;

           
            this.StartPosition = FormStartPosition.Manual;

            // check if the saved bounds are nonzero and visible on any screen
            if (Default.WindowPosition != Rectangle.Empty &&
                IsVisibleOnAnyScreen(Default.WindowPosition))
            {
                // first set the bounds
                
                this.DesktopBounds = Default.WindowPosition;
            }
            else
            {
                //position at bottom right per default
                var r = Screen.PrimaryScreen.WorkingArea;
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(r.Width - this.Width, r.Height - this.Height);

            }
            this.windowInitialized = true;
        }

        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }

            return false;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Default.Save();
        }

        #region window size/position
        // msorens: Added region to handle closing when window is minimized or maximized.

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            TrackWindowState();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            TrackWindowState();
        }

        // On a move or resize in Normal state, record the new values as they occur.
        // This solves the problem of closing the app when minimized or maximized.
        private void TrackWindowState()
        {
            // Don't record the window setup, otherwise we lose the persistent values!
            if (!windowInitialized) { return; }

            if (WindowState == FormWindowState.Normal)
            {
                Default.WindowPosition = this.DesktopBounds;
            }
        }

        #endregion window size/position

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AutoPositionedForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(210, 61);
            this.ForeColor = System.Drawing.Color.Crimson;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AutoPositionedForm";
            this.Load += new System.EventHandler(this.PositionForm_Load);
            this.ResumeLayout(false);

        }

        private void PositionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
