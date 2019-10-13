namespace ReplaceString
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入字符串";
            // 
            // richInput
            // 
            this.richInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richInput.Location = new System.Drawing.Point(29, 122);
            this.richInput.Name = "richInput";
            this.richInput.Size = new System.Drawing.Size(1168, 177);
            this.richInput.TabIndex = 1;
            this.richInput.Text = "";
            // 
            // richResult
            // 
            this.richResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richResult.Location = new System.Drawing.Point(29, 333);
            this.richResult.Name = "richResult";
            this.richResult.Size = new System.Drawing.Size(1168, 236);
            this.richResult.TabIndex = 2;
            this.richResult.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "替换后，字符串";
            // 
            // btnReplace01
            // 
            this.btnReplace01.Location = new System.Drawing.Point(29, 28);
            this.btnReplace01.Name = "btnReplace01";
            this.btnReplace01.Size = new System.Drawing.Size(207, 23);
            this.btnReplace01.TabIndex = 4;
            this.btnReplace01.Text = "将字符串中的所有数字加1";
            this.btnReplace01.UseVisualStyleBackColor = true;
            this.btnReplace01.Click += new System.EventHandler(this.btnReplace01_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 28);
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
            this.label3.Location = new System.Drawing.Point(569, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "除结尾符号";
            // 
            // txtEndChar
            // 
            this.txtEndChar.Location = new System.Drawing.Point(658, 28);
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
            this.button3.Location = new System.Drawing.Point(30, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "使用普通的正则表达式";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(217, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "普通替换";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(356, 67);
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
            this.cbxWordUper.Location = new System.Drawing.Point(438, 71);
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
            this.button7.Location = new System.Drawing.Point(1110, 68);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 18;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 601);
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
    }
}

