using BaseClassUtils;
using ReplaceString.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceString
{
    public partial class FrmReplaceOracleSql : Form
    {
        public FrmReplaceOracleSql()
        {
            InitializeComponent();
        }

		private void saveBeforeContent()
		{
			richOriginContent.Text = richInput.Text;
		}
		private void button1_Click(object sender, EventArgs e)
        {	
        }
		
		private void button5_Click(object sender, EventArgs e)
        {
            FrmExcel dlg = new FrmExcel();
            dlg.Show();
            return;
            MessageBox.Show(string.Format("直到{0}之前都还未完成！", DateTime.Now.ToString()));
            string strResult = "";
            //将Oracle的sql转换为Sqlserver的sql
            //将某行中带有字符串“REM INSERTING”或“SET DEFINE OFF”的删除掉
            txtOperNotContained.Text = "REM INSERTING|SET DEFINE OFF";
            btnSaveByNotContainAnyStr_Click(null, null);
            strResult = richInput.Text;
            //将字符串“C##FUSION.”转换为空字符
            strResult = strResult.Replace("C##FUSION.", "");
            //将“TM_OPERATION_EQUIPMENTU ”的类似字符去除最后的U
            strResult = strResult.Replace("U ", "");
            //将“IDU,WORK_POSITION_NOU,”的类似字符去除最后的U
            strResult = strResult.Replace("U,", ",");
            //将“ROW_VERSIONU)”的类似字符去除最后的U
            strResult = strResult.Replace("U)", ")");

            //用正则表达式将“to_date(.*)”转换为“GETDATE()”
            strResult = (new Regex(@"to_date\(.*?\)")).Replace(strResult, "GETDATE()");
            //将“"GETDATE(),'E6B0AA6F43EE4648AB99F998A2F16102')”转换为“"GETDATE(), 0xE6B0AA6F43EE4648AB99F998A2F16102)”
            strResult = (new Regex(@"GETDATE\(\),'(.*)?'\)")).Replace(strResult, "GETDATE(), 0x$1)");
            //将“values ('C21FCA8D2943BA47A42AC5F15AC06EE9',”转换为“values( NEWID(),”
            strResult = (new Regex(@"values \('.*?',")).Replace(strResult, "values( NEWID(),");


            //将 TM_WORK_REGION->TM_WorkRegion，and so on
            strResult = strResult.Replace("TM_WORK_REGION", "TM_WorkRegion");
            strResult = strResult.Replace("TM_WORK_POSITION", "TM_WorkPosition");
            strResult = strResult.Replace("TM_WORK_PATH", "TM_WorkPath");
            strResult = strResult.Replace("TM_OPERATION_EQUIPMENT", "TM_OperationEquipment");
            strResult = strResult.Replace(" ", " ");
            //将TM_换成其他的，后面再换回来，因为要把strRepeatUniqueString换成空字符串。 
            string strRepeatUniqueString = "mmmmmmmmmmmmmmm";
            strResult = strResult.Replace("TM_", strRepeatUniqueString);
            strResult = strResult.Replace("_", "");
            strResult = strResult.Replace(strRepeatUniqueString, "TM_");

            strResult = strResult.ToLower();

            richInput.Text = strResult;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //通过excel数据生成insertSql语句
            (new FrmExcel()).ShowDialog();
            return;
            string filePath = "";
            #region choose import file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(Microsoft Excel 2013;Microsoft Excel 2007)|*.xlsx;*.xls";
            DialogResult dialogResult = dialog.ShowDialog();
            if (DialogResult.Cancel == dialogResult)
            {
                return;
            }
            else if(DialogResult.OK == dialogResult)
            {
                filePath = dialog.FileName;
            }
            #endregion

            string result = "";
            var sheetNames = ExcelUtils.GetXlsSheetnames(filePath, out result);
            //DataSet ds = FileUtils.GetExcelDataSet(filePath);
            //string tableName = ds.Tables[0].Rows[2 - 1][1 - 1].ToString(), insertColumnList = "";
            //for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            //{
            //    insertColumnList += string.Format(ds.Tables[0].Rows[3 - 1][i].ToString() + ",");
            //}
            //insertColumnList = deleteLastDouhao(insertColumnList);  //去除最后的,号
            ////insert inot tb() values
            //StringBuilder sbSql = new StringBuilder();
            //sbSql.AppendFormat(("insert into "));
            //sbSql.AppendFormat(tableName);
            //sbSql.AppendFormat(@"(");
            //sbSql.AppendFormat(insertColumnList);
            //sbSql.AppendFormat(@") values (");
            //sbSql.AppendFormat(@");");

        }

        string deleteLastDouhao(string input)
        {
            return input.Substring(0, input.Length - 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //将“'System.Byte[]' ”替换为"SYS_GUID()"
            string str = richInput.Text;
            richInput.Text = str.Replace(@"'System.Byte[]' ", "SYS_GUID()");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //将双引号替换为空
            string str = richInput.Text;
            richInput.Text = str.Replace("\"", "");
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //将'2019/11/18 17:17:00'这样的日期类型 替换为 txtReplaced内容
            string strTemp = richInput.Text;
            strTemp = (new Regex(@"'\d{4}/\d{1,2}/\d{1,2} \d{1,2}:\d{2}:\d{2}'")).Replace(strTemp,"SYSDATE");
            richInput.Text = strTemp;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            richInput.Text = richInput.Text.Replace(txtReplacedStr02.Text, txtReplaceStr.Text);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //where ((("IDU" =  SYS_GUID()) and   替换为 where ((
            richInput.Text = richInput.Text.Replace(txtBeReplaceStr04.Text, txtReplaceStr04.Text);
        }

		private void button15_Click(object sender, EventArgs e)
		{
			saveBeforeContent();
			richInput.Text = richInput.Text.RawToGuid();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			saveBeforeContent();
			richInput.Text = richInput.Text.GuidToRaw();
		}


		#region 

		#region 主要功能是替换功能的tabControl中所有click事件
		#endregion
		#region 主要功能是替换功能的tabControl中所有click事件
		private void btnReplace_Click(object sender, EventArgs e)
		{
			saveBeforeContent();

			string inputText = richInput.Text;
			richInput.Text = ReplaceStr(richInput.Text, txtOriginStr.Text, txtFinalStr.Text, chkIgnoreCase.Checked);
			
			ReplaceHistoryModel model = new ReplaceHistoryModel("ReplaceStr", JsonHelper.SerializeObject(new ActionParam(txtOriginStr.Text, txtFinalStr.Text, chkIgnoreCase.Checked)), InputText:inputText, ResultText:richInput.Text);
			FrmDatabase.InsertDatabase(model);
		}
		public static string ReplaceStr(string input, string replacedText, string replacText, bool isIgnoreCase = false)
		{
			//替换字符串
			StringBuilder sbOutput = new StringBuilder();

			//将需要的改动的内容转义成strTemp ，防止出错       //如果内容中包含*号等转义字符，替换就会出错了。
			string strTempOriginEncry = replacedText;
			string strTempFinalEncry = replacedText;
			if (isIgnoreCase)
			{
				strTempOriginEncry = strTempOriginEncry.ToLower();
				strTempFinalEncry = strTempFinalEncry.ToLower();
			}
			strTempOriginEncry = strTempOriginEncry.ToEncryInneredParticularWord();
			strTempFinalEncry = strTempFinalEncry.ToEncryInneredParticularWord();

			foreach (string str in input.ToEncryInneredParticularWord().GetSplitLineKeepEmptyRow())
			{
				sbOutput.AppendLine(str.Replace(strTempOriginEncry, strTempFinalEncry));
			}

			return sbOutput.ToString().RemoveLastChar().ToDecodeInneredParticularWord();
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
			
			//如果新的地方提示没有这数据库，记得在Form1那里初始化数据库
			TransferHelper.ExecuteInsert("SixSpaceToBreakLine");
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

			TransferHelper.ExecuteInsert("AddBeforeExceptEmpty", txtAppendToBefore.Text);
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

			TransferHelper.ExecuteInsert("RemoveEveryRowPreviousStrExeceptEmptyRow", txtAppendToBefore.Text);
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

			TransferHelper.ExecuteInsert("AddEverRowSuffixStrExceptEmptyRow", txtAppendToEnd.Text);
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

			TransferHelper.ExecuteInsert("RemoveEveryRowSuffixStrExeceptEmptyRow", txtAppendToEnd.Text);
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

			TransferHelper.ExecuteInsert("SaveByNotContainAnyStr", $"{txtOperNotContained.Text}");
		}

		private void btnSaveByContainAnyStr_Click(object sender, EventArgs e)
		{
			//某行带这些内容则保留，以 | 符号组合

			saveBeforeContent();
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

			TransferHelper.ExecuteInsert("SaveByContainAnyStr", $"{txtOperContent.Text}");
		}
		#endregion

		#endregion

		#endregion

		private void button11_Click_1(object sender, EventArgs e)
		{
			saveBeforeContent();
			//将从Excel复制两格相邻单元格到txt中的几个空格转换为空
			richInput.Text = richInput.Text.Replace("	", "");
		}
	}
}
