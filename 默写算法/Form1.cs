using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 默写算法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            冒泡排序();
        }

        private void  冒泡排序()
        {
            int[] array1 = new int[6] { 23, 12, 14, 19, 01, 02 };
            for(int i = 0; i < array1.Length; i++)
            {
                for(int j = i+1; j< array1.Length; j++)
                {
                    if(array1[j] < array1[i])
                    {
                        int temp = array1[j];
                        array1[j] = array1[i];
                        array1[i] = temp;
                    }
                }
            }
            richTextBox1.Text = "";
            for(int i = 0; i < array1.Length; i++)
            {
                richTextBox1.Text += array1[i] + "，";
            }
        }
    }
}
