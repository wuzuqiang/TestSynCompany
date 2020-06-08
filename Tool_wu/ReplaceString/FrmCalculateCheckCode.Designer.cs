namespace ReplaceString
{
    partial class FrmCalculateCheckCode
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
            this.txtArraysBeforeArray = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFinalCheckedCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArraysAfterArray = new System.Windows.Forms.TextBox();
            this.txtMayNeedCaculateNode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtArraysBeforeArray
            // 
            this.txtArraysBeforeArray.Location = new System.Drawing.Point(254, 67);
            this.txtArraysBeforeArray.Name = "txtArraysBeforeArray";
            this.txtArraysBeforeArray.Size = new System.Drawing.Size(607, 25);
            this.txtArraysBeforeArray.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "整形数组的前部分：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "反推出可能的存在中间的整形数据";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "获取最终校验码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFinalCheckedCode
            // 
            this.txtFinalCheckedCode.Location = new System.Drawing.Point(293, 270);
            this.txtFinalCheckedCode.Name = "txtFinalCheckedCode";
            this.txtFinalCheckedCode.Size = new System.Drawing.Size(331, 25);
            this.txtFinalCheckedCode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "整形数组的后部分：";
            // 
            // txtArraysAfterArray
            // 
            this.txtArraysAfterArray.Location = new System.Drawing.Point(254, 200);
            this.txtArraysAfterArray.Name = "txtArraysAfterArray";
            this.txtArraysAfterArray.Size = new System.Drawing.Size(607, 25);
            this.txtArraysAfterArray.TabIndex = 5;
            // 
            // txtMayNeedCaculateNode
            // 
            this.txtMayNeedCaculateNode.Location = new System.Drawing.Point(329, 138);
            this.txtMayNeedCaculateNode.Name = "txtMayNeedCaculateNode";
            this.txtMayNeedCaculateNode.Size = new System.Drawing.Size(317, 25);
            this.txtMayNeedCaculateNode.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(630, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "由最终校验码反推中间数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(94, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "备注：数组以逗号分隔";
            // 
            // FrmCalculateCheckCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 579);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMayNeedCaculateNode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArraysAfterArray);
            this.Controls.Add(this.txtFinalCheckedCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArraysBeforeArray);
            this.Name = "FrmCalculateCheckCode";
            this.Text = "FrmCalculateCheckCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArraysBeforeArray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFinalCheckedCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArraysAfterArray;
        private System.Windows.Forms.TextBox txtMayNeedCaculateNode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}