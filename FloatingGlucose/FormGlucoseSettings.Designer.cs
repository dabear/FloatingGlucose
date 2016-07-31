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
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNSURL);
            this.groupBox1.Controls.Add(this.txtNSURL);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(670, 206);
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
            this.txtNSURL.Location = new System.Drawing.Point(301, 46);
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
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel1.Size = new System.Drawing.Size(697, 111);
            this.panel1.TabIndex = 0;
            // 
            // lblSettingsDesc
            // 
            this.lblSettingsDesc.AutoSize = true;
            this.lblSettingsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsDesc.Location = new System.Drawing.Point(33, 28);
            this.lblSettingsDesc.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblSettingsDesc.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblSettingsDesc.Name = "lblSettingsDesc";
            this.lblSettingsDesc.Size = new System.Drawing.Size(535, 40);
            this.lblSettingsDesc.TabIndex = 0;
            this.lblSettingsDesc.Text = "Welcome. These are the necessary settings for an installation of FloatingGlucose " +
    "to function. Please edit the values below and press ok";
            // 
            // btnVerifySubmit
            // 
            this.btnVerifySubmit.Location = new System.Drawing.Point(536, 489);
            this.btnVerifySubmit.Name = "btnVerifySubmit";
            this.btnVerifySubmit.Size = new System.Drawing.Size(166, 37);
            this.btnVerifySubmit.TabIndex = 1;
            this.btnVerifySubmit.Text = "Verify and continue";
            this.btnVerifySubmit.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(22, 146);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.panel2.Size = new System.Drawing.Size(697, 337);
            this.panel2.TabIndex = 1;
            // 
            // FormGlucoseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 538);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnVerifySubmit);
            this.Controls.Add(this.panel1);
            this.Name = "FormGlucoseSettings";
            this.Text = "Glucose Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
    }
}