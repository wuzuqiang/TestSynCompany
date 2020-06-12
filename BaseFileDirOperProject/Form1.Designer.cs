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
            this.button4 = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "目录1：";
            // 
            // txtFilePath01
            // 
            this.txtFilePath01.Location = new System.Drawing.Point(93, 67);
            this.txtFilePath01.Name = "txtFilePath01";
            this.txtFilePath01.Size = new System.Drawing.Size(538, 25);
            this.txtFilePath01.TabIndex = 1;
            this.txtFilePath01.Text = "E:\\repository\\Fusion\\src\\User Interface\\Fusion\\bin";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(651, 59);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(272, 37);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "打开文件或打开目录";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(331, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "打开上述合并的文件或目录(即目录2)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCombineDir
            // 
            this.txtCombineDir.Location = new System.Drawing.Point(93, 146);
            this.txtCombineDir.Name = "txtCombineDir";
            this.txtCombineDir.Size = new System.Drawing.Size(538, 25);
            this.txtCombineDir.TabIndex = 4;
            this.txtCombineDir.Text = "D:\\workspace\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "目录2：";
            // 
            // txtCombineRelaPath
            // 
            this.txtCombineRelaPath.Location = new System.Drawing.Point(93, 198);
            this.txtCombineRelaPath.Name = "txtCombineRelaPath";
            this.txtCombineRelaPath.Size = new System.Drawing.Size(538, 25);
            this.txtCombineRelaPath.TabIndex = 7;
            this.txtCombineRelaPath.Text = "repository\\Fusion\\src\\User Interface\\Fusion\\bin";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(637, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 26);
            this.button2.TabIndex = 8;
            this.button2.Text = "选择基目录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(637, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "选择目录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(37, 351);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(291, 30);
            this.button4.TabIndex = 10;
            this.button4.Text = "获取目录2下所有文件名称和所在路径";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(345, 371);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(284, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "记录所有文件信息到当前路径默认日志";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(37, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "打开本程序根目录";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbxAppendRowIndex
            // 
            this.cbxAppendRowIndex.AutoSize = true;
            this.cbxAppendRowIndex.Location = new System.Drawing.Point(635, 371);
            this.cbxAppendRowIndex.Name = "cbxAppendRowIndex";
            this.cbxAppendRowIndex.Size = new System.Drawing.Size(89, 19);
            this.cbxAppendRowIndex.TabIndex = 13;
            this.cbxAppendRowIndex.Text = "添加行号";
            this.cbxAppendRowIndex.UseVisualStyleBackColor = true;
            // 
            // cbxClearOrigin
            // 
            this.cbxClearOrigin.AutoSize = true;
            this.cbxClearOrigin.Location = new System.Drawing.Point(730, 371);
            this.cbxClearOrigin.Name = "cbxClearOrigin";
            this.cbxClearOrigin.Size = new System.Drawing.Size(119, 19);
            this.cbxClearOrigin.TabIndex = 14;
            this.cbxClearOrigin.Text = "覆盖原有内容";
            this.cbxClearOrigin.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(37, 573);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(137, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "复制文件";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(37, 388);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(266, 29);
            this.button6.TabIndex = 17;
            this.button6.Text = "获取目录2下所有文件名称列表";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(37, 452);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(620, 28);
            this.button8.TabIndex = 18;
            this.button8.Text = "获取目录2下所有软件安装包文件名(去除基目录)，并保存在文件(清空原有内容)：";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // cbxIsCreateIfNotExist
            // 
            this.cbxIsCreateIfNotExist.AutoSize = true;
            this.cbxIsCreateIfNotExist.Location = new System.Drawing.Point(953, 69);
            this.cbxIsCreateIfNotExist.Name = "cbxIsCreateIfNotExist";
            this.cbxIsCreateIfNotExist.Size = new System.Drawing.Size(119, 19);
            this.cbxIsCreateIfNotExist.TabIndex = 19;
            this.cbxIsCreateIfNotExist.Text = "不存在则创建";
            this.cbxIsCreateIfNotExist.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(951, 482);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(137, 28);
            this.button9.TabIndex = 21;
            this.button9.Text = "选择文件";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtFilePathThatContainAllSoftwarePackage
            // 
            this.txtFilePathThatContainAllSoftwarePackage.Location = new System.Drawing.Point(37, 486);
            this.txtFilePathThatContainAllSoftwarePackage.Name = "txtFilePathThatContainAllSoftwarePackage";
            this.txtFilePathThatContainAllSoftwarePackage.Size = new System.Drawing.Size(886, 25);
            this.txtFilePathThatContainAllSoftwarePackage.TabIndex = 20;
            this.txtFilePathThatContainAllSoftwarePackage.Text = "E:\\repository\\TestSynCompany\\Regex\\文件是否上传到服务器\\当前某服务器某目录所有的软件安装包.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 630);
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
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCombineRelaPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCombineDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtFilePath01);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button button4;
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
    }
}

