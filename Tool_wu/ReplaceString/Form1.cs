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
            //dialog.Filter = "Microsoft Excel 2013|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName;
            }
            else
            {
                return;
            }
            #endregion
            return;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //
            int dataN = 23; 
            int data1 = 0;
            int data2 = 0;
            int num = 3;
            int[] intArray = new int[num];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                int iTemp = (new Random()).Next(0, 200);
                //intArray[0] = i;
                //...
                //intArray[num - 2] = i;  //这种情况下结合[0]倒是达到结果
                //intArray[num - 2] = (new Random()).Next();  //没一条满足条件
                //intArray[num - 1] = 2 * intArray[num - 2];  //作为CheckCode

                intArray[0] = (new Random()).Next(201,300);
                intArray[num - 2] = (new Random()).Next(0, 200);  
                intArray[num - 1] = intArray[0]+intArray[1];  //作为CheckCode
                int[] tempArray = intArray.Take(num - 1).ToArray();
                if (intArray[num - 1] == CalculateCheckCode(tempArray))
                {
                    sb.AppendLine($"结果满足的数组第{i}次：{string.Join(",",intArray)}");
                }
            }
            if(!string.IsNullOrEmpty(sb.ToString()))
                MessageBox.Show("试出满足数据如下\n"+ sb.ToString());
        }
        /// <summary>
        /// 计算校验码。
        /// </summary>
        /// <param name="data">需要计算的int数组</param>
        /// <returns>返回计算后的校验码</returns>
        public static int CalculateCheckCode(int[] data)
        {
            int temp = 0;

            foreach (var item in data)
            {
                temp = ((temp & 65535) + (item & 65535)) & 65535;
            }

            return temp & 65535;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<string> listSplit = new List<string>();
            foreach(string str in richInput.Text.Split(','))
            {
                listSplit.Add(str);
            }
            StringBuilder sb = new StringBuilder();
            foreach(string str in listSplit)
            {
                if (string.IsNullOrEmpty(str)) { continue; }
                string tempInputText = richInput.Text.Replace(str, str.Substring(0,str.Length-1));
                if(richInput.Text.Length - tempInputText.Length >= 2)
                {
                    sb.AppendLine(str + " 出现两次以上");
                }
            }
            richResult.Text = sb.ToString();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //只压缩行
            richResult.Text = (new Regex("\\n")).Replace(richInput.Text, "");
        }

        int clickNum = 1;
        private void richInput_Click(object sender, EventArgs e)
        {
            int index = richInput.GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = richInput.GetLineFromCharIndex(index) + 1;//得到当前行的行号,从0开始，习惯是从1开始，所以+1.
            int col = richInput.SelectionStart - index + 1;//.SelectionStart得到光标所在位置的索引 减去 当前行第一个字符的索引 = 光标所在的列数（从0开始)
            txtCurrentIndex.Text = line + "," + col;
            return;
            //txtCurrentIndex.Text = (1 + Convert.ToInt32(txtCurrentIndex.Text)).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //生成GUID
            richInput.Text = System.Guid.NewGuid().ToString().ToUpper();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //首字母大小写
			List<string> listInput = richInput.Text.GetSplitLineWithoutEmpty();
			string input = "";
			foreach(string temp in listInput)
			{
				if (cbkToUper.Checked)
				{
					input += temp.Substring(0, 1).ToUpper() + temp.Substring(1) + "\n";
				}
				else
				{
					input += temp.Substring(0, 1).ToLower() + temp.Substring(1) + "\n";
				}
			}
			richResult.Text = input.RemoveLastChar();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //THOK计算校验码
            (new FrmCalculateCheckCode()).Show();
        }
    }
}
