﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using System.Data;
using System.Data.OleDb;

namespace BaseClassUtils
{
    public class FileUtils 
    {
        #region string字符串的文件类型校验
        public static void CheckedFile(string srcFileFullName)
        {
            string dirName = Path.GetDirectoryName(srcFileFullName + "a.txt");
            if (Directory.Exists(srcFileFullName) || srcFileFullName == dirName)
            {
                throw new Exception($"抱歉，文件：{srcFileFullName}非文件类型(明显是目录)！请检查！");
            }
        }
        #endregion

        #region 文件的新建、打开、复制、移动

        public static void CopyFile(string srcFileFullName, string destFileFullName)
        {
            CheckedFile(srcFileFullName);
            File.Copy(srcFileFullName, destFileFullName);
        }

        public void copyAllFile(string[] fileFullNames)
        {
            foreach (string fileFullName in fileFullNames)
            {
                //先针对一个点解决E:\useful\Thkj-Resource\origin\Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\Brand1s\Brand1Model.cs;
                //=>~\Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\Brand1s\Brand1Model.cs;
                string fileCopyDestPath = fileFullName.Replace(@"E:\useful\Thkj-Resource\origin\", AppDomain.CurrentDomain.BaseDirectory);
                Directory.CreateDirectory(Path.GetDirectoryName(fileCopyDestPath));
                File.Copy(fileFullName, fileCopyDestPath);
            }
        }

        public void copyFile(string fileFullName, string product, string brand1)
        {
            //先针对一个点解决D:\workspace\\Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\Brand1s\Brand1Model.cs;
            //=>~\Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\Brand1s\Brand1Model.cs;
            string orginBaseDir = @"D:\workspace\";
            string fileCopyDestPath = fileFullName.Replace(orginBaseDir, AppDomain.CurrentDomain.BaseDirectory).Replace("Product", product).Replace("Brand1", brand1);
            Directory.CreateDirectory(Path.GetDirectoryName(fileCopyDestPath));
            File.Copy(fileFullName, fileCopyDestPath);
        }

        public void openFile(string fileFullName, string product, string brand1)
        {
            string orginBaseDir = @"D:\workspace\";
            string fileCopyDestPath = fileFullName.Replace(orginBaseDir, AppDomain.CurrentDomain.BaseDirectory).Replace("Product", product).Replace("Brand1", brand1);
            if (string.IsNullOrEmpty(fileCopyDestPath))
            {
                return;
            }
            System.Diagnostics.Process.Start(fileCopyDestPath);
        }

        public static void OpenFileIfnotthencreat(string filePath, bool isCreateIfNotExist = true)
        {
            if(isCreateIfNotExist)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            System.Diagnostics.Process.Start(filePath);
        }

        public static void ChangeFileName(string srcFileLocationDir, string srcFileName, string destFileName)
        {
            string srcFilePath = Path.Combine(srcFileLocationDir, srcFileName);
            string destFilePath = Path.Combine(srcFileLocationDir, destFileName);
            File.Copy(srcFilePath, destFilePath);
            File.Delete(srcFilePath);
        }
        #endregion

        public static Encoding GetFileEncoding(string filePath)
        {
            Encoding Result = null;
            FileInfo info = new FileInfo(filePath);
            FileStream fs = default(FileStream);
            try
            {
                fs = info.OpenRead();
                Encoding[] unicodeEncodings =
                {
                    Encoding.BigEndianUnicode,
                    Encoding.Unicode,
                    Encoding.UTF8,
                    Encoding.UTF32,
                    Encoding.UTF7,
                    new UTF32Encoding(true,true)
                };
                for (int i = 0; Result == null && i < unicodeEncodings.Length; i++)
                {
                    fs.Position = 0;
                    byte[] preamble = unicodeEncodings[i].GetPreamble();
                    bool isEqual = true;
                    for (int j = 0; isEqual && j < preamble.Length; j++)
                    {
                        isEqual = preamble[j] == fs.ReadByte();
                    }
                    if (isEqual)
                        Result = unicodeEncodings[i];

                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();//包括了Dispose,并通过GC强行释放资源
                }
            }
            if (object.ReferenceEquals(null, Result))
            {
                Result = Encoding.Default;
            }
            return Result;
        }

        #region 文件的读、写
        #region 读取文件

        public static string ReadFileByStreamReader(string path, string encoding = "UTF-8")
        {
            string fileData = string.Empty;
            try
            {   ///读取文件的内容    
                StreamReader reader = new StreamReader(path, Encoding.GetEncoding(encoding));
                fileData = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }  ///抛出异常    
            return fileData;
        }
        #endregion
        public string ReadFileByFileStream(string filePath, string encoding = "UTF-8")
        {
            string strContent = "";
            using (FileStream fsRead = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                int iFileLength = fsRead.Length.ToString().ToInt32();
                byte[] byteFile = new byte[iFileLength];
                fsRead.Read(byteFile, 0, iFileLength);
                strContent = Encoding.GetEncoding(encoding).GetString(byteFile);
            }
            return strContent;
        }

        /// <summary>
        /// 读取文件，跳过skipRowIndex行，读取takeRowNum行文件内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="skipRowIndex"></param>
        /// <param name="takeRowNum"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadMultiLines(string filePath,int skipRowIndex = 0, int takeRowNum = 100, string encode="UTF-8")
        {
            var lines = File.ReadLines(filePath, Encoding.GetEncoding(encode)).Skip(skipRowIndex).Take(takeRowNum);
            return lines;
        }

        /// <summary>
        /// 读取文件所有内容，大文件也没问题
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="rowNumEveryTime">每次读取行数</param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static List<string> ReadAllText(string filePath, int rowNumEveryTime = 100, string encode = "UTF-8")
        {
            try
            {
                List<string> listFileContent = new List<string>();
                int totalRows = File.ReadLines(filePath).Count();
                int _currentLine = 0;
                //string headerLine = File.ReadLines(filePath).FirstOrDefault(); // Read the first row for headings
                int readTime = totalRows / rowNumEveryTime + 1;
                for(int i = 0; i <= readTime; i++)
                {
                    if(totalRows < (_currentLine+1)*rowNumEveryTime)    //将要读取的行数大于总数，则缩小每次读取次数
                    {
                        rowNumEveryTime = totalRows % rowNumEveryTime;
                    }
                    listFileContent.AddRange(ReadMultiLines(filePath, _currentLine, rowNumEveryTime, encode));
                    _currentLine += rowNumEveryTime;
                }
                return listFileContent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 清空文件，并写入内容
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="content"></param>
        public static void WriteToFile(string fileFullName, string content, string encoding="UTF-8")
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileFullName));
            File.WriteAllBytes(fileFullName, Encoding.GetEncoding(encoding).GetBytes(content));
        }

