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
        {
            bool isNeedAddBaseDir = cbxIsNeedAddBaseDir.Checked;
            string needCopyFiles = richCopyFiles.Text;
            string msg = "";
            CopyFile(needCopyFiles, isNeedAddBaseDir,ref msg);
            string extraTips = string.IsNullOrEmpty(msg) ? " " : $"但出现异常：{msg}";
            MessageBox.Show("恭喜！操作成功！" + extraTips);
        }

        private void CopyFile(string needCopyFiles, bool isNeedAddBaseDir, ref string msg)
        {//将这些路径下的文件都复制到目录
            if(Directory.Exists(txtDestBaseDir.Text))
            {
                if(DialogResult.OK == MessageBox.Show("已存在目录" + "是否先连子目录也删除？\n" + txtDestBaseDir.Text, "目录已存在！是否先连子目录也删除？", MessageBoxButtons.OKCancel))
                {
                    DirUtil.DeleteDirRecursive(txtDestBaseDir.Text);
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
                    string desPath = $"{ txtDestBaseDir.Text.Trim()}\\{str.Trim().Replace(":\\", "")}";
                    DirUtil.CreateDir(desPath);
                    CopyFile(srcPath, desPath);
                }
                else
                {
                    msg += $"整合目录{srcPath}不存在！\n";
                }
            }
        }
        private void CopyFile(string src, string des)
        {
            if(File.Exists(src))
            {
                throw new Exception($"抱歉，文件：{src}不存在！请检查！");
            }
            File.Copy(src, des);
        }

        private void FrmCopyFile_Load(object sender, EventArgs e)
        {
            txtDestBaseDir.Text = AppDomain.CurrentDomain.BaseDirectory + $"{DateTime.Now.ToString("yyyy-MM-dd")}";
        }
    }
}
