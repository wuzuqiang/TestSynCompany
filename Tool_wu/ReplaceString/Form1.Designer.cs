﻿namespace ReplaceString
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.richInput = new System.Windows.Forms.RichTextBox();
			this.richResult = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnReplace01 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEndChar = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.cbxWordUper = new System.Windows.Forms.CheckBox();
			this.txtEncountSymbol = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.txtAddedContent = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCurrentIndex = new System.Windows.Forms.TextBox();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.cbkToUper = new System.Windows.Forms.CheckBox();
			this.button15 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 197);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入字符串";
			// 
			// richInput
			// 
			this.richInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richInput.Location = new System.Drawing.Point(29, 218);
			this.richInput.Name = "richInput";
			this.richInput.Size = new System.Drawing.Size(1414, 177);
			this.richInput.TabIndex = 1;
			this.richInput.Text = "";
			this.richInput.Click += new System.EventHandler(this.richInput_Click);
			// 
			// richResult
			// 
			this.richResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richResult.Location = new System.Drawing.Point(29, 451);
			this.richResult.Name = "richResult";
			this.richResult.Size = new System.Drawing.Size(1414, 242);
			this.richResult.TabIndex = 2;
			this.richResult.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 425);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "替换后，字符串";
			// 
			// btnReplace01
			// 
			this.btnReplace01.Location = new System.Drawing.Point(759, 122);
			this.btnReplace01.Name = "btnReplace01";
			this.btnReplace01.Size = new System.Drawing.Size(207, 23);
			this.btnReplace01.TabIndex = 4;
			this.btnReplace01.Text = "将字符串中的所有数字加1";
			this.btnReplace01.UseVisualStyleBackColor = true;
			this.btnReplace01.Click += new System.EventHandler(this.btnReplace01_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(761, 167);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(225, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "将每行的等号左右两边内容互换";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(992, 171);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "除结尾符号";
			// 
			// txtEndChar
			// 
			this.txtEndChar.Location = new System.Drawing.Point(1081, 167);
			this.txtEndChar.Name = "txtEndChar";
			this.txtEndChar.Size = new System.Drawing.Size(100, 25);
			this.txtEndChar.TabIndex = 7;
			this.txtEndChar.Text = ";";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(819, 28);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(207, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "将函数中的变量都去除类型";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(434, 148);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(148, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "使用普通的正则表达式";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(207, 68);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(106, 37);
			this.button4.TabIndex = 10;
			this.button4.Text = "普通替换";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(984, 107);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 11;
			this.button5.Text = "互换字母大小写";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// cbxWordUper
			// 
			this.cbxWordUper.AutoSize = true;
			this.cbxWordUper.Location = new System.Drawing.Point(1066, 111);
			this.cbxWordUper.Name = "cbxWordUper";
			this.cbxWordUper.Size = new System.Drawing.Size(74, 19);
			this.cbxWordUper.TabIndex = 12;
			this.cbxWordUper.Text = "换大写";
			this.cbxWordUper.UseVisualStyleBackColor = true;
			// 
			// txtEncountSymbol
			// 
			this.txtEncountSymbol.Location = new System.Drawing.Point(683, 67);
			this.txtEncountSymbol.Name = "txtEncountSymbol";
			this.txtEncountSymbol.Size = new System.Drawing.Size(100, 25);
			this.txtEncountSymbol.TabIndex = 14;
			this.txtEncountSymbol.Text = ";";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(537, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(127, 15);
			this.label4.TabIndex = 13;
			this.label4.Text = "如果行中存在符号";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(789, 67);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(89, 23);
			this.button6.TabIndex = 15;
			this.button6.Text = "则加内容";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// txtAddedContent
			// 
			this.txtAddedContent.Location = new System.Drawing.Point(886, 66);
			this.txtAddedContent.Name = "txtAddedContent";
			this.txtAddedContent.Size = new System.Drawing.Size(100, 25);
			this.txtAddedContent.TabIndex = 16;
			this.txtAddedContent.Text = ";";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(992, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 15);
			this.label5.TabIndex = 17;
			this.label5.Text = "到其之前";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(30, 69);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(132, 36);
			this.button7.TabIndex = 18;
			this.button7.Text = "调整oracle的Sql";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(1368, 27);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(98, 23);
			this.button8.TabIndex = 19;
			this.button8.Text = "编码";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(156, 148);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(80, 23);
			this.button9.TabIndex = 20;
			this.button9.Text = "压缩";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(1091, 66);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(124, 23);
			this.button11.TabIndex = 22;
			this.button11.Text = "测试校验码";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(1041, 24);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(255, 23);
			this.button12.TabIndex = 23;
			this.button12.Text = "查找逗号分隔的出现两次的内容";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(27, 154);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(93, 23);
			this.button10.TabIndex = 24;
			this.button10.Text = "只压缩行";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click_1);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1058, 713);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 15);
			this.label6.TabIndex = 25;
			this.label6.Text = "当前行列：";
			// 
			// txtCurrentIndex
			// 
			this.txtCurrentIndex.Location = new System.Drawing.Point(1146, 710);
			this.txtCurrentIndex.Name = "txtCurrentIndex";
			this.txtCurrentIndex.Size = new System.Drawing.Size(100, 25);
			this.txtCurrentIndex.TabIndex = 26;
			this.txtCurrentIndex.Text = "0";
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(27, 111);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(93, 34);
			this.button13.TabIndex = 27;
			this.button13.Text = "生成GUID";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(27, 30);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(111, 23);
			this.button14.TabIndex = 28;
			this.button14.Text = "首字母大小写";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// cbkToUper
			// 
			this.cbkToUper.AutoSize = true;
			this.cbkToUper.Location = new System.Drawing.Point(145, 30);
			this.cbkToUper.Name = "cbkToUper";
			this.cbkToUper.Size = new System.Drawing.Size(59, 19);
			this.cbkToUper.TabIndex = 29;
			this.cbkToUper.Text = "大写";
			this.cbkToUper.UseVisualStyleBackColor = true;
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(1330, 65);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(136, 23);
			this.button15.TabIndex = 30;
			this.button15.Text = "THOK计算校验码";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new System.EventHandler(this.button15_Click);
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(557, 12);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(141, 24);
			this.button16.TabIndex = 31;
			this.button16.Text = "初始化SQLite";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new System.EventHandler(this.button16_Click);
			// 
			// button17
			// 
			this.button17.Location = new System.Drawing.Point(265, 13);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(144, 23);
			this.button17.TabIndex = 32;
			this.button17.Text = "压缩";
			this.button17.UseVisualStyleBackColor = true;
			// 
			// button18
			// 
			this.button18.Location = new System.Drawing.Point(1339, 111);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(104, 34);
			this.button18.TabIndex = 33;
			this.button18.Text = "转换成各类数据";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new System.EventHandler(this.button18_Click);
			// 
			// button19
			// 
			this.button19.Location = new System.Drawing.Point(30, 0);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(57, 24);
			this.button19.TabIndex = 34;
			this.button19.Text = "Test";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new System.EventHandler(this.button19_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1491, 740);
			this.Controls.Add(this.button19);
			this.Controls.Add(this.button18);
			this.Controls.Add(this.button17);
			this.Controls.Add(this.button16);
			this.Controls.Add(this.button15);
			this.Controls.Add(this.cbkToUper);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.txtCurrentIndex);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtAddedContent);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.txtEncountSymbol);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbxWordUper);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtEndChar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnReplace01);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.richResult);
			this.Controls.Add(this.richInput);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richInput;
        private System.Windows.Forms.RichTextBox richResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReplace01;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndChar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox cbxWordUper;
        private System.Windows.Forms.TextBox txtEncountSymbol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtAddedContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentIndex;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.CheckBox cbkToUper;
        private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.Button button17;
		private System.Windows.Forms.Button button18;
		private System.Windows.Forms.Button button19;
	}
}

