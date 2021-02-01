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
    public partial class FrmRegex : Form
    {
        public FrmRegex()
        {
            InitializeComponent();
        }

        private void btnRegMatch_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string pattern = txtPattern.Text;
            txtResult.Text = "";
            MatchCollection matchCollection;
            try
            {
                matchCollection = Regex.Matches(input, pattern);
				txtResult.Text += "匹配内容如下：\n";
                foreach (Match match in matchCollection)
				{
					GroupCollection groups = match.Groups;
					txtResult.Text += (string.Format("共有{1}个分组；match.Vale为{0}使用正则表达式：{2}\n"
												, match.Value, groups.Count, pattern));

					//提取匹配项内的分组信息
					for (int i = 0; i < groups.Count; i++)
					{
						txtResult.Text += (
							string.Format("分组{0}的内容为{1}，位置为{2}，长度为{3}\n"
										, i
										, groups[i].Value
										, groups[i].Index
										, groups[i].Length));
					}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string pattern = txtPattern.Text;
            txtResult.Text = "";
            MatchCollection matchCollection;
            try
            {
                matchCollection = Regex.Matches(input, pattern);
                txtResult.Text = (new Regex(pattern)).Replace(txtInput.Text, txtReplaceStr.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
    }
}
