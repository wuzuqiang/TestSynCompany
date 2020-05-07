using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace BaseClassUtils
{
    public static class StringUtils
    {
        #region 按首字母的拼音或笔画排序字符串
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="arrlist">排序字符串数组</param>
        /// <param name="type">类型：1发音，2笔画</param>
        /// <returns></returns>
        public static List<string> SortList(this List<string> arrlist, int? type = 1)
        {
            string[] arr = arrlist.ToArray();
            //发音 LCID：0x00000804
            if (type.Value == 1)
            {
                CultureInfo PronoCi = new CultureInfo(2052); //这行要不要一样，默认
                Array.Sort(arr);
            }
            else
            {
                //笔画数 LCID：0x00020804
                CultureInfo StrokCi = new CultureInfo(133124);
                Thread.CurrentThread.CurrentCulture = StrokCi;
                Array.Sort(arr);
            }
            return arr.ToList<string>();
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="arr">排序字符串数组</param>
        /// <param name="type">类型：1发音，2笔画</param>
        /// <returns></returns>
        public static string[] SortArray(this string[] arr, int? type = 1)
        {
            //发音 LCID：0x00000804
            if (type.Value == 1)
            {
                CultureInfo PronoCi = new CultureInfo(2052);//这行要不要一样，默认
                Array.Sort(arr);
            }
            else
            {
                //笔画数 LCID：0x00020804
                CultureInfo StrokCi = new CultureInfo(133124);
                Thread.CurrentThread.CurrentCulture = StrokCi;
                Array.Sort(arr);
            }
            return arr;
        }
        #endregion
        public static string DeleteNewLineCharater(this string input)
        {
            return input.Replace("\r", "").Replace("\n", "");
        }
        #region String.ToXXX()转换成某类数据
        public static Int32 ToInt32(this string input)
        {
            return Convert.ToInt32(input);
        }
        #endregion

        public static List<string> GetSplitLineWithoutEmpty(this string input)
        {
            List<string> list = new List<string>();
            foreach(string str in input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                list.Add(str);
            }
            return list;
        }

        public static List<string> GetSplitLine(string input)
        {
            List<string> list = new List<string>();
            foreach (string str in input.Split(new char[] { '\n' }))
            {
                list.Add(str);
            }
            return list;
        }

        public static Dictionary<int, string> GetSplitLine(this string input, char splitChar)
        {
            Dictionary<int, string> dicSplit = new Dictionary<int, string>();
            int rowSerial = 1;
            foreach (string str in input.Split(new char[] { splitChar }))
            {
                dicSplit.Add(rowSerial++, str);
            }
            return dicSplit;
        }

        public static string GetSameBaseDirString(this string input, string input02)
        {
            StringBuilder sbSame = new StringBuilder();
            int iMaxSame = 0;
            for(int i= 0; i < 1; i++)
            {
                for(int j=1; (i+j) < input.Count(); j++)
                {
                    string matchedString = input.Substring(i, j);
                    if (input02.Contains(matchedString))
                    {
                        sbSame = new StringBuilder(matchedString);
                        iMaxSame = matchedString.Count();
                        break;
                    }
                }
                if(iMaxSame > 0)
                {
                    break;
                }
            }
            return sbSame.ToString();
        }

        public static string GetStringAfterDeleteDriveString(this string input)
        {
            return input.Replace("C:\\", " ").Replace("D:\\", " ").Replace("E:\\", " ");
        }

        public static bool isMatch(string fileSuffix, string strContained)
        {
            bool isMatch = false;
            List<string> listMatched = new List<string>();
            foreach(string str in strContained.Split('|'))
            {
                if(fileSuffix.Contains(str))
                {
                    return true;
                }
            }
            return isMatch;
        }

        public static string ToTranslateRegexStr(this string input)
        {
            string strNeedTransferInReg = "*, ., [, ], {, }, ^, $";
            string strTemp = input;
            foreach (string strSplit in strNeedTransferInReg.Split(','))
            {
                if (!string.IsNullOrEmpty(strSplit))
                {
                    strTemp = strTemp.Replace(strSplit.Trim(), $"\\{strSplit.Trim()}");
                }
            }
            return strTemp;
        }

        /// <summary>
        /// 加密input中的特殊字符
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToEncryInneredParticularWord(this string input)
        {
            StringBuilder sbTemp = new StringBuilder(input);
            foreach (string strSplit in strNeedTransferInReg.Split(','))
            {
                if (!string.IsNullOrEmpty(strSplit))
                {
                    listNeedTransferInReg.Add(strSplit.Trim());
                }
            }
            foreach (string strSplit in strCanTransferInReg.Split(','))
            {
                if (!string.IsNullOrEmpty(strSplit))
                {
                    listCanTransferInReg.Add(strSplit.Trim());
                }
            }
            for(int i = 0; i < listNeedTransferInReg.Count; i++)
            {
                sbTemp = sbTemp.Replace(listNeedTransferInReg[i], listCanTransferInReg[i]);
            }
            return sbTemp.ToString();
        }

        /// <summary>
        /// 通配符，不仅仅限制于Reg表达式
        /// </summary>
        static string strNeedTransferInReg = "*     , .     , [      , ]      , {      , }     , ^       , $     ,<    ,>    ,?";
        static List<string> listNeedTransferInReg = new List<string>();
        static string strCanTransferInReg = "-__0__-, __1__-, -__2__-, -__3__-, -__4__-,- __5__-, -__6__-,-__7__-,-_8_-,-_9_-,-_10_-,";
        static List<string> listCanTransferInReg = new List<string>();
        /// <summary>
        /// 解密input中的特殊字符
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToDecodeInneredParticularWord(this string input)
        {
            StringBuilder sbTemp = new StringBuilder(input);
            foreach (string strSplit in strNeedTransferInReg.Split(','))
            {
                if (!string.IsNullOrEmpty(strSplit))
                {
                    listNeedTransferInReg.Add(strSplit.Trim());
                }
            }
            foreach (string strSplit in strCanTransferInReg.Split(','))
            {
                if (!string.IsNullOrEmpty(strSplit))
                {
                    listCanTransferInReg.Add(strSplit.Trim());
                }
            }
            for (int i = 0; i < listNeedTransferInReg.Count; i++)
            {
                sbTemp = sbTemp.Replace(listCanTransferInReg[i], listNeedTransferInReg[i]);
            }
            return sbTemp.ToString();
        }
    }
}
