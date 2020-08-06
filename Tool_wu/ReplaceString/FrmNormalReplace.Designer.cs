namespace ReplaceString
{
    partial class FrmNormalReplace
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtContentLength = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtFlagString = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cbxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.chkContainThatWords = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.cbxOrderType = new System.Windows.Forms.CheckBox();
            this.richOriginContent = new System.Windows.Forms.RichTextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.txtCodeTypeNames = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 155);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 21);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "将";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "替换为";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(55, 199);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 21);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 258);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 18);
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
            this.richInput.Location = new System.Drawing.Point(244, 60);
            this.richInput.Margin = new System.Windows.Forms.Padding(2);
            this.richInput.Name = "richInput";
            this.richInput.Size = new System.Drawing.Size(909, 635);
            this.richInput.TabIndex = 5;
            this.richInput.Text = "";
            this.richInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richInput_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 60);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 18);
            this.button2.TabIndex = 6;
            this.button2.Text = "求文字长度";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtContentLength
            // 
            this.txtContentLength.Location = new System.Drawing.Point(97, 58);
            this.txtContentLength.Margin = new System.Windows.Forms.Padding(2);
            this.txtContentLength.Name = "txtContentLength";
            this.txtContentLength.Size = new System.Drawing.Size(76, 21);
            this.txtContentLength.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(477, 10);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(223, 21);
            this.button3.TabIndex = 8;
            this.button3.Text = "将每行中这些字符前的字符都删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtFlagString
            // 
            this.txtFlagString.Location = new System.Drawing.Point(244, 23);
            this.txtFlagString.Margin = new System.Windows.Forms.Padding(2);
            this.txtFlagString.Name = "txtFlagString";
            this.txtFlagString.Size = new System.Drawing.Size(221, 21);
            this.txtFlagString.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 306);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 42);
            this.button4.TabIndex = 10;
            this.button4.Text = "将所有内容整合成一行，中间以Tab键盘分隔";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbxIgnoreCase
            // 
            this.cbxIgnoreCase.AutoSize = true;
            this.cbxIgnoreCase.Location = new System.Drawing.Point(26, 258);
            this.cbxIgnoreCase.Margin = new System.Windows.Forms.Padding(2);
            this.cbxIgnoreCase.Name = "cbxIgnoreCase";
            this.cbxIgnoreCase.Size = new System.Drawing.Size(84, 16);
            this.cbxIgnoreCase.TabIndex = 11;
            this.cbxIgnoreCase.Text = "忽略大小写";
            this.cbxIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // chkContainThatWords
            // 
            this.chkContainThatWords.AutoSize = true;
            this.chkContainThatWords.Location = new System.Drawing.Point(726, 14);
            this.chkContainThatWords.Margin = new System.Windows.Forms.Padding(2);
            this.chkContainThatWords.Name = "chkContainThatWords";
            this.chkContainThatWords.Size = new System.Drawing.Size(120, 16);
            this.chkContainThatWords.TabIndex = 12;
            this.chkContainThatWords.Text = "连这些字符也删除";
            this.chkContainThatWords.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(477, 34);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(223, 21);
            this.button5.TabIndex = 13;
            this.button5.Text = "将每行中这些字符后的字符都删除";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(18, 366);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 32);
            this.button6.TabIndex = 14;
            this.button6.Text = "raw转guid";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(18, 403);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(84, 32);
            this.button7.TabIndex = 15;
            this.button7.Text = "guid转raw";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(18, 448);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(132, 32);
            this.button8.TabIndex = 16;
            this.button8.Text = "反转义双引号右下划线";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(9, 91);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(163, 23);
            this.button9.TabIndex = 17;
            this.button9.Text = "将六个空格替换为换行符号";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(110, 490);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(84, 32);
            this.button10.TabIndex = 18;
            this.button10.Text = "排序每行";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // cbxOrderType
            // 
            this.cbxOrderType.AutoSize = true;
            this.cbxOrderType.Location = new System.Drawing.Point(11, 499);
            this.cbxOrderType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxOrderType.Name = "cbxOrderType";
            this.cbxOrderType.Size = new System.Drawing.Size(96, 16);
            this.cbxOrderType.TabIndex = 19;
            this.cbxOrderType.Text = "按首字母拼音";
            this.cbxOrderType.UseVisualStyleBackColor = true;
            // 
            // richOriginContent
            // 
            this.richOriginContent.Location = new System.Drawing.Point(884, 6);
            this.richOriginContent.Margin = new System.Windows.Forms.Padding(2);
            this.richOriginContent.Name = "richOriginContent";
            this.richOriginContent.Size = new System.Drawing.Size(251, 50);
            this.richOriginContent.TabIndex = 20;
            this.richOriginContent.Text = "";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(9, 567);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(229, 33);
            this.button11.TabIndex = 22;
            this.button11.Text = "将如下这些C#变量类型和其后的空格替换为空";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // txtCodeTypeNames
            // 
            this.txtCodeTypeNames.Location = new System.Drawing.Point(9, 605);
            this.txtCodeTypeNames.Name = "txtCodeTypeNames";
            this.txtCodeTypeNames.Size = new System.Drawing.Size(218, 55);
            this.txtCodeTypeNames.TabIndex = 23;
            this.txtCodeTypeNames.Text = "string,int,decimal,bool,Guid,DateTime";
            // 
            // FrmNormalReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 719);
            this.Controls.Add(this.txtCodeTypeNames);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.richOriginContent);
            this.Controls.Add(this.cbxOrderType);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.chkContainThatWords);
            this.Controls.Add(this.cbxIgnoreCase);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtFlagString);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtContentLength);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmNormalReplace";
            this.Text = "FrmNormalReplace";
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtContentLength;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtFlagString;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox cbxIgnoreCase;
        private System.Windows.Forms.CheckBox chkContainThatWords;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox cbxOrderType;
        private System.Windows.Forms.RichTextBox richOriginContent;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.RichTextBox txtCodeTypeNames;
    }
}