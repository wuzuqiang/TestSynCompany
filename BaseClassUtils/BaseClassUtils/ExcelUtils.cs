using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
    public class ExcelUtils
    {
        #region Enum
        public enum ExceType
        {
            Excel2003 = 0,
            Excel2007 = 1
        }
        #endregion

        #region Enum ToString
        public static string getExcelExtesion(object excelType)
        {
            string strTemp = "";
            switch ((int)excelType)
            {
                case 0:
                    strTemp = ".xls";
                    break;
                case 1:
                    strTemp = ".xlsx";
                    break;
            }
            return strTemp;
        }
        #endregion

        
        public static bool IsExcelFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath);
            if (ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2003) == fileExtension || ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2007) == fileExtension)
            {
                return true;
            }
            return false;
        }

        public static List<string> GetXlsxSheetnames(string filePath, out string message)
        {
            message = "success";
            List<string> listSheetname = new List<string>();
            if (ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2007) != Path.GetExtension(filePath))
            {
                message = "文件格式不为Excel2007";
                return new List<string>();
            }
            FileStream fileStream = null;
            try
            {
                fileStream = File.OpenRead(filePath);
            }
            catch (IOException ex)
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
                foreach (var worksheet in package.Workbook.Worksheets)
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
                for (int i = 1; i <= lastColumn; i++)
                {
                    dtWorksheet.Columns.Add($"colum-{i}");
                }
                for (int row = 1; row <= lastRow; row++)
                {
                    DataRow dr = dtWorksheet.NewRow();
                    for (int column = 1; column <= lastColumn; column++)
                    {
                        dr[column - 1] = worksheet.GetValue(row, column);
                    }
                    dtWorksheet.Rows.Add(dr);
                }
                dsExcel.Tables.Add(dtWorksheet);
            }
            return dsExcel;
        }
    }
}
