namespace FloatingIcon
{
    partial class Form1
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
            this.lblGlucoseNotAvailable = new System.Windows.Forms.Label();
            this.lblGlucoseValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.labelDoNotEverRemoveThisLabel = new System.Windows.Forms.Label();
            this.lblDebugModeOn = new System.Windows.Forms.Label();
            this.lblClickToCloseApp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGlucose
            // 
            this.lblGlucose.AutoSize = true;
            this.lblGlucose.BackColor = System.Drawing.Color.Black;
            this.lblGlucose.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucose.ForeColor = System.Drawing.Color.Green;
            this.lblGlucose.Location = new System.Drawing.Point(32, 21);
            this.lblGlucose.Name = "lblGlucose";
            this.lblGlucose.Size = new System.Drawing.Size(70, 38);
            this.lblGlucose.TabIndex = 0;
            this.lblGlucose.Text = "BS:";
            this.lblGlucose.Click += new System.EventHandler(this.lblGlucose_Click);
            // 
            // lblGlucoseNotAvailable
            // 
            this.lblGlucoseNotAvailable.AutoSize = true;
            this.lblGlucoseNotAvailable.BackColor = System.Drawing.Color.AliceBlue;
            this.lblGlucoseNotAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucoseNotAvailable.ForeColor = System.Drawing.Color.Green;
            this.lblGlucoseNotAvailable.Location = new System.Drawing.Point(134, 11);
            this.lblGlucoseNotAvailable.Name = "lblGlucoseNotAvailable";
            this.lblGlucoseNotAvailable.Size = new System.Drawing.Size(277, 51);
            this.lblGlucoseNotAvailable.TabIndex = 1;
            this.lblGlucoseNotAvailable.Text = "Not Available";
            this.lblGlucoseNotAvailable.Visible = false;
            // 
            // lblGlucoseValue
            // 
            this.lblGlucoseValue.AutoSize = true;
            this.lblGlucoseValue.BackColor = System.Drawing.Color.Black;
            this.lblGlucoseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucoseValue.ForeColor = System.Drawing.Color.Green;
            this.lblGlucoseValue.Location = new System.Drawing.Point(134, 12);
            this.lblGlucoseValue.Name = "lblGlucoseValue";
            this.lblGlucoseValue.Size = new System.Drawing.Size(277, 51);
            this.lblGlucoseValue.TabIndex = 2;
            this.lblGlucoseValue.Text = "Not Available";
            this.lblGlucoseValue.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(140, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Last update:";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Green;
            this.lblLastUpdate.Location = new System.Drawing.Point(233, 63);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(31, 17);
            this.lblLastUpdate.TabIndex = 4;
            this.lblLastUpdate.Text = "N/A";
            // 
            // labelDoNotEverRemoveThisLabel
            // 
            this.labelDoNotEverRemoveThisLabel.AutoSize = true;
            this.labelDoNotEverRemoveThisLabel.Location = new System.Drawing.Point(36, 9);
            this.labelDoNotEverRemoveThisLabel.Name = "labelDoNotEverRemoveThisLabel";
            this.labelDoNotEverRemoveThisLabel.Size = new System.Drawing.Size(403, 17);
            this.labelDoNotEverRemoveThisLabel.TabIndex = 5;
            this.labelDoNotEverRemoveThisLabel.Text = "this label is only used as a syncobject by the filesystemwatcher";
            this.labelDoNotEverRemoveThisLabel.Visible = false;
            // 
            // lblDebugModeOn
            // 
            this.lblDebugModeOn.AutoSize = true;
            this.lblDebugModeOn.ForeColor = System.Drawing.Color.Yellow;
            this.lblDebugModeOn.Location = new System.Drawing.Point(27, 59);
            this.lblDebugModeOn.Name = "lblDebugModeOn";
            this.lblDebugModeOn.Size = new System.Drawing.Size(87, 17);
            this.lblDebugModeOn.TabIndex = 6;
            this.lblDebugModeOn.Text = "(DEVMODE)";
            this.lblDebugModeOn.Visible = false;
            // 
            // lblClickToCloseApp
            // 
            this.lblClickToCloseApp.AutoSize = true;
            this.lblClickToCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClickToCloseApp.ForeColor = System.Drawing.Color.Green;
            this.lblClickToCloseApp.Location = new System.Drawing.Point(407, 67);
            this.lblClickToCloseApp.Name = "lblClickToCloseApp";
            this.lblClickToCloseApp.Size = new System.Drawing.Size(36, 20);
            this.lblClickToCloseApp.TabIndex = 7;
            this.lblClickToCloseApp.Text = "(Exit)";
            this.lblClickToCloseApp.UseCompatibleTextRendering = true;
            this.lblClickToCloseApp.Visible = false;
            this.lblClickToCloseApp.Click += new System.EventHandler(this.lblClickToCloseApp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(452, 90);
            this.Controls.Add(this.lblClickToCloseApp);
            this.Controls.Add(this.lblDebugModeOn);
            this.Controls.Add(this.labelDoNotEverRemoveThisLabel);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGlucoseValue);
            this.Controls.Add(this.lblGlucoseNotAvailable);
            this.Controls.Add(this.lblGlucose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGlucose;
        private System.Windows.Forms.Label lblGlucoseNotAvailable;
        private System.Windows.Forms.Label lblGlucoseValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label labelDoNotEverRemoveThisLabel;
        private System.Windows.Forms.Label lblDebugModeOn;
        private System.Windows.Forms.Label lblClickToCloseApp;
    }
}

