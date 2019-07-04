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
