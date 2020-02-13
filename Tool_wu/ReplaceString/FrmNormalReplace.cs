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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxIgnoreCase.Checked)
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
            foreach (string str in input.Split('\n'))
            {
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
        
        private void button6_Click(object sender, EventArgs e)
        {
            //raw转guid
            //new guid(byte[] id);
            var guid_Val = new Guid(HexStringToBytes(richInput.Text, Encoding.Unicode));
            richInput.Text = guid_Val.ToString();

            //MessageBox.Show("吴祖强在加油中！！");
            return;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var temp2 = byte.Parse("1b", NumberStyles.HexNumber); 
            //guid转raw
            var temp = (new Guid(richInput.Text)).ToByteArray();
            richInput.Text = BitConverter.ToString(temp).Replace("-","");
        }

        //3、将16进制字符串转为字符串
        private byte[] HexStringToBytes(string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            //按照指定编码将字节数组变为字符串
            return b;
        }

        //4、将byte[]转为16进制字符串
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //反转义双引号、右下划线
            richInput.Text = (new Regex("\"")).Replace(richInput.Text, "\\\"");
            richInput.Text = (new Regex("\\\\")).Replace(richInput.Text, "\\\\");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //将六个空格替换为换行
            //中文全角空格为\u3000，英文半角空格为\u0020，
            richInput.Text = (new Regex("[\u0020\u3000]{6}")).Replace(richInput.Text, "\n");
        }
    }
}