        /// <summary>
        /// 清空文件，并写入内容
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="contents"></param>
        /// <param name="encoding"></param>
        public static void WriteAllLines(string fileFullName, List<string> contents, string encoding = "UTF-8")
        {
            if(Directory.Exists(fileFullName))
            {
                Directory.Delete(fileFullName);
            }
            File.WriteAllLines(fileFullName, contents, Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// 不清空文件，并写入内容
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="content"></param>
        public static void AppendAllText(string fileFullName, string content, string encoding = "UTF-8")
        {
            File.AppendAllText(fileFullName, content, Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// 不清空文件，并写入内容
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="contents"></param>
        /// <param name="encoding"></param>
        public static void AppendAllText(string fileFullName, List<string> contents, string encoding = "UTF-8")
        {
            File.AppendAllLines(fileFullName, contents, Encoding.GetEncoding(encoding));
        }
        #endregion


        /// <summary>
        /// 获取整理后的文件信息
        /// </summary>
        /// <param name="fileSystemInfos"></param>
        /// <param name="isContainBaseDir"></param>
        /// <param name="baseDir"></param>
        /// <param name="isContainSerialNumber"></param>
        /// <param name="isContainFileName"></param>
        /// <param name="isContainFilePath"></param>
        /// <param name="isContainCreateTime"></param>
        /// <returns></returns>
        public static List<string> GetCollateFileSystemInfo(List<FileSystemInfo> fileSystemInfos, bool isContainBaseDir = true, string baseDir = " ", bool isContainSerialNumber = false
            , bool isContainFileName = true, bool isContainFilePath = true, bool isContainCreateTime = false,bool isContainLastTime = false)
        {
            List<string> contents = new List<string>();
            int iIndex = 1;
            foreach (var fileInfo in fileSystemInfos)
            {
                StringBuilder rowContent = new StringBuilder();
                if (isContainFilePath)
                {
                    rowContent.Append($"{fileInfo.FullName}，");
                }
                if (isContainFilePath && !isContainBaseDir)
                {   //都不包含文件全路径，何谈是否包含根目录
                    rowContent = rowContent.Replace(baseDir, " ");
                }
                if (isContainCreateTime)
                {
                    rowContent.Append($"{fileInfo.CreationTime.ToString("yyyy--MM--dd")}，");
                }
                if (isContainLastTime)
                {
                    rowContent.Append($"{fileInfo.LastWriteTime.ToString("yyyy--MM--dd")}，");
                }
                if (isContainFileName)
                {
                    rowContent.Insert(0, $"{fileInfo.Name}, ");
                }
                if (isContainSerialNumber)
                {
                    rowContent.Insert(0, $"{(iIndex++).ToString().PadLeft(4)}, ");
                }
                contents.Add(rowContent.ToString());
            }
            return contents;
        }

    }
}
