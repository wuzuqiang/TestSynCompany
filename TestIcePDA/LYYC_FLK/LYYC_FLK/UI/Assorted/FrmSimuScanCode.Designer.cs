namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    partial class FrmSimuScanCode
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtScanBarCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtScanBarCode
            // 
            this.txtScanBarCode.Location = new System.Drawing.Point(13, 32);
            this.txtScanBarCode.Name = "txtScanBarCode";
            this.txtScanBarCode.Size = new System.Drawing.Size(202, 23);
            this.txtScanBarCode.TabIndex = 0;
            this.txtScanBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScanBarCode_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "取消";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmSimuScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(231, 129);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtScanBarCode);
            this.Menu = this.mainMenu1;
            this.Name = "FrmSimuScanCode";
            this.Text = "扫描产品编码";
            this.Load += new System.EventHandler(this.FrmSimuScanCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtScanBarCode;
        private System.Windows.Forms.Button button1;
    }
}