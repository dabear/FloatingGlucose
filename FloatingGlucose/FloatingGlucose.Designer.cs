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
            this.lblGlucose = new System.Windows.Forms.Label();
            this.lblGlucoseValue = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblDebugModeOn = new System.Windows.Forms.Label();
            this.lblClickToCloseApp = new System.Windows.Forms.Label();
            this.lblShowSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGlucose
            // 
            this.lblGlucose.AutoSize = true;
            this.lblGlucose.BackColor = System.Drawing.Color.Black;
            this.lblGlucose.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucose.ForeColor = System.Drawing.Color.Green;
            this.lblGlucose.Location = new System.Drawing.Point(59, 25);
            this.lblGlucose.Name = "lblGlucose";
            this.lblGlucose.Size = new System.Drawing.Size(93, 52);
            this.lblGlucose.TabIndex = 0;
            this.lblGlucose.Text = "BS:";
            this.lblGlucose.Click += new System.EventHandler(this.lblGlucose_Click);
            // 
            // lblGlucoseValue
            // 
            this.lblGlucoseValue.AutoSize = true;
            this.lblGlucoseValue.BackColor = System.Drawing.Color.Black;
            this.lblGlucoseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucoseValue.ForeColor = System.Drawing.Color.Green;
            this.lblGlucoseValue.Location = new System.Drawing.Point(148, 25);
            this.lblGlucoseValue.Name = "lblGlucoseValue";
            this.lblGlucoseValue.Size = new System.Drawing.Size(104, 55);
            this.lblGlucoseValue.TabIndex = 2;
            this.lblGlucoseValue.Text = "N/A";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Green;
            this.lblLastUpdate.Location = new System.Drawing.Point(140, 77);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(37, 20);
            this.lblLastUpdate.TabIndex = 4;
            this.lblLastUpdate.Text = "N/A";
            this.lblLastUpdate.Click += new System.EventHandler(this.lblLastUpdate_Click);
            // 
            // lblDebugModeOn
            // 
            this.lblDebugModeOn.AutoSize = true;
            this.lblDebugModeOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebugModeOn.ForeColor = System.Drawing.Color.Yellow;
            this.lblDebugModeOn.Location = new System.Drawing.Point(165, 18);
            this.lblDebugModeOn.Name = "lblDebugModeOn";
            this.lblDebugModeOn.Size = new System.Drawing.Size(35, 13);
            this.lblDebugModeOn.TabIndex = 6;
            this.lblDebugModeOn.Text = "(DEV)";
            this.lblDebugModeOn.Visible = false;
            // 
            // lblClickToCloseApp
            // 
            this.lblClickToCloseApp.AutoSize = true;
            this.lblClickToCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClickToCloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClickToCloseApp.ForeColor = System.Drawing.Color.Green;
            this.lblClickToCloseApp.Location = new System.Drawing.Point(302, 100);
            this.lblClickToCloseApp.Name = "lblClickToCloseApp";
            this.lblClickToCloseApp.Size = new System.Drawing.Size(47, 25);
            this.lblClickToCloseApp.TabIndex = 7;
            this.lblClickToCloseApp.Text = "(Exit)";
            this.lblClickToCloseApp.UseCompatibleTextRendering = true;
            this.lblClickToCloseApp.Click += new System.EventHandler(this.lblClickToCloseApp_Click);
            // 
            // lblShowSettings
            // 
            this.lblShowSettings.AutoSize = true;
            this.lblShowSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowSettings.ForeColor = System.Drawing.Color.Green;
            this.lblShowSettings.Location = new System.Drawing.Point(204, 98);
            this.lblShowSettings.Name = "lblShowSettings";
            this.lblShowSettings.Size = new System.Drawing.Size(81, 25);
            this.lblShowSettings.TabIndex = 8;
            this.lblShowSettings.Text = "(Settings)";
            this.lblShowSettings.UseCompatibleTextRendering = true;
            this.lblShowSettings.Click += new System.EventHandler(this.lblShowSettings_Click);
            // 
            // FloatingGlucose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(372, 132);
            this.Controls.Add(this.lblShowSettings);
            this.Controls.Add(this.lblClickToCloseApp);
            this.Controls.Add(this.lblDebugModeOn);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.lblGlucoseValue);
            this.Controls.Add(this.lblGlucose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FloatingGlucose";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FloatingGlucose";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.FloatingGlucose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGlucose;
        private System.Windows.Forms.Label lblGlucoseValue;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblDebugModeOn;
        private System.Windows.Forms.Label lblClickToCloseApp;
        private System.Windows.Forms.Label lblShowSettings;
    }
}

