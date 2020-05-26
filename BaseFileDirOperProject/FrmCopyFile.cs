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
    public partial class FrmCopyFile : Form
    {
        public FrmCopyFile()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {   //将文本框中的所有文件都复制到目录(每行一个)
            bool isNeedAddBaseDir = cbxIsNeedAddBaseDir.Checked;
            string needCopyFiles = richCopyFiles.Text;
            string msg = "";

            CopyFile(needCopyFiles, isNeedAddBaseDir, txtDestBaseDir.Text, ref msg);
            string extraTips = string.IsNullOrEmpty(msg) ? " " : $"但出现异常：{msg}";
            MessageBox.Show("恭喜！操作成功！" + extraTips);
        }

        private void CopyFile(string needCopyFiles, bool isNeedAddBaseDir, string strDestBaseDir, ref string msg)
        {//将这些路径下的文件都复制到目录
            if (Directory.Exists(strDestBaseDir))
            {
                if (DialogResult.OK == MessageBox.Show("已存在目录" + "是否先连子目录也删除？\n" + strDestBaseDir, "目录已存在！是否先连子目录也删除？", MessageBoxButtons.OKCancel))
                {
                    DirUtil.DeleteDirRecursive(strDestBaseDir);
                }
            }
            List<string> listSrcPath = new List<string>();
            foreach (string str in needCopyFiles.GetSplitLineWithoutEmpty())
            {
                string srcPath = "";
                if (isNeedAddBaseDir)
                {
                    srcPath = Path.Combine(txtBaseDir.Text, str.Trim());
                }
                else
                {
                    srcPath = str.Trim();
                }
                listSrcPath.Add(srcPath);

            }

            int index = 0;
            foreach (string str in needCopyFiles.GetSplitLineWithoutEmpty())
            {
                string srcPath = listSrcPath[index++];

                if (DirUtil.IsFileDirectory(srcPath))
                {
                    //listPath.Add(srcPath);
                    string desPath = $"{ strDestBaseDir.Trim()}\\{str.Trim().Replace(":\\", "")}";
                    DirUtil.CreateDir(desPath);
                    FileUtils.CopyFile(srcPath, desPath);
                }
                else
                {
                    msg += $"整合目录{srcPath}不存在！\n";
                }
            }
        }
        private void CopyFile(string src, string des)
        {
            File.Copy(src, des);
        }

        private void FrmCopyFile_Load(object sender, EventArgs e)
        {
            strDestBaseDir = AppDomain.CurrentDomain.BaseDirectory + $"{DateTime.Now.ToString("yyyy-MM-dd")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //假如输入的是目录列表，那么先转换为文件列表，然后如上复制文件即可实现复制目录以及子目录
            List<string> listSrcPath = new List<string>();
            foreach (string str in richCopyFiles.Text.GetSplitLineWithoutEmpty())
            {
                foreach(FileInfo fileInfo in DirUtil.getAllFile(str))
                {
                    listSrcPath.Add(fileInfo.FullName);
                }
            }

            richCopyFiles.Text = "";
            foreach(string str in listSrcPath)
            {
                richCopyFiles.Text += $"{str}\n";
            }
        }
    }
}
