using BaseClassUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceString
{
    public partial class FrmNormalReplace : Form
    {
        public FrmNormalReplace()
        {
            InitializeComponent();
        }
        private void saveBeforeContent()
        {
            richOriginContent.Text = richInput.Text;
        }


        private void 保留使用正则表达式替换某些内容(object sender, EventArgs e)
        {	//主要是为了保留使用正则表达式替换某些内容
            //saveBeforeContent();
            ////将每行中某字符前的字符都删除
            //string input = richInput.Text;
            //StringBuilder sbOutput = new StringBuilder();
            //foreach (string str in input.Split('\n'))
            //{
            //    //sbOutput.AppendLine((new Regex(@".+"+txtFlagString.Text+"").Replace(str, "")));
            //    //如果内容中包含*号等转义字符，上面就会出错了。
            //    string strTemp = txtFlagString.Text;
            //    foreach (string strSplit in strNeedTransferInReg.Split(','))
            //    {
            //        if (!string.IsNullOrEmpty(strSplit))
            //        {
            //            strTemp = strTemp.Replace(strSplit.Trim(), $"\\{strSplit.Trim()}");
            //        }
            //    }
            //    if (chkContainThatWords.Checked)
            //    {
            //        sbOutput.AppendLine((new Regex(@".*" + strTemp + "").Replace(str, "")));
            //    }
            //    else
            //    {
            //        string pattern = @".*(?=" + strTemp + ")";
            //        sbOutput.AppendLine((new Regex(pattern)).Replace(str, ""));
            //    }
            //}
            //richInput.Text = sbOutput.ToString();
        }
		public string FuncN(string input)
		{
			string output = "";
			return output;
		}
		
        private void richInput_KeyDown(object sender, KeyEventArgs e)
        {
			TestKeyDown(sender, e);
        }
        public void TestKeyDown(object sender, KeyEventArgs e)
		{

            // Ctrl + H 
            if ((Control.ModifierKeys & Keys.Control) != 0 && e.KeyCode == Keys.H)
            {
                MessageBox.Show("Ctrl + H");
            }

            // Alt + H 
            if ((Control.ModifierKeys & Keys.Alt) != 0 && e.KeyCode == Keys.H)
            {
                MessageBox.Show("Alt + H");
            }

            // Shift + H 
            if ((Control.ModifierKeys & Keys.Shift) != 0 && e.KeyCode == Keys.H)
            {
                MessageBox.Show("Shift + H");
            }

            // Ctrl + Alt + Shift + H 
            if ((Control.ModifierKeys & Keys.Control) != 0 &&
                 (Control.ModifierKeys & Keys.Alt) != 0 &&
                 (Control.ModifierKeys & Keys.Shift) != 0 &&
                 e.KeyCode == Keys.H)
            {
                MessageBox.Show("Ctrl + Alt + Shift + H");
            }
        }



		#region 
		#region 主要功能是替换功能的tabControl中所有click事件
		#endregion
		#region 主要功能是替换功能的tabControl中所有click事件
		private void btnReplace_Click(object sender, EventArgs e)
		{
			//替换字符串
			saveBeforeContent();
			StringBuilder sbOutput = new StringBuilder();

			//将需要的改动的内容转义成strTemp ，防止出错       //如果内容中包含*号等转义字符，替换就会出错了。
			string strTempOriginEncry = "";
			string strTempFinalEncry = "";
			if (chkIgnoreCase.Checked)
			{
				strTempOriginEncry = txtOriginStr.Text.ToLower();
				strTempFinalEncry = txtFinalStr.Text.ToLower();
			}
			strTempOriginEncry = strTempOriginEncry.ToEncryInneredParticularWord();
			strTempFinalEncry = strTempFinalEncry.ToEncryInneredParticularWord();

			foreach (string str in richInput.Text.ToEncryInneredParticularWord().GetSplitLineKeepEmptyRow())
			{
				sbOutput.AppendLine(str.Replace(strTempFinalEncry, strTempFinalEncry));
			}
			string strChangeTextThatTransfer = txtAppendToBefore.Text.ToEncryInneredParticularWord();

			richInput.Text = sbOutput.ToString().RemoveLastChar().ToDecodeInneredParticularWord();
		}

		private void btnCombineAllLineToOneLine_Click(object sender, EventArgs e)
		{
			saveBeforeContent();
			richInput.Text = ManyRowToOneRowByLinkMiddleStr(richInput.Text, txtLinkStr.Text);
		}

		public string ManyRowToOneRowByLinkMiddleStr(string input, string linkMiddle)
		{
			string output = "";
			//将所有内容整合成一行，中间以某字符连接形成一行
			string temp = input.ToEncryInneredParticularWord();
			StringBuilder sbOutput = new StringBuilder();
			foreach (string str in temp.Split('\n'))
			{
				sbOutput.AppendFormat(str + linkMiddle);
			}
			output = sbOutput.ToString().ToDecodeInneredParticularWord();

			return output;
		}

		private void btnSixSpaceToBreakLine_Click(object sender, EventArgs e)
		{
			saveBeforeContent();
			//将六个空格替换为换行
			//中文全角空格为\u3000，英文半角空格为\u0020，
			richInput.Text = (new Regex("[\u0020\u3000]{6}")).Replace(richInput.Text, "\n");
		}

		private void btnSortAll_Click(object sender, EventArgs e)
		{
			//按首字母拼音或者笔画(反)排序每行
			saveBeforeContent();
			if (cbxOrderType.Checked)
			{ //按首字母拼音
				richInput.Text = richInput.Text.GetSplitLineWithoutEmpty().SortList().Aggregate((n, j) => n + "\n" + j);
			}
		}

		private void btnGetAllTextLength_Click(object sender, EventArgs e)
		{
			//获取输入框文字总长度
			txtContentLength.Text = richInput.Text.Length.ToString();
		}
		#endregion
		#region 常用转换特定转换
		private void btnTransferParticularChar_Click(object sender, EventArgs e)
		{
			saveBeforeContent();
			//反转义双引号、右下划线
			richInput.Text = (new Regex("\"")).Replace(richInput.Text, "\\\"");
			richInput.Text = (new Regex("\\\\")).Replace(richInput.Text, "\\\\");
		}
		private void btnReplaceCodeType_Click(object sender, EventArgs e)
		{
			//将如下这些C#变量类型和其后的空格替换为空
			saveBeforeContent();
			List<string> listCodeTypeName = txtCodeTypeNames.Text.GetSplitLineWithoutEmpty(',');
			string regexPattern = "";
			foreach (string codeTypeName in listCodeTypeName)
			{
				regexPattern += $"|{codeTypeName} ?(?=\\S)"; //前面?号表示0个或N个，后面(?=\\s)表示正则表达式查找或替换时不会包含\\S
			}
			regexPattern = regexPattern.RemovFrontChar();
			Regex regex = new Regex(regexPattern);
			richInput.Text = regex.Replace(richInput.Text, "");
		}
		#endregion
		#region 主要功能是前后增、删、查功能的tabControl中所有click事件
		#region 增加或者删除 每行前或后的某些字符串
		private void btnAddBeforeExceptEmptyR_Click(object sender, EventArgs e)
		{
			//在每行前新增txtAppend.Text

			//txtAppendToBefore.Text = txtAppendToBefore.Text.Trim();
			//获取每行内容组成的List
			StringBuilder sbOutput = new StringBuilder();
			foreach (string str in richInput.Text.GetSplitLineKeepEmptyRow())
			{
				if (string.IsNullOrEmpty(str))
				{
					sbOutput.AppendLine();
					continue;
				}
				sbOutput.AppendLine(txtAppendToBefore.Text + str);
			}
			richInput.Text = sbOutput.ToString().RemoveLastChar();

		}

		private void btnRemoveEveryRowPreviousStrExeceptEmptyRow_Click(object sender, EventArgs e)
		{
			//移除每行某某内容前的所有内容

			//txtAppendToBefore.Text = txtAppendToBefore.Text.Trim();

			StringBuilder sb = new StringBuilder();
			foreach (string line in richInput.Text.GetSplitLineKeepEmptyRow())
			{
				int index = line.IndexOf(txtAppendToBefore.Text);

				if (index >= 0)
				{
					if (chkContainThatPreviousWords.Checked)
					{
						sb.Append(line.Substring(index + txtAppendToBefore.Text.Length) + "\n");
					}
					if (!chkContainThatPreviousWords.Checked)
					{
						sb.Append(line.Substring(index) + "\n");
					}
				}
				else
				{
					sb.Append(line + "\n");
				}
			}
			richInput.Text = sb.ToString().RemoveLastChar();
		}

		private void btnAddEverRowSuffixStrExceptEmptyRow_Click(object sender, EventArgs e)
		{
			//新增到每行最尾端

			//txtAppendToEnd.Text = txtAppendToEnd.Text.Trim();
			//获取每行内容组成的List
			List<string> list = StringUtils.GetSplitLine(richInput.Text);
			StringBuilder sb = new StringBuilder();
			foreach (string line in list)
			{
				if (string.IsNullOrEmpty(line.Trim()))
				{
					sb.Append(line + "\n");
					continue;
				}
				sb.AppendLine(line + txtAppendToEnd.Text.ToString().Trim());
			}
			richInput.Text = sb.ToString().RemoveLastChar();
		}

		private void btnRemoveEveryRowSuffixStrExeceptEmptyRow_Click(object sender, EventArgs e)
		{
			//移除每行后 字符串

			//txtAppendToEnd.Text = txtAppendToEnd.Text.Trim();

			StringBuilder sb = new StringBuilder();
			foreach (string line in richInput.Text.GetSplitLineKeepEmptyRow())
			{
				int index = line.LastIndexOf(txtAppendToEnd.Text);

				if (index >= 0)
				{
					if (chkContainThatSuffixStr.Checked)
					{
						sb.Append(line.Substring(0, index) + "\n");
					}
					if (!chkContainThatSuffixStr.Checked)
					{
						sb.Append(line.Substring(0, index + txtAppendToEnd.Text.Length) + "\n");
					}
				}
				else
				{
					sb.Append(line + "\n");
				}
			}
			richInput.Text = sb.ToString().RemoveLastChar();
		}
		#endregion


		#region 保留或者不保留哪些行
		/// <summary>
		/// 某行不带这些内容则保留，以|符号组合
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveByNotContainAnyStr_Click(object sender, EventArgs e)
		{
			saveBeforeContent();
			//获取每行内容组成的List
			List<string> list = richInput.Text.Split('\n').ToList();
			List<string> listNeedExistedString = txtOperNotContained.Text.Split('|').ToList();

			int lineIndex = 0;
			List<int> listNeedRemoveIndexS1 = new List<int>(); //带有这些内容，则这行不保留，需要从list中移除
			StringBuilder sb = new StringBuilder();
			foreach (string line in list)
			{
				bool isExisted = false;
				foreach (string str in listNeedExistedString)
				{
					if (line.ToEncryInneredParticularWord().Contains(str.ToEncryInneredParticularWord()))
					{
						isExisted = true;
						break;
					}
				}
				if (isExisted)
				{   //如果带了这些内容，就不存这行了
					listNeedRemoveIndexS1.Add(lineIndex);
				}
				lineIndex++;
			}

			//使用对比插入
			List<int> listNeedRemoveIndexS2 = new List<int>(); //带有这些内容，则这行不保留，需要从list中移除
			int s1TotalCount = listNeedRemoveIndexS1.Count();
			for (int i = 0; i < s1TotalCount; i++)
			{
				int operIndex = listNeedRemoveIndexS1[i];
				listNeedRemoveIndexS2.Add(operIndex);

				int beforeRowNum = txtConcludeBeforeRowNum.Text.ToInt32();
				if (beforeRowNum > 0)
				{
					int temp = 1;
					while (operIndex >= temp && temp <= beforeRowNum)
					{
						listNeedRemoveIndexS2.Add(operIndex - temp);
						temp++;
					}
				}

				int afterRowNum = txtConcludeAfterRowNum.Text.ToInt32();
				if (afterRowNum > 0)
				{
					int temp = 1;
					while (operIndex + temp < list.Count && temp <= afterRowNum)
					{
						listNeedRemoveIndexS2.Add(operIndex + temp);
						temp++;
					}
				}
			}

			listNeedRemoveIndexS2 = listNeedRemoveIndexS2.Distinct().ToList();
			listNeedRemoveIndexS2.SortByDesc<int>();

			foreach (int removeIndex in listNeedRemoveIndexS2)
			{
				list.RemoveAt(removeIndex);
			}

			foreach (var saveRow in list)
			{
				sb.Append($"{saveRow}\n");
			}
			richInput.Text = sb.ToString().RemoveLastChar();
		}

		private void btnSaveByContainAnyStr_Click(object sender, EventArgs e)
		{
			//某行带这些内容则保留，以 | 符号组合
			//获取每行内容组成的List
			List<string> list = richInput.Text.Split('\n').ToList();
			List<string> listNeedExistedString = txtOperContent.Text.Split('|').ToList();
			richInput.Text = "";
			StringBuilder sb = new StringBuilder();
			foreach (string line in list)
			{
				bool isExisted = false;
				foreach (string str in listNeedExistedString)
				{
					if (line.ToLower().Contains(str.ToLower()))
					{
						isExisted = true;
						break;
					}
				}
				if (isExisted)
				{
					sb.AppendFormat(line + "\n");
				}
			}
			richInput.Text = sb.ToString();
		}
		#endregion
		#endregion
		#endregion

	}
}
