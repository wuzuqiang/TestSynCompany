﻿namespace ReplaceString
{
    partial class FrmReplaceOracleSql
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richInput = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtOperContent = new System.Windows.Forms.TextBox();
            this.txtOperNotContained = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtAppendToBefore = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtReplaced = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.txtReplaceStr = new System.Windows.Forms.TextBox();
            this.txtReplacedStr02 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAppendToEnd = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.txtReplaceStr04 = new System.Windows.Forms.TextBox();
            this.txtBeReplaceStr04 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConcludeBeforeRowNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConcludeAfterRowNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 190);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 25);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "将";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "替换为";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(71, 245);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(252, 25);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 305);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "开始替换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richInput
            // 
            this.richInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richInput.Location = new System.Drawing.Point(351, 225);
            this.richInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richInput.Name = "richInput";
            this.richInput.Size = new System.Drawing.Size(1057, 598);
            this.richInput.TabIndex = 5;
            this.richInput.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "某行带这些内容则保留，以|符号组合";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 598);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 22);
            this.button2.TabIndex = 7;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOperContent
            // 
            this.txtOperContent.Location = new System.Drawing.Point(39, 565);
            this.txtOperContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOperContent.Name = "txtOperContent";
            this.txtOperContent.Size = new System.Drawing.Size(252, 25);
            this.txtOperContent.TabIndex = 8;
            // 
            // txtOperNotContained
            // 
            this.txtOperNotContained.Location = new System.Drawing.Point(39, 442);
            this.txtOperNotContained.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOperNotContained.Name = "txtOperNotContained";
            this.txtOperNotContained.Size = new System.Drawing.Size(252, 25);
            this.txtOperNotContained.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 476);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 22);
            this.button3.TabIndex = 10;
            this.button3.Text = "开始整理";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "某行不带这些内容则保留，以|符号组合";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 129);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 22);
            this.button4.TabIndex = 12;
            this.button4.Text = "将每行以|组合起来";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(5, 44);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(300, 22);
            this.button5.TabIndex = 13;
            this.button5.Text = "Undo,将Oracle的sql转换为Sqlserver的sql";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(5, 12);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(300, 22);
            this.button6.TabIndex = 14;
            this.button6.Text = "Uncoplete，通过excel数据生成insertSql语句";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(351, 78);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(339, 35);
            this.button8.TabIndex = 16;
            this.button8.Text = "将“\'System.Byte[]\' ”替换为\"SYS_GUID()\"";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(907, 20);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(200, 22);
            this.button9.TabIndex = 17;
            this.button9.Text = "在每行前新增(空行除外)";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtAppendToBefore
            // 
            this.txtAppendToBefore.Location = new System.Drawing.Point(1128, 28);
            this.txtAppendToBefore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppendToBefore.Name = "txtAppendToBefore";
            this.txtAppendToBefore.Size = new System.Drawing.Size(148, 25);
            this.txtAppendToBefore.TabIndex = 18;
            this.txtAppendToBefore.Text = "--";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(907, 49);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(200, 22);
            this.button10.TabIndex = 19;
            this.button10.Text = "移除每行前(空行除外)";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(907, 81);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(200, 35);
            this.button11.TabIndex = 20;
            this.button11.Text = "新增到每行最尾端(空行除外)";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "将";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(379, 126);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(281, 25);
            this.textBox3.TabIndex = 22;
            this.textBox3.Text = "2019/11/18 17:17:00这样的日期类型";
            // 
            // txtReplaced
            // 
            this.txtReplaced.Location = new System.Drawing.Point(755, 126);
            this.txtReplaced.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReplaced.Name = "txtReplaced";
            this.txtReplaced.Size = new System.Drawing.Size(100, 25);
            this.txtReplaced.TabIndex = 24;
            this.txtReplaced.Text = "SYSDATE";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(667, 119);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 38);
            this.button12.TabIndex = 25;
            this.button12.Text = "替换为";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(667, 28);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 38);
            this.button13.TabIndex = 29;
            this.button13.Text = "替换为";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txtReplaceStr
            // 
            this.txtReplaceStr.Location = new System.Drawing.Point(755, 35);
            this.txtReplaceStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReplaceStr.Name = "txtReplaceStr";
            this.txtReplaceStr.Size = new System.Drawing.Size(100, 25);
            this.txtReplaceStr.TabIndex = 28;
            // 
            // txtReplacedStr02
            // 
            this.txtReplacedStr02.Location = new System.Drawing.Point(379, 35);
            this.txtReplacedStr02.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReplacedStr02.Name = "txtReplacedStr02";
            this.txtReplacedStr02.Size = new System.Drawing.Size(281, 25);
            this.txtReplacedStr02.TabIndex = 27;
            this.txtReplacedStr02.Text = " and (\"ROW_VERSIONU\" =  \'System.Byte[]\' )";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "将";
            // 
            // txtAppendToEnd
            // 
            this.txtAppendToEnd.Location = new System.Drawing.Point(1128, 88);
            this.txtAppendToEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAppendToEnd.Name = "txtAppendToEnd";
            this.txtAppendToEnd.Size = new System.Drawing.Size(148, 25);
            this.txtAppendToEnd.TabIndex = 30;
            this.txtAppendToEnd.Text = "--";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(769, 168);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 38);
            this.button7.TabIndex = 34;
            this.button7.Text = "替换为";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // txtReplaceStr04
            // 
            this.txtReplaceStr04.Location = new System.Drawing.Point(857, 175);
            this.txtReplaceStr04.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReplaceStr04.Name = "txtReplaceStr04";
            this.txtReplaceStr04.Size = new System.Drawing.Size(100, 25);
            this.txtReplaceStr04.TabIndex = 33;
            this.txtReplaceStr04.Text = "where ((";
            // 
            // txtBeReplaceStr04
            // 
            this.txtBeReplaceStr04.Location = new System.Drawing.Point(481, 175);
            this.txtBeReplaceStr04.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBeReplaceStr04.Name = "txtBeReplaceStr04";
            this.txtBeReplaceStr04.Size = new System.Drawing.Size(281, 25);
            this.txtBeReplaceStr04.TabIndex = 32;
            this.txtBeReplaceStr04.Text = "where (((\"IDU\" =  SYS_GUID()) and";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "_-_带IDU条件的";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "囊括前";
            // 
            // txtConcludeBeforeRowNum
            // 
            this.txtConcludeBeforeRowNum.Location = new System.Drawing.Point(97, 382);
            this.txtConcludeBeforeRowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConcludeBeforeRowNum.Name = "txtConcludeBeforeRowNum";
            this.txtConcludeBeforeRowNum.Size = new System.Drawing.Size(53, 25);
            this.txtConcludeBeforeRowNum.TabIndex = 36;
            this.txtConcludeBeforeRowNum.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 37;
            this.label9.Text = "和囊括后";
            // 
            // txtConcludeAfterRowNum
            // 
            this.txtConcludeAfterRowNum.Location = new System.Drawing.Point(249, 380);
            this.txtConcludeAfterRowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConcludeAfterRowNum.Name = "txtConcludeAfterRowNum";
            this.txtConcludeAfterRowNum.Size = new System.Drawing.Size(53, 25);
            this.txtConcludeAfterRowNum.TabIndex = 38;
            this.txtConcludeAfterRowNum.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 39;
            this.label10.Text = "行";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(304, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "行";
            // 
            // FrmReplaceOracleSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 862);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtConcludeAfterRowNum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtConcludeBeforeRowNum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtReplaceStr04);
            this.Controls.Add(this.txtBeReplaceStr04);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAppendToEnd);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.txtReplaceStr);
            this.Controls.Add(this.txtReplacedStr02);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.txtReplaced);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.txtAppendToBefore);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtOperNotContained);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOperContent);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmReplaceOracleSql";
            this.Text = "FrmReplaceOracleSql";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtOperContent;
        private System.Windows.Forms.TextBox txtOperNotContained;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtAppendToBefore;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtReplaced;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox txtReplaceStr;
        private System.Windows.Forms.TextBox txtReplacedStr02;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAppendToEnd;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtReplaceStr04;
        private System.Windows.Forms.TextBox txtBeReplaceStr04;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConcludeBeforeRowNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtConcludeAfterRowNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}