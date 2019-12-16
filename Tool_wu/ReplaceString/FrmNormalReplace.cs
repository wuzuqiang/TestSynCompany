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
    public partial class FrmNormalReplace : Form
    {
        public FrmNormalReplace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbxIgnoreCase.Checked)
                richInput.Text = richInput.Text.ToLower().Replace(textBox1.Text.ToLower(), textBox2.Text.ToLower());
            else
                richInput.Text = richInput.Text.Replace(textBox1.Text, textBox2.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //求文字长度
            txtContentLength.Text = richInput.Text.Length.ToString();
        }

        string strNeedTransferInReg = "*, ., [, ], {, }, ^, $, (, )";
        private void button3_Click(object sender, EventArgs e)
        {
            //将每行中某字符前的字符都删除
            string input = richInput.Text;
            StringBuilder sbOutput = new StringBuilder();
            foreach(string str in input.Split('\n'))
            {
                //sbOutput.AppendLine((new Regex(@".+"+txtFlagString.Text+"").Replace(str, "")));
                //如果内容中包含*号等转义字符，上面就会出错了。
                string strTemp = txtFlagString.Text;
                foreach (string strSplit in strNeedTransferInReg.Split(','))
                {
                    if(!string.IsNullOrEmpty(strSplit))
                    {
                        strTemp = strTemp.Replace(strSplit.Trim(), $"\\{strSplit.Trim()}");
                    }
                }
                if (chkContainThatWords.Checked)
                {
                    sbOutput.AppendLine((new Regex(@".*" + strTemp + "").Replace(str, "")));
                }
                else
                {
                    string pattern = @".*(?=" + strTemp + ")";
                    sbOutput.AppendLine((new Regex(pattern)).Replace(str, ""));
                }
            }
            richInput.Text = sbOutput.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //将所有内容整合成一行，中间以Tab键盘分隔
            string input = richInput.Text.ToEncryInneredParticularWord();
            StringBuilder sbOutput = new StringBuilder();
            foreach (string str in input.Split('\n'))
            {
                sbOutput.AppendFormat(str + "\t");
            }
            richInput.Text = sbOutput.ToString().ToDecodeInneredParticularWord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //将每行中这些字符替换为空
            string input = richInput.Text;
            StringBuilder sbOutput = new StringBuilder();
            foreach (string str in input.Split('\n'))
            {
                sbOutput.AppendFormat(str.Replace(txtFlagString.Text, ""));
            }
            richInput.Text = sbOutput.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //将每行中这些字符后的字符都删除
            string input = richInput.Text;
            StringBuilder sbOutput = new StringBuilder();
            foreach (string str in input.Split('\n'))
            {
                if (string.IsNullOrEmpty(str)) continue;
                //sbOutput.AppendLine((new Regex(@".+"+txtFlagString.Text+"").Replace(str, "")));
                //如果内容中包含*号等转义字符，上面就会出错了。
                string strTemp = txtFlagString.Text;
                foreach (string strSplit in strNeedTransferInReg.Split(','))
                {
                    if (!string.IsNullOrEmpty(strSplit))
                    {
                        strTemp = strTemp.Replace(strSplit.Trim(), $"\\{strSplit.Trim()}");
                    }
                }
                if (chkContainThatWords.Checked)
                {
                    sbOutput.AppendLine((new Regex(strTemp + @".*").Replace(str, "")));
                }
                else
                {
                    string pattern = @"(?<=(" + strTemp + "))" + @".*";
                    sbOutput.AppendLine((new Regex(pattern).Replace(str, "")));
                }
            }
            richInput.Text = sbOutput.ToString();
            //MessageBox.Show("吴祖强正在开发，敬请期待！");
        }
    }
}
