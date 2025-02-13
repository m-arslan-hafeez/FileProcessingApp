﻿namespace FileProcessingApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbLibrary = new System.Windows.Forms.TextBox();
            this.lblLibrary = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEncDec = new System.Windows.Forms.Button();
            this.optFile = new System.Windows.Forms.RadioButton();
            this.optText = new System.Windows.Forms.RadioButton();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.cbOptions = new System.Windows.Forms.ComboBox();
            this.chBoxShow = new System.Windows.Forms.CheckBox();
            this.btnSaveOutput = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnLibrary = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabControlShow = new System.Windows.Forms.TabControl();
            this.tpOutputTab = new System.Windows.Forms.TabPage();
            this.tpResultTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLibrary
            // 
            this.tbLibrary.BackColor = System.Drawing.SystemColors.Window;
            this.tbLibrary.Location = new System.Drawing.Point(136, 17);
            this.tbLibrary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbLibrary.Name = "tbLibrary";
            this.tbLibrary.ReadOnly = true;
            this.tbLibrary.Size = new System.Drawing.Size(416, 21);
            this.tbLibrary.TabIndex = 0;
            // 
            // lblLibrary
            // 
            this.lblLibrary.AutoSize = true;
            this.lblLibrary.Location = new System.Drawing.Point(17, 22);
            this.lblLibrary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLibrary.Name = "lblLibrary";
            this.lblLibrary.Size = new System.Drawing.Size(100, 15);
            this.lblLibrary.TabIndex = 2;
            this.lblLibrary.Text = "Import Library:";
            // 
            // tbFile
            // 
            this.tbFile.BackColor = System.Drawing.SystemColors.Window;
            this.tbFile.Location = new System.Drawing.Point(136, 96);
            this.tbFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(416, 21);
            this.tbFile.TabIndex = 3;
            this.tbFile.Visible = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(17, 100);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(66, 15);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Add Text:";
            this.lblText.Visible = false;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(136, 82);
            this.tbText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(416, 84);
            this.tbText.TabIndex = 3;
            this.tbText.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Key:";
            // 
            // tbKey
            // 
            this.tbKey.BackColor = System.Drawing.SystemColors.Window;
            this.tbKey.Location = new System.Drawing.Point(136, 186);
            this.tbKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(239, 21);
            this.tbKey.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(410, 227);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 27);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEncDec
            // 
            this.btnEncDec.Location = new System.Drawing.Point(465, 185);
            this.btnEncDec.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEncDec.Name = "btnEncDec";
            this.btnEncDec.Size = new System.Drawing.Size(88, 25);
            this.btnEncDec.TabIndex = 12;
            this.btnEncDec.Text = "OK";
            this.btnEncDec.UseVisualStyleBackColor = true;
            this.btnEncDec.Visible = false;
            this.btnEncDec.Click += new System.EventHandler(this.btnEncDec_Click);
            // 
            // optFile
            // 
            this.optFile.AutoSize = true;
            this.optFile.Location = new System.Drawing.Point(136, 56);
            this.optFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(49, 19);
            this.optFile.TabIndex = 15;
            this.optFile.Text = "File";
            this.optFile.UseVisualStyleBackColor = true;
            this.optFile.CheckedChanged += new System.EventHandler(this.optFile_CheckedChanged);
            // 
            // optText
            // 
            this.optText.AutoSize = true;
            this.optText.Location = new System.Drawing.Point(327, 56);
            this.optText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optText.Name = "optText";
            this.optText.Size = new System.Drawing.Size(52, 19);
            this.optText.TabIndex = 16;
            this.optText.Text = "Text";
            this.optText.UseVisualStyleBackColor = true;
            this.optText.CheckedChanged += new System.EventHandler(this.optText_CheckedChanged);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(17, 101);
            this.lblFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(79, 15);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "Select File:";
            this.lblFile.Visible = false;
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(17, 132);
            this.lblOutputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(81, 15);
            this.lblOutputFile.TabIndex = 19;
            this.lblOutputFile.Text = "Output File:";
            this.lblOutputFile.Visible = false;
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.BackColor = System.Drawing.SystemColors.Window;
            this.tbOutputFile.Location = new System.Drawing.Point(136, 132);
            this.tbOutputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(416, 21);
            this.tbOutputFile.TabIndex = 18;
            this.tbOutputFile.Visible = false;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(485, 227);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(67, 27);
            this.btnShow.TabIndex = 21;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cbOptions
            // 
            this.cbOptions.BackColor = System.Drawing.SystemColors.Control;
            this.cbOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOptions.Items.AddRange(new object[] {
            "Decrypt",
            "Encrypt"});
            this.cbOptions.Location = new System.Drawing.Point(423, 51);
            this.cbOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbOptions.MaxDropDownItems = 2;
            this.cbOptions.Name = "cbOptions";
            this.cbOptions.Size = new System.Drawing.Size(129, 23);
            this.cbOptions.Sorted = true;
            this.cbOptions.TabIndex = 22;
            this.cbOptions.Text = "Select Option";
            this.cbOptions.Visible = false;
            this.cbOptions.SelectedIndexChanged += new System.EventHandler(this.cbOptions_SelectedIndexChanged);
            // 
            // chBoxShow
            // 
            this.chBoxShow.AutoSize = true;
            this.chBoxShow.Checked = true;
            this.chBoxShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxShow.Location = new System.Drawing.Point(384, 188);
            this.chBoxShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chBoxShow.Name = "chBoxShow";
            this.chBoxShow.Size = new System.Drawing.Size(61, 19);
            this.chBoxShow.TabIndex = 24;
            this.chBoxShow.Text = "Show";
            this.chBoxShow.UseVisualStyleBackColor = true;
            this.chBoxShow.CheckedChanged += new System.EventHandler(this.chBoxShow_CheckedChanged);
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveOutput.Image")));
            this.btnSaveOutput.Location = new System.Drawing.Point(561, 126);
            this.btnSaveOutput.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveOutput.Name = "btnSaveOutput";
            this.btnSaveOutput.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.btnSaveOutput.Size = new System.Drawing.Size(33, 33);
            this.btnSaveOutput.TabIndex = 20;
            this.btnSaveOutput.UseVisualStyleBackColor = true;
            this.btnSaveOutput.Visible = false;
            this.btnSaveOutput.Click += new System.EventHandler(this.btnSaveOutput_Click);
            // 
            // btnFile
            // 
            this.btnFile.Image = global::FileProcessingApp.Properties.Resources.icons8_add_file_24;
            this.btnFile.Location = new System.Drawing.Point(561, 87);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(33, 33);
            this.btnFile.TabIndex = 4;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Visible = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnLibrary
            // 
            this.btnLibrary.Image = global::FileProcessingApp.Properties.Resources.icons8_dll_24;
            this.btnLibrary.Location = new System.Drawing.Point(561, 11);
            this.btnLibrary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(33, 33);
            this.btnLibrary.TabIndex = 1;
            this.btnLibrary.UseVisualStyleBackColor = true;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(20, 227);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(97, 27);
            this.btnClearAll.TabIndex = 13;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Visible = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(136, 227);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(73, 27);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(217, 227);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 27);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tabControlShow
            // 
            this.tabControlShow.Controls.Add(this.tpOutputTab);
            this.tabControlShow.Controls.Add(this.tpResultTab);
            this.tabControlShow.Location = new System.Drawing.Point(20, 269);
            this.tabControlShow.Multiline = true;
            this.tabControlShow.Name = "tabControlShow";
            this.tabControlShow.SelectedIndex = 0;
            this.tabControlShow.Size = new System.Drawing.Size(574, 207);
            this.tabControlShow.TabIndex = 27;
            this.tabControlShow.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlShow_Selected);
            // 
            // tpOutputTab
            // 
            this.tpOutputTab.BackColor = System.Drawing.SystemColors.Window;
            this.tpOutputTab.Location = new System.Drawing.Point(4, 24);
            this.tpOutputTab.Name = "tpOutputTab";
            this.tpOutputTab.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutputTab.Size = new System.Drawing.Size(566, 179);
            this.tpOutputTab.TabIndex = 0;
            this.tpOutputTab.Text = "Output";
            // 
            // tpResultTab
            // 
            this.tpResultTab.Location = new System.Drawing.Point(4, 24);
            this.tpResultTab.Name = "tpResultTab";
            this.tpResultTab.Padding = new System.Windows.Forms.Padding(3);
            this.tpResultTab.Size = new System.Drawing.Size(566, 179);
            this.tpResultTab.TabIndex = 1;
            this.tpResultTab.Text = "Result";
            this.tpResultTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 28;
            this.button1.Text = "Rotate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(614, 507);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControlShow);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chBoxShow);
            this.Controls.Add(this.cbOptions);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnSaveOutput);
            this.Controls.Add(this.lblOutputFile);
            this.Controls.Add(this.tbOutputFile);
            this.Controls.Add(this.optText);
            this.Controls.Add(this.optFile);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnEncDec);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.lblLibrary);
            this.Controls.Add(this.btnLibrary);
            this.Controls.Add(this.tbLibrary);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Processing Application";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.frmMain_Load);
            this.tabControlShow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLibrary;
        private System.Windows.Forms.Button btnLibrary;
        private System.Windows.Forms.Label lblLibrary;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton optFile;
        private System.Windows.Forms.RadioButton optText;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.TextBox tbOutputFile;
        private System.Windows.Forms.Button btnSaveOutput;
        private System.Windows.Forms.Button btnShow;
        public System.Windows.Forms.Button btnEncDec;
        public System.Windows.Forms.ComboBox cbOptions;
        private System.Windows.Forms.CheckBox chBoxShow;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tabControlShow;
        private System.Windows.Forms.TabPage tpOutputTab;
        private System.Windows.Forms.TabPage tpResultTab;
        private System.Windows.Forms.Button button1;
    }
}

