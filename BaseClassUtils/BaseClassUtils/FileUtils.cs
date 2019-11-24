using System;
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
        public static object ExcelEnum { get; private set; }

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

        public static void OpenFileIfnotthencreat(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            System.Diagnostics.Process.Start(filePath);
        }

        
        public static List<string> GetSheetnames(string filePath, out string message)
        {
            message = "success";
            List<string> listSheetname = new List<string>();
            if (!IsExcelFile(filePath))
            {
                return new List<string>();
            }
            if (ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2003) == Path.GetExtension(filePath))
            {
                listSheetname = GetXlsSheetnames(filePath, out message);
            }
            else if(ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2007) == Path.GetExtension(filePath))
            {
                listSheetname = GetXlsxSheetnames(filePath,out message);
            }
            return listSheetname;
        }

        public static List<string> GetXlsSheetnames(string filePath, out string message)
        {
            message = "success";
            List<string> listSheetname = new List<string>();
            string fileExtension = Path.GetExtension(filePath);
            if (".xls" == fileExtension)
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
                //connectstring = "Provider=Microsoft.ACE.OLEDB.12.0; data source=" + excelPath + ";Extended Properties='Excel 12.0 Xml; HDR=" + hdr + "; IMEX=" + imex.GetHashCode() + "'";
                OleDbConnection conn = new OleDbConnection(strConn);
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                    foreach (DataRow dr in schemaTable.Rows)
                    {
                        listSheetname.Add(dr[2].ToString().Trim());
                    }
                    //string tableName = schemaTable.Rows[0][2].ToString().Trim();

                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    listSheetname = new List<string>();
                }
                finally
                {
                    conn.Close();
                }
            }
            return listSheetname;
        }

        public static List<string> GetXlsxSheetnames(string filePath, out string message)
        {
            message = "success";
            List<string> listSheetname = new List<string>();
            if(ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2007) != Path.GetExtension(filePath))
            {
                message = "文件格式不为Excel2007";
                return new List<string>();
            }
            FileStream fileStream = null;
            try
            {
                fileStream = File.OpenRead(filePath);
            }
            catch(IOException ex)
            {
                message = ex.Message;
                return new List<string>();
            }
            finally
            {
                int a = 2;
            }
            using (fileStream)
            {
                ExcelPackage package = new ExcelPackage(fileStream);
                foreach(var worksheet in package.Workbook.Worksheets)
                {
                    listSheetname.Add(worksheet.Name);
                }
            }
            return listSheetname;
        }

        public static DataSet getXlsData(string filePath, string workbookName)
        {
            DataSet dsXls = new DataSet();
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                OleDbDataAdapter myDa = new OleDbDataAdapter($"select * from [{workbookName}]", conn);
                myDa.Fill(dsXls);
            }
            finally
            {
            }
            return dsXls;
        }

        public static DataSet getXlsxExcelData(string filePath, string workbookName)
        {
            DataSet dsExcel = new DataSet();
            FileStream fileStream = null;
            fileStream = File.OpenRead(filePath);
            using (fileStream)
            {
                ExcelPackage package = new ExcelPackage(fileStream);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[workbookName];
                int lastRow = worksheet.Dimension.End.Row;
                int lastColumn = worksheet.Dimension.End.Column;
                DataTable dtWorksheet = new DataTable("workSheet");
                for(int i = 1; i <= lastColumn; i++)
                {
                    dtWorksheet.Columns.Add($"colum-{i}");
                }
                for(int row = 1; row <= lastRow; row++)
                {
                    DataRow dr = dtWorksheet.NewRow();
                    for(int column = 1; column <= lastColumn; column++)
                    {
                        dr[column-1] = worksheet.GetValue(row, column);
                    }
                    dtWorksheet.Rows.Add(dr);
                }
                dsExcel.Tables.Add(dtWorksheet);
            }
            return dsExcel;
        }

        public static bool IsExcelFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            if(ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2003) == fileExtension || ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2007) == fileExtension)
            {
                return true;
            }
            return false;
        }
    }
}
