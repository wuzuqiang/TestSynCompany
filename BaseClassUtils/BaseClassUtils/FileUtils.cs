using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using System.Data;

namespace BaseClassUtils
{
    public class FileUtils
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


        /// <summary>
        /// 向文件中写入内容
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="content"></param>
        public void writeAppendFile(string fileFullName, string[] contents)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileFullName));
            File.AppendAllLines(fileFullName, contents, Encoding.UTF8);
        }

        public static void ExecFile(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            System.Diagnostics.Process.Start(filePath);
        }

        

        public static DataSet GetExcelDataSet(string filePath)
        {
            DataSet ds = new DataSet();
            #region check file if exists
            FileStream stream = null;
            try
            {
                //stream = new FileStream(dialog.FileName, FileMode.Open);
                stream = File.OpenRead(filePath);
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
            #endregion
            
            #region read excel
            using (stream)
            {
                ExcelPackage package = new ExcelPackage(stream);

                ExcelWorksheet sheet = package.Workbook.Worksheets[1];
                #region check excel format
                if (sheet == null)
                {

                    throw new Exception("sheet == null");
                }
                #endregion

                #region get last row index
                int lastRow = sheet.Dimension.End.Row;
                int lastColumn = sheet.Dimension.End.Column;
                int maxDrColumn = 0;
                while (sheet.Cells[lastRow, 1].Value == null)
                {
                    lastRow--;
                }
                #endregion

                DataTable dt = new DataTable();
                #region read datas
                int titleRowindex = 3;  //从第三行开始摆标题，第一行是数据检索sql，第二行隔开
                StringBuilder sb = new StringBuilder();
                for (int j1 = 1; j1 <= lastColumn; j1++)
                {
                    try
                    {
                        dt.Columns.Add(sheet.Cells[titleRowindex, j1].Value.ToString());
                        maxDrColumn = j1-1;
                    }
                    catch
                    {
                        sb.AppendLine($"DataRow{j1-1}列，标题为空！");
                    }
                }
                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    throw new Exception(sb.ToString());
                }

                for (int i = 3; i <= lastRow; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j <= maxDrColumn; j++)
                    {
                        dr[j] = sheet.Cells[i, j+1].Value;
                    }
                    dt.Rows.Add(dr);
                }
                #endregion
                ds.Tables.Add(dt);
            }
            #endregion
            return ds;
        }
    }
}
