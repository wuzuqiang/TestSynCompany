namespace ScanDemo.UI.Assorted
{
    partial class FrmScanCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScanCode));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(534, 455);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgDetail);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 292);
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
            this.tpgDetail.Size = new System.Drawing.Size(227, 265);
            this.tpgDetail.Text = "配盘细表";
            // 
            // labInfo
            // 
            this.labInfo.BackColor = System.Drawing.Color.White;
            this.labInfo.Location = new System.Drawing.Point(3, 12);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(221, 20);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.Text = "托盘条码:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(15, 173);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 26);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(120, 173);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 26);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtScanCode
            // 
            this.txtScanCode.Location = new System.Drawing.Point(3, 75);
            this.txtScanCode.Name = "txtScanCode";
            this.txtScanCode.Size = new System.Drawing.Size(221, 23);
            this.txtScanCode.TabIndex = 0;
            // 
            // FrmScanBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(534, 455);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "FrmScanBarCode";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScanBarCode_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tpgDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgDetail;
        private System.Windows.Forms.TextBox txtScanCode;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labInfo;
    }
}