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
