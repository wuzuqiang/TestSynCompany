namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    partial class FrmGetMatchPalletCode
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgDetail = new System.Windows.Forms.TabPage();
            this.labInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtScanCode = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tpgDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgDetail);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 249);
            this.tabControl1.TabIndex = 3;
            // 
            // tpgDetail
            // 
            this.tpgDetail.BackColor = System.Drawing.Color.White;
            this.tpgDetail.Controls.Add(this.labInfo);
            this.tpgDetail.Controls.Add(this.label1);
            this.tpgDetail.Controls.Add(this.btnExit);
            this.tpgDetail.Controls.Add(this.btnNext);
            this.tpgDetail.Controls.Add(this.txtScanCode);
            this.tpgDetail.Location = new System.Drawing.Point(4, 23);
            this.tpgDetail.Name = "tpgDetail";
            this.tpgDetail.Size = new System.Drawing.Size(227, 222);
            this.tpgDetail.TabIndex = 0;
            this.tpgDetail.Text = "扫码";
            this.tpgDetail.UseVisualStyleBackColor = true;
            // 
            // labInfo
            // 
            this.labInfo.BackColor = System.Drawing.Color.White;
            this.labInfo.Location = new System.Drawing.Point(3, 12);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(221, 20);
            this.labInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "托盘条码:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(15, 155);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 26);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "<-返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(120, 155);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 26);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一步->";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtScanCode
            // 
            this.txtScanCode.Location = new System.Drawing.Point(3, 81);
            this.txtScanCode.Name = "txtScanCode";
            this.txtScanCode.Size = new System.Drawing.Size(221, 22);
            this.txtScanCode.TabIndex = 0;
            // 
            // FrmGetMatchPalletCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(241, 261);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "FrmGetMatchPalletCode";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScanBarCode_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tpgDetail.ResumeLayout(false);
            this.tpgDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgDetail;
        private System.Windows.Forms.TextBox txtScanCode;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labInfo;
    }
}