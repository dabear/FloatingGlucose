namespace FloatingGlucose
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
            this.lblGlucoseValue = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblDebugModeOn = new System.Windows.Forms.Label();
            this.lblClickToCloseApp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGlucose
            // 
            this.lblGlucose.AutoSize = true;
            this.lblGlucose.BackColor = System.Drawing.Color.Black;
            this.lblGlucose.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucose.ForeColor = System.Drawing.Color.Green;
            this.lblGlucose.Location = new System.Drawing.Point(45, 22);
            this.lblGlucose.Name = "lblGlucose";
            this.lblGlucose.Size = new System.Drawing.Size(81, 44);
            this.lblGlucose.TabIndex = 0;
            this.lblGlucose.Text = "BS:";
            this.lblGlucose.Click += new System.EventHandler(this.lblGlucose_Click);
            // 
            // lblGlucoseValue
            // 
            this.lblGlucoseValue.AutoSize = true;
            this.lblGlucoseValue.BackColor = System.Drawing.Color.Black;
            this.lblGlucoseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlucoseValue.ForeColor = System.Drawing.Color.Green;
            this.lblGlucoseValue.Location = new System.Drawing.Point(120, 22);
            this.lblGlucoseValue.Name = "lblGlucoseValue";
            this.lblGlucoseValue.Size = new System.Drawing.Size(83, 44);
            this.lblGlucoseValue.TabIndex = 2;
            this.lblGlucoseValue.Text = "N/A";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Green;
            this.lblLastUpdate.Location = new System.Drawing.Point(125, 61);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(31, 17);
            this.lblLastUpdate.TabIndex = 4;
            this.lblLastUpdate.Text = "N/A";
            // 
            // lblDebugModeOn
            // 
            this.lblDebugModeOn.AutoSize = true;
            this.lblDebugModeOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebugModeOn.ForeColor = System.Drawing.Color.Yellow;
            this.lblDebugModeOn.Location = new System.Drawing.Point(154, 15);
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
            this.lblClickToCloseApp.ForeColor = System.Drawing.Color.Green;
            this.lblClickToCloseApp.Location = new System.Drawing.Point(52, 61);
            this.lblClickToCloseApp.Name = "lblClickToCloseApp";
            this.lblClickToCloseApp.Size = new System.Drawing.Size(36, 20);
            this.lblClickToCloseApp.TabIndex = 7;
            this.lblClickToCloseApp.Text = "(Exit)";
            this.lblClickToCloseApp.UseCompatibleTextRendering = true;
            this.lblClickToCloseApp.Click += new System.EventHandler(this.lblClickToCloseApp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(276, 102);
            this.Controls.Add(this.lblClickToCloseApp);
            this.Controls.Add(this.lblDebugModeOn);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.lblGlucoseValue);
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
        private System.Windows.Forms.Label lblGlucoseValue;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblDebugModeOn;
        private System.Windows.Forms.Label lblClickToCloseApp;
    }
}

