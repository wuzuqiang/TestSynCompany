namespace ReplaceString
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
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtAppend = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtReplaced = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 190);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "将";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "替换为";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(154, 245);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
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
            this.richInput.Location = new System.Drawing.Point(351, 190);
            this.richInput.Name = "richInput";
            this.richInput.Size = new System.Drawing.Size(998, 501);
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
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOperContent
            // 
            this.txtOperContent.Location = new System.Drawing.Point(39, 565);
            this.txtOperContent.Name = "txtOperContent";
            this.txtOperContent.Size = new System.Drawing.Size(252, 25);
            this.txtOperContent.TabIndex = 8;
            // 
            // txtOperNotContained
            // 
            this.txtOperNotContained.Location = new System.Drawing.Point(39, 443);
            this.txtOperNotContained.Name = "txtOperNotContained";
            this.txtOperNotContained.Size = new System.Drawing.Size(252, 25);
            this.txtOperNotContained.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 476);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
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
            this.button4.Location = new System.Drawing.Point(39, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "将每行以|组合起来";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1059, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(339, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "UnComplete,将Oracle的sql转换为Sqlserver的sql";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1059, 50);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(339, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "通过excel数据生成insertSql语句";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(351, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(239, 31);
            this.button7.TabIndex = 15;
            this.button7.Text = "将“””号替换为空";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(351, 38);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(339, 35);
            this.button8.TabIndex = 16;
            this.button8.Text = "将“\'System.Byte[]\' ”替换为\"SYS_GUID()\"";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(351, 126);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(173, 23);
            this.button9.TabIndex = 17;
            this.button9.Text = "在每行前新增";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtAppend
            // 
            this.txtAppend.Location = new System.Drawing.Point(537, 127);
            this.txtAppend.Name = "txtAppend";
            this.txtAppend.Size = new System.Drawing.Size(100, 25);
            this.txtAppend.TabIndex = 18;
            this.txtAppend.Text = "--";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(351, 155);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(173, 23);
            this.button10.TabIndex = 19;
            this.button10.Text = "移除每行前";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(656, 129);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(173, 23);
            this.button11.TabIndex = 20;
            this.button11.Text = "新增到每行最尾端";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "将";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(379, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(282, 25);
            this.textBox3.TabIndex = 22;
            this.textBox3.Text = "2019/11/18 17:17:00这样的日期类型";
            // 
            // txtReplaced
            // 
            this.txtReplaced.Location = new System.Drawing.Point(754, 86);
            this.txtReplaced.Name = "txtReplaced";
            this.txtReplaced.Size = new System.Drawing.Size(100, 25);
            this.txtReplaced.TabIndex = 24;
            this.txtReplaced.Text = "SYSDATE";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(667, 79);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 38);
            this.button12.TabIndex = 25;
            this.button12.Text = "替换为";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // FrmReplaceOracleSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 731);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.txtReplaced);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.txtAppend);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
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
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtAppend;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtReplaced;
        private System.Windows.Forms.Button button12;
    }
}