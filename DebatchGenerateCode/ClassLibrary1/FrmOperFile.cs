using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClassUtils;

namespace ClassLibrary1
{
    public partial class FrmOperFile : Form
    {
        public FrmOperFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(DialogResult.OK == dlg.ShowDialog())
            {
                txtFolder.Text = dlg.SelectedPath;
            }
            //foreach(FileInfo info in (new DirUtil()).getAllFile(txtFolder.Text))
            //{
            //    txtFiles.Text += info.FullName + ";\n";
            //}
            foreach (FileInfo info in (new DirUtil()).getAllFile(txtFolder.Text, txtFileNameNeedContain.Text))
            {
                if(StringUtils.isMatch(Path.GetExtension(info.FullName), ".cs|.js"))
                    txtFiles.Text += info.FullName + ";\n";
            }
            //foreach(DirectoryInfo info in (new DirUtil()).getAllDir(txtFolder.Text))
            //{
            //    txtFiles.Text += info.FullName + ";\n";
            //}
            //(new DirUtil()).recycleChangeDir(txtFolder.Text.Trim(), "23", "wu");
            //foreach (string info in (new DirUtil()).get第二级别下各自的一行目录或者文件(txtFolder.Text))
            //{
            //    txtFiles.Text += info + ";\n";
            //}
        }

        private void FrmOperFile_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //创建目录
            DirUtil.CreateDir(txtFolder.Text);
        }
    }
}
