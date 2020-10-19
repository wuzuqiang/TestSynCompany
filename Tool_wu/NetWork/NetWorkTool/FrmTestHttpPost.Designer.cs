namespace TestHttpPost
{
	partial class FrmTestHttpPost
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
			this.pnlTool = new System.Windows.Forms.Panel();
			this.cboResEncoding = new System.Windows.Forms.ComboBox();
			this.lblResEncoding = new System.Windows.Forms.Label();
			this.lblPostData = new System.Windows.Forms.Label();
			this.txtPostData = new System.Windows.Forms.TextBox();
			this.btnGo = new System.Windows.Forms.Button();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.cboMode = new System.Windows.Forms.ComboBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.ddlContentType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlTool.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTool
			// 
			this.pnlTool.Controls.Add(this.cboResEncoding);
			this.pnlTool.Controls.Add(this.lblResEncoding);
			this.pnlTool.Controls.Add(this.lblPostData);
			this.pnlTool.Controls.Add(this.txtPostData);
			this.pnlTool.Controls.Add(this.btnGo);
			this.pnlTool.Controls.Add(this.txtUrl);
			this.pnlTool.Controls.Add(this.cboMode);
			this.pnlTool.Location = new System.Drawing.Point(0, 0);
			this.pnlTool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlTool.Name = "pnlTool";
			this.pnlTool.Size = new System.Drawing.Size(779, 150);
			this.pnlTool.TabIndex = 0;
			// 
			// cboResEncoding
			// 
			this.cboResEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboResEncoding.DropDownHeight = 400;
			this.cboResEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboResEncoding.FormattingEnabled = true;
			this.cboResEncoding.IntegralHeight = false;
			this.cboResEncoding.Location = new System.Drawing.Point(163, 121);
			this.cboResEncoding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cboResEncoding.Name = "cboResEncoding";
			this.cboResEncoding.Size = new System.Drawing.Size(615, 23);
			this.cboResEncoding.TabIndex = 6;
			this.cboResEncoding.SelectedIndexChanged += new System.EventHandler(this.cboResEncoding_SelectedIndexChanged);
			// 
			// lblResEncoding
			// 
			this.lblResEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblResEncoding.AutoSize = true;
			this.lblResEncoding.Location = new System.Drawing.Point(4, 125);
			this.lblResEncoding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblResEncoding.Name = "lblResEncoding";
			this.lblResEncoding.Size = new System.Drawing.Size(151, 15);
			this.lblResEncoding.TabIndex = 5;
			this.lblResEncoding.Text = "Response Encoding:";
			// 
			// lblPostData
			// 
			this.lblPostData.AutoSize = true;
			this.lblPostData.Location = new System.Drawing.Point(4, 41);
			this.lblPostData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPostData.Name = "lblPostData";
			this.lblPostData.Size = new System.Drawing.Size(87, 15);
			this.lblPostData.TabIndex = 4;
			this.lblPostData.Text = "Post Data:";
			// 
			// txtPostData
			// 
			this.txtPostData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPostData.Location = new System.Drawing.Point(115, 38);
			this.txtPostData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtPostData.Multiline = true;
			this.txtPostData.Name = "txtPostData";
			this.txtPostData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPostData.Size = new System.Drawing.Size(663, 75);
			this.txtPostData.TabIndex = 3;
			this.txtPostData.Text = "[\"P202010080008\", \"P202010080007\", \"P202010080006\"]";
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Location = new System.Drawing.Point(693, 0);
			this.btnGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(85, 29);
			this.btnGo.TabIndex = 2;
			this.btnGo.Text = "Go";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// txtUrl
			// 
			this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUrl.Location = new System.Drawing.Point(115, 2);
			this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(569, 25);
			this.txtUrl.TabIndex = 1;
			this.txtUrl.Text = "http://localhost:8080/Api/ProductionPlan/Send";
			// 
			// cboMode
			// 
			this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMode.FormattingEnabled = true;
			this.cboMode.Items.AddRange(new object[] {
            "GET",
            "POST"});
			this.cboMode.Location = new System.Drawing.Point(4, 2);
			this.cboMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cboMode.Name = "cboMode";
			this.cboMode.Size = new System.Drawing.Size(105, 23);
			this.cboMode.TabIndex = 0;
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 185);
			this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(777, 267);
			this.txtLog.TabIndex = 1;
			this.txtLog.WordWrap = false;
			// 
			// ddlContentType
			// 
			this.ddlContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlContentType.FormattingEnabled = true;
			this.ddlContentType.Location = new System.Drawing.Point(130, 155);
			this.ddlContentType.Margin = new System.Windows.Forms.Padding(4);
			this.ddlContentType.Name = "ddlContentType";
			this.ddlContentType.Size = new System.Drawing.Size(306, 23);
			this.ddlContentType.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 158);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "ContentType：";
			// 
			// FrmTestHttpPost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 452);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ddlContentType);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.pnlTool);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FrmTestHttpPost";
			this.Text = "TestHttpPost(测试Http的POST方法)";
			this.Load += new System.EventHandler(this.FrmTestHttpPost_Load);
			this.pnlTool.ResumeLayout(false);
			this.pnlTool.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlTool;
		private System.Windows.Forms.ComboBox cboMode;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.TextBox txtPostData;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Label lblPostData;
		private System.Windows.Forms.Label lblResEncoding;
		private System.Windows.Forms.ComboBox cboResEncoding;
		private System.Windows.Forms.ComboBox ddlContentType;
		private System.Windows.Forms.Label label1;
	}
}

