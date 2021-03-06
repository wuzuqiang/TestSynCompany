﻿using System;
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
            FileUtils.OpenFileIfnotthencreat(System.IO.Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text), false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {   //反正自己用的，替换掉就是
            txtFilePathThatContainAllSoftwarePackage.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "当前某服务器某目录所有的软件安装包.txt");//.Replace(@"\bin\Debug\", @"\");
            lbDefaultFileSavePath.Text = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //打开本程序根目录
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmCopyFile dlg = new FrmCopyFile();
            dlg.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //获取目录2下所有文件信息
            var fileInfos = getAllFileConsideSerialNum();

            //获取要写入的文件信息
            var listContent = FileUtils.GetCollateFileSystemInfo(fileInfos.ToList(), cbxAddBaseDir.Checked, txtCombineDir.Text, cbxOrderFileName.Checked, cbxAddFileName.Checked
                , cbxAddFilePath.Checked, cbxAddCreateTime.Checked, cbxAddLastWriteTime.Checked);

            //获取数据保存在哪个文件
            string saveFilePath = getSaveFilePath();

            //将数据写入文件
            writeToFile(saveFilePath, listContent);

            MessageBox.Show("恭喜！操作成功！");
        }

        private IEnumerable<FileSystemInfo> getAllFileConsideSerialNum()
        {
            return DirUtil.GetAllFileSystemInfo(Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text), cbxOrderFileName.Checked);
        }

        private List<string> getContents(IEnumerable<FileSystemInfo> fileSystemInfos)
        {
            return FileUtils.GetCollateFileSystemInfo(fileSystemInfos.ToList(), cbxAddBaseDir.Checked, txtCombineDir.Text, cbxAppendRowIndex.Checked, cbxAddFileName.Checked
                , cbxAddFilePath.Checked, cbxAddCreateTime.Checked, cbxAddLastWriteTime.Checked);
        }

        private void writeToFile(string saveFilePath, List<string> listContent)
        {
            if (cbxCoverageOrigin.Checked)
            {
                FileUtils.WriteAllLines(saveFilePath, listContent);
            }
            else
            {
                FileUtils.AppendAllText(saveFilePath, listContent);
            }
        }

        private string getSaveFilePath()
        {
            string saveFilePath = lbDefaultFileSavePath.Text;
            if (!cbxSaveToDefaultPath.Checked)
            {   //记录所有文件信息到自己选择的目录文件
                saveFilePath = txtFilePathThatContainAllSoftwarePackage.Text;
            }
            return saveFilePath;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //获取目录2下所有软件安装包文件信息
            string path = txtFilePath01.Text;
            path = Path.Combine(txtCombineDir.Text, txtCombineRelaPath.Text);
            var fileSystemInfos00= getAllFileConsideSerialNum();
            
            List<string> matchFileExtensionV0 = new List<string>() { ".exe", ".zip", ".rar", ".apk", ".EXE", ".cab", ".msi", ".jar", ".iso", ".vsix"
                , ".bat", ".ppt", ".doc", ".docx", ".txt", ".pdf", ".xls", ".xlsx", ".chm", ".xmind", ".sql" };
            List<string> matchFileExtensionV1 = new List<string>();
            matchFileExtensionV1.AddRange(matchFileExtensionV0.Select(s => s.ToLower()));
            var fileInfos = fileSystemInfos00.Where(w => matchFileExtensionV1.Contains(Path.GetExtension(w.FullName.ToLower())));
            
            //获取要写入的文件信息
            var listContent = getContents(fileInfos);

            //获取数据保存在哪个文件
            string saveFilePath = getSaveFilePath();

            //将数据写入文件
            writeToFile(saveFilePath, listContent);

            MessageBox.Show("恭喜！操作成功！");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtFilePathThatContainAllSoftwarePackage.Text = WinFormUtil.ShowOpenFileDialog() ?? txtFilePathThatContainAllSoftwarePackage.Text;
        }
    }
}
