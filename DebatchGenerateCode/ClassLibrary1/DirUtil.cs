using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    class DirUtil
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
                        //File.Move(info.FullName, info.FullName.Replace(match, toMatch));
                    }
                }
            }
        }

        public static List<string> listFile = new List<string>();
        public FileInfo[] recycleGetFile(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles("*", SearchOption.AllDirectories);
            FileSystemInfo[] fileSysArray = directoryInfo.GetFileSystemInfos();
            foreach (FileSystemInfo info in fileSysArray)
            {
                if (info is DirectoryInfo)
                {
                    recycleGetFile(info.FullName);
                }
                else
                {
                    listFile.Add(info.FullName);
                }
            }
        }
    }
}
