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
            //打开文件(不存在则创建)或打开目录
            FileUtils.OpenFileIfnotthencreat(txtFilePath01.Text, cbxIsCreateIfNotExist.Checked);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = txtFilePath01.Text;
            path = Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text);
            //获取目录2下所有文件内容 //排列文件名称
            var fileSystemInfos = DirUtil.GetAllFileSystemInfo(path).OrderBy(a => ((FileInfo) a).DirectoryName).ThenBy(a => a.FullName);

            if (checkBox1.Checked)
            { //记录所有文件信息到当前路径默认日志
                List<string> contents = getAllFileNameAndFilePath(fileSystemInfos.ToList());
                if (cbxClearOrigin.Checked)
                { //覆盖原有内容
                    FileUtils.WriteAllLines(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), contents);
                }
                else
                FileUtils.AppendAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"),contents);
            }

            MessageBox.Show("恭喜！操作成功！");
            
        }

        private List<string> getAllFileNameAndFilePath(List<FileSystemInfo> fileSystemInfos)
        {
            StringBuilder sb = new StringBuilder();
            List<string> contents = new List<string>();
            int iIndex = 1;
            sb.AppendLine($"iIndex++，Name，FullName，根目录为{txtCombineDir.Text}");
            foreach (var fileInfo in fileSystemInfos)
            {
                string temp = $"{fileInfo.Name.PadRight(70)},{fileInfo.FullName.Replace(txtCombineDir.Text, "")}";
                if (cbxAppendRowIndex.Checked)
                {
                    contents.Add($"{(iIndex++).ToString().PadLeft(4)}, " + temp);
                }
                else
                {
                    contents.Add(temp);
                }
            }
            return contents;
        }

        private List<string> getAllFileName(List<FileSystemInfo> fileSystemInfos)
        {
            StringBuilder sb = new StringBuilder();
            List<string> contents = new List<string>();
            int iIndex = 1;
            sb.AppendLine($"iIndex++，Name，目录为{txtCombineDir.Text}");
            foreach (var fileInfo in fileSystemInfos)
            {
                string temp = $"{fileInfo.Name.PadRight(70)}";
                if (cbxAppendRowIndex.Checked)
                {
                    contents.Add($"{(iIndex++).ToString().PadLeft(4)}, " + temp);
                }
                else
                {
                    contents.Add(temp);
                }
            }
            return contents;
        }

        private List<string> getAllFilePath(List<FileSystemInfo> fileSystemInfos)
        {
            StringBuilder sb = new StringBuilder();
            List<string> contents = new List<string>();
            int iIndex = 1;
            sb.AppendLine($"iIndex++，Name，目录为{txtCombineDir.Text}");
            foreach (var fileInfo in fileSystemInfos)
            {
                string temp = $"{fileInfo.FullName.PadRight(70)}";
                if (cbxAppendRowIndex.Checked)
                {
                    contents.Add($"{(iIndex++).ToString().PadLeft(4)}, " + temp);
                }
                else
                {
                    contents.Add(temp);
                }
            }
            return contents;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //打开本程序根目录
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmCopyFile dlg = new FrmCopyFile();
            dlg.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //获取目录2下所有文件名称列表
            string path = txtFilePath01.Text;
            path = Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text);
            var fileSystemInfos = DirUtil.GetAllFileSystemInfo(path).OrderBy(a => ((FileInfo)a).DirectoryName).ThenBy(a => a.FullName);

            if (checkBox1.Checked)
            { //记录所有文件信息到当前路径默认日志
                List<string> contents = getAllFileName(fileSystemInfos.ToList());
                if (cbxClearOrigin.Checked)
                { //覆盖原有内容
                    FileUtils.WriteAllLines(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "(只含文件名称).txt"), contents);
                }
                else
                    FileUtils.AppendAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "(只含文件名称).txt"), contents);
            }

            MessageBox.Show("恭喜！操作成功！");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //获取目录2下所有文件路径列表
            string path = txtFilePath01.Text;
            path = Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text);
            var fileSystemInfos = DirUtil.GetAllFileSystemInfo(path).OrderBy(a => ((FileInfo)a).DirectoryName).ThenBy(a => a.FullName);

            if (checkBox1.Checked)
            { //记录所有文件信息到当前路径默认日志
                List<string> contents = getAllFilePath(fileSystemInfos.ToList());
                if (cbxClearOrigin.Checked)
                { //覆盖原有内容
                    FileUtils.WriteAllLines(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "(只含文件路径).txt"), contents);
                }
                else
                    FileUtils.AppendAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "(只含文件路径).txt"), contents);
            }

            MessageBox.Show("恭喜！操作成功！");
        }
    }
}
