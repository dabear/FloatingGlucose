namespace FloatingGlucose
{
    partial class FloatingGlucose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGlucoseValue = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblDebugModeOn = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDelta = new System.Windows.Forms.Label();
            this.lblRawBG = new System.Windows.Forms.Label();
            this.lasttime = new System.Windows.Forms.Label();
            this.lastRaw = new System.Windows.Forms.Label();
            this.RawBGD = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGlucoseValue
            // 
            this.lblGlucoseValue.AutoSize = true;
            this.lblGlucoseValue.BackColor = System.Drawing.Color.Black;
            this.lblGlucoseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucoseValue.ForeColor = System.Drawing.Color.Green;
            this.lblGlucoseValue.Location = new System.Drawing.Point(116, 9);
            this.lblGlucoseValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGlucoseValue.Name = "lblGlucoseValue";
            this.lblGlucoseValue.Size = new System.Drawing.Size(164, 86);
            this.lblGlucoseValue.TabIndex = 2;
            this.lblGlucoseValue.Text = "N/A";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Green;
            this.lblLastUpdate.Location = new System.Drawing.Point(125, 124);
            this.lblLastUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(62, 32);
            this.lblLastUpdate.TabIndex = 4;
            this.lblLastUpdate.Text = "N/A";
            // 
            // lblDebugModeOn
            // 
            this.lblDebugModeOn.AutoSize = true;
            this.lblDebugModeOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebugModeOn.ForeColor = System.Drawing.Color.Yellow;
            this.lblDebugModeOn.Location = new System.Drawing.Point(12, 144);
            this.lblDebugModeOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebugModeOn.Name = "lblDebugModeOn";
            this.lblDebugModeOn.Size = new System.Drawing.Size(53, 20);
            this.lblDebugModeOn.TabIndex = 6;
            this.lblDebugModeOn.Text = "(DEV)";
            this.lblDebugModeOn.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(276, 112);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(275, 36);
            this.showApplicationToolStripMenuItem.Text = "Show &Application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(275, 36);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(275, 36);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // lblDelta
            // 
            this.lblDelta.AutoSize = true;
            this.lblDelta.BackColor = System.Drawing.Color.Black;
            this.lblDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelta.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDelta.Location = new System.Drawing.Point(123, 83);
            this.lblDelta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelta.Name = "lblDelta";
            this.lblDelta.Size = new System.Drawing.Size(86, 44);
            this.lblDelta.TabIndex = 7;
            this.lblDelta.Text = "N/A";
            // 
            // lblRawBG
            // 
            this.lblRawBG.AutoSize = true;
            this.lblRawBG.BackColor = System.Drawing.Color.Black;
            this.lblRawBG.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawBG.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRawBG.Location = new System.Drawing.Point(13, 19);
            this.lblRawBG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRawBG.Name = "lblRawBG";
            this.lblRawBG.Size = new System.Drawing.Size(42, 44);
            this.lblRawBG.TabIndex = 8;
            this.lblRawBG.Text = "0";
            // 
            // lasttime
            // 
            this.lasttime.AutoSize = true;
            this.lasttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lasttime.ForeColor = System.Drawing.Color.Green;
            this.lasttime.Location = new System.Drawing.Point(322, 127);
            this.lasttime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lasttime.Name = "lasttime";
            this.lasttime.Size = new System.Drawing.Size(62, 32);
            this.lasttime.TabIndex = 9;
            this.lasttime.Text = "N/A";
            this.lasttime.Visible = false;
            // 
            // lastRaw
            // 
            this.lastRaw.AutoSize = true;
            this.lastRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastRaw.ForeColor = System.Drawing.Color.Green;
            this.lastRaw.Location = new System.Drawing.Point(322, 95);
            this.lastRaw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastRaw.Name = "lastRaw";
            this.lastRaw.Size = new System.Drawing.Size(62, 32);
            this.lastRaw.TabIndex = 10;
            this.lastRaw.Text = "N/A";
            this.lastRaw.Visible = false;
            // 
            // RawBGD
            // 
            this.RawBGD.AutoSize = true;
            this.RawBGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RawBGD.ForeColor = System.Drawing.Color.Chocolate;
            this.RawBGD.Location = new System.Drawing.Point(13, 63);
            this.RawBGD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RawBGD.Name = "RawBGD";
            this.RawBGD.Size = new System.Drawing.Size(24, 32);
            this.RawBGD.TabIndex = 11;
            this.RawBGD.Text = "-";
            // 
            // FloatingGlucose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(486, 165);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.RawBGD);
            this.Controls.Add(this.lastRaw);
            this.Controls.Add(this.lasttime);
            this.Controls.Add(this.lblRawBG);
            this.Controls.Add(this.lblDelta);
            this.Controls.Add(this.lblDebugModeOn);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.lblGlucoseValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FloatingGlucose";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FloatingGlucose";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.FloatingGlucose_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblGlucoseValue;
        private System.Windows.Forms.Label lblDelta;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblDebugModeOn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label lblRawBG;
        private System.Windows.Forms.Label lasttime;
        private System.Windows.Forms.Label lastRaw;
        private System.Windows.Forms.Label RawBGD;
    }
}

