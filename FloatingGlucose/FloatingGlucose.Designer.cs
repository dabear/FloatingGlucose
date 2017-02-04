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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponeAlarmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponeFor30MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponeFor90MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reenableAlarmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponedUntilFooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNightscoutSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDelta = new System.Windows.Forms.Label();
            this.lblRawBG = new System.Windows.Forms.Label();
            this.lblRawDelta = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGlucoseValue
            // 
            this.lblGlucoseValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGlucoseValue.AutoSize = true;
            this.lblGlucoseValue.BackColor = System.Drawing.Color.Transparent;
            this.lblGlucoseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucoseValue.ForeColor = System.Drawing.Color.Green;
            this.lblGlucoseValue.Location = new System.Drawing.Point(35, 9);
            this.lblGlucoseValue.Name = "lblGlucoseValue";
            this.lblGlucoseValue.Size = new System.Drawing.Size(104, 55);
            this.lblGlucoseValue.TabIndex = 2;
            this.lblGlucoseValue.Text = "N/A";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Green;
            this.lblLastUpdate.Location = new System.Drawing.Point(48, 81);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(42, 24);
            this.lblLastUpdate.TabIndex = 4;
            this.lblLastUpdate.Text = "N/A";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.postponeAlarmsToolStripMenuItem,
            this.openNightscoutSiteToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 160);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.showApplicationToolStripMenuItem.Text = "Show &Application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // postponeAlarmsToolStripMenuItem
            // 
            this.postponeAlarmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postponeFor30MinutesToolStripMenuItem,
            this.postponeFor90MinutesToolStripMenuItem,
            this.reenableAlarmsToolStripMenuItem,
            this.postponedUntilFooToolStripMenuItem});
            this.postponeAlarmsToolStripMenuItem.Name = "postponeAlarmsToolStripMenuItem";
            this.postponeAlarmsToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.postponeAlarmsToolStripMenuItem.Text = "Sn&ooze sound alarms";
            // 
            // postponeFor30MinutesToolStripMenuItem
            // 
            this.postponeFor30MinutesToolStripMenuItem.Name = "postponeFor30MinutesToolStripMenuItem";
            this.postponeFor30MinutesToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.postponeFor30MinutesToolStripMenuItem.Text = "Snooze for &30 minutes";
            this.postponeFor30MinutesToolStripMenuItem.Click += new System.EventHandler(this.postponeFor30MinutesToolStripMenuItem_Click);
            // 
            // postponeFor90MinutesToolStripMenuItem
            // 
            this.postponeFor90MinutesToolStripMenuItem.Name = "postponeFor90MinutesToolStripMenuItem";
            this.postponeFor90MinutesToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.postponeFor90MinutesToolStripMenuItem.Text = "Snooze for &90 minutes";
            this.postponeFor90MinutesToolStripMenuItem.Click += new System.EventHandler(this.postponeFor90MinutesToolStripMenuItem_Click);
            // 
            // reenableAlarmsToolStripMenuItem
            // 
            this.reenableAlarmsToolStripMenuItem.Name = "reenableAlarmsToolStripMenuItem";
            this.reenableAlarmsToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.reenableAlarmsToolStripMenuItem.Text = "&Re-enable alarms";
            this.reenableAlarmsToolStripMenuItem.Visible = false;
            this.reenableAlarmsToolStripMenuItem.Click += new System.EventHandler(this.reenableAlarmsToolStripMenuItem_Click);
            // 
            // postponedUntilFooToolStripMenuItem
            // 
            this.postponedUntilFooToolStripMenuItem.Enabled = false;
            this.postponedUntilFooToolStripMenuItem.Name = "postponedUntilFooToolStripMenuItem";
            this.postponedUntilFooToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.postponedUntilFooToolStripMenuItem.Text = "Snoozed until ";
            this.postponedUntilFooToolStripMenuItem.Visible = false;
            // 
            // openNightscoutSiteToolStripMenuItem
            // 
            this.openNightscoutSiteToolStripMenuItem.Name = "openNightscoutSiteToolStripMenuItem";
            this.openNightscoutSiteToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.openNightscoutSiteToolStripMenuItem.Text = "&Open nightscout site";
            this.openNightscoutSiteToolStripMenuItem.Click += new System.EventHandler(this.openNightscoutSiteToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.reloadToolStripMenuItem.Text = "&Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // lblDelta
            // 
            this.lblDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelta.AutoSize = true;
            this.lblDelta.BackColor = System.Drawing.Color.Transparent;
            this.lblDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDelta.Location = new System.Drawing.Point(48, 57);
            this.lblDelta.Name = "lblDelta";
            this.lblDelta.Size = new System.Drawing.Size(45, 24);
            this.lblDelta.TabIndex = 7;
            this.lblDelta.Text = "N/A";
            this.lblDelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRawBG
            // 
            this.lblRawBG.AutoSize = true;
            this.lblRawBG.BackColor = System.Drawing.Color.Black;
            this.lblRawBG.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawBG.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRawBG.Location = new System.Drawing.Point(21, 22);
            this.lblRawBG.Name = "lblRawBG";
            this.lblRawBG.Size = new System.Drawing.Size(27, 29);
            this.lblRawBG.TabIndex = 8;
            this.lblRawBG.Text = "0";
            this.lblRawBG.Visible = false;
            // 
            // lblRawDelta
            // 
            this.lblRawDelta.AutoSize = true;
            this.lblRawDelta.BackColor = System.Drawing.Color.Black;
            this.lblRawDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawDelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRawDelta.Location = new System.Drawing.Point(22, 51);
            this.lblRawDelta.Name = "lblRawDelta";
            this.lblRawDelta.Size = new System.Drawing.Size(17, 24);
            this.lblRawDelta.TabIndex = 9;
            this.lblRawDelta.Text = "-";
            this.lblRawDelta.Visible = false;
            // 
            // FloatingGlucose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(232, 112);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblRawDelta);
            this.Controls.Add(this.lblRawBG);
            this.Controls.Add(this.lblDelta);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.lblGlucoseValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FloatingGlucose";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label lblRawBG;
        private System.Windows.Forms.Label lblRawDelta;
        private System.Windows.Forms.ToolStripMenuItem postponeAlarmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postponeFor30MinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postponeFor90MinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postponedUntilFooToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reenableAlarmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNightscoutSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
    }
}

