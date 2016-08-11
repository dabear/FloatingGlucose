namespace FloatingGlucose
{
    partial class FormGlucoseSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNSURL = new System.Windows.Forms.Label();
            this.txtNSURL = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSettingsDesc = new System.Windows.Forms.Label();
            this.btnVerifySubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpAlarmSettings = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numUrgentLow = new System.Windows.Forms.NumericUpDown();
            this.numLow = new System.Windows.Forms.NumericUpDown();
            this.numHigh = new System.Windows.Forms.NumericUpDown();
            this.numUrgentHigh = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisableAlarms = new System.Windows.Forms.RadioButton();
            this.btnEnableAlarms = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpAlarmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentHigh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNSURL);
            this.groupBox1.Controls.Add(this.txtNSURL);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(927, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nightscout settings";
            // 
            // lblNSURL
            // 
            this.lblNSURL.AutoSize = true;
            this.lblNSURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNSURL.Location = new System.Drawing.Point(14, 49);
            this.lblNSURL.Name = "lblNSURL";
            this.lblNSURL.Size = new System.Drawing.Size(252, 20);
            this.lblNSURL.TabIndex = 1;
            this.lblNSURL.Text = "Your Nightscout installation URL";
            // 
            // txtNSURL
            // 
            this.txtNSURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSURL.Location = new System.Drawing.Point(453, 42);
            this.txtNSURL.Name = "txtNSURL";
            this.txtNSURL.Size = new System.Drawing.Size(351, 27);
            this.txtNSURL.TabIndex = 0;
            this.txtNSURL.Text = "https://mysite.azurewebsites.net";
            this.txtNSURL.TextChanged += new System.EventHandler(this.txtNSURL_TextChanged);
            this.txtNSURL.GotFocus += new System.EventHandler(this.txtNSURL_GotFocus);
            this.txtNSURL.LostFocus += new System.EventHandler(this.txtNSURL_LostFocus);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSettingsDesc);
            this.panel1.Location = new System.Drawing.Point(22, 25);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel1.Size = new System.Drawing.Size(743, 73);
            this.panel1.TabIndex = 0;
            // 
            // lblSettingsDesc
            // 
            this.lblSettingsDesc.AutoSize = true;
            this.lblSettingsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsDesc.Location = new System.Drawing.Point(25, 23);
            this.lblSettingsDesc.MaximumSize = new System.Drawing.Size(700, 0);
            this.lblSettingsDesc.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblSettingsDesc.Name = "lblSettingsDesc";
            this.lblSettingsDesc.Size = new System.Drawing.Size(639, 40);
            this.lblSettingsDesc.TabIndex = 0;
            this.lblSettingsDesc.Text = "Welcome. These are the necessary settings for an installation of FloatingGlucose " +
    "to function. Please edit the values below and press \"verify and continue\".";
            // 
            // btnVerifySubmit
            // 
            this.btnVerifySubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifySubmit.Location = new System.Drawing.Point(744, 605);
            this.btnVerifySubmit.Name = "btnVerifySubmit";
            this.btnVerifySubmit.Size = new System.Drawing.Size(229, 53);
            this.btnVerifySubmit.TabIndex = 1;
            this.btnVerifySubmit.Text = "Verify and continue";
            this.btnVerifySubmit.UseVisualStyleBackColor = true;
            this.btnVerifySubmit.Click += new System.EventHandler(this.btnVerifySubmit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.grpAlarmSettings);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(22, 119);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.panel2.Size = new System.Drawing.Size(951, 480);
            this.panel2.TabIndex = 1;
            // 
            // grpAlarmSettings
            // 
            this.grpAlarmSettings.Controls.Add(this.label5);
            this.grpAlarmSettings.Controls.Add(this.numUrgentLow);
            this.grpAlarmSettings.Controls.Add(this.numLow);
            this.grpAlarmSettings.Controls.Add(this.numHigh);
            this.grpAlarmSettings.Controls.Add(this.numUrgentHigh);
            this.grpAlarmSettings.Controls.Add(this.label4);
            this.grpAlarmSettings.Controls.Add(this.label3);
            this.grpAlarmSettings.Controls.Add(this.label2);
            this.grpAlarmSettings.Controls.Add(this.label1);
            this.grpAlarmSettings.Controls.Add(this.btnDisableAlarms);
            this.grpAlarmSettings.Controls.Add(this.btnEnableAlarms);
            this.grpAlarmSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAlarmSettings.Location = new System.Drawing.Point(24, 157);
            this.grpAlarmSettings.Name = "grpAlarmSettings";
            this.grpAlarmSettings.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.grpAlarmSettings.Size = new System.Drawing.Size(927, 251);
            this.grpAlarmSettings.TabIndex = 2;
            this.grpAlarmSettings.TabStop = false;
            this.grpAlarmSettings.Text = "Alarm settings";
            this.grpAlarmSettings.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(769, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "NB! These alams values should only be set in mmol/L if your azure DISPLAY_UNITS i" +
    "s set to \"mmol\".";
            // 
            // numUrgentLow
            // 
            this.numUrgentLow.DecimalPlaces = 1;
            this.numUrgentLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUrgentLow.Location = new System.Drawing.Point(453, 201);
            this.numUrgentLow.Name = "numUrgentLow";
            this.numUrgentLow.Size = new System.Drawing.Size(120, 27);
            this.numUrgentLow.TabIndex = 9;
            this.numUrgentLow.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numLow
            // 
            this.numLow.DecimalPlaces = 1;
            this.numLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLow.Location = new System.Drawing.Point(453, 168);
            this.numLow.Name = "numLow";
            this.numLow.Size = new System.Drawing.Size(120, 27);
            this.numLow.TabIndex = 8;
            this.numLow.Value = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            // 
            // numHigh
            // 
            this.numHigh.DecimalPlaces = 1;
            this.numHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numHigh.Location = new System.Drawing.Point(453, 135);
            this.numHigh.Name = "numHigh";
            this.numHigh.Size = new System.Drawing.Size(120, 27);
            this.numHigh.TabIndex = 7;
            this.numHigh.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // numUrgentHigh
            // 
            this.numUrgentHigh.DecimalPlaces = 1;
            this.numUrgentHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUrgentHigh.Location = new System.Drawing.Point(453, 102);
            this.numUrgentHigh.Name = "numUrgentHigh";
            this.numUrgentHigh.Size = new System.Drawing.Size(120, 27);
            this.numUrgentHigh.TabIndex = 6;
            this.numUrgentHigh.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Urgent low alarm";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Low Alarm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "High Alarm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Urgent High Alarm";
            // 
            // btnDisableAlarms
            // 
            this.btnDisableAlarms.AutoSize = true;
            this.btnDisableAlarms.Checked = true;
            this.btnDisableAlarms.Location = new System.Drawing.Point(18, 36);
            this.btnDisableAlarms.Name = "btnDisableAlarms";
            this.btnDisableAlarms.Size = new System.Drawing.Size(143, 24);
            this.btnDisableAlarms.TabIndex = 1;
            this.btnDisableAlarms.TabStop = true;
            this.btnDisableAlarms.Text = "Disable alarms";
            this.btnDisableAlarms.UseVisualStyleBackColor = true;
            // 
            // btnEnableAlarms
            // 
            this.btnEnableAlarms.AutoSize = true;
            this.btnEnableAlarms.Location = new System.Drawing.Point(233, 36);
            this.btnEnableAlarms.Name = "btnEnableAlarms";
            this.btnEnableAlarms.Size = new System.Drawing.Size(137, 24);
            this.btnEnableAlarms.TabIndex = 0;
            this.btnEnableAlarms.Text = "Enable alarms";
            this.btnEnableAlarms.UseVisualStyleBackColor = true;
            this.btnEnableAlarms.CheckedChanged += new System.EventHandler(this.btnEnableAlarms_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(646, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "NB! To show this window again, right click the app or tray icon and choose \"Setti" +
    "ngs\".";
            // 
            // FormGlucoseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 682);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnVerifySubmit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormGlucoseSettings";
            this.Text = "Glucose Settings";
            this.Load += new System.EventHandler(this.FormGlucoseSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpAlarmSettings.ResumeLayout(false);
            this.grpAlarmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentHigh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNSURL;
        private System.Windows.Forms.TextBox txtNSURL;
        private System.Windows.Forms.Label lblSettingsDesc;
        private System.Windows.Forms.Button btnVerifySubmit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpAlarmSettings;
        private System.Windows.Forms.RadioButton btnDisableAlarms;
        private System.Windows.Forms.RadioButton btnEnableAlarms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numUrgentLow;
        private System.Windows.Forms.NumericUpDown numLow;
        private System.Windows.Forms.NumericUpDown numHigh;
        private System.Windows.Forms.NumericUpDown numUrgentHigh;
        private System.Windows.Forms.Label label6;
    }
}