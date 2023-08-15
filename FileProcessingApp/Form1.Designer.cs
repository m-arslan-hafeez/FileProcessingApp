namespace FileProcessingApp
{
    partial class frmMain
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
            this.tbLibrary = new System.Windows.Forms.TextBox();
            this.btnLibrary = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEncDec = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbShow = new System.Windows.Forms.RichTextBox();
            this.optFile = new System.Windows.Forms.RadioButton();
            this.optText = new System.Windows.Forms.RadioButton();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.btnSaveOutput = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.cbOptions = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbLibrary
            // 
            this.tbLibrary.BackColor = System.Drawing.SystemColors.Window;
            this.tbLibrary.Location = new System.Drawing.Point(102, 36);
            this.tbLibrary.Name = "tbLibrary";
            this.tbLibrary.ReadOnly = true;
            this.tbLibrary.Size = new System.Drawing.Size(313, 20);
            this.tbLibrary.TabIndex = 0;
            // 
            // btnLibrary
            // 
            this.btnLibrary.Location = new System.Drawing.Point(421, 36);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(28, 20);
            this.btnLibrary.TabIndex = 1;
            this.btnLibrary.Text = "...";
            this.btnLibrary.UseVisualStyleBackColor = true;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Import Library:";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(421, 105);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(28, 19);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Visible = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // tbFile
            // 
            this.tbFile.BackColor = System.Drawing.SystemColors.Window;
            this.tbFile.Location = new System.Drawing.Point(102, 105);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(313, 20);
            this.tbFile.TabIndex = 3;
            this.tbFile.Visible = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(13, 108);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(53, 13);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Add Text:";
            this.lblText.Visible = false;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(102, 93);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(313, 73);
            this.tbText.TabIndex = 3;
            this.tbText.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Key:";
            // 
            // tbKey
            // 
            this.tbKey.BackColor = System.Drawing.SystemColors.Window;
            this.tbKey.Location = new System.Drawing.Point(102, 183);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(180, 20);
            this.tbKey.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(429, 468);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEncDec
            // 
            this.btnEncDec.Location = new System.Drawing.Point(288, 182);
            this.btnEncDec.Name = "btnEncDec";
            this.btnEncDec.Size = new System.Drawing.Size(127, 22);
            this.btnEncDec.TabIndex = 12;
            this.btnEncDec.Text = "Encrypt/Decrypt";
            this.btnEncDec.UseVisualStyleBackColor = true;
            this.btnEncDec.Click += new System.EventHandler(this.btnEncDec_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 468);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbShow
            // 
            this.rtbShow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbShow.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbShow.Location = new System.Drawing.Point(20, 246);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.Size = new System.Drawing.Size(488, 214);
            this.rtbShow.TabIndex = 14;
            this.rtbShow.Text = "";
            // 
            // optFile
            // 
            this.optFile.AutoSize = true;
            this.optFile.Location = new System.Drawing.Point(102, 70);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(41, 17);
            this.optFile.TabIndex = 15;
            this.optFile.Text = "File";
            this.optFile.UseVisualStyleBackColor = true;
            this.optFile.CheckedChanged += new System.EventHandler(this.optFile_CheckedChanged);
            // 
            // optText
            // 
            this.optText.AutoSize = true;
            this.optText.Location = new System.Drawing.Point(245, 70);
            this.optText.Name = "optText";
            this.optText.Size = new System.Drawing.Size(46, 17);
            this.optText.TabIndex = 16;
            this.optText.Text = "Text";
            this.optText.UseVisualStyleBackColor = true;
            this.optText.CheckedChanged += new System.EventHandler(this.optText_CheckedChanged);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(13, 109);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(59, 13);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "Select File:";
            this.lblFile.Visible = false;
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(13, 220);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(61, 13);
            this.lblOutputFile.TabIndex = 19;
            this.lblOutputFile.Text = "Output File:";
            this.lblOutputFile.Visible = false;
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.BackColor = System.Drawing.SystemColors.Window;
            this.tbOutputFile.Location = new System.Drawing.Point(102, 214);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(313, 20);
            this.tbOutputFile.TabIndex = 18;
            this.tbOutputFile.Visible = false;
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.Location = new System.Drawing.Point(421, 214);
            this.btnSaveOutput.Name = "btnSaveOutput";
            this.btnSaveOutput.Size = new System.Drawing.Size(28, 19);
            this.btnSaveOutput.TabIndex = 20;
            this.btnSaveOutput.Text = "...";
            this.btnSaveOutput.UseVisualStyleBackColor = true;
            this.btnSaveOutput.Visible = false;
            this.btnSaveOutput.Click += new System.EventHandler(this.btnSaveOutput_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(336, 467);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 21;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cbOptions
            // 
            this.cbOptions.BackColor = System.Drawing.SystemColors.Control;
            this.cbOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOptions.Items.AddRange(new object[] {
            "Decrypt",
            "Encrypt"});
            this.cbOptions.Location = new System.Drawing.Point(317, 66);
            this.cbOptions.MaxDropDownItems = 2;
            this.cbOptions.Name = "cbOptions";
            this.cbOptions.Size = new System.Drawing.Size(98, 21);
            this.cbOptions.Sorted = true;
            this.cbOptions.TabIndex = 22;
            this.cbOptions.Text = "Select Option";
            this.cbOptions.Visible = false;
            this.cbOptions.SelectedIndexChanged += new System.EventHandler(this.cbOptions_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(531, 496);
            this.Controls.Add(this.cbOptions);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnSaveOutput);
            this.Controls.Add(this.lblOutputFile);
            this.Controls.Add(this.tbOutputFile);
            this.Controls.Add(this.optText);
            this.Controls.Add(this.optFile);
            this.Controls.Add(this.rtbShow);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEncDec);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLibrary);
            this.Controls.Add(this.tbLibrary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLibrary;
        private System.Windows.Forms.Button btnLibrary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton optFile;
        private System.Windows.Forms.RadioButton optText;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.TextBox tbOutputFile;
        private System.Windows.Forms.Button btnSaveOutput;
        public System.Windows.Forms.RichTextBox rtbShow;
        private System.Windows.Forms.Button btnShow;
        public System.Windows.Forms.Button btnEncDec;
        public System.Windows.Forms.ComboBox cbOptions;
    }
}

