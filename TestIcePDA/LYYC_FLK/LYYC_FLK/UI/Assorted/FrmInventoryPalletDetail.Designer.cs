namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    partial class FrmInventoryPalletDetail
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
            this.tpgAssorted = new System.Windows.Forms.TabPage();
            this.PageCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBeforePage = new System.Windows.Forms.Button();
            this.BtnNextPage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.TotalPage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwMathPalletList = new System.Windows.Forms.ListView();
            this.cloMathPalletCode = new System.Windows.Forms.ColumnHeader();
            this.colMatchPalletPlanNo = new System.Windows.Forms.ColumnHeader();
            this.cloMathPalletName = new System.Windows.Forms.ColumnHeader();
            this.colplanDate = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpgAssorted.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 261);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgAssorted);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 248);
            this.tabControl1.TabIndex = 4;
            // 
            // tpgAssorted
            // 
            this.tpgAssorted.BackColor = System.Drawing.Color.White;
            this.tpgAssorted.Controls.Add(this.PageCount);
            this.tpgAssorted.Controls.Add(this.label2);
            this.tpgAssorted.Controls.Add(this.label5);
            this.tpgAssorted.Controls.Add(this.btnBeforePage);
            this.tpgAssorted.Controls.Add(this.BtnNextPage);
            this.tpgAssorted.Controls.Add(this.btnExit);
            this.tpgAssorted.Controls.Add(this.btnBack);
            this.tpgAssorted.Controls.Add(this.TotalPage);
            this.tpgAssorted.Controls.Add(this.label4);
            this.tpgAssorted.Controls.Add(this.label3);
            this.tpgAssorted.Controls.Add(this.lvwMathPalletList);
            this.tpgAssorted.Location = new System.Drawing.Point(4, 23);
            this.tpgAssorted.Name = "tpgAssorted";
            this.tpgAssorted.Size = new System.Drawing.Size(227, 221);
            this.tpgAssorted.TabIndex = 0;
            this.tpgAssorted.Text = "盘点盘位信息";
            this.tpgAssorted.UseVisualStyleBackColor = true;
            // 
            // PageCount
            // 
            this.PageCount.Font = new System.Drawing.Font("宋体", 12F);
            this.PageCount.Location = new System.Drawing.Point(33, 175);
            this.PageCount.Name = "PageCount";
            this.PageCount.Size = new System.Drawing.Size(16, 16);
            this.PageCount.TabIndex = 0;
            this.PageCount.Text = "0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(51, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "页";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(-2, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "共:";
            // 
            // btnBeforePage
            // 
            this.btnBeforePage.Location = new System.Drawing.Point(76, 172);
            this.btnBeforePage.Name = "btnBeforePage";
            this.btnBeforePage.Size = new System.Drawing.Size(66, 22);
            this.btnBeforePage.TabIndex = 16;
            this.btnBeforePage.Text = "上页";
            this.btnBeforePage.Click += new System.EventHandler(this.btnBeforePage_Click);
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.Location = new System.Drawing.Point(148, 173);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.Size = new System.Drawing.Size(66, 22);
            this.BtnNextPage.TabIndex = 15;
            this.BtnNextPage.Text = "下页";
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(148, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 22);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "完 成";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(76, 196);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(66, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "返   回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // TotalPage
            // 
            this.TotalPage.Font = new System.Drawing.Font("宋体", 12F);
            this.TotalPage.Location = new System.Drawing.Point(32, 196);
            this.TotalPage.Name = "TotalPage";
            this.TotalPage.Size = new System.Drawing.Size(16, 16);
            this.TotalPage.TabIndex = 17;
            this.TotalPage.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(51, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "页";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(0, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "第:";
            // 
            // lvwMathPalletList
            // 
            this.lvwMathPalletList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cloMathPalletCode,
            this.colMatchPalletPlanNo,
            this.cloMathPalletName,
            this.colplanDate});
            this.lvwMathPalletList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lvwMathPalletList.FullRowSelect = true;
            this.lvwMathPalletList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwMathPalletList.Location = new System.Drawing.Point(0, 3);
            this.lvwMathPalletList.Name = "lvwMathPalletList";
            this.lvwMathPalletList.Size = new System.Drawing.Size(227, 156);
            this.lvwMathPalletList.TabIndex = 3;
            this.lvwMathPalletList.UseCompatibleStateImageBehavior = false;
            this.lvwMathPalletList.View = System.Windows.Forms.View.Details;
            this.lvwMathPalletList.ItemActivate += new System.EventHandler(this.lvwMathPalletList_ItemActivate);
            this.lvwMathPalletList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwMathPalletList_KeyDown);
            // 
            // cloMathPalletCode
            // 
            this.cloMathPalletCode.Text = "盘点单据号";
            this.cloMathPalletCode.Width = 100;
            // 
            // colMatchPalletPlanNo
            // 
            this.colMatchPalletPlanNo.Text = "托盘条码";
            this.colMatchPalletPlanNo.Width = 100;
            // 
            // cloMathPalletName
            // 
            this.cloMathPalletName.DisplayIndex = 3;
            this.cloMathPalletName.Text = "货位名称";
            this.cloMathPalletName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cloMathPalletName.Width = 100;
            // 
            // colplanDate
            // 
            this.colplanDate.DisplayIndex = 2;
            this.colplanDate.Text = "盘位名称";
            this.colplanDate.Width = 100;
            // 
            // FrmInventoryPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(243, 261);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "FrmInventoryPallet";
            this.Closed += new System.EventHandler(this.FrmAssorted_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpgAssorted.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgAssorted;
        private System.Windows.Forms.ListView lvwMathPalletList;
        private System.Windows.Forms.ColumnHeader cloMathPalletCode;
        private System.Windows.Forms.ColumnHeader cloMathPalletName;
        private System.Windows.Forms.Label TotalPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader colplanDate;
        private System.Windows.Forms.ColumnHeader colMatchPalletPlanNo;
        private System.Windows.Forms.Button BtnNextPage;
        private System.Windows.Forms.Button btnBeforePage;
        private System.Windows.Forms.Label PageCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}