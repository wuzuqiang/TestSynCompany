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
            CheckDestDir();
            List<string> listSrcPath = new List<string>();
            listSrcPath = GetListSrcCopyFile(richCopyFiles.Text, cbxIsNeedAddBaseDir.Checked);

            string msg = "";
            CopyFile(listSrcPath, txtDestDir.Text, ref msg);
            string extraTips = string.IsNullOrEmpty(msg) ? " " : $"但出现异常：{msg}";
            MessageBox.Show("恭喜！操作成功！" + extraTips);
        }

        private void CheckDestDir()
        {
            string strDestBaseDir = txtBaseDir.Text;
            if (Directory.Exists(strDestBaseDir))
            {
                if (DialogResult.OK == MessageBox.Show("已存在目录" + "是否先连子目录也删除？\n" + strDestBaseDir, "目录已存在！是否先连子目录也删除？", MessageBoxButtons.OKCancel))
                {
                    DirUtil.DeleteDirRecursive(strDestBaseDir);
                }
            }
        }

        private void CopyFile(List<string> listSrcPath, string strDestBaseDir, ref string msg)
        {//将这些路径下的文件都复制到目录strDestBaseDir下
            foreach (string srcPath in listSrcPath)
            {
                if (DirUtil.IsFileDirectory(srcPath))
                {
                    //listPath.Add(srcPath);
                    string desPath = $"{ strDestBaseDir.Trim()}\\{srcPath.Trim().Replace(":\\", "__\\")}";
                    DirUtil.CreateDir(desPath);
                    FileUtils.CopyFile(srcPath, desPath);
                }
                else
                {
                    msg += $"整合目录{srcPath}不存在！\n";
                }
            }
        }

        public List<string> GetListSrcCopyFile(string needCopyFiles, bool isNeedAddBaseDir)
        {
            List<string> listSrcPath = new List<string>();
            foreach (string str in needCopyFiles.GetSplitLineWithoutEmpty())
            {
                string srcPath = "";
                if (isNeedAddBaseDir)
                {
                    if(str.Length > 2)
                    {
                        srcPath = Path.Combine(txtBaseDir.Text, (str.Substring(0, 2).Replace("\\", "") + str.Substring(2)).Trim());
                    }
                    else
                    {
                        srcPath = Path.Combine(txtBaseDir.Text, str.Trim());
                    }
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
            txtDestDir.Text = AppDomain.CurrentDomain.BaseDirectory + $"{DateTime.Now.ToString("yyyy-MM-dd")}";

            dptMinTime.Format = DateTimePickerFormat.Custom;
            dptMinTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dptMaxTime.Format = DateTimePickerFormat.Custom;
            dptMaxTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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
            CheckDestDir();
            List<string> listSrcPath = new List<string>();
            listSrcPath = GetListSrcCopyFile(richCopyFiles.Text, cbxIsNeedAddBaseDir.Checked);
            List<string> listDestPath = new List<string>();

            //将这些路径下的文件都复制到目录strDestBaseDir下
            foreach (string srcPath in listSrcPath)
            {
                if (DirUtil.IsFileDirectory(srcPath))
                {
                    string strReplaced = string.IsNullOrEmpty(txtSrc01.Text) ? " " : txtSrc01.Text.Trim();
                    string strReplace = string.IsNullOrEmpty(txtDest01.Text) ? " " : txtDest01.Text.Trim();
                    string destDir = $"{ txtDestDir.Text.Trim()}\\{Path.GetDirectoryName(srcPath)}".Replace(strReplaced, strReplace);
                    string destFileName = $"{Path.GetFileName(srcPath).Replace(strReplaced, strReplace)}";

                    string destPath = $"{destDir}\\{destFileName}".Replace("\\E:\\", "\\"); //将中间的E:\去掉，不然是非法路径，异常提示也很让人懵逼
                    listDestPath.Add(destPath);
                    DirUtil.CreateDir(destPath);
                    FileUtils.CopyFile(srcPath, destPath);   //有时会出现错误：指定的路径或文件名太长，或者两者都太长。完全限定文件名必须少于 260 个字符，并且目录名必须少于 248 个字符
                }
                else
                {
                    string msg = $"整合目录{srcPath}不存在！\n";
                    MessageBox.Show(msg);
                }
            }

            richCopyFiles.Text = "";
            foreach(string path in listDestPath)
            {
                richCopyFiles.Text += $"{path}\n";
            }

            MessageBox.Show("恭喜！操作成功！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打开文本框中的所有文件
            foreach(string str in richCopyFiles.Text.GetSplitLineWithoutEmpty())
            {
                if (Path.GetExtension(str) == ".resx")
                    continue;
                System.Diagnostics.Process.Start(str);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FilterFile();
        }

        private void FilterFile()
        {
            List<string> listSrcPath = GetListSrcCopyFile(richCopyFiles.Text, cbxIsNeedAddBaseDir.Checked);
            List<FileInfo> listFileInfo = filePathToFileInfo(listSrcPath);
            var filterFileInfo = GetFilterFileInfos(listFileInfo);
            if (filterFileInfo.Count() >= 2)
                richCopyFiles.Text = GetFilterFileInfos(listFileInfo).Select(s => s.FullName).Aggregate((a1, a2) => $"{a1}\n{a2}");
            else
            {
                richCopyFiles.Text = "";
                foreach (var info in filterFileInfo)
                {
                    richCopyFiles.Text += $"{info.FullName}\n";
                }
            }
        }

        private IEnumerable<FileInfo> GetFilterFileInfos(List<FileInfo> listFileInfo)
        {
            IEnumerable<FileInfo> fileInfos = listFileInfo.Where(w => true);
            if(cbxTimeGreaterThan.Checked)
            {
                string minTime = string.IsNullOrEmpty(txtMinTime.Text) ? dptMinTime.Text : txtMinTime.Text;
                fileInfos = fileInfos.Where(w => w.LastWriteTime >= minTime.ToDateTime());
            }
            if (cbxTimeLessThan.Checked)
            {
                string maxTime = string.IsNullOrEmpty(txtMaxTime.Text) ? dptMaxTime.Text : txtMaxTime.Text;
                fileInfos = fileInfos.Where(w => w.LastWriteTime <= dptMaxTime.Text.ToDateTime());
            }
            if(cbxFileNameContain.Checked)
            {
                fileInfos = fileInfos.Where(w => w.Name.Contains(txtContainStr.Text));
            }
            if(cbxContainContent.Checked)
            {
                fileInfos = fileInfos.Where(w => {
                    List<string> fileContents = FileUtils.ReadAllText(w.FullName);
                    return fileContents.Contains(txtContainContent.Text);
                });
            }
            
            return fileInfos;
        }

        private List<FileInfo> filePathToFileInfo(List<string> listPath)
        {
            List<FileInfo> listFileInfo = new List<FileInfo>();
            foreach (string path in listPath)
            {
                FileInfo fileInfo = new FileInfo(path);
                listFileInfo.Add(fileInfo);
            }
            return listFileInfo;
        }
    }
}
