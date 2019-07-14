using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    class FileUtils
    {
        /// <summary>
        /// 清空文件，并写入内容
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="content"></param>
        public void writeToFile(string fileFullName, string content)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileFullName));
            File.WriteAllBytes(fileFullName, Encoding.UTF8.GetBytes(content));
        }
    }
}
