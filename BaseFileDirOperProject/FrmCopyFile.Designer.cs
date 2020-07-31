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
            this.panelFileFilterCondition = new System.Windows.Forms.Panel();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.txtMinTime = new System.Windows.Forms.TextBox();
            this.txtContainContent = new System.Windows.Forms.TextBox();
            this.cbxContainContent = new System.Windows.Forms.CheckBox();
            this.cbxTimeLessThan = new System.Windows.Forms.CheckBox();
            this.dptMaxTime = new System.Windows.Forms.DateTimePicker();
            this.txtContainFileName = new System.Windows.Forms.TextBox();
            this.cbxFileNameContain = new System.Windows.Forms.CheckBox();
            this.cbxTimeGreaterThan = new System.Windows.Forms.CheckBox();
            this.dptMinTime = new System.Windows.Forms.DateTimePicker();
            this.btnRestoreFilterCondition = new System.Windows.Forms.Button();
            this.btnSaveFilterCondition = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbxExtraCopyFunc01 = new System.Windows.Forms.CheckBox();
            this.panelFileFilterCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(53, 18);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(387, 32);
            this.button6.TabIndex = 16;
            this.button6.Text = "将文本框中的所有文件都复制到目录(每行一个)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cbxIsNeedAddBaseDir
            // 
            this.cbxIsNeedAddBaseDir.AutoSize = true;
            this.cbxIsNeedAddBaseDir.Location = new System.Drawing.Point(59, 295);
            this.cbxIsNeedAddBaseDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxIsNeedAddBaseDir.Name = "cbxIsNeedAddBaseDir";
            this.cbxIsNeedAddBaseDir.Size = new System.Drawing.Size(209, 19);
            this.cbxIsNeedAddBaseDir.TabIndex = 17;
            this.cbxIsNeedAddBaseDir.Text = "原目录是否需要带根目录？";
            this.cbxIsNeedAddBaseDir.UseVisualStyleBackColor = true;
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.Location = new System.Drawing.Point(269, 292);
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
            this.richCopyFiles.Location = new System.Drawing.Point(56, 335);
            this.richCopyFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richCopyFiles.Name = "richCopyFiles";
            this.richCopyFiles.Size = new System.Drawing.Size(1577, 262);
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
            this.txtDestDir.Size = new System.Drawing.Size(1179, 25);
            this.txtDestDir.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(871, 286);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(763, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "假如输入的是目录列表，那么先转换为文件列表，然后如上复制文件即可实现复制目录以及子目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 56);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 32);
            this.button2.TabIndex = 22;
            this.button2.Text = "修改文件名和带这些内容的目录由";
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
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1419, 625);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 38);
            this.button3.TabIndex = 28;
            this.button3.Text = "打开文本框中的所有文件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelFileFilterCondition
            // 
            this.panelFileFilterCondition.Controls.Add(this.txtMaxTime);
            this.panelFileFilterCondition.Controls.Add(this.txtMinTime);
            this.panelFileFilterCondition.Controls.Add(this.txtContainContent);
            this.panelFileFilterCondition.Controls.Add(this.cbxContainContent);
            this.panelFileFilterCondition.Controls.Add(this.cbxTimeLessThan);
            this.panelFileFilterCondition.Controls.Add(this.dptMaxTime);
            this.panelFileFilterCondition.Controls.Add(this.txtContainFileName);
            this.panelFileFilterCondition.Controls.Add(this.cbxFileNameContain);
            this.panelFileFilterCondition.Controls.Add(this.cbxTimeGreaterThan);
            this.panelFileFilterCondition.Controls.Add(this.dptMinTime);
            this.panelFileFilterCondition.Location = new System.Drawing.Point(53, 151);
            this.panelFileFilterCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFileFilterCondition.Name = "panelFileFilterCondition";
            this.panelFileFilterCondition.Size = new System.Drawing.Size(1581, 100);
            this.panelFileFilterCondition.TabIndex = 43;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.Location = new System.Drawing.Point(817, 22);
            this.txtMaxTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.Size = new System.Drawing.Size(199, 25);
            this.txtMaxTime.TabIndex = 53;
            // 
            // txtMinTime
            // 
            this.txtMinTime.Location = new System.Drawing.Point(283, 22);
            this.txtMinTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.Size = new System.Drawing.Size(209, 25);
            this.txtMinTime.TabIndex = 52;
            // 
            // txtContainContent
            // 
            this.txtContainContent.Location = new System.Drawing.Point(152, 52);
            this.txtContainContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContainContent.Name = "txtContainContent";
            this.txtContainContent.Size = new System.Drawing.Size(341, 25);
            this.txtContainContent.TabIndex = 51;
            // 
            // cbxContainContent
            // 
            this.cbxContainContent.AutoSize = true;
            this.cbxContainContent.Location = new System.Drawing.Point(21, 55);
            this.cbxContainContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxContainContent.Name = "cbxContainContent";
            this.cbxContainContent.Size = new System.Drawing.Size(119, 19);
            this.cbxContainContent.TabIndex = 50;
            this.cbxContainContent.Text = "文件内容包含";
            this.cbxContainContent.UseVisualStyleBackColor = true;
            // 
            // cbxTimeLessThan
            // 
            this.cbxTimeLessThan.AutoSize = true;
            this.cbxTimeLessThan.Location = new System.Drawing.Point(556, 29);
            this.cbxTimeLessThan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTimeLessThan.Name = "cbxTimeLessThan";
            this.cbxTimeLessThan.Size = new System.Drawing.Size(97, 19);
            this.cbxTimeLessThan.TabIndex = 49;
            this.cbxTimeLessThan.Text = "修改时间<";
            this.cbxTimeLessThan.UseVisualStyleBackColor = true;
            // 
            // dptMaxTime
            // 
            this.dptMaxTime.Location = new System.Drawing.Point(668, 22);
            this.dptMaxTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dptMaxTime.Name = "dptMaxTime";
            this.dptMaxTime.Size = new System.Drawing.Size(141, 25);
            this.dptMaxTime.TabIndex = 48;
            this.dptMaxTime.ValueChanged += new System.EventHandler(this.dptMaxTime_ValueChanged);
            // 
            // txtContainFileName
            // 
            this.txtContainFileName.Location = new System.Drawing.Point(1185, 26);
            this.txtContainFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContainFileName.Name = "txtContainFileName";
            this.txtContainFileName.Size = new System.Drawing.Size(341, 25);
            this.txtContainFileName.TabIndex = 47;
            // 
            // cbxFileNameContain
            // 
            this.cbxFileNameContain.AutoSize = true;
            this.cbxFileNameContain.Location = new System.Drawing.Point(1075, 28);
            this.cbxFileNameContain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFileNameContain.Name = "cbxFileNameContain";
            this.cbxFileNameContain.Size = new System.Drawing.Size(104, 19);
            this.cbxFileNameContain.TabIndex = 46;
            this.cbxFileNameContain.Text = "文件名包含";
            this.cbxFileNameContain.UseVisualStyleBackColor = true;
            // 
            // cbxTimeGreaterThan
            // 
            this.cbxTimeGreaterThan.AutoSize = true;
            this.cbxTimeGreaterThan.Location = new System.Drawing.Point(21, 28);
            this.cbxTimeGreaterThan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTimeGreaterThan.Name = "cbxTimeGreaterThan";
            this.cbxTimeGreaterThan.Size = new System.Drawing.Size(97, 19);
            this.cbxTimeGreaterThan.TabIndex = 45;
            this.cbxTimeGreaterThan.Tag = "filterCondition";
            this.cbxTimeGreaterThan.Text = "修改时间>";
            this.cbxTimeGreaterThan.UseVisualStyleBackColor = true;
            // 
            // dptMinTime
            // 
            this.dptMinTime.Location = new System.Drawing.Point(133, 22);
            this.dptMinTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dptMinTime.Name = "dptMinTime";
            this.dptMinTime.Size = new System.Drawing.Size(143, 25);
            this.dptMinTime.TabIndex = 44;
            this.dptMinTime.ValueChanged += new System.EventHandler(this.dptMinTime_ValueChanged);
            // 
            // btnRestoreFilterCondition
            // 
            this.btnRestoreFilterCondition.Location = new System.Drawing.Point(492, 112);
            this.btnRestoreFilterCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestoreFilterCondition.Name = "btnRestoreFilterCondition";
            this.btnRestoreFilterCondition.Size = new System.Drawing.Size(175, 28);
            this.btnRestoreFilterCondition.TabIndex = 55;
            this.btnRestoreFilterCondition.Text = "还原过滤条件";
            this.btnRestoreFilterCondition.UseVisualStyleBackColor = true;
            this.btnRestoreFilterCondition.Click += new System.EventHandler(this.btnRestoreFilterCondition_Click);
            // 
            // btnSaveFilterCondition
            // 
            this.btnSaveFilterCondition.Location = new System.Drawing.Point(265, 112);
            this.btnSaveFilterCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveFilterCondition.Name = "btnSaveFilterCondition";
            this.btnSaveFilterCondition.Size = new System.Drawing.Size(175, 28);
            this.btnSaveFilterCondition.TabIndex = 54;
            this.btnSaveFilterCondition.Text = "保存过滤条件";
            this.btnSaveFilterCondition.UseVisualStyleBackColor = true;
            this.btnSaveFilterCondition.Click += new System.EventHandler(this.btnSaveFilterCondition_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(55, 108);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 38);
            this.button4.TabIndex = 43;
            this.button4.Text = "过滤文件";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // cbxExtraCopyFunc01
            // 
            this.cbxExtraCopyFunc01.AutoSize = true;
            this.cbxExtraCopyFunc01.Location = new System.Drawing.Point(53, 61);
            this.cbxExtraCopyFunc01.Name = "cbxExtraCopyFunc01";
            this.cbxExtraCopyFunc01.Size = new System.Drawing.Size(89, 19);
            this.cbxExtraCopyFunc01.TabIndex = 56;
            this.cbxExtraCopyFunc01.Text = "附加功能";
            this.cbxExtraCopyFunc01.UseVisualStyleBackColor = true;
            // 
            // FrmCopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 674);
            this.Controls.Add(this.cbxExtraCopyFunc01);
            this.Controls.Add(this.btnRestoreFilterCondition);
            this.Controls.Add(this.panelFileFilterCondition);
            this.Controls.Add(this.btnSaveFilterCondition);
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
            this.Controls.Add(this.button4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCopyFile";
            this.Text = "FrmCopyFile";
            this.Load += new System.EventHandler(this.FrmCopyFile_Load);
            this.panelFileFilterCondition.ResumeLayout(false);
            this.panelFileFilterCondition.PerformLayout();
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
        private System.Windows.Forms.Panel panelFileFilterCondition;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.TextBox txtContainContent;
        private System.Windows.Forms.CheckBox cbxContainContent;
        private System.Windows.Forms.CheckBox cbxTimeLessThan;
        private System.Windows.Forms.DateTimePicker dptMaxTime;
        private System.Windows.Forms.TextBox txtContainFileName;
        private System.Windows.Forms.CheckBox cbxFileNameContain;
        private System.Windows.Forms.CheckBox cbxTimeGreaterThan;
        private System.Windows.Forms.DateTimePicker dptMinTime;
        private System.Windows.Forms.Button btnRestoreFilterCondition;
        private System.Windows.Forms.Button btnSaveFilterCondition;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox cbxExtraCopyFunc01;
    }
}