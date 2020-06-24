namespace BaseFileDirOperProject
{
    partial class FrmCopyFile
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
            this.button6 = new System.Windows.Forms.Button();
            this.cbxIsNeedAddBaseDir = new System.Windows.Forms.CheckBox();
            this.txtBaseDir = new System.Windows.Forms.TextBox();
            this.richCopyFiles = new System.Windows.Forms.RichTextBox();
            this.txtDestDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.修改为 = new System.Windows.Forms.Label();
            this.txtDest01 = new System.Windows.Forms.TextBox();
            this.txtSrc01 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dptMinTime = new System.Windows.Forms.DateTimePicker();
            this.cbxTimeGreaterThan = new System.Windows.Forms.CheckBox();
            this.cbxFileNameContain = new System.Windows.Forms.CheckBox();
            this.txtContainStr = new System.Windows.Forms.TextBox();
            this.cbxTimeLessThan = new System.Windows.Forms.CheckBox();
            this.dptMaxTime = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtMinTime = new System.Windows.Forms.TextBox();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(55, 24);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(385, 22);
            this.button6.TabIndex = 16;
            this.button6.Text = "将文本框中的所有文件都复制到目录(每行一个)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cbxIsNeedAddBaseDir
            // 
            this.cbxIsNeedAddBaseDir.AutoSize = true;
            this.cbxIsNeedAddBaseDir.Location = new System.Drawing.Point(55, 188);
            this.cbxIsNeedAddBaseDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxIsNeedAddBaseDir.Name = "cbxIsNeedAddBaseDir";
            this.cbxIsNeedAddBaseDir.Size = new System.Drawing.Size(209, 19);
            this.cbxIsNeedAddBaseDir.TabIndex = 17;
            this.cbxIsNeedAddBaseDir.Text = "原目录是否需要带根目录？";
            this.cbxIsNeedAddBaseDir.UseVisualStyleBackColor = true;
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.Location = new System.Drawing.Point(267, 185);
            this.txtBaseDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaseDir.Name = "txtBaseDir";
            this.txtBaseDir.Size = new System.Drawing.Size(341, 25);
            this.txtBaseDir.TabIndex = 18;
            // 
            // richCopyFiles
            // 
            this.richCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richCopyFiles.Location = new System.Drawing.Point(55, 216);
            this.richCopyFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richCopyFiles.Name = "richCopyFiles";
            this.richCopyFiles.Size = new System.Drawing.Size(1668, 632);
            this.richCopyFiles.TabIndex = 19;
            this.richCopyFiles.Text = "需要复制文件列表";
            // 
            // txtDestDir
            // 
            this.txtDestDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestDir.Location = new System.Drawing.Point(455, 22);
            this.txtDestDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestDir.Name = "txtDestDir";
            this.txtDestDir.Size = new System.Drawing.Size(1268, 25);
            this.txtDestDir.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(940, 184);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(763, 26);
            this.button1.TabIndex = 21;
            this.button1.Text = "假如输入的是目录列表，那么先转换为文件列表，然后如上复制文件即可实现复制目录以及子目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 56);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 32);
            this.button2.TabIndex = 22;
            this.button2.Text = "附加功能，修改文件名和带这些内容的目录由";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 修改为
            // 
            this.修改为.AutoSize = true;
            this.修改为.Location = new System.Drawing.Point(661, 66);
            this.修改为.Name = "修改为";
            this.修改为.Size = new System.Drawing.Size(52, 15);
            this.修改为.TabIndex = 27;
            this.修改为.Text = "修改为";
            // 
            // txtDest01
            // 
            this.txtDest01.Location = new System.Drawing.Point(733, 59);
            this.txtDest01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDest01.Name = "txtDest01";
            this.txtDest01.Size = new System.Drawing.Size(279, 25);
            this.txtDest01.TabIndex = 26;
            // 
            // txtSrc01
            // 
            this.txtSrc01.Location = new System.Drawing.Point(415, 59);
            this.txtSrc01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSrc01.Name = "txtSrc01";
            this.txtSrc01.Size = new System.Drawing.Size(240, 25);
            this.txtSrc01.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(1509, 865);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 38);
            this.button3.TabIndex = 28;
            this.button3.Text = "打开文本框中的所有文件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(55, 112);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 38);
            this.button4.TabIndex = 29;
            this.button4.Text = "过滤文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dptMinTime
            // 
            this.dptMinTime.Location = new System.Drawing.Point(321, 116);
            this.dptMinTime.Margin = new System.Windows.Forms.Padding(4);
            this.dptMinTime.Name = "dptMinTime";
            this.dptMinTime.Size = new System.Drawing.Size(273, 25);
            this.dptMinTime.TabIndex = 31;
            // 
            // cbxTimeGreaterThan
            // 
            this.cbxTimeGreaterThan.AutoSize = true;
            this.cbxTimeGreaterThan.Location = new System.Drawing.Point(209, 122);
            this.cbxTimeGreaterThan.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTimeGreaterThan.Name = "cbxTimeGreaterThan";
            this.cbxTimeGreaterThan.Size = new System.Drawing.Size(97, 19);
            this.cbxTimeGreaterThan.TabIndex = 32;
            this.cbxTimeGreaterThan.Text = "修改时间>";
            this.cbxTimeGreaterThan.UseVisualStyleBackColor = true;
            // 
            // cbxFileNameContain
            // 
            this.cbxFileNameContain.AutoSize = true;
            this.cbxFileNameContain.Location = new System.Drawing.Point(1256, 122);
            this.cbxFileNameContain.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFileNameContain.Name = "cbxFileNameContain";
            this.cbxFileNameContain.Size = new System.Drawing.Size(104, 19);
            this.cbxFileNameContain.TabIndex = 33;
            this.cbxFileNameContain.Text = "文件名包含";
            this.cbxFileNameContain.UseVisualStyleBackColor = true;
            // 
            // txtContainStr
            // 
            this.txtContainStr.Location = new System.Drawing.Point(1367, 120);
            this.txtContainStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContainStr.Name = "txtContainStr";
            this.txtContainStr.Size = new System.Drawing.Size(341, 25);
            this.txtContainStr.TabIndex = 34;
            // 
            // cbxTimeLessThan
            // 
            this.cbxTimeLessThan.AutoSize = true;
            this.cbxTimeLessThan.Location = new System.Drawing.Point(729, 123);
            this.cbxTimeLessThan.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTimeLessThan.Name = "cbxTimeLessThan";
            this.cbxTimeLessThan.Size = new System.Drawing.Size(97, 19);
            this.cbxTimeLessThan.TabIndex = 36;
            this.cbxTimeLessThan.Text = "修改时间<";
            this.cbxTimeLessThan.UseVisualStyleBackColor = true;
            // 
            // dptMaxTime
            // 
            this.dptMaxTime.Location = new System.Drawing.Point(841, 117);
            this.dptMaxTime.Margin = new System.Windows.Forms.Padding(4);
            this.dptMaxTime.Name = "dptMaxTime";
            this.dptMaxTime.Size = new System.Drawing.Size(273, 25);
            this.dptMaxTime.TabIndex = 35;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(209, 149);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 19);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "文件名包含";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(314, 147);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 25);
            this.textBox1.TabIndex = 38;
            // 
            // txtMinTime
            // 
            this.txtMinTime.Location = new System.Drawing.Point(601, 116);
            this.txtMinTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.Size = new System.Drawing.Size(93, 25);
            this.txtMinTime.TabIndex = 39;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.Location = new System.Drawing.Point(1121, 117);
            this.txtMaxTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.Size = new System.Drawing.Size(93, 25);
            this.txtMaxTime.TabIndex = 40;
            // 
            // FrmCopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1759, 916);
            this.Controls.Add(this.txtMaxTime);
            this.Controls.Add(this.txtMinTime);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbxTimeLessThan);
            this.Controls.Add(this.dptMaxTime);
            this.Controls.Add(this.txtContainStr);
            this.Controls.Add(this.cbxFileNameContain);
            this.Controls.Add(this.cbxTimeGreaterThan);
            this.Controls.Add(this.dptMinTime);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.修改为);
            this.Controls.Add(this.txtDest01);
            this.Controls.Add(this.txtSrc01);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDestDir);
            this.Controls.Add(this.richCopyFiles);
            this.Controls.Add(this.txtBaseDir);
            this.Controls.Add(this.cbxIsNeedAddBaseDir);
            this.Controls.Add(this.button6);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCopyFile";
            this.Text = "FrmCopyFile";
            this.Load += new System.EventHandler(this.FrmCopyFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox cbxIsNeedAddBaseDir;
        private System.Windows.Forms.TextBox txtBaseDir;
        private System.Windows.Forms.RichTextBox richCopyFiles;
        private System.Windows.Forms.TextBox txtDestDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label 修改为;
        private System.Windows.Forms.TextBox txtDest01;
        private System.Windows.Forms.TextBox txtSrc01;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dptMinTime;
        private System.Windows.Forms.CheckBox cbxTimeGreaterThan;
        private System.Windows.Forms.CheckBox cbxFileNameContain;
        private System.Windows.Forms.TextBox txtContainStr;
        private System.Windows.Forms.CheckBox cbxTimeLessThan;
        private System.Windows.Forms.DateTimePicker dptMaxTime;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.TextBox txtMaxTime;
    }
}