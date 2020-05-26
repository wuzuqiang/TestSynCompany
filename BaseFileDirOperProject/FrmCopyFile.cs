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
    public partial class FrmCopyFile : Form
    {
        public FrmCopyFile()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {   //将文本框中的所有文件都复制到目录(每行一个)

            List<string> listSrcPath = new List<string>();
            listSrcPath = GetListSrcCopyFile(richCopyFiles.Text, cbxIsNeedAddBaseDir.Checked, txtDestBaseDir.Text);

            string msg = "";
            CopyFile(listSrcPath, txtDestBaseDir.Text, ref msg);
            string extraTips = string.IsNullOrEmpty(msg) ? " " : $"但出现异常：{msg}";
            MessageBox.Show("恭喜！操作成功！" + extraTips);
        }

        private void CopyFile(List<string> listSrcPath, string strDestBaseDir, ref string msg)
        {//将这些路径下的文件都复制到目录strDestBaseDir下
            foreach (string srcPath in listSrcPath)
            {
                if (DirUtil.IsFileDirectory(srcPath))
                {
                    //listPath.Add(srcPath);
                    string desPath = $"{ strDestBaseDir.Trim()}\\{srcPath.Trim().Replace(":\\", "")}";
                    DirUtil.CreateDir(desPath);
                    FileUtils.CopyFile(srcPath, desPath);
                }
                else
                {
                    msg += $"整合目录{srcPath}不存在！\n";
                }
            }
        }

        public List<string> GetListSrcCopyFile(string needCopyFiles, bool isNeedAddBaseDir, string strDestBaseDir)
        {
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

            return listSrcPath;
        }

        private void FrmCopyFile_Load(object sender, EventArgs e)
        {
            txtDestBaseDir.Text = AppDomain.CurrentDomain.BaseDirectory + $"{DateTime.Now.ToString("yyyy-MM-dd")}";
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

        private void button2_Click(object sender, EventArgs e)
        {
            //包含原有功能外，附加功能，修改文件名和带这些内容的目录由
            List<string> listSrcPath = new List<string>();
            listSrcPath = GetListSrcCopyFile(richCopyFiles.Text, cbxIsNeedAddBaseDir.Checked, txtDestBaseDir.Text);

            //将这些路径下的文件都复制到目录strDestBaseDir下
            foreach (string srcPath in listSrcPath)
            {
                if (DirUtil.IsFileDirectory(srcPath))
                {
                    string strReplaced = string.IsNullOrEmpty(txtSrc01.Text) ? " " : txtSrc01.Text.Trim();
                    string strReplace = string.IsNullOrEmpty(txtDest01.Text) ? " " : txtDest01.Text.Trim();
                    string destDir = $"{ txtDestBaseDir.Text.Trim()}\\{Path.GetDirectoryName(srcPath)}".Replace(strReplaced, strReplace);
                    string destFileName = $"{Path.GetFileName(srcPath).Replace(strReplaced, strReplace)}";

                    string desPath = $"{destDir}\\{destFileName}".Replace("\\E:\\", "\\"); //将中间的E:\去掉，不然是非法路径，异常提示也很让人懵逼
                    DirUtil.CreateDir(desPath);
                    FileUtils.CopyFile(srcPath, desPath);   //有时会出现错误：指定的路径或文件名太长，或者两者都太长。完全限定文件名必须少于 260 个字符，并且目录名必须少于 248 个字符
                }
                else
                {
                    string msg = $"整合目录{srcPath}不存在！\n";
                    MessageBox.Show(msg);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打开文本框中的所有文件
            foreach(string str in richCopyFiles.Text.GetSplitLineWithoutEmpty())
            {
                System.Diagnostics.Process.Start(str);
            }
        }
    }
}
