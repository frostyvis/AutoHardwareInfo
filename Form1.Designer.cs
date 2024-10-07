namespace AutoHardwareMonitorInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.btnSaveUsername = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIntervalDays = new System.Windows.Forms.Button();
            this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.btnFileName = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeleteIntervalDays = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(40, 119);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(132, 22);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // btnSaveUsername
            // 
            this.btnSaveUsername.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSaveUsername.Location = new System.Drawing.Point(181, 117);
            this.btnSaveUsername.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveUsername.Name = "btnSaveUsername";
            this.btnSaveUsername.Size = new System.Drawing.Size(100, 28);
            this.btnSaveUsername.TabIndex = 1;
            this.btnSaveUsername.Text = "Save";
            this.btnSaveUsername.UseVisualStyleBackColor = true;
            this.btnSaveUsername.Click += new System.EventHandler(this.btnSaveUsername_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Username Telegram";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(804, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "To start using the software, write to the telegram chat bot @AutoHardwareInfo_bot" +
    ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enter the interval for collecting and sending information \r\n(optional if you want" +
    " to do it manually or once)";
            // 
            // btnIntervalDays
            // 
            this.btnIntervalDays.Location = new System.Drawing.Point(620, 154);
            this.btnIntervalDays.Margin = new System.Windows.Forms.Padding(4);
            this.btnIntervalDays.Name = "btnIntervalDays";
            this.btnIntervalDays.Size = new System.Drawing.Size(100, 28);
            this.btnIntervalDays.TabIndex = 8;
            this.btnIntervalDays.Text = "Save";
            this.btnIntervalDays.UseVisualStyleBackColor = true;
            this.btnIntervalDays.Click += new System.EventHandler(this.btnIntervalDays_Click);
            // 
            // numericUpDownDays
            // 
            this.numericUpDownDays.Location = new System.Drawing.Point(433, 158);
            this.numericUpDownDays.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownDays.Name = "numericUpDownDays";
            this.numericUpDownDays.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownDays.TabIndex = 9;
            this.numericUpDownDays.ValueChanged += new System.EventHandler(this.numericUpDownDays_ValueChanged);
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.Location = new System.Drawing.Point(526, 158);
            this.numericUpDownHours.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownHours.TabIndex = 10;
            this.numericUpDownHours.ValueChanged += new System.EventHandler(this.numericUpDownHours_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Days";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hours";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(271, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Enter the name of the file to be sent (optional)";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(40, 241);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(132, 22);
            this.textBoxFileName.TabIndex = 14;
            this.textBoxFileName.TextChanged += new System.EventHandler(this.textBoxFileName_TextChanged);
            // 
            // btnFileName
            // 
            this.btnFileName.Location = new System.Drawing.Point(181, 239);
            this.btnFileName.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileName.Name = "btnFileName";
            this.btnFileName.Size = new System.Drawing.Size(100, 28);
            this.btnFileName.TabIndex = 15;
            this.btnFileName.Text = "Save";
            this.btnFileName.UseVisualStyleBackColor = true;
            this.btnFileName.Click += new System.EventHandler(this.btnFileName_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Click for test send";
            // 
            // btnSendTest
            // 
            this.btnSendTest.Location = new System.Drawing.Point(40, 345);
            this.btnSendTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(148, 62);
            this.btnSendTest.TabIndex = 17;
            this.btnSendTest.Text = "Test";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Or delete the task from the task scheduler";
            // 
            // btnDeleteIntervalDays
            // 
            this.btnDeleteIntervalDays.Location = new System.Drawing.Point(720, 205);
            this.btnDeleteIntervalDays.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteIntervalDays.Name = "btnDeleteIntervalDays";
            this.btnDeleteIntervalDays.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteIntervalDays.TabIndex = 20;
            this.btnDeleteIntervalDays.Text = "Delete";
            this.btnDeleteIntervalDays.UseVisualStyleBackColor = true;
            this.btnDeleteIntervalDays.Click += new System.EventHandler(this.btnDeleteIntervalDays_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 426);
            this.Controls.Add(this.btnDeleteIntervalDays);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnFileName);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownHours);
            this.Controls.Add(this.numericUpDownDays);
            this.Controls.Add(this.btnIntervalDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "AutoHardwareInfo";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button btnSaveUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIntervalDays;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button btnFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSendTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeleteIntervalDays;
    }
}