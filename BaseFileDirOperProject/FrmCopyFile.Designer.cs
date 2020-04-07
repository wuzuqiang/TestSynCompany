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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(55, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(490, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "将这些路径下的文件都复制相应目录下";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cbxIsNeedAddBaseDir
            // 
            this.cbxIsNeedAddBaseDir.AutoSize = true;
            this.cbxIsNeedAddBaseDir.Location = new System.Drawing.Point(55, 98);
            this.cbxIsNeedAddBaseDir.Name = "cbxIsNeedAddBaseDir";
            this.cbxIsNeedAddBaseDir.Size = new System.Drawing.Size(134, 19);
            this.cbxIsNeedAddBaseDir.TabIndex = 17;
            this.cbxIsNeedAddBaseDir.Text = "是否带根目录？";
            this.cbxIsNeedAddBaseDir.UseVisualStyleBackColor = true;
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.Location = new System.Drawing.Point(204, 96);
            this.txtBaseDir.Name = "txtBaseDir";
            this.txtBaseDir.Size = new System.Drawing.Size(341, 25);
            this.txtBaseDir.TabIndex = 18;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(55, 141);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(665, 285);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "需要复制文件的目录列表";
            // 
            // FrmCopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 585);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtBaseDir);
            this.Controls.Add(this.cbxIsNeedAddBaseDir);
            this.Controls.Add(this.button6);
            this.Name = "FrmCopyFile";
            this.Text = "FrmCopyFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox cbxIsNeedAddBaseDir;
        private System.Windows.Forms.TextBox txtBaseDir;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}