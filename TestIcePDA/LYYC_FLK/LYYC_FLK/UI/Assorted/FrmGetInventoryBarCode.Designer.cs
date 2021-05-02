namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    partial class FrmGetInventoryBarCode
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabControl1.Size = new System.Drawing.Size(238, 246);
            this.tabControl1.TabIndex = 3;
            // 
            // tpgDetail
            // 
            this.tpgDetail.BackColor = System.Drawing.Color.White;
            this.tpgDetail.Controls.Add(this.label1);
            this.tpgDetail.Controls.Add(this.comboBox3);
            this.tpgDetail.Controls.Add(this.textBox1);
            this.tpgDetail.Controls.Add(this.button1);
            this.tpgDetail.Controls.Add(this.label6);
            this.tpgDetail.Controls.Add(this.btnExit);
            this.tpgDetail.Controls.Add(this.btnNext);
            this.tpgDetail.Location = new System.Drawing.Point(4, 23);
            this.tpgDetail.Name = "tpgDetail";
            this.tpgDetail.Size = new System.Drawing.Size(230, 219);
            this.tpgDetail.TabIndex = 0;
            this.tpgDetail.Text = "确认盘点条码";
            this.tpgDetail.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(153, 22);
            this.textBox1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 26);
            this.button1.TabIndex = 16;
            this.button1.Text = "手工维护记录条码(慎用)：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "记录条码：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(15, 168);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 26);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "<-返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(120, 168);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 26);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一步->";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "货位01",
            "货位02"});
            this.comboBox3.Location = new System.Drawing.Point(89, 42);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(133, 22);
            this.comboBox3.TabIndex = 19;
            this.comboBox3.Text = "03420001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(177, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "(*非空)";
            // 
            // FrmGetInventoryBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(241, 261);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "FrmGetInventoryBarCode";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScanBarCode_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tpgDetail.ResumeLayout(false);
            this.tpgDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgDetail;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label1;
    }
}