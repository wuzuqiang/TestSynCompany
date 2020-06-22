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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbxTimeGreaterThan = new System.Windows.Forms.CheckBox();
            this.cbxFileNameContain = new System.Windows.Forms.CheckBox();
            this.txtContainStr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(41, 19);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(289, 18);
            this.button6.TabIndex = 16;
            this.button6.Text = "将文本框中的所有文件都复制到目录(每行一个)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cbxIsNeedAddBaseDir
            // 
            this.cbxIsNeedAddBaseDir.AutoSize = true;
            this.cbxIsNeedAddBaseDir.Location = new System.Drawing.Point(41, 150);
            this.cbxIsNeedAddBaseDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxIsNeedAddBaseDir.Name = "cbxIsNeedAddBaseDir";
            this.cbxIsNeedAddBaseDir.Size = new System.Drawing.Size(168, 16);
            this.cbxIsNeedAddBaseDir.TabIndex = 17;
            this.cbxIsNeedAddBaseDir.Text = "原目录是否需要带根目录？";
            this.cbxIsNeedAddBaseDir.UseVisualStyleBackColor = true;
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.Location = new System.Drawing.Point(200, 148);
            this.txtBaseDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBaseDir.Name = "txtBaseDir";
            this.txtBaseDir.Size = new System.Drawing.Size(257, 21);
            this.txtBaseDir.TabIndex = 18;
            // 
            // richCopyFiles
            // 
            this.richCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richCopyFiles.Location = new System.Drawing.Point(41, 173);
            this.richCopyFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richCopyFiles.Name = "richCopyFiles";
            this.richCopyFiles.Size = new System.Drawing.Size(1252, 506);
            this.richCopyFiles.TabIndex = 19;
            this.richCopyFiles.Text = "需要复制文件列表";
            // 
            // txtDestDir
            // 
            this.txtDestDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestDir.Location = new System.Drawing.Point(341, 18);
            this.txtDestDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDestDir.Name = "txtDestDir";
            this.txtDestDir.Size = new System.Drawing.Size(952, 21);
            this.txtDestDir.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(705, 147);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(572, 21);
            this.button1.TabIndex = 21;
            this.button1.Text = "假如输入的是目录列表，那么先转换为文件列表，然后如上复制文件即可实现复制目录以及子目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 45);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(253, 26);
            this.button2.TabIndex = 22;
            this.button2.Text = "附加功能，修改文件名和带这些内容的目录由";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 修改为
            // 
            this.修改为.AutoSize = true;
            this.修改为.Location = new System.Drawing.Point(496, 53);
            this.修改为.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.修改为.Name = "修改为";
            this.修改为.Size = new System.Drawing.Size(41, 12);
            this.修改为.TabIndex = 27;
            this.修改为.Text = "修改为";
            // 
            // txtDest01
            // 
            this.txtDest01.Location = new System.Drawing.Point(550, 47);
            this.txtDest01.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDest01.Name = "txtDest01";
            this.txtDest01.Size = new System.Drawing.Size(210, 21);
            this.txtDest01.TabIndex = 26;
            // 
            // txtSrc01
            // 
            this.txtSrc01.Location = new System.Drawing.Point(311, 47);
            this.txtSrc01.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSrc01.Name = "txtSrc01";
            this.txtSrc01.Size = new System.Drawing.Size(181, 21);
            this.txtSrc01.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(1132, 692);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 30);
            this.button3.TabIndex = 28;
            this.button3.Text = "打开文本框中的所有文件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(41, 90);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 30);
            this.button4.TabIndex = 29;
            this.button4.Text = "过滤文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(241, 93);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 21);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // cbxTimeGreaterThan
            // 
            this.cbxTimeGreaterThan.AutoSize = true;
            this.cbxTimeGreaterThan.Location = new System.Drawing.Point(157, 98);
            this.cbxTimeGreaterThan.Name = "cbxTimeGreaterThan";
            this.cbxTimeGreaterThan.Size = new System.Drawing.Size(78, 16);
            this.cbxTimeGreaterThan.TabIndex = 32;
            this.cbxTimeGreaterThan.Text = "修改时间>";
            this.cbxTimeGreaterThan.UseVisualStyleBackColor = true;
            // 
            // cbxFileNameContain
            // 
            this.cbxFileNameContain.AutoSize = true;
            this.cbxFileNameContain.Location = new System.Drawing.Point(498, 98);
            this.cbxFileNameContain.Name = "cbxFileNameContain";
            this.cbxFileNameContain.Size = new System.Drawing.Size(84, 16);
            this.cbxFileNameContain.TabIndex = 33;
            this.cbxFileNameContain.Text = "文件名包含";
            this.cbxFileNameContain.UseVisualStyleBackColor = true;
            // 
            // txtContainStr
            // 
            this.txtContainStr.Location = new System.Drawing.Point(587, 93);
            this.txtContainStr.Margin = new System.Windows.Forms.Padding(2);
            this.txtContainStr.Name = "txtContainStr";
            this.txtContainStr.Size = new System.Drawing.Size(257, 21);
            this.txtContainStr.TabIndex = 34;
            // 
            // FrmCopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 733);
            this.Controls.Add(this.txtContainStr);
            this.Controls.Add(this.cbxFileNameContain);
            this.Controls.Add(this.cbxTimeGreaterThan);
            this.Controls.Add(this.dateTimePicker1);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox cbxTimeGreaterThan;
        private System.Windows.Forms.CheckBox cbxFileNameContain;
        private System.Windows.Forms.TextBox txtContainStr;
    }
}