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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkEnableExceptions = new System.Windows.Forms.CheckBox();
            this.numScaling = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpAlarmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentHigh)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).BeginInit();
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
            this.btnVerifySubmit.Location = new System.Drawing.Point(753, 607);
            this.btnVerifySubmit.Name = "btnVerifySubmit";
            this.btnVerifySubmit.Size = new System.Drawing.Size(229, 53);
            this.btnVerifySubmit.TabIndex = 1;
            this.btnVerifySubmit.Text = "Verify and continue";
            this.btnVerifySubmit.UseVisualStyleBackColor = true;
            this.btnVerifySubmit.Click += new System.EventHandler(this.btnVerifySubmit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpAlarmSettings);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.panel2.Size = new System.Drawing.Size(960, 413);
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
            this.grpAlarmSettings.Location = new System.Drawing.Point(24, 142);
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
            this.numUrgentLow.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
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
            this.numLow.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
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
            this.numHigh.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
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
            this.numUrgentHigh.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
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
            this.label6.Location = new System.Drawing.Point(47, 561);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(646, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "NB! To show this window again, right click the app or tray icon and choose \"Setti" +
    "ngs\".";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageBasic);
            this.tabSettings.Controls.Add(this.tabPageAdvanced);
            this.tabSettings.Location = new System.Drawing.Point(12, 104);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(1010, 454);
            this.tabSettings.TabIndex = 2;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBasic.Controls.Add(this.panel2);
            this.tabPageBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageBasic.Location = new System.Drawing.Point(4, 25);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(1002, 425);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic Settings";
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAdvanced.Controls.Add(this.groupBox2);
            this.tabPageAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(1002, 425);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Advanced Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numScaling);
            this.groupBox2.Controls.Add(this.chkEnableExceptions);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numRefreshInterval);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(35, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(959, 346);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced application settings (requires restart)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "GUI Scaling ratio";
            // 
            // numRefreshInterval
            // 
            this.numRefreshInterval.Location = new System.Drawing.Point(444, 45);
            this.numRefreshInterval.Name = "numRefreshInterval";
            this.numRefreshInterval.Size = new System.Drawing.Size(120, 27);
            this.numRefreshInterval.TabIndex = 7;
            this.numRefreshInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "GUI Refresh interval";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Enable exception logging to stderr";
            // 
            // chkEnableExceptions
            // 
            this.chkEnableExceptions.AutoSize = true;
            this.chkEnableExceptions.Location = new System.Drawing.Point(546, 129);
            this.chkEnableExceptions.Name = "chkEnableExceptions";
            this.chkEnableExceptions.Size = new System.Drawing.Size(18, 17);
            this.chkEnableExceptions.TabIndex = 10;
            this.chkEnableExceptions.UseVisualStyleBackColor = true;
            // 
            // numScaling
            // 
            this.numScaling.DecimalPlaces = 1;
            this.numScaling.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numScaling.Location = new System.Drawing.Point(444, 81);
            this.numScaling.Name = "numScaling";
            this.numScaling.Size = new System.Drawing.Size(120, 27);
            this.numScaling.TabIndex = 11;
            this.numScaling.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormGlucoseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 672);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabSettings);
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
            this.grpAlarmSettings.ResumeLayout(false);
            this.grpAlarmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentHigh)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageAdvanced.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numRefreshInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkEnableExceptions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numScaling;
    }
}