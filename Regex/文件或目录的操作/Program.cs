using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Utility;

namespace 文件或目录的操作
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRegedit();
            TestFileHelperV1();
        }
        private static void TestFileHelperV1()
        {
            FileHelper fileHelper = new FileHelper();
            string filePath = @"E:\WU\DevelpedProject\UBoardCamera\UBoardCamera\UBoardCamera\bin\Debug";
            string filePathName = @"D:\" + DateTime.Now.ToString("yyyyMMdd") + ".Txt";
            StringBuilder sb = new StringBuilder();
            foreach (string str in fileHelper.GetAllFileNames(filePath))
            {
                if (str.Contains(".dll"))
                {
                    sb.AppendLine(string.Format("listNeedCheckedFileName.Add(\"{0}\");", str));
                }
            }
            if (fileHelper.TextWriteInFile(sb.ToString(), filePathName))
            {
            }
            
            //fileHelper.StringAppendToFile(sb.ToString(), filePathName);
        }
        private void TestFileHelperV0()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            FileHelper fileHelper = new FileHelper();
            #region //目录下有哪些和哪些目录
            //Console.WriteLine(string.Format("{0}目录下有文件：", currentPath));
            //foreach (string str in fileHelper.GetFileNames(currentPath))
            //{
            //    Console.Write(string.Format("{0}\t", str));
            //}
            //Console.WriteLine();

            //Console.WriteLine(string.Format("{0}目录下有目录：", currentPath));
            //foreach (string str in fileHelper.GetDirectories(currentPath))
            //{
            //    Console.Write(string.Format("{0}\t", str));
            //}
            //Console.WriteLine();
            #endregion
            #region 获取目录下的所有文件
            //fileHelper.GetAllFileNames(currentPath);
            Console.WriteLine(string.Format("目录{0}下共有文件：", currentPath));
            foreach (string str in fileHelper.GetAllFileNames(currentPath))
            {
                Console.Write(string.Format("{0}\t", str));
            }
            #endregion
            Console.ReadLine();
        }
        private static void TestRegedit()
        {
            RegistryKey BaseRK = Registry.CurrentUser;
            string strItemName = "SOFTWARE\\Item1";
            RegeditUtil regeditUtil = new RegeditUtil(BaseRK, true, strItemName);
            if (regeditUtil.RegeditItemExist(strItemName))
            {   //存在CurrentUser\\{strItemName}项
            }
            else
            {   //不存在
            }
            if (regeditUtil.RegeditKeyExist("Key1"))
            {
            }
        }
        private static void TestRegeditV0()
        {
            RegistryKey baseRK = Registry.CurrentUser;
            baseRK.Close();
            string[] strArray = baseRK.GetSubKeyNames();    //close注册表root下的节点不影响其节点
            string ItemName = "A-rkTestV2";
            string strOperRK = "\\SOFTWARE\\ABC\\" + ItemName;
            baseRK.Close();
            RegistryKey rkOpering = baseRK.CreateSubKey(strOperRK);
            //bool isA = IsKeyValueExist(strOperRK, "");
            //baseRK.Close();
            //rkOpering.Close();  //关闭后，会造成其SetValue出现错误
            //rkOpering.SetValue("keyA1", "valueA10");
            //rkOpering.SetValue("keyA2", "valueA11");
            rkOpering.DeleteValue("keyA1"); //删除键名称为keyA1的键
        }
        /// <summary>
         /// 判断注册表项是否存在
         /// </summary>
         /// <returns>bool</returns>
        private static bool IsRegeditItemExist(string strOperRK, string strRKName)
        {
            string[] subkeyNames;
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.OpenSubKey(strOperRK);
            subkeyNames = software.GetSubKeyNames();
            //在这里我是判断test表项是否存在
            foreach (string keyName in subkeyNames)
            {
                if (keyName == strRKName)
                {
                    key.Close();
                    return true;
                }
            }
            key.Close();
            return false;
        }
        /// <summary>
        /// 判断值是否存在
        /// </summary>
        /// <returns>bool</returns>
        private static bool IsKeyValueExist(string strOperRK, string strKeyValue)
        {
            string[] subkeyNames;
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.OpenSubKey(strOperRK);
            subkeyNames = software.GetValueNames();
            //在这里我是判断test表项是否存在
            foreach (string keyName in subkeyNames)
            {
                if (software.GetValue(keyName, "").ToString() == strKeyValue)
                {
                    key.Close();
                    return true;
                }
            }
            key.Close();
            return false;
        }
    }

}
