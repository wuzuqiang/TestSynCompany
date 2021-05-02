namespace Fusion.LYYC.PDA.Scanner
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
            this.tpgScan = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnOnce = new System.Windows.Forms.Button();
            this.listScan = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tpgScan.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tpgScan);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 292);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged_1);
            // 
            // tpgScan
            // 
            this.tpgScan.BackColor = System.Drawing.Color.White;
            this.tpgScan.Controls.Add(this.btnExit);
            this.tpgScan.Controls.Add(this.btnMore);
            this.tpgScan.Controls.Add(this.btnClean);
            this.tpgScan.Controls.Add(this.btnOnce);
            this.tpgScan.Controls.Add(this.listScan);
            this.tpgScan.Location = new System.Drawing.Point(4, 23);
            this.tpgScan.Name = "tpgScan";
            this.tpgScan.Size = new System.Drawing.Size(227, 265);
            this.tpgScan.Text = "扫码";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.Location = new System.Drawing.Point(0, 245);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(227, 20);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMore.Location = new System.Drawing.Point(152, 205);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(72, 23);
            this.btnMore.TabIndex = 5;
            this.btnMore.Text = "多次扫码";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClean.Location = new System.Drawing.Point(77, 205);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(72, 23);
            this.btnClean.TabIndex = 4;
            this.btnClean.Text = "清    空";
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnOnce
            // 
            this.btnOnce.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOnce.Location = new System.Drawing.Point(1, 205);
            this.btnOnce.Name = "btnOnce";
            this.btnOnce.Size = new System.Drawing.Size(72, 23);
            this.btnOnce.TabIndex = 3;
            this.btnOnce.Text = "单次扫码";
            this.btnOnce.Click += new System.EventHandler(this.btnOnce_Click);
            // 
            // listScan
            // 
            this.listScan.Columns.Add(this.columnHeader1);
            this.listScan.Columns.Add(this.columnHeader2);
            this.listScan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.listScan.Location = new System.Drawing.Point(-4, 0);
            this.listScan.Name = "listScan";
            this.listScan.Size = new System.Drawing.Size(231, 187);
            this.listScan.TabIndex = 2;
            this.listScan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "条码编号";
            this.columnHeader1.Width = 175;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "次数";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 50;
            // 
            // FrmScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(534, 455);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "FrmScanCode";
            this.Text = "条码";
            this.Load += new System.EventHandler(this.FrmScanCode_Load);
            this.Closed += new System.EventHandler(this.FrmScanCode_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScanCode_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tpgScan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgScan;
        private System.Windows.Forms.ListView listScan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnOnce;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnExit;
    }
}