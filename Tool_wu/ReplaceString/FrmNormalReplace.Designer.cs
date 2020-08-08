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
			this.richInput = new System.Windows.Forms.RichTextBox();
			this.btnTransferParticularChar = new System.Windows.Forms.Button();
			this.richOriginContent = new System.Windows.Forms.RichTextBox();
			this.btnReplaceCodeType = new System.Windows.Forms.Button();
			this.txtCodeTypeNames = new System.Windows.Forms.RichTextBox();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.btnReplace = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtFinalStr = new System.Windows.Forms.TextBox();
			this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
			this.txtOriginStr = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.chkContainThatSuffixStr = new System.Windows.Forms.CheckBox();
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow = new System.Windows.Forms.Button();
			this.chkContainThatPreviousWords = new System.Windows.Forms.CheckBox();
			this.btnAddBeforeExceptEmptyR = new System.Windows.Forms.Button();
			this.txtAppendToBefore = new System.Windows.Forms.TextBox();
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow = new System.Windows.Forms.Button();
			this.btnAddEverRowSuffixStrExceptEmptyRow = new System.Windows.Forms.Button();
			this.txtAppendToEnd = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSaveByContainAnyStr = new System.Windows.Forms.Button();
			this.txtOperContent = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btnSaveByNotContainAnyStr = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.txtOperNotContained = new System.Windows.Forms.TextBox();
			this.txtConcludeAfterRowNum = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtConcludeBeforeRowNum = new System.Windows.Forms.TextBox();
			this.btnCombineAllLineToOneLine = new System.Windows.Forms.Button();
			this.btnSixSpaceToBreakLine = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLinkStr = new System.Windows.Forms.TextBox();
			this.btnSortAll = new System.Windows.Forms.Button();
			this.txtContentLength = new System.Windows.Forms.TextBox();
			this.cbxOrderType = new System.Windows.Forms.CheckBox();
			this.btnGetAllTextLength = new System.Windows.Forms.Button();
			this.tabControl3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// richInput
			// 
			this.richInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richInput.Location = new System.Drawing.Point(367, 74);
			this.richInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richInput.Name = "richInput";
			this.richInput.Size = new System.Drawing.Size(1169, 794);
			this.richInput.TabIndex = 5;
			this.richInput.Text = "";
			this.richInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richInput_KeyDown);
			// 
			// btnTransferParticularChar
			// 
			this.btnTransferParticularChar.Location = new System.Drawing.Point(8, 5);
			this.btnTransferParticularChar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnTransferParticularChar.Name = "btnTransferParticularChar";
			this.btnTransferParticularChar.Size = new System.Drawing.Size(176, 40);
			this.btnTransferParticularChar.TabIndex = 16;
			this.btnTransferParticularChar.Text = "反转义双引号右下划线";
			this.btnTransferParticularChar.UseVisualStyleBackColor = true;
			this.btnTransferParticularChar.Click += new System.EventHandler(this.btnTransferParticularChar_Click);
			// 
			// richOriginContent
			// 
			this.richOriginContent.Location = new System.Drawing.Point(1179, 8);
			this.richOriginContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richOriginContent.Name = "richOriginContent";
			this.richOriginContent.Size = new System.Drawing.Size(333, 62);
			this.richOriginContent.TabIndex = 20;
			this.richOriginContent.Text = "";
			// 
			// btnReplaceCodeType
			// 
			this.btnReplaceCodeType.Location = new System.Drawing.Point(8, 49);
			this.btnReplaceCodeType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnReplaceCodeType.Name = "btnReplaceCodeType";
			this.btnReplaceCodeType.Size = new System.Drawing.Size(305, 41);
			this.btnReplaceCodeType.TabIndex = 22;
			this.btnReplaceCodeType.Text = "将如下这些C#变量类型和其后的空格替换为空";
			this.btnReplaceCodeType.UseVisualStyleBackColor = true;
			this.btnReplaceCodeType.Click += new System.EventHandler(this.btnReplaceCodeType_Click);
			// 
			// txtCodeTypeNames
			// 
			this.txtCodeTypeNames.Location = new System.Drawing.Point(8, 96);
			this.txtCodeTypeNames.Margin = new System.Windows.Forms.Padding(4);
			this.txtCodeTypeNames.Name = "txtCodeTypeNames";
			this.txtCodeTypeNames.Size = new System.Drawing.Size(291, 61);
			this.txtCodeTypeNames.TabIndex = 23;
			this.txtCodeTypeNames.Text = "string,int,decimal,bool,Guid,DateTime";
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tabPage5);
			this.tabControl3.Controls.Add(this.tabPage6);
			this.tabControl3.Location = new System.Drawing.Point(10, 74);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(333, 371);
			this.tabControl3.TabIndex = 51;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.btnSortAll);
			this.tabPage5.Controls.Add(this.txtContentLength);
			this.tabPage5.Controls.Add(this.cbxOrderType);
			this.tabPage5.Controls.Add(this.btnGetAllTextLength);
			this.tabPage5.Controls.Add(this.btnCombineAllLineToOneLine);
			this.tabPage5.Controls.Add(this.btnSixSpaceToBreakLine);
			this.tabPage5.Controls.Add(this.label3);
			this.tabPage5.Controls.Add(this.txtLinkStr);
			this.tabPage5.Controls.Add(this.textBox8);
			this.tabPage5.Controls.Add(this.checkBox1);
			this.tabPage5.Controls.Add(this.textBox9);
			this.tabPage5.Controls.Add(this.label15);
			this.tabPage5.Controls.Add(this.label16);
			this.tabPage5.Controls.Add(this.btnReplace);
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(325, 342);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "替换";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(57, 60);
			this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(252, 25);
			this.textBox8.TabIndex = 2;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(8, 123);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 19);
			this.checkBox1.TabIndex = 47;
			this.checkBox1.Text = "忽略大小写";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(57, 5);
			this.textBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(252, 25);
			this.textBox9.TabIndex = 0;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(2, 5);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(22, 15);
			this.label15.TabIndex = 1;
			this.label15.Text = "将";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(2, 60);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(52, 15);
			this.label16.TabIndex = 3;
			this.label16.Text = "替换为";
			// 
			// btnReplace
			// 
			this.btnReplace.Location = new System.Drawing.Point(167, 120);
			this.btnReplace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(75, 22);
			this.btnReplace.TabIndex = 4;
			this.btnReplace.Text = "开始替换";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// tabPage6
			// 
			this.tabPage6.AutoScroll = true;
			this.tabPage6.Controls.Add(this.btnTransferParticularChar);
			this.tabPage6.Controls.Add(this.txtCodeTypeNames);
			this.tabPage6.Controls.Add(this.btnReplaceCodeType);
			this.tabPage6.Location = new System.Drawing.Point(4, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(325, 342);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "常用转换";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Location = new System.Drawing.Point(10, 216);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(333, 229);
			this.tabControl2.TabIndex = 50;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.txtFinalStr);
			this.tabPage3.Controls.Add(this.chkIgnoreCase);
			this.tabPage3.Controls.Add(this.txtOriginStr);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(325, 200);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "替换";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// txtFinalStr
			// 
			this.txtFinalStr.Location = new System.Drawing.Point(57, 60);
			this.txtFinalStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFinalStr.Name = "txtFinalStr";
			this.txtFinalStr.Size = new System.Drawing.Size(252, 25);
			this.txtFinalStr.TabIndex = 2;
			// 
			// chkIgnoreCase
			// 
			this.chkIgnoreCase.AutoSize = true;
			this.chkIgnoreCase.Location = new System.Drawing.Point(8, 123);
			this.chkIgnoreCase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkIgnoreCase.Name = "chkIgnoreCase";
			this.chkIgnoreCase.Size = new System.Drawing.Size(104, 19);
			this.chkIgnoreCase.TabIndex = 47;
			this.chkIgnoreCase.Text = "忽略大小写";
			this.chkIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// txtOriginStr
			// 
			this.txtOriginStr.Location = new System.Drawing.Point(57, 5);
			this.txtOriginStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtOriginStr.Name = "txtOriginStr";
			this.txtOriginStr.Size = new System.Drawing.Size(252, 25);
			this.txtOriginStr.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(22, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "将";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "替换为";
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(325, 200);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(10, 497);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(333, 397);
			this.tabControl1.TabIndex = 49;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.chkContainThatSuffixStr);
			this.tabPage1.Controls.Add(this.btnRemoveEveryRowSuffixStrExeceptEmptyRow);
			this.tabPage1.Controls.Add(this.chkContainThatPreviousWords);
			this.tabPage1.Controls.Add(this.btnAddBeforeExceptEmptyR);
			this.tabPage1.Controls.Add(this.txtAppendToBefore);
			this.tabPage1.Controls.Add(this.btnRemoveEveryRowPreviousStrExeceptEmptyRow);
			this.tabPage1.Controls.Add(this.btnAddEverRowSuffixStrExceptEmptyRow);
			this.tabPage1.Controls.Add(this.txtAppendToEnd);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(325, 368);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "增加或者删除每行前或后文本";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// chkContainThatSuffixStr
			// 
			this.chkContainThatSuffixStr.AutoSize = true;
			this.chkContainThatSuffixStr.Checked = true;
			this.chkContainThatSuffixStr.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkContainThatSuffixStr.Location = new System.Drawing.Point(199, 176);
			this.chkContainThatSuffixStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkContainThatSuffixStr.Name = "chkContainThatSuffixStr";
			this.chkContainThatSuffixStr.Size = new System.Drawing.Size(119, 19);
			this.chkContainThatSuffixStr.TabIndex = 33;
			this.chkContainThatSuffixStr.Text = "连这些也删除";
			this.chkContainThatSuffixStr.UseVisualStyleBackColor = true;
			// 
			// btnRemoveEveryRowSuffixStrExeceptEmptyRow
			// 
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.Location = new System.Drawing.Point(3, 169);
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.Name = "btnRemoveEveryRowSuffixStrExeceptEmptyRow";
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.Size = new System.Drawing.Size(189, 30);
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.TabIndex = 32;
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.Text = "移除每行后(空行除外)";
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.UseVisualStyleBackColor = true;
			this.btnRemoveEveryRowSuffixStrExeceptEmptyRow.Click += new System.EventHandler(this.btnRemoveEveryRowSuffixStrExeceptEmptyRow_Click);
			// 
			// chkContainThatPreviousWords
			// 
			this.chkContainThatPreviousWords.AutoSize = true;
			this.chkContainThatPreviousWords.Checked = true;
			this.chkContainThatPreviousWords.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkContainThatPreviousWords.Location = new System.Drawing.Point(198, 55);
			this.chkContainThatPreviousWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkContainThatPreviousWords.Name = "chkContainThatPreviousWords";
			this.chkContainThatPreviousWords.Size = new System.Drawing.Size(119, 19);
			this.chkContainThatPreviousWords.TabIndex = 31;
			this.chkContainThatPreviousWords.Text = "连这些也删除";
			this.chkContainThatPreviousWords.UseVisualStyleBackColor = true;
			// 
			// btnAddBeforeExceptEmptyR
			// 
			this.btnAddBeforeExceptEmptyR.Location = new System.Drawing.Point(3, 5);
			this.btnAddBeforeExceptEmptyR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAddBeforeExceptEmptyR.Name = "btnAddBeforeExceptEmptyR";
			this.btnAddBeforeExceptEmptyR.Size = new System.Drawing.Size(201, 40);
			this.btnAddBeforeExceptEmptyR.TabIndex = 17;
			this.btnAddBeforeExceptEmptyR.Text = "在每行前新增(空行除外)";
			this.btnAddBeforeExceptEmptyR.UseVisualStyleBackColor = true;
			this.btnAddBeforeExceptEmptyR.Click += new System.EventHandler(this.btnAddBeforeExceptEmptyR_Click);
			// 
			// txtAppendToBefore
			// 
			this.txtAppendToBefore.Location = new System.Drawing.Point(6, 85);
			this.txtAppendToBefore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtAppendToBefore.Name = "txtAppendToBefore";
			this.txtAppendToBefore.Size = new System.Drawing.Size(148, 25);
			this.txtAppendToBefore.TabIndex = 18;
			this.txtAppendToBefore.Text = "--";
			// 
			// btnRemoveEveryRowPreviousStrExeceptEmptyRow
			// 
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.Location = new System.Drawing.Point(3, 52);
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.Name = "btnRemoveEveryRowPreviousStrExeceptEmptyRow";
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.Size = new System.Drawing.Size(189, 29);
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.TabIndex = 19;
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.Text = "移除每行前(空行除外)";
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.UseVisualStyleBackColor = true;
			this.btnRemoveEveryRowPreviousStrExeceptEmptyRow.Click += new System.EventHandler(this.btnRemoveEveryRowPreviousStrExeceptEmptyRow_Click);
			// 
			// btnAddEverRowSuffixStrExceptEmptyRow
			// 
			this.btnAddEverRowSuffixStrExceptEmptyRow.Location = new System.Drawing.Point(3, 129);
			this.btnAddEverRowSuffixStrExceptEmptyRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAddEverRowSuffixStrExceptEmptyRow.Name = "btnAddEverRowSuffixStrExceptEmptyRow";
			this.btnAddEverRowSuffixStrExceptEmptyRow.Size = new System.Drawing.Size(217, 35);
			this.btnAddEverRowSuffixStrExceptEmptyRow.TabIndex = 20;
			this.btnAddEverRowSuffixStrExceptEmptyRow.Text = "新增到每行最尾端(空行除外)";
			this.btnAddEverRowSuffixStrExceptEmptyRow.UseVisualStyleBackColor = true;
			this.btnAddEverRowSuffixStrExceptEmptyRow.Click += new System.EventHandler(this.btnAddEverRowSuffixStrExceptEmptyRow_Click);
			// 
			// txtAppendToEnd
			// 
			this.txtAppendToEnd.Location = new System.Drawing.Point(3, 211);
			this.txtAppendToEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtAppendToEnd.Name = "txtAppendToEnd";
			this.txtAppendToEnd.Size = new System.Drawing.Size(148, 25);
			this.txtAppendToEnd.TabIndex = 30;
			this.txtAppendToEnd.Text = "--";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.btnSaveByContainAnyStr);
			this.tabPage2.Controls.Add(this.txtOperContent);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.btnSaveByNotContainAnyStr);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.txtOperNotContained);
			this.tabPage2.Controls.Add(this.txtConcludeAfterRowNum);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.txtConcludeBeforeRowNum);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(325, 368);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "保留或不保留哪些行";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(270, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "某行不带这些内容则保留，以|符号组合";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 161);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(255, 15);
			this.label5.TabIndex = 6;
			this.label5.Text = "某行带这些内容则保留，以|符号组合";
			// 
			// btnSaveByContainAnyStr
			// 
			this.btnSaveByContainAnyStr.Location = new System.Drawing.Point(9, 219);
			this.btnSaveByContainAnyStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSaveByContainAnyStr.Name = "btnSaveByContainAnyStr";
			this.btnSaveByContainAnyStr.Size = new System.Drawing.Size(100, 22);
			this.btnSaveByContainAnyStr.TabIndex = 7;
			this.btnSaveByContainAnyStr.Text = "开始";
			this.btnSaveByContainAnyStr.UseVisualStyleBackColor = true;
			this.btnSaveByContainAnyStr.Click += new System.EventHandler(this.btnSaveByContainAnyStr_Click);
			// 
			// txtOperContent
			// 
			this.txtOperContent.Location = new System.Drawing.Point(9, 186);
			this.txtOperContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtOperContent.Name = "txtOperContent";
			this.txtOperContent.Size = new System.Drawing.Size(252, 25);
			this.txtOperContent.TabIndex = 8;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(274, 7);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(22, 15);
			this.label11.TabIndex = 40;
			this.label11.Text = "行";
			// 
			// btnSaveByNotContainAnyStr
			// 
			this.btnSaveByNotContainAnyStr.Location = new System.Drawing.Point(9, 97);
			this.btnSaveByNotContainAnyStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSaveByNotContainAnyStr.Name = "btnSaveByNotContainAnyStr";
			this.btnSaveByNotContainAnyStr.Size = new System.Drawing.Size(100, 22);
			this.btnSaveByNotContainAnyStr.TabIndex = 10;
			this.btnSaveByNotContainAnyStr.Text = "开始整理";
			this.btnSaveByNotContainAnyStr.UseVisualStyleBackColor = true;
			this.btnSaveByNotContainAnyStr.Click += new System.EventHandler(this.btnSaveByNotContainAnyStr_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(122, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(22, 15);
			this.label10.TabIndex = 39;
			this.label10.Text = "行";
			// 
			// txtOperNotContained
			// 
			this.txtOperNotContained.Location = new System.Drawing.Point(9, 63);
			this.txtOperNotContained.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtOperNotContained.Name = "txtOperNotContained";
			this.txtOperNotContained.Size = new System.Drawing.Size(252, 25);
			this.txtOperNotContained.TabIndex = 11;
			this.txtOperNotContained.Text = "1|2|4";
			// 
			// txtConcludeAfterRowNum
			// 
			this.txtConcludeAfterRowNum.Location = new System.Drawing.Point(219, 1);
			this.txtConcludeAfterRowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtConcludeAfterRowNum.Name = "txtConcludeAfterRowNum";
			this.txtConcludeAfterRowNum.Size = new System.Drawing.Size(53, 25);
			this.txtConcludeAfterRowNum.TabIndex = 38;
			this.txtConcludeAfterRowNum.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 6);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 15);
			this.label8.TabIndex = 35;
			this.label8.Text = "囊括前";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(149, 7);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 15);
			this.label9.TabIndex = 37;
			this.label9.Text = "和囊括后";
			// 
			// txtConcludeBeforeRowNum
			// 
			this.txtConcludeBeforeRowNum.Location = new System.Drawing.Point(67, 3);
			this.txtConcludeBeforeRowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtConcludeBeforeRowNum.Name = "txtConcludeBeforeRowNum";
			this.txtConcludeBeforeRowNum.Size = new System.Drawing.Size(53, 25);
			this.txtConcludeBeforeRowNum.TabIndex = 36;
			this.txtConcludeBeforeRowNum.Text = "0";
			// 
			// btnCombineAllLineToOneLine
			// 
			this.btnCombineAllLineToOneLine.Location = new System.Drawing.Point(8, 164);
			this.btnCombineAllLineToOneLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCombineAllLineToOneLine.Name = "btnCombineAllLineToOneLine";
			this.btnCombineAllLineToOneLine.Size = new System.Drawing.Size(129, 48);
			this.btnCombineAllLineToOneLine.TabIndex = 48;
			this.btnCombineAllLineToOneLine.Text = "将所有内容整合成一行，中间以";
			this.btnCombineAllLineToOneLine.UseVisualStyleBackColor = true;
			this.btnCombineAllLineToOneLine.Click += new System.EventHandler(this.btnCombineAllLineToOneLine_Click);
			// 
			// btnSixSpaceToBreakLine
			// 
			this.btnSixSpaceToBreakLine.Location = new System.Drawing.Point(10, 219);
			this.btnSixSpaceToBreakLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSixSpaceToBreakLine.Name = "btnSixSpaceToBreakLine";
			this.btnSixSpaceToBreakLine.Size = new System.Drawing.Size(217, 29);
			this.btnSixSpaceToBreakLine.TabIndex = 49;
			this.btnSixSpaceToBreakLine.Text = "将六个空格替换为换行符号";
			this.btnSixSpaceToBreakLine.UseVisualStyleBackColor = true;
			this.btnSixSpaceToBreakLine.Click += new System.EventHandler(this.btnSixSpaceToBreakLine_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(220, 181);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 15);
			this.label3.TabIndex = 51;
			this.label3.Text = "连接";
			// 
			// txtLinkStr
			// 
			this.txtLinkStr.Location = new System.Drawing.Point(143, 178);
			this.txtLinkStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtLinkStr.Name = "txtLinkStr";
			this.txtLinkStr.Size = new System.Drawing.Size(70, 25);
			this.txtLinkStr.TabIndex = 50;
			this.txtLinkStr.Text = "|";
			// 
			// btnSortAll
			// 
			this.btnSortAll.Location = new System.Drawing.Point(145, 265);
			this.btnSortAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSortAll.Name = "btnSortAll";
			this.btnSortAll.Size = new System.Drawing.Size(112, 40);
			this.btnSortAll.TabIndex = 54;
			this.btnSortAll.Text = "排序每行";
			this.btnSortAll.UseVisualStyleBackColor = true;
			this.btnSortAll.Click += new System.EventHandler(this.btnSortAll_Click);
			// 
			// txtContentLength
			// 
			this.txtContentLength.Location = new System.Drawing.Point(174, 310);
			this.txtContentLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtContentLength.Name = "txtContentLength";
			this.txtContentLength.Size = new System.Drawing.Size(100, 25);
			this.txtContentLength.TabIndex = 53;
			// 
			// cbxOrderType
			// 
			this.cbxOrderType.AutoSize = true;
			this.cbxOrderType.Location = new System.Drawing.Point(20, 277);
			this.cbxOrderType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cbxOrderType.Name = "cbxOrderType";
			this.cbxOrderType.Size = new System.Drawing.Size(119, 19);
			this.cbxOrderType.TabIndex = 55;
			this.cbxOrderType.Text = "按首字母拼音";
			this.cbxOrderType.UseVisualStyleBackColor = true;
			// 
			// btnGetAllTextLength
			// 
			this.btnGetAllTextLength.Location = new System.Drawing.Point(8, 309);
			this.btnGetAllTextLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnGetAllTextLength.Name = "btnGetAllTextLength";
			this.btnGetAllTextLength.Size = new System.Drawing.Size(160, 28);
			this.btnGetAllTextLength.TabIndex = 52;
			this.btnGetAllTextLength.Text = "获取输入框文字总长度";
			this.btnGetAllTextLength.UseVisualStyleBackColor = true;
			this.btnGetAllTextLength.Click += new System.EventHandler(this.btnGetAllTextLength_Click);
			// 
			// FrmNormalReplace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1567, 899);
			this.Controls.Add(this.tabControl3);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.richOriginContent);
			this.Controls.Add(this.richInput);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FrmNormalReplace";
			this.Text = "FrmNormalReplace";
			this.tabControl3.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richInput;
        private System.Windows.Forms.Button btnTransferParticularChar;
        private System.Windows.Forms.RichTextBox richOriginContent;
        private System.Windows.Forms.Button btnReplaceCodeType;
        private System.Windows.Forms.RichTextBox txtCodeTypeNames;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox txtFinalStr;
		private System.Windows.Forms.CheckBox chkIgnoreCase;
		private System.Windows.Forms.TextBox txtOriginStr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.CheckBox chkContainThatSuffixStr;
		private System.Windows.Forms.Button btnRemoveEveryRowSuffixStrExeceptEmptyRow;
		private System.Windows.Forms.CheckBox chkContainThatPreviousWords;
		private System.Windows.Forms.Button btnAddBeforeExceptEmptyR;
		private System.Windows.Forms.TextBox txtAppendToBefore;
		private System.Windows.Forms.Button btnRemoveEveryRowPreviousStrExeceptEmptyRow;
		private System.Windows.Forms.Button btnAddEverRowSuffixStrExceptEmptyRow;
		private System.Windows.Forms.TextBox txtAppendToEnd;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnSaveByContainAnyStr;
		private System.Windows.Forms.TextBox txtOperContent;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnSaveByNotContainAnyStr;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtOperNotContained;
		private System.Windows.Forms.TextBox txtConcludeAfterRowNum;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtConcludeBeforeRowNum;
		private System.Windows.Forms.Button btnCombineAllLineToOneLine;
		private System.Windows.Forms.Button btnSixSpaceToBreakLine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLinkStr;
		private System.Windows.Forms.Button btnSortAll;
		private System.Windows.Forms.TextBox txtContentLength;
		private System.Windows.Forms.CheckBox cbxOrderType;
		private System.Windows.Forms.Button btnGetAllTextLength;
	}
}