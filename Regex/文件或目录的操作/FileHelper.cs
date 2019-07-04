using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件或目录的操作
{
    public class FileHelper
    {
        #region 通用文件参数，比如写入字符串
        /// <summary>
        /// 将字符串写入文件
        /// </summary>
        /// <param name="writeText">要写入的文本</param>
        /// <param name="filePathName"></param>
        /// <param name="isAppend">是否追加到文件末尾</param>
        /// <returns></returns>
        public bool TextWriteInFile(string writeText, string filePathName, bool isAppend = true)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(filePathName, isAppend, Encoding.Default);
                streamWriter.Write(writeText);
                streamWriter.Flush();
                streamWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TextWriteInFile(List<string> listWriteText, string filePathName, bool isAppend = true)
        {
            try
            {
                foreach (string writeText in listWriteText)
                {
                    StreamWriter streamWriter = new StreamWriter(filePathName, isAppend, Encoding.Default);
                    streamWriter.WriteLine(writeText);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region 目录结合文件
        /// <summary>
        /// 获取目录下的所有文件
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private List<string> GetFileNames(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            FileInfo[] fileInfo = dir.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (FileInfo item in fileInfo)
            {
                fileNames.Add(item.Name);
            }
            return fileNames;
        }

        /// <summary>
        /// 获取目录下的所有目录
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private List<string> GetDirectories(string dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            DirectoryInfo[] dirInfos = dir.GetDirectories();
            List<string> dirNames = new List<string>();
            foreach (DirectoryInfo item in dirInfos)
            {
                dirNames.Add(item.Name);
            }
            return dirNames;
        }

        private List<string> listAllFileNames = new List<string>();
        private void SetListAllFileNames(string dirPath)
        {
            foreach (string str in GetFileNames(dirPath))
            {
                listAllFileNames.Add(str);
            }
            List<string> listCurrentDirs = new List<string>();
            listCurrentDirs = GetDirectories(dirPath);
            if (0 == listCurrentDirs.Count)
            {
                return;
            }
            foreach (string str in listCurrentDirs)
            {
                SetListAllFileNames(Path.Combine(dirPath, str));
            }
        }

        /// <summary>
        /// 获取目录下的所有文件
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public List<string> GetAllFileNames(string dirPath)
        {
            listAllFileNames = new List<string>();
            if (!IsDir(dirPath))
            {
                return listAllFileNames;
            }
            SetListAllFileNames(dirPath);
            return listAllFileNames;
        }

        public bool IsDir(string path)
        {
            if (Directory.Exists(path))
            {   //文件夹
                return true;
            }
            return false;
        }
        #endregion
    }
}
