namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    partial class FrmProductFacture
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
            this.tpgProductFacture = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lvwProductFacture = new System.Windows.Forms.ListView();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colFactureName = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colFactureCode = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tpgProductFacture.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(534, 455);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgProductFacture);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 249);
            this.tabControl1.TabIndex = 3;
            // 
            // tpgProductFacture
            // 
            this.tpgProductFacture.BackColor = System.Drawing.Color.White;
            this.tpgProductFacture.Controls.Add(this.btnBack);
            this.tpgProductFacture.Controls.Add(this.btnNext);
            this.tpgProductFacture.Controls.Add(this.lvwProductFacture);
            this.tpgProductFacture.Location = new System.Drawing.Point(4, 23);
            this.tpgProductFacture.Name = "tpgProductFacture";
            this.tpgProductFacture.Size = new System.Drawing.Size(227, 222);
            this.tpgProductFacture.Text = "产品厂商";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(17, 185);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 26);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "<-返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(122, 185);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 26);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "下一步->";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lvwProductFacture
            // 
            this.lvwProductFacture.Columns.Add(this.colProductName);
            this.lvwProductFacture.Columns.Add(this.colFactureName);
            this.lvwProductFacture.Columns.Add(this.colProductCode);
            this.lvwProductFacture.Columns.Add(this.colFactureCode);
            this.lvwProductFacture.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lvwProductFacture.FullRowSelect = true;
            this.lvwProductFacture.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwProductFacture.Location = new System.Drawing.Point(-4, 0);
            this.lvwProductFacture.Name = "lvwProductFacture";
            this.lvwProductFacture.Size = new System.Drawing.Size(231, 168);
            this.lvwProductFacture.TabIndex = 2;
            this.lvwProductFacture.View = System.Windows.Forms.View.Details;
            this.lvwProductFacture.ItemActivate += new System.EventHandler(this.lvwProductFacture_ItemActivate);
            // 
            // colProductName
            // 
            this.colProductName.Text = "产品名称";
            this.colProductName.Width = 150;
            // 
            // colFactureName
            // 
            this.colFactureName.Text = "厂商名称";
            this.colFactureName.Width = 100;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "产品编号";
            this.colProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colProductCode.Width = 150;
            // 
            // colFactureCode
            // 
            this.colFactureCode.Text = "厂商编码";
            this.colFactureCode.Width = 80;
            // 
            // FrmProductFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(534, 455);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "FrmProductFacture";
            this.Load += new System.EventHandler(this.FrmProductFacture_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpgProductFacture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgProductFacture;
        private System.Windows.Forms.ListView lvwProductFacture;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colFactureName;
        private System.Windows.Forms.ColumnHeader colFactureCode;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
    }
}