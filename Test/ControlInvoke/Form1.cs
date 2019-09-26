using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInvoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //System.Threading.Thread.CurrentThread.Name = "UIThread";
            //Thread th = new Thread(new ThreadStart(StartThread));
            //th.Start();
            StartThread();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public delegate void treeinvoke();
        private void UpdateTreeView()
        {
            MessageBox.Show(System.Threading.Thread.CurrentThread.Name);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.Name = "UIThread";
            Thread th = new Thread(new ThreadStart(StartThread));
            th.Start();
        }
        private void StartThread()
        {
            Thread.CurrentThread.Name = "Work Thread";
            treeView1.BeginInvoke(new treeinvoke(UpdateTreeView));  //不要在类构造函数Form1中调用StartThread函数，不然会报错“在创建窗口句柄之前，不能在控件上调用 Invoke 或 BeginInvoke。”
        }
    }


}
