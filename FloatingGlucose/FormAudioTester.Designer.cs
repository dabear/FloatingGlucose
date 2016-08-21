namespace FloatingGlucose
{
    partial class FormAudioTester
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
            this.btnPlayGlucoseAlarm = new System.Windows.Forms.Button();
            this.btnPlayStaleAlarm = new System.Windows.Forms.Button();
            this.btnStopPlayback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlayGlucoseAlarm
            // 
            this.btnPlayGlucoseAlarm.Location = new System.Drawing.Point(53, 45);
            this.btnPlayGlucoseAlarm.Name = "btnPlayGlucoseAlarm";
            this.btnPlayGlucoseAlarm.Size = new System.Drawing.Size(165, 77);
            this.btnPlayGlucoseAlarm.TabIndex = 0;
            this.btnPlayGlucoseAlarm.Text = "Play glucose alarm";
            this.btnPlayGlucoseAlarm.UseVisualStyleBackColor = true;
            this.btnPlayGlucoseAlarm.Click += new System.EventHandler(this.btnPlayGlucoseAlarm_Click);
            // 
            // btnPlayStaleAlarm
            // 
            this.btnPlayStaleAlarm.Location = new System.Drawing.Point(293, 45);
            this.btnPlayStaleAlarm.Name = "btnPlayStaleAlarm";
            this.btnPlayStaleAlarm.Size = new System.Drawing.Size(165, 77);
            this.btnPlayStaleAlarm.TabIndex = 1;
            this.btnPlayStaleAlarm.Text = "Play stale data alarm";
            this.btnPlayStaleAlarm.UseVisualStyleBackColor = true;
            this.btnPlayStaleAlarm.Click += new System.EventHandler(this.btnPlayStaleAlarm_Click);
            // 
            // btnStopPlayback
            // 
            this.btnStopPlayback.Location = new System.Drawing.Point(170, 165);
            this.btnStopPlayback.Name = "btnStopPlayback";
            this.btnStopPlayback.Size = new System.Drawing.Size(165, 77);
            this.btnStopPlayback.TabIndex = 2;
            this.btnStopPlayback.Text = "Stop playback";
            this.btnStopPlayback.UseVisualStyleBackColor = true;
            this.btnStopPlayback.Click += new System.EventHandler(this.btnStopPlayback_Click);
            // 
            // FormAudioTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 333);
            this.Controls.Add(this.btnStopPlayback);
            this.Controls.Add(this.btnPlayStaleAlarm);
            this.Controls.Add(this.btnPlayGlucoseAlarm);
            this.Name = "FormAudioTester";
            this.Text = "FormAudioTester";
            this.Load += new System.EventHandler(this.FormAudioTester_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayGlucoseAlarm;
        private System.Windows.Forms.Button btnPlayStaleAlarm;
        private System.Windows.Forms.Button btnStopPlayback;
    }
}