using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 使用dos命令执行批量的sql操作权限和增删查改
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string command = "";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                command = dlg.FileName;
            }
            using (Process process = new Process())
            {
                process.StartInfo.FileName = command;
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(command);

                //run as admin
                process.StartInfo.Verb = "runas";

                process.Start();
                while(!process.HasExited)
                {
                    process.WaitForExit(1000);
                }
            }
        }
    }
}
