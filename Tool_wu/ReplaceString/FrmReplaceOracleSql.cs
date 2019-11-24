using BaseClassUtils;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //需要排除select from 
            richInput.Text = richInput.Text.Replace(textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //某行带这些内容则保留，以 | 符号组合
            //获取每行内容组成的List
            List<string> list = richInput.Text.Split('\n').ToList();
            List<string> listNeedExistedString = txtOperContent.Text.Split('|').ToList();
            richInput.Text = "";
            StringBuilder sb = new StringBuilder();
            foreach(string line in list)
            {
                bool isExisted = false;
                foreach(string str in listNeedExistedString)
                {
                    if (line.ToLower().Contains(str.ToLower()))
                    {
                        isExisted = true;
                        break;
                    }
                }
                if(isExisted)
                {
                    sb.AppendFormat(line + "\n");
                }
            }
            richInput.Text = sb.ToString();
        }

        /// <summary>
        /// 某行不带这些内容则保留，以|符号组合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //获取每行内容组成的List
            List<string> list = richInput.Text.Split('\n').ToList();
            List<string> listNeedExistedString = txtOperNotContained.Text.Split('|').ToList();
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
                if (!isExisted)
                {
                    sb.AppendFormat(line + "\n");
                }
            }
            richInput.Text = sb.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //将每行以|组合起来
            string str = richInput.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Aggregate((e1, e2) => string.Format("{0}|{1}", e1, e2));
            richInput.Text = str;
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
            button3_Click(null, null);
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
            var sheetNames = FileUtils.GetXlsSheetnames(filePath, out result);
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

        private void button9_Click(object sender, EventArgs e)
        {
            //在每行前新增txtAppend.Text
            //获取每行内容组成的List
            List<string> list = richInput.Text.Split('\n').ToList();
            StringBuilder sb = new StringBuilder();
            foreach (string line in list)
            {
                sb.Append(txtAppend.Text + line + "\n");
            }
            richInput.Text = sb.ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //移除每行前txtAppend.Text
            //获取每行内容组成的List
            List<string> list = richInput.Text.Split('\n').ToList();
            StringBuilder sb = new StringBuilder();
            foreach (string line in list)
            {   
                if(line.Length > txtAppend.Text.Length && line.Substring(0, txtAppend.Text.Length).Contains(txtAppend.Text))
                {
                    sb.Append(line.Substring(txtAppend.Text.Length) + "\n");

                }
                else
                {
                    sb.Append(line + "\n");
                }
            }
            richInput.Text = sb.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //新增到每行最尾端
            //获取每行内容组成的List
            List<string> list = richInput.Text.Split('\n').ToList();
            StringBuilder sb = new StringBuilder();
            foreach (string line in list)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                sb.AppendLine(line + txtAppend.Text.ToString().Trim());
            }
            richInput.Text = sb.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //将'2019/11/18 17:17:00'这样的日期类型 替换为 txtReplaced内容
            string strTemp = richInput.Text;
            strTemp = (new Regex(@"'\d{4}/\d{2}/\d{2} \d{2}:\d{2}:\d{2}'")).Replace(strTemp,"SYSDATE");
            richInput.Text = strTemp;
        }
    }
}
