namespace BaseFileDirOperProject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath01 = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCombineDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCombineRelaPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cbxAppendRowIndex = new System.Windows.Forms.CheckBox();
            this.cbxClearOrigin = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.cbxIsCreateIfNotExist = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.txtFilePathThatContainAllSoftwarePackage = new System.Windows.Forms.TextBox();
            this.cbxAddBaseDir = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cbxAddFilePath = new System.Windows.Forms.CheckBox();
            this.cbxAddCreateTime = new System.Windows.Forms.CheckBox();
            this.cbxOrderFileName = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目录1：";
            // 
            // txtFilePath01
            // 
            this.txtFilePath01.Location = new System.Drawing.Point(70, 54);
            this.txtFilePath01.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFilePath01.Name = "txtFilePath01";
            this.txtFilePath01.Size = new System.Drawing.Size(404, 21);
            this.txtFilePath01.TabIndex = 1;
            this.txtFilePath01.Text = "E:\\repository\\Fusion\\src\\User Interface\\Fusion\\bin";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(488, 47);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(204, 30);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "打开文件或打开目录";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 191);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "打开上述合并的文件或目录(即目录2)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCombineDir
            // 
            this.txtCombineDir.Location = new System.Drawing.Point(70, 117);
            this.txtCombineDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCombineDir.Name = "txtCombineDir";
            this.txtCombineDir.Size = new System.Drawing.Size(404, 21);
            this.txtCombineDir.TabIndex = 4;
            this.txtCombineDir.Text = "D:\\workspace\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "目录2：";
            // 
            // txtCombineRelaPath
            // 
            this.txtCombineRelaPath.Location = new System.Drawing.Point(70, 158);
            this.txtCombineRelaPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCombineRelaPath.Name = "txtCombineRelaPath";
            this.txtCombineRelaPath.Size = new System.Drawing.Size(404, 21);
            this.txtCombineRelaPath.TabIndex = 7;
            this.txtCombineRelaPath.Text = "repository\\Fusion\\src\\User Interface\\Fusion\\bin";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 116);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 21);
            this.button2.TabIndex = 8;
            this.button2.Text = "选择基目录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(478, 158);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 21);
            this.button3.TabIndex = 9;
            this.button3.Text = "选择目录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 263);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(228, 16);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "记录所有文件信息到当前路径默认日志";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 10);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 18);
            this.button5.TabIndex = 12;
            this.button5.Text = "打开本程序根目录";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbxAppendRowIndex
            // 
            this.cbxAppendRowIndex.AutoSize = true;
            this.cbxAppendRowIndex.Location = new System.Drawing.Point(127, 328);
            this.cbxAppendRowIndex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxAppendRowIndex.Name = "cbxAppendRowIndex";
            this.cbxAppendRowIndex.Size = new System.Drawing.Size(72, 16);
            this.cbxAppendRowIndex.TabIndex = 13;
            this.cbxAppendRowIndex.Text = "添加行号";
            this.cbxAppendRowIndex.UseVisualStyleBackColor = true;
            // 
            // cbxClearOrigin
            // 
            this.cbxClearOrigin.AutoSize = true;
            this.cbxClearOrigin.Checked = true;
            this.cbxClearOrigin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxClearOrigin.Location = new System.Drawing.Point(27, 328);
            this.cbxClearOrigin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxClearOrigin.Name = "cbxClearOrigin";
            this.cbxClearOrigin.Size = new System.Drawing.Size(96, 16);
            this.cbxClearOrigin.TabIndex = 14;
            this.cbxClearOrigin.Text = "覆盖原有内容";
            this.cbxClearOrigin.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(27, 551);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(118, 22);
            this.button7.TabIndex = 16;
            this.button7.Text = "复制文件";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(305, 403);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "获取目录2下所有文件信息";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(23, 404);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(253, 22);
            this.button8.TabIndex = 18;
            this.button8.Text = "获取目录2下所有软件安装包文件信息";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // cbxIsCreateIfNotExist
            // 
            this.cbxIsCreateIfNotExist.AutoSize = true;
            this.cbxIsCreateIfNotExist.Location = new System.Drawing.Point(715, 55);
            this.cbxIsCreateIfNotExist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxIsCreateIfNotExist.Name = "cbxIsCreateIfNotExist";
            this.cbxIsCreateIfNotExist.Size = new System.Drawing.Size(96, 16);
            this.cbxIsCreateIfNotExist.TabIndex = 19;
            this.cbxIsCreateIfNotExist.Text = "不存在则创建";
            this.cbxIsCreateIfNotExist.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(23, 278);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(118, 28);
            this.button9.TabIndex = 21;
            this.button9.Text = "选择文件保存路径";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtFilePathThatContainAllSoftwarePackage
            // 
            this.txtFilePathThatContainAllSoftwarePackage.Location = new System.Drawing.Point(145, 283);
            this.txtFilePathThatContainAllSoftwarePackage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFilePathThatContainAllSoftwarePackage.Name = "txtFilePathThatContainAllSoftwarePackage";
            this.txtFilePathThatContainAllSoftwarePackage.Size = new System.Drawing.Size(666, 21);
            this.txtFilePathThatContainAllSoftwarePackage.TabIndex = 20;
            this.txtFilePathThatContainAllSoftwarePackage.Text = "E:\\repository\\TestSynCompany\\Regex\\文件是否上传到服务器\\当前某服务器某目录所有的软件安装包.txt";
            // 
            // cbxAddBaseDir
            // 
            this.cbxAddBaseDir.AutoSize = true;
            this.cbxAddBaseDir.Location = new System.Drawing.Point(439, 328);
            this.cbxAddBaseDir.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAddBaseDir.Name = "cbxAddBaseDir";
            this.cbxAddBaseDir.Size = new System.Drawing.Size(132, 16);
            this.cbxAddBaseDir.TabIndex = 22;
            this.cbxAddBaseDir.Text = "添加文件所在根目录";
            this.cbxAddBaseDir.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(215, 328);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "添加文件名称";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbxAddFilePath
            // 
            this.cbxAddFilePath.AutoSize = true;
            this.cbxAddFilePath.Checked = true;
            this.cbxAddFilePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAddFilePath.Location = new System.Drawing.Point(315, 328);
            this.cbxAddFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAddFilePath.Name = "cbxAddFilePath";
            this.cbxAddFilePath.Size = new System.Drawing.Size(120, 16);
            this.cbxAddFilePath.TabIndex = 24;
            this.cbxAddFilePath.Text = "添加文件所在路径";
            this.cbxAddFilePath.UseVisualStyleBackColor = true;
            // 
            // cbxAddCreateTime
            // 
            this.cbxAddCreateTime.AutoSize = true;
            this.cbxAddCreateTime.Checked = true;
            this.cbxAddCreateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAddCreateTime.Location = new System.Drawing.Point(575, 328);
            this.cbxAddCreateTime.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAddCreateTime.Name = "cbxAddCreateTime";
            this.cbxAddCreateTime.Size = new System.Drawing.Size(96, 16);
            this.cbxAddCreateTime.TabIndex = 25;
            this.cbxAddCreateTime.Text = "添加创建时间";
            this.cbxAddCreateTime.UseVisualStyleBackColor = true;
            // 
            // cbxOrderFileName
            // 
            this.cbxOrderFileName.AutoSize = true;
            this.cbxOrderFileName.Checked = true;
            this.cbxOrderFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxOrderFileName.Location = new System.Drawing.Point(27, 357);
            this.cbxOrderFileName.Margin = new System.Windows.Forms.Padding(2);
            this.cbxOrderFileName.Name = "cbxOrderFileName";
            this.cbxOrderFileName.Size = new System.Drawing.Size(96, 16);
            this.cbxOrderFileName.TabIndex = 26;
            this.cbxOrderFileName.Text = "排序文件名称";
            this.cbxOrderFileName.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 608);
            this.Controls.Add(this.cbxOrderFileName);
            this.Controls.Add(this.cbxAddCreateTime);
            this.Controls.Add(this.cbxAddFilePath);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.cbxAddBaseDir);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.txtFilePathThatContainAllSoftwarePackage);
            this.Controls.Add(this.cbxIsCreateIfNotExist);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.cbxClearOrigin);
            this.Controls.Add(this.cbxAppendRowIndex);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCombineRelaPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCombineDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtFilePath01);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath01;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCombineDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCombineRelaPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox cbxAppendRowIndex;
        private System.Windows.Forms.CheckBox cbxClearOrigin;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox cbxIsCreateIfNotExist;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtFilePathThatContainAllSoftwarePackage;
        private System.Windows.Forms.CheckBox cbxAddBaseDir;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox cbxAddFilePath;
        private System.Windows.Forms.CheckBox cbxAddCreateTime;
        private System.Windows.Forms.CheckBox cbxOrderFileName;
    }
}

