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

namespace TestReg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string input = "Warning" + '\u0007';
            string input2 = "a b111c d; b2222" + "aa\b" + "\\u008";
            string str1 = "Warning\u98989990007";
            MatchCollection matchCollect = new Regex("", RegexOptions.IgnoreCase).Matches("");
            //new Regex.Opt
            string expr = @"\040b";
            Regex _regex = new Regex("");
            //MatchCollection _matchCollect = _regex.Matches("");
            MatchCollection _matchCollect =  Regex.Matches(input, expr);
            string[] strArray = Regex.Split(input, expr);


            //string content = "23794大富科世纪东方了djfkasdl@qq.com9548dhf28340385@163.comsdfjsd  2349@sina.com305983*&*&*2";//声明匹配规则对象，并设定匹配规则
            //Regex regex = new Regex(@"[a-zA-Z0-9]+@[a-zA-z0-9]+\.com");//构造方法里面的参数就是匹配规则。
            //MatchCollection matchs; //声明匹配结果集对象
            ////调用匹配多个出多个结果的方法进行匹配，将返回的匹配结果集对象赋值给matchs
            //matchs = regex.Matches(content);
            ////输出所有匹配结果
            //foreach (Match match in matchs)
            //{
            //    txtResult.Text += match.Value + ";\n";
            //}

            //定义匹配规则
            Regex regex = new Regex(@"([a-zA-Z0-9_]+)@([a-zA-Z0-9])+\.com");
            //定义要被匹配的字符串
            string content = "nihao123@qq.com   myemail@163.comasjdfjsdf";
            //进行匹配，并返回结果集
            MatchCollection matchs = regex.Matches(content);
            //输出结果
            for (int i = 0; i < matchs.Count; i++)
            {
                txtResult.Text += string.Format("匹配到的第{0}个邮箱结果是{1}，对应用户名是{2}", i + 1, matchs[i], matchs[i].Groups[1]) + "\n";
            }
        }

        private void btnRegMatch_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string pattern = txtPattern.Text;
            txtResult.Text = "";
            foreach(Match match in Regex.Matches(input, pattern))
            {
                txtResult.Text += string.Format("匹配到的字符串是{0};", match.Value) + "\n";
            }
            //如果有记录，就将其写入文件
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
