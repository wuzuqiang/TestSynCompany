using BaseClassUtils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReplace01_Click(object sender, EventArgs e)
        {
            //将字符串中的所有数字加1
            //只做到了两位数以下的自加，2019年10月4日20:56:25
            List<string> listOnetimeResult = new List<string>();
            string input = richInput.Text;string output = "";
            Regex reg1 = new Regex(@"[^\d]([\d][\d])[^\d]");    //只能从大数到小数了，不然20,10啊，这些不知道怎么变动
            output = reg1.Replace(input, TranslateNum);
            //数字小于10，这时公有一位数字，前后都不能为数字
            Regex reg = new Regex(@"[^\d]([\d])[^\d]");
            MatchCollection result = reg.Matches(input);
            output = reg.Replace(output, TranslateNum);
            richResult.Text = output;
        }

        public string TranslateNum(Match match)
        {
            int iRet = Convert.ToInt32(match.Groups[1].Value);
            string strRet = "";
            //if (iRet % 10 == 0 && iRet != 0)
            //{
            //    strRet = match.Value;
            //}
            //else if (iRet% 10 != 0 || iRet == 0)//排除9加1变成10之后又被更改了
            //{
            //    strRet = match.Value.Replace(iRet.ToString(), (++iRet).ToString());
            //}
            strRet = match.Value.Replace(iRet.ToString(), (++iRet).ToString());
            return strRet;
        }

        private void button1_Click(object sender, EventArgs e)
        {   //将每行的等号左右两边内容互换
            string input = "";string output = "";
            Regex regex = new Regex(@"(.*)\=(.*)" + txtEndChar.Text);
            output = regex.Replace(richInput.Text, SwitchTheContentTwosidesequal);
            richResult.Text = output;
        }
        public string SwitchTheContentTwosidesequal(Match match)
        {
            string strRet = "";
            string equalLeft = match.Groups[1].Value;string tempStr = "^_^";
            strRet = match.Value.Replace(match.Groups[1].Value, tempStr); //将等号左边内容替换为^_^，防止被替换掉
            strRet = strRet.Replace(match.Groups[2].Value, " " + equalLeft.Trim() + " "); //将等号右边内容替换为左边内容
            strRet = strRet.Replace(tempStr, match.Groups[2].Value.Trim() + " "); //将等号左边内容替换为右边边内容
            return strRet;
        }

        private void button2_Click(object sender, EventArgs e)
        {   //将函数中的变量都去除类型
            List<string> listCSharpType = new List<string>() { "int", "string", "string[]" };
            string input = ""; string output = richInput.Text;
            foreach (string str in listCSharpType)
            {
                output = output.Replace(str, "");
            }
            output = (new Regex(@"[ \r\n]")).Replace(output, "");
            richResult.Text = output;
        }
        public string WipeCSharpType(Match match)
        {
            string strRet = "";
            return "";
        }

        private void button3_Click(object sender, EventArgs e)
        {   //使用普通的正则表达式
            (new FrmRegex()).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {   //普通替换
            (new FrmNormalReplace()).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {   //互换字母大小写
            if(cbxWordUper.Checked)
            {   //所有内容换成大写
                richResult.Text = richInput.Text.ToUpper();
            }
            else
            {
                richResult.Text = richInput.Text.ToLower();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {   //如果行中存在符号，则加内容

        }

        private void button7_Click(object sender, EventArgs e)
        {
            (new FrmReplaceOracleSql()).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //编码
            (new FrmCodeFormat()).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //压缩
            richResult.Text = (new Regex("\\s")).Replace(richInput.Text, "");
        }

        private void button10_Click(object sender, EventArgs e)
        {   //获取Excel数据
            string path = "";
            #region choose import file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Microsoft Excel 2013|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                path = dialog.FileName;
            }
            #endregion
            DataSet ds = FileUtils.GetExcelDataSet(path);
            return;
        }
    }
}
