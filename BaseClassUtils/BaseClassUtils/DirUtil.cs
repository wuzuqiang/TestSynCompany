using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace BaseClassUtils
{
    public class DirUtil
    {
        public void recycleChangeDir(string path, string match, string toMatch)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileSystemInfo[] fileSysArray = directoryInfo.GetFileSystemInfos();
            foreach(FileSystemInfo info in fileSysArray)
            {
                if(info is DirectoryInfo)
                {
                    recycleChangeDir(info.FullName, match, toMatch);
                }
                else
                {
                    if(info.FullName.Contains(match))
                    {
                        File.Move(info.FullName, info.FullName.Replace(match, toMatch));
                    }
                }
            }
        }

        /// <summary>
        /// 是否是文件目录，不包含\字符也不算
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFileDirectory( string path)
        {
            if(!path.Contains("\\"))
            {
                return false;
            }
            try
            {
                Path.GetDirectoryName(path);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static FileInfo[] getAllFile(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles("*", SearchOption.AllDirectories);
        }

        public FileInfo[] getAllFile(string path, string contained)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles("*"+contained+"*", SearchOption.AllDirectories);
        }

        public DirectoryInfo[] getAllDir(string path)
        {
            return (new DirectoryInfo(path)).GetDirectories("*", SearchOption.AllDirectories);
        }

        /// <summary>
        /// 依据文件名称，创建文件所需目录
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateDir(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        public static void DeleteDirRecursive(string dirPath)
        {
            Directory.Delete(dirPath, true);
        }

        public List<string> get第二级别下各自的一行目录或者文件(string path)
        {
            List<string> listFile = new List<string>();
            //d:\aa\bb\cc\dd\ee\ff\gg
            //需要得到类似d:\aa\bb\cc[.txt]的字符串
            string pattern = @"\w+:\\\w+\\\w+";
            //string input = @"d:\aa\bb\cc\dd\ee\ff\gg";
            Regex regex = new Regex(pattern);
            MatchCollection matchs = regex.Matches(path);
            if(matchs.Count > 0)
            {
                path = matchs[0].Value;
            }
            else
            {
                throw new Exception(string.Format("未能匹配到路径：{0}的第二级别路径名", path));
            }

            return listFile;
        }

        static List<FileSystemInfo> fileSystemInfos = new List<FileSystemInfo>();
        public static List<FileSystemInfo> GetAllFileSystemInfo(string path)
        {
            FileSystemInfo[] fileSysArray = (new DirectoryInfo(path)).GetFileSystemInfos();
            foreach (FileSystemInfo info in fileSysArray)
            {
                if (info is DirectoryInfo)
                {
                    GetAllFileSystemInfo(info.FullName);
                }
                else
                {
                    fileSystemInfos.Add(info);
                }
            }
            return fileSystemInfos;
        }
        

    }
}
