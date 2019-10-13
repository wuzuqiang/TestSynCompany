using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BaseClassUtils;

namespace TestReg
{
    public partial class RegTest : Form
    {
        public RegTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInput.Text = @"23794大富科世纪东方了djfkasdl@qq.com9548dhf28340385@163.comsdfjsd  2349@sina.com305983*&*&*2";
            txtPattern.Text = @"[a-zA-Z0-9]+@[a-zA-z0-9]+\.com";
            TestMustUseCode();
        }

        private void btnRegMatch_Click(object sender, EventArgs e)
        {
            string recordPath = AppDomain.CurrentDomain.BaseDirectory + "RegTestResult.txt";
            string input = txtInput.Text;
            string pattern = txtPattern.Text;
            txtResult.Text = "";
            MatchCollection matchCollection;
            try
            {
                matchCollection = Regex.Matches(input, pattern);
                foreach (Match match in matchCollection)
                {
                    txtResult.Text += string.Format("匹配到的字符串是{0};", match.Value) + "\n";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            //如果有记录，就将其写入文件
            (new FileUtils()).writeAppendFile(recordPath, new string[] { string.Format("{2}\r\n对字符串：\"{0}\"\r\n使用正则表达式：\"{1}\"的结果是"
                , input, pattern, DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")) });
            if (matchCollection.Count > 0)
            {
                (new FileUtils()).writeAppendFile(recordPath, Regex.Split(txtResult.Text, @";"));
            }
        }

        private void TestMustUseCode()
        {
            string recordPath = AppDomain.CurrentDomain.BaseDirectory + "RegTestResult.txt";
            string input = "ABCD\n\t123efgh  321ijk";
            string pattern = @"\w.";
            txtInput.Text = input;
            txtPattern.Text = pattern;
            txtResult.Text = "";
            MatchCollection matchCollection;
            try
            {
                matchCollection = Regex.Matches(input, pattern);
                foreach (Match match in matchCollection)
                {
                    txtResult.Text += string.Format("匹配到的字符串是{0};", match.Value) + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            //如果有记录，就将其写入文件
            (new FileUtils()).writeAppendFile(recordPath, new string[] { string.Format("{2}\r\n对字符串：\"{0}\"\r\n使用正则表达式：\"{1}\"的结果是"
                , input, pattern, DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")) });
            if (matchCollection.Count > 0)
            {
                (new FileUtils()).writeAppendFile(recordPath, Regex.Split(txtResult.Text, @";"));
            }


            //string input = "Warning" + '\u0007';
            //string input2 = "a b111c d; b2222" + "aa\b" + "\\u008";
            //string str1 = "Warning\u98989990007";
            //MatchCollection matchCollect = new Regex("", RegexOptions.IgnoreCase).Matches("");
            ////new Regex.Opt
            //string expr = @"\040b";
            //Regex _regex = new Regex("");
            ////MatchCollection _matchCollect = _regex.Matches("");
            //MatchCollection _matchCollect =  Regex.Matches(input, expr);
            //string[] strArray = Regex.Split(input, expr);
        }
    }
    public class cA_hB : cB
    {
        protected new string InternalCategory = "互动元素";
        int i1 = 2;
    }
    public class cB
    {
        public string InternalCategory = "";
    }
}
