using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClassLibrary1
{
    class RegUtils
    {
        /// <summary>
        /// 将首次出现字符串(含)前的字符串替换掉
        /// </summary>
        /// <param name="input"></param>
        /// <param name="firstOccur"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public string replaceAllBeforeFirststring(string input, string firstOccur, string replacement)
        {
            string ret = "";
            string pattern = @"\w*^(" + firstOccur.Replace("\\", @"\\") + @")" + firstOccur.Replace("\\", @"\\");
            pattern = @"\S*(?=\\Fussion\\)\\Fussion\\";
            if (Regex.Matches(input, pattern).Count > 0)
                ret = Regex.Replace(input, pattern, replacement);
            return ret;
        }

        public static void Test()
        {
            //定义匹配规则

            Regex regex = new Regex(@"([a-zA-Z0-9_]+)@([a-zA-Z0-9]+)\.com");

            //定义要被匹配的字符串

            string content = "nihao123@qq.com   myemail@163.comasjdfjsdf";

            string pattern = "(^abc)";
            string input = @"0a1b1c1d2e2f2";
            MatchCollection matches = Regex.Matches(input, pattern);

            //进行匹配，并返回结果集

            MatchCollection matchs = regex.Matches(content);

            //输出结果

            for (int i = 0; i < matchs.Count; i++)

            {

                Console.WriteLine("匹配到的第{0}个邮箱结果是{1}，对应用户名是{2}", i + 1, matchs[i], matchs[i].Groups[1]);
            }
        }
    }
}
