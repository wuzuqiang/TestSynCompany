using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClassUtils;

namespace BaseFileDirOperProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            FileUtils.OpenFileIfnotthencreat(txtFilePath.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //打开目录
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(DialogResult.OK == dlg.ShowDialog())
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打开文件或目录
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打开上述合并的文件或目录
            OpenFileDialog dlg = new OpenFileDialog();
            FileUtils.OpenFileIfnotthencreat(System.IO.Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text));
        }
    }
}
