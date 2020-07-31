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
            string extraTips = string.IsNullOrEmpty(msg) ? " " : $"但出现异常：\n{msg}";
            MessageBox.Show("恭喜！操作成功！" + extraTips);
        }

        private void CheckDestDir()
        {
            string strDestBaseDir = txtDestDir.Text;
            if (Directory.Exists(strDestBaseDir))
            {
                if (DialogResult.OK == MessageBox.Show("已存在目录" + "是否先连子目录也删除？\n" + strDestBaseDir, "目录已存在！是否先连子目录也删除？", MessageBoxButtons.OKCancel))
                {
                    DirUtil.DeleteDirRecursive(strDestBaseDir);
                }
            }
        }

        private string getDestPath(string strDestBaseDir, string srcPath)
        {
            string destPath = $"{ strDestBaseDir.Trim()}\\";
            if (cbxIsNeedAddBaseDir.Checked)
            {   //通用目录不考虑
                var tempPath = $"{srcPath.Trim()}";
                destPath += tempPath.Replace(txtBaseDir.Text + "\\", "").Replace(":\\", "__\\"); //将中间的E:\去掉，不然是非法路径，异常提示也很让人懵逼
                if (cbxExtraCopyFunc01.Checked)
                {
                    destPath = destPath.Replace(txtSrc01.Text.Trim(), txtDest01.Text.Trim());
                }
            }
            if (!cbxIsNeedAddBaseDir.Checked)
            {
                var tempPath = $"{srcPath.Trim()}";
                destPath += tempPath.Replace(":\\", "__\\");
            }
            return destPath;
        }

        private void CopyFile(List<string> listSrcPath, string strDestBaseDir, ref string msg)
        {//将这些路径下的文件都复制到目录strDestBaseDir下
            List<string> listDestPath = new List<string>();
            foreach (string srcPath in listSrcPath)
            {
                if (DirUtil.IsFileDirectory(srcPath))
                {
                    //listPath.Add(srcPath);
                    listDestPath.Add(getDestPath(strDestBaseDir, srcPath));
                }
                else
                {
                    msg += $"源文件路径：{srcPath}不存在！\n";
                }
            }

            CopyFile(listSrcPath, listDestPath);
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
                    listDestPath.Add(getDestPath(txtDestDir.Text, srcPath));
                }
                else
                {
                    string msg = $"整合目录{srcPath}不存在！\n";
                    MessageBox.Show(msg);
                }
            }

            CopyFile(listSrcPath, listDestPath);

            richCopyFiles.Text = "";
            foreach(string path in listDestPath)
            {
                richCopyFiles.Text += $"{path}\n";
            }
            cbxIsNeedAddBaseDir.Checked = false;

            MessageBox.Show("恭喜！操作成功！");
        }

        private void CopyFile(List<string> listSrcPath, List<string> listDestPath)
        {
            if (listSrcPath.Count() != listDestPath.Count())
                throw new Exception("抱歉！源路径和目标路径数不相等！无法一一复制！");
            for (int i = 0; i < listSrcPath.Count(); i++)
            {   //请保证来源路径和目标路径是一一对应的
                DirUtil.CreateDir(listDestPath[i]);
                FileUtils.CopyFile(listSrcPath[i], listDestPath[i]);   //有时会出现错误：指定的路径或文件名太长，或者两者都太长。完全限定文件名必须少于 260 个字符，并且目录名必须少于 248 个字符
            }
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
                fileInfos = fileInfos.Where(w => w.LastWriteTime >= txtMinTime.Text.ToDateTime());
            }
            if (cbxTimeLessThan.Checked)
            {
                fileInfos = fileInfos.Where(w => w.LastWriteTime <= txtMaxTime.Text.ToDateTime());
            }
            if(cbxFileNameContain.Checked)
            {
                fileInfos = fileInfos.Where(w => w.Name.Contains(txtContainFileName.Text));
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

        private void btnSaveFilterCondition_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicFilterCondition = new Dictionary<string, string>();
            dicFilterCondition.Add(txtContainContent.Name, txtContainContent.Text);
            dicFilterCondition.Add(txtContainFileName.Name, txtContainFileName.Text);
            dicFilterCondition.Add(txtMinTime.Name, txtMinTime.Text);
            dicFilterCondition.Add(txtMaxTime.Name, txtMaxTime.Text);
            string content = JsonHelper.SerializeObject<Dictionary<string, string>>(dicFilterCondition);

            var savePath = WinFormUtil.ShowOpenFileDialog(AppDomain.CurrentDomain.BaseDirectory, $"initCofig.wuconfig", "搜索配置文件|*.wuconfig") ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"initCofig.wuconfig");
            FileUtils.WriteToFile(savePath, content);

            MessageBox.Show("恭喜！保存成功！");
        }

        private void btnRestoreFilterCondition_Click(object sender, EventArgs e)
        {
            var savePath = WinFormUtil.ShowOpenFileDialog(AppDomain.CurrentDomain.BaseDirectory, $"initCofig.wuconfig", "搜索配置文件|*.wuconfig") ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"initCofig.wuconfig");
            var fileContent = FileUtils.ReadFileByStreamReader(savePath);
            var dicConfigCondition = JsonHelper.DeserializeObject<Dictionary<string, string>>(fileContent);
            txtMaxTime.Text = dicConfigCondition[txtMaxTime.Name];
            txtMinTime.Text = dicConfigCondition[txtMinTime.Name];
            txtContainFileName.Text = dicConfigCondition[txtContainFileName.Name];
            txtContainContent.Text = dicConfigCondition[txtContainFileName.Name];
        }

        private void dptMinTime_ValueChanged(object sender, EventArgs e)
        {
            txtMinTime.Text = dptMinTime.Text;
        }

        private void dptMaxTime_ValueChanged(object sender, EventArgs e)
        {
            txtMaxTime.Text = dptMaxTime.Text;
        }
    }
}
