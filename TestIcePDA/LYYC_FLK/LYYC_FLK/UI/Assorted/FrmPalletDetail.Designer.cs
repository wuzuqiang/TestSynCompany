namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    partial class FrmPalletDetail
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgDetail = new System.Windows.Forms.TabPage();
            this.btnComplete = new System.Windows.Forms.Button();
            this.listviewScan = new System.Windows.Forms.ListView();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colNum = new System.Windows.Forms.ColumnHeader();
            this.colScanNum = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpgDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(534, 455);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgDetail);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 261);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged_1);
            // 
            // tpgDetail
            // 
            this.tpgDetail.BackColor = System.Drawing.Color.White;
            this.tpgDetail.Controls.Add(this.btnBack);
            this.tpgDetail.Controls.Add(this.btnComplete);
            this.tpgDetail.Controls.Add(this.listviewScan);
            this.tpgDetail.Location = new System.Drawing.Point(4, 23);
            this.tpgDetail.Name = "tpgDetail";
            this.tpgDetail.Size = new System.Drawing.Size(227, 234);
            this.tpgDetail.TabIndex = 0;
            this.tpgDetail.Text = "盘位明细";
            this.tpgDetail.UseVisualStyleBackColor = true;
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(123, 198);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(72, 23);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.Text = "完 成";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // listviewScan
            // 
            this.listviewScan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductName,
            this.colNum,
            this.colScanNum,
            this.colProductCode});
            this.listviewScan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.listviewScan.FullRowSelect = true;
            this.listviewScan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listviewScan.Location = new System.Drawing.Point(0, 0);
            this.listviewScan.Name = "listviewScan";
            this.listviewScan.Size = new System.Drawing.Size(231, 179);
            this.listviewScan.TabIndex = 2;
            this.listviewScan.UseCompatibleStateImageBehavior = false;
            this.listviewScan.View = System.Windows.Forms.View.Details;
            this.listviewScan.ItemActivate += new System.EventHandler(this.listviewScan_ItemActivate);
            // 
            // colProductName
            // 
            this.colProductName.Text = "产品名称";
            this.colProductName.Width = 150;
            // 
            // colNum
            // 
            this.colNum.Text = "系统数量";
            this.colNum.Width = 100;
            // 
            // colScanNum
            // 
            this.colScanNum.Text = "实际数量";
            this.colScanNum.Width = 100;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "产品编号";
            this.colProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colProductCode.Width = 200;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(21, 198);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(66, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "返   回";
            // 
            // FrmPalletDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(534, 455);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "FrmPalletDetail";
            this.Load += new System.EventHandler(this.FrmAssortedDetail_Load);
            this.Closed += new System.EventHandler(this.FrmAssortedDetail_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAssortedDetail_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpgDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgDetail;
        private System.Windows.Forms.ListView listviewScan;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.ColumnHeader colNum;
        private System.Windows.Forms.ColumnHeader colScanNum;
        private System.Windows.Forms.Button btnBack;
    }
}