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

        /// <summary>
        /// 移除换行符
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DeleteNewLineCharater(this string input)
        {
            return input.Replace("\r", "").Replace("\n", "");
        }

        /// <summary>
        /// 移除字符串的最后lastNum行
        /// </summary>
        /// <param name="input"></param>
        /// <param name="lastNum">要移除最后的几行？</param>
        /// <returns></returns>
        public static string RemoveLastChar(this string input, int lastNum = 1)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            return input.Remove(input.Length - lastNum, lastNum);
        }

        /// <summary>
        /// 移除字符串的前面beforeNum行，直到字符串为空
        /// </summary>
        /// <param name="input"></param>
        /// <param name="lastNum">要移除最后的几行？</param>
        /// <returns></returns>
        public static string RemovFrontChar(this string input, int beforeNum = 1)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            return input.Remove(0, beforeNum < input.Length ? beforeNum : input.Length);
        }

        #region String.ToXXX()转换成某类数据
        public static Int32 ToInt32(this string input)
        {
            return Convert.ToInt32(input);
        }

        public static DateTime ToDateTime(this string input)
        {
            DateTime dt = DateTime.ParseExact(input, "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return dt;
		}

		public static string ToJson(this string[] input)
		{
			return JsonHelper.SerializeObject<string[]>(input);
		}

		/// <summary>
		/// 在指定的字符串列表CnStr中检索符合拼音索引字符串
		/// </summary>
		/// <param name="CnStr">汉字字符串</param>
		/// <returns>相对应的汉语拼音首字母串</returns>
		public static string GetSpellCode(string CnStr)
		{

			string strTemp = "";

			int iLen = CnStr.Length;

			int i = 0;

			for (i = 0; i <= iLen - 1; i++)
			{

				strTemp += GetCharSpellCode(CnStr.Substring(i, 1));

			}

			return strTemp;

		}

		/// <summary>
		/// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
		/// </summary>
		/// <param name="CnChar">单个汉字</param>
		/// <returns>单个大写字母</returns>

		private static string GetCharSpellCode(string CnChar)
		{
			long iCnChar;
			byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);
			//如果是字母，则直接返回
			if (ZW.Length == 1)
			{
				return CnChar.ToUpper();
			}
			else
			{
				// get the array of byte from the single char
				int i1 = (short)(ZW[0]);
				int i2 = (short)(ZW[1]);
				iCnChar = i1 * 256 + i2;
			}

			// iCnChar match the constant
			if ((iCnChar >= 45217) && (iCnChar <= 45252))
			{
				return "A";
			}
			else if ((iCnChar >= 45253) && (iCnChar <= 45760))
			{
				return "B";
			}
			else if ((iCnChar >= 45761) && (iCnChar <= 46317))
			{
				return "C";
			}
			else if ((iCnChar >= 46318) && (iCnChar <= 46825))
			{
				return "D";
			}
			else if ((iCnChar >= 46826) && (iCnChar <= 47009))
			{
				return "E";
			}
			else if ((iCnChar >= 47010) && (iCnChar <= 47296))
			{
				return "F";
			}
			else if ((iCnChar >= 47297) && (iCnChar <= 47613))
			{
				return "G";
			}
			else if ((iCnChar >= 47614) && (iCnChar <= 48118))
			{
				return "H";
			}
			else if ((iCnChar >= 48119) && (iCnChar <= 49061))
			{
				return "J";
			}
			else if ((iCnChar >= 49062) && (iCnChar <= 49323))
			{
				return "K";
			}
			else if ((iCnChar >= 49324) && (iCnChar <= 49895))
			{
				return "L";
			}
			else if ((iCnChar >= 49896) && (iCnChar <= 50370))
			{
				return "M";
			}
			else if ((iCnChar >= 50371) && (iCnChar <= 50613))
			{
				return "N";
			}
			else if ((iCnChar >= 50614) && (iCnChar <= 50621))
			{
				return "O";
			}
			else if ((iCnChar >= 50622) && (iCnChar <= 50905))
			{
				return "P";
			}
			else if ((iCnChar >= 50906) && (iCnChar <= 51386))
			{
				return "Q";
			}
			else if ((iCnChar >= 51387) && (iCnChar <= 51445))
			{
				return "R";
			}
			else if ((iCnChar >= 51446) && (iCnChar <= 52217))
			{
				return "S";
			}
			else if ((iCnChar >= 52218) && (iCnChar <= 52697))
			{
				return "T";
			}
			else if ((iCnChar >= 52698) && (iCnChar <= 52979))
			{
				return "W";
			}
			else if ((iCnChar >= 52980) && (iCnChar <= 53640))
			{
				return "X";
			}
			else if ((iCnChar >= 53689) && (iCnChar <= 54480))
			{
				return "Y";
			}
			else if ((iCnChar >= 54481) && (iCnChar <= 55289))
			{
				return "Z";
			}
			else
				return ("?");
		}
		#endregion

		#region GUID和RAW字符类互转
		public static string RawToGuid(this string input)
		{
			string output = "";
			//raw转guid
			//new guid(byte[] id);
			var guid_Val = new Guid(HexStringToBytes(input, Encoding.Unicode));
			output = guid_Val.ToString();

			return output;
		}

		//3、将16进制字符串转为字符串
		public static byte[] HexStringToBytes(string hex, Encoding encode)
		{
			string strTemp = "";
			byte[] b = new byte[hex.Length / 2];
			for (int i = 0; i < hex.Length / 2; i++)
			{
				strTemp = hex.Substring(i * 2, 2);
				b[i] = Convert.ToByte(strTemp, 16);
			}
			//按照指定编码将字节数组变为字符串
			return b;
		}

		public static string GuidToRaw(this string input)
		{
			string output = "";

			//var temp2 = byte.Parse("1b", NumberStyles.HexNumber);
			//guid转raw
			var temp = (new Guid(input)).ToByteArray();
			output = BitConverter.ToString(temp).Replace("-", "");

			return output;
		}
		#endregion

		public static List<string> GetSplitLineWithoutEmpty(this string input, char splitArray= '\n')
        {
            List<string> list = new List<string>();
            foreach(string str in input.Split(new char[] { splitArray }, StringSplitOptions.RemoveEmptyEntries))
            {
                list.Add(str);
            }
            return list;
		}

		public static List<string> GetSplitLineKeepEmptyRow(this string input, char splitArray = '\n')
		{
			List<string> list = new List<string>();
			foreach (string str in input.Split(new char[] { splitArray }))
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
