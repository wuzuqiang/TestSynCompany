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
            //打开目录2的基目录
            txtCombineDir.Text = WinFormUtil.ShowFolderBrowserDialog() ?? txtCombineDir.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //选择目录2
            txtCombineRelaPath.Text = WinFormUtil.ShowFolderBrowserDialog() ?? txtCombineRelaPath.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打开上述合并的文件或目录
            FileUtils.OpenFileIfnotthencreat(System.IO.Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {   //反正自己用的，替换掉就是
            txtFilePathThatContainAllSoftwarePackage.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "当前某服务器某目录所有的软件安装包.txt");//.Replace(@"\bin\Debug\", @"\");
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

        private List<string> getAllFilePath(List<FileSystemInfo> fileSystemInfos, bool isNotContainedBaseDir = true, string baseDir = " ")
        {
            StringBuilder sb = new StringBuilder();
            List<string> contents = new List<string>();
            foreach (var fileInfo in fileSystemInfos)
            {
                string temp = "";
                if(isNotContainedBaseDir)
                {
                    temp = $"{fileInfo.FullName}".Replace(baseDir, " ");
                }
                contents.Add(temp);
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
            //获取目录2下所有文件信息
            string path = txtFilePath01.Text;
            path = Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text);

            MessageBox.Show("恭喜！操作成功！");
        }

        private string getSaveFilePath()
        {
            string saveFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            if (!checkBox1.Checked)
            {   //记录所有文件信息到当前路径默认日志
                saveFilePath = txtFilePathThatContainAllSoftwarePackage.Text;
            }
            return saveFilePath;
        }

        private IEnumerable<FileSystemInfo> getFileSysteInfo(string path)
        {
            var fileSystemInfos = DirUtil.GetAllFileSystemInfo(path, false);
            if(cbxOrderFileName.Checked)
            {
                fileSystemInfos = fileSystemInfos.OrderBy(a => ((FileInfo)a).DirectoryName).ThenBy(a => a.FullName);
            }
            return fileSystemInfos;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //获取目录2下所有软件安装包文件信息
            string path = txtFilePath01.Text;
            path = Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text);
            var fileSystemInfos00= DirUtil.GetAllFileSystemInfo(path);

            List<string> matchFileExtension = new List<string>() { ".exe", ".zip", ".rar", ".apk", ".EXE", ".cab", ".msi", ".jar", ".iso", ".vsix"
                , ".bat", ".ppt", ".doc", ".docx", ".txt", ".pdf", ".xls", ".xlsx", ".chm", ".xmind", ".sql" };
            var fileSystemInfos = fileSystemInfos00.Where(w => matchFileExtension.Contains(Path.GetExtension(w.FullName)));

            //记录所有文件信息到当前路径默认日志
            List<string> contents = getAllFilePath(fileSystemInfos.ToList(), true, txtCombineDir.Text);
            FileUtils.WriteAllLines(txtFilePathThatContainAllSoftwarePackage.Text, contents);

            MessageBox.Show("恭喜！操作成功！");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtFilePathThatContainAllSoftwarePackage.Text = WinFormUtil.ShowOpenFileDialog() ?? txtFilePathThatContainAllSoftwarePackage.Text;
        }
    }
}
