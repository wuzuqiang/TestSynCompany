﻿namespace ReplaceString
{
    partial class FrmExcel
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSheetnames = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFreshSheetnamse = new System.Windows.Forms.Button();
            this.richShowData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开Excel文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(54, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "获取数据并生成Insert Sql";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "工作表";
            // 
            // txtSheetnames
            // 
            this.txtSheetnames.FormattingEnabled = true;
            this.txtSheetnames.Location = new System.Drawing.Point(109, 118);
            this.txtSheetnames.Name = "txtSheetnames";
            this.txtSheetnames.Size = new System.Drawing.Size(140, 23);
            this.txtSheetnames.TabIndex = 3;
            this.txtSheetnames.SelectedIndexChanged += new System.EventHandler(this.txtSheetnames_SelectedIndexChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(210, 58);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(451, 25);
            this.txtFilePath.TabIndex = 4;
            this.txtFilePath.Text = "C:\\test.xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(638, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "然后第二行第一列是表名，第三行是各列别名(隐藏)，第四行是英文字段，第五行开始时值列表";
            // 
            // btnFreshSheetnamse
            // 
            this.btnFreshSheetnamse.Location = new System.Drawing.Point(278, 122);
            this.btnFreshSheetnamse.Name = "btnFreshSheetnamse";
            this.btnFreshSheetnamse.Size = new System.Drawing.Size(75, 23);
            this.btnFreshSheetnamse.TabIndex = 6;
            this.btnFreshSheetnamse.Text = "刷新";
            this.btnFreshSheetnamse.UseVisualStyleBackColor = true;
            this.btnFreshSheetnamse.Click += new System.EventHandler(this.btnFreshSheetnamse_Click);
            // 
            // richShowData
            // 
            this.richShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richShowData.Location = new System.Drawing.Point(54, 265);
            this.richShowData.Name = "richShowData";
            this.richShowData.Size = new System.Drawing.Size(735, 371);
            this.richShowData.TabIndex = 7;
            this.richShowData.Text = "";
            // 
            // FrmExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 682);
            this.Controls.Add(this.richShowData);
            this.Controls.Add(this.btnFreshSheetnamse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtSheetnames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmExcel";
            this.Text = "FrmExcel";
            this.Load += new System.EventHandler(this.FrmExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtSheetnames;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFreshSheetnamse;
        private System.Windows.Forms.RichTextBox richShowData;
    }
}