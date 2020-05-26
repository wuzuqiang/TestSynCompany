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
            this.txtDestBaseDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(55, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(385, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "将文本框中的所有文件都复制到目录(每行一个)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cbxIsNeedAddBaseDir
            // 
            this.cbxIsNeedAddBaseDir.AutoSize = true;
            this.cbxIsNeedAddBaseDir.Location = new System.Drawing.Point(55, 114);
            this.cbxIsNeedAddBaseDir.Name = "cbxIsNeedAddBaseDir";
            this.cbxIsNeedAddBaseDir.Size = new System.Drawing.Size(209, 19);
            this.cbxIsNeedAddBaseDir.TabIndex = 17;
            this.cbxIsNeedAddBaseDir.Text = "原目录是否需要带根目录？";
            this.cbxIsNeedAddBaseDir.UseVisualStyleBackColor = true;
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.Location = new System.Drawing.Point(289, 112);
            this.txtBaseDir.Name = "txtBaseDir";
            this.txtBaseDir.Size = new System.Drawing.Size(341, 25);
            this.txtBaseDir.TabIndex = 18;
            // 
            // richCopyFiles
            // 
            this.richCopyFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richCopyFiles.Location = new System.Drawing.Point(55, 141);
            this.richCopyFiles.Name = "richCopyFiles";
            this.richCopyFiles.Size = new System.Drawing.Size(789, 519);
            this.richCopyFiles.TabIndex = 19;
            this.richCopyFiles.Text = "需要复制文件列表";
            // 
            // txtDestBaseDir
            // 
            this.txtDestBaseDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestBaseDir.Location = new System.Drawing.Point(455, 47);
            this.txtDestBaseDir.Name = "txtDestBaseDir";
            this.txtDestBaseDir.Size = new System.Drawing.Size(389, 25);
            this.txtDestBaseDir.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(55, 678);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(757, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "假如输入的是目录列表，那么先转换为文件列表，然后如上复制文件即可实现复制目录以及子目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDestBaseDir);
            this.Controls.Add(this.richCopyFiles);
            this.Controls.Add(this.txtBaseDir);
            this.Controls.Add(this.cbxIsNeedAddBaseDir);
            this.Controls.Add(this.button6);
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
        private System.Windows.Forms.TextBox txtDestBaseDir;
        private System.Windows.Forms.Button button1;
    }
}