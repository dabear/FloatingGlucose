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
            this.cbDataSource = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnUnitsMGDL = new System.Windows.Forms.RadioButton();
            this.btnUnitsMMOL = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDataSourceLocation = new System.Windows.Forms.Label();
            this.txtDataSouceLocation = new System.Windows.Forms.TextBox();
            this.btnVerifySubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpAlarmSettings = new System.Windows.Forms.GroupBox();
            this.chkEnableSoundAlarms = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numStaleUrgent = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numStaleWarning = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
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
            this.label18 = new System.Windows.Forms.Label();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.chkDisableSoundOnWorkstationLock = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkEnableRAWGlucose = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numScaling = new System.Windows.Forms.NumericUpDown();
            this.chkEnableExceptions = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVersionInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpAlarmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStaleUrgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStaleWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentHigh)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDataSource);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.btnUnitsMGDL);
            this.groupBox1.Controls.Add(this.btnUnitsMMOL);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblDataSourceLocation);
            this.groupBox1.Controls.Add(this.txtDataSouceLocation);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(840, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nightscout settings";
            // 
            // cbDataSource
            // 
            this.cbDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataSource.FormattingEnabled = true;
            this.cbDataSource.Location = new System.Drawing.Point(455, 27);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.Size = new System.Drawing.Size(350, 28);
            this.cbDataSource.TabIndex = 6;
            this.cbDataSource.SelectedIndexChanged += new System.EventHandler(this.cbDataSource_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(14, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "Datasource";
            // 
            // btnUnitsMGDL
            // 
            this.btnUnitsMGDL.AutoSize = true;
            this.btnUnitsMGDL.Location = new System.Drawing.Point(547, 99);
            this.btnUnitsMGDL.Name = "btnUnitsMGDL";
            this.btnUnitsMGDL.Size = new System.Drawing.Size(77, 24);
            this.btnUnitsMGDL.TabIndex = 4;
            this.btnUnitsMGDL.Text = "mg/dL";
            this.btnUnitsMGDL.UseVisualStyleBackColor = true;
            // 
            // btnUnitsMMOL
            // 
            this.btnUnitsMMOL.AutoSize = true;
            this.btnUnitsMMOL.Checked = true;
            this.btnUnitsMMOL.Location = new System.Drawing.Point(455, 99);
            this.btnUnitsMMOL.Name = "btnUnitsMMOL";
            this.btnUnitsMMOL.Size = new System.Drawing.Size(86, 24);
            this.btnUnitsMMOL.TabIndex = 3;
            this.btnUnitsMMOL.TabStop = true;
            this.btnUnitsMMOL.Text = "mmol/L";
            this.btnUnitsMMOL.UseVisualStyleBackColor = true;
            this.btnUnitsMMOL.CheckedChanged += new System.EventHandler(this.GlucoseUnit_Changed);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Units";
            // 
            // lblDataSourceLocation
            // 
            this.lblDataSourceLocation.AutoSize = true;
            this.lblDataSourceLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSourceLocation.Location = new System.Drawing.Point(16, 69);
            this.lblDataSourceLocation.Name = "lblDataSourceLocation";
            this.lblDataSourceLocation.Size = new System.Drawing.Size(252, 20);
            this.lblDataSourceLocation.TabIndex = 1;
            this.lblDataSourceLocation.Text = "Your Nightscout installation URL";
            // 
            // txtDataSouceLocation
            // 
            this.txtDataSouceLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSouceLocation.Location = new System.Drawing.Point(455, 62);
            this.txtDataSouceLocation.Name = "txtDataSouceLocation";
            this.txtDataSouceLocation.Size = new System.Drawing.Size(351, 27);
            this.txtDataSouceLocation.TabIndex = 0;
            this.txtDataSouceLocation.Text = "https://mysite.azurewebsites.net";
            this.txtDataSouceLocation.GotFocus += new System.EventHandler(this.txtDataSouceLocation_GotFocus);
            this.txtDataSouceLocation.LostFocus += new System.EventHandler(this.txtDataSouceLocation_LostFocus);
            // 
            // btnVerifySubmit
            // 
            this.btnVerifySubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifySubmit.Location = new System.Drawing.Point(12, 587);
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
            this.panel2.Size = new System.Drawing.Size(869, 497);
            this.panel2.TabIndex = 1;
            // 
            // grpAlarmSettings
            // 
            this.grpAlarmSettings.Controls.Add(this.chkEnableSoundAlarms);
            this.grpAlarmSettings.Controls.Add(this.label15);
            this.grpAlarmSettings.Controls.Add(this.numStaleUrgent);
            this.grpAlarmSettings.Controls.Add(this.label13);
            this.grpAlarmSettings.Controls.Add(this.label14);
            this.grpAlarmSettings.Controls.Add(this.numStaleWarning);
            this.grpAlarmSettings.Controls.Add(this.label12);
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
            this.grpAlarmSettings.Location = new System.Drawing.Point(24, 170);
            this.grpAlarmSettings.Name = "grpAlarmSettings";
            this.grpAlarmSettings.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.grpAlarmSettings.Size = new System.Drawing.Size(840, 314);
            this.grpAlarmSettings.TabIndex = 2;
            this.grpAlarmSettings.TabStop = false;
            this.grpAlarmSettings.Text = "Alarm settings";
            // 
            // chkEnableSoundAlarms
            // 
            this.chkEnableSoundAlarms.AutoSize = true;
            this.chkEnableSoundAlarms.Location = new System.Drawing.Point(555, 289);
            this.chkEnableSoundAlarms.Name = "chkEnableSoundAlarms";
            this.chkEnableSoundAlarms.Size = new System.Drawing.Size(18, 17);
            this.chkEnableSoundAlarms.TabIndex = 19;
            this.chkEnableSoundAlarms.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 286);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(166, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "Enable sound alarms";
            // 
            // numStaleUrgent
            // 
            this.numStaleUrgent.Location = new System.Drawing.Point(453, 247);
            this.numStaleUrgent.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
            this.numStaleUrgent.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numStaleUrgent.Name = "numStaleUrgent";
            this.numStaleUrgent.Size = new System.Drawing.Size(120, 27);
            this.numStaleUrgent.TabIndex = 17;
            this.numStaleUrgent.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(580, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "minutes";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(580, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 20);
            this.label14.TabIndex = 15;
            this.label14.Text = "minutes";
            // 
            // numStaleWarning
            // 
            this.numStaleWarning.Location = new System.Drawing.Point(454, 213);
            this.numStaleWarning.Maximum = new decimal(new int[] {
            650,
            0,
            0,
            0});
            this.numStaleWarning.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStaleWarning.Name = "numStaleWarning";
            this.numStaleWarning.Size = new System.Drawing.Size(120, 27);
            this.numStaleWarning.TabIndex = 12;
            this.numStaleWarning.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 254);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 20);
            this.label12.TabIndex = 11;
            this.label12.Text = "Stale data urgent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stale data warning";
            // 
            // numUrgentLow
            // 
            this.numUrgentLow.DecimalPlaces = 1;
            this.numUrgentLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUrgentLow.Location = new System.Drawing.Point(454, 178);
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
            this.numLow.Location = new System.Drawing.Point(454, 145);
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
            this.numHigh.Location = new System.Drawing.Point(454, 112);
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
            this.numUrgentHigh.Location = new System.Drawing.Point(454, 79);
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
            this.label4.Location = new System.Drawing.Point(16, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Urgent low alarm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Low Alarm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "High Alarm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 86);
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(260, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(631, 56);
            this.label6.TabIndex = 3;
            this.label6.Text = "NB! To show this window again, right click the app or tray icon and choose \"Setti" +
    "ngs\".";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageBasic);
            this.tabSettings.Controls.Add(this.tabPageAdvanced);
            this.tabSettings.Location = new System.Drawing.Point(12, 40);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(904, 538);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "30";
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBasic.Controls.Add(this.panel2);
            this.tabPageBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageBasic.Location = new System.Drawing.Point(4, 25);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(896, 509);
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
            this.tabPageAdvanced.Size = new System.Drawing.Size(896, 509);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Advanced Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.numOpacity);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.chkDisableSoundOnWorkstationLock);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.chkEnableRAWGlucose);
            this.groupBox2.Controls.Add(this.label10);
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(570, 119);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 20);
            this.label18.TabIndex = 18;
            this.label18.Text = "%";
            // 
            // numOpacity
            // 
            this.numOpacity.Location = new System.Drawing.Point(444, 117);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(120, 27);
            this.numOpacity.TabIndex = 17;
            this.numOpacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(38, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 20);
            this.label17.TabIndex = 16;
            this.label17.Text = "GUI opacity";
            // 
            // chkDisableSoundOnWorkstationLock
            // 
            this.chkDisableSoundOnWorkstationLock.AutoSize = true;
            this.chkDisableSoundOnWorkstationLock.Location = new System.Drawing.Point(546, 232);
            this.chkDisableSoundOnWorkstationLock.Name = "chkDisableSoundOnWorkstationLock";
            this.chkDisableSoundOnWorkstationLock.Size = new System.Drawing.Size(18, 17);
            this.chkDisableSoundOnWorkstationLock.TabIndex = 15;
            this.chkDisableSoundOnWorkstationLock.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(38, 232);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(419, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "Temporarily disable sounds when workstation is locked";
            // 
            // chkEnableRAWGlucose
            // 
            this.chkEnableRAWGlucose.AutoSize = true;
            this.chkEnableRAWGlucose.Location = new System.Drawing.Point(546, 200);
            this.chkEnableRAWGlucose.Name = "chkEnableRAWGlucose";
            this.chkEnableRAWGlucose.Size = new System.Drawing.Size(18, 17);
            this.chkEnableRAWGlucose.TabIndex = 13;
            this.chkEnableRAWGlucose.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(284, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Enable display of raw glucose values";
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
            // chkEnableExceptions
            // 
            this.chkEnableExceptions.AutoSize = true;
            this.chkEnableExceptions.Location = new System.Drawing.Point(546, 161);
            this.chkEnableExceptions.Name = "chkEnableExceptions";
            this.chkEnableExceptions.Size = new System.Drawing.Size(18, 17);
            this.chkEnableExceptions.TabIndex = 10;
            this.chkEnableExceptions.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Enable exception logging to stderr";
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
            this.numRefreshInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
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
            // lblVersionInfo
            // 
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.Enabled = false;
            this.lblVersionInfo.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblVersionInfo.Location = new System.Drawing.Point(12, 658);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(93, 17);
            this.lblVersionInfo.TabIndex = 4;
            this.lblVersionInfo.Text = "lblVersionInfo";
            // 
            // FormGlucoseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 687);
            this.Controls.Add(this.lblVersionInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.btnVerifySubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormGlucoseSettings";
            this.Text = "Glucose Settings";
            this.Load += new System.EventHandler(this.FormGlucoseSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grpAlarmSettings.ResumeLayout(false);
            this.grpAlarmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStaleUrgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStaleWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrgentHigh)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageAdvanced.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDataSouceLocation;
        private System.Windows.Forms.Button btnVerifySubmit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpAlarmSettings;
        private System.Windows.Forms.RadioButton btnDisableAlarms;
        private System.Windows.Forms.RadioButton btnEnableAlarms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.CheckBox chkEnableRAWGlucose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton btnUnitsMGDL;
        private System.Windows.Forms.RadioButton btnUnitsMMOL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numStaleUrgent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numStaleWarning;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnableSoundAlarms;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkDisableSoundOnWorkstationLock;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblVersionInfo;
        private System.Windows.Forms.ComboBox cbDataSource;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label lblDataSourceLocation;
    }
}