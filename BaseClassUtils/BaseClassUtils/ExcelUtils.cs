using System;
using System.Collections.Generic;
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
    }
}
