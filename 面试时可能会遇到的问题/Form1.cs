using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 面试时可能会遇到的问题
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int a = 2, b = 2, c;
            Fun1(ref a, b, out c);
        }

        public void Fun1(ref int i, int j, out int c, params int[] array)
        {
            i = i + 1;
            j = j + 1;
            c = i;
        }
    }
}
