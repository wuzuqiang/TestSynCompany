using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BaseClassUtils
{
    class StringUtils
    {
        public List<string> Get(string[] array, string strContained)
        {
            List<string> listMatched = new List<string>();
            string pattern = @"(\.ext+)(.)";
            foreach(string str in array)
            {
                if((new Regex(pattern).Matches(str).Count > 0))
                {
                    listMatched.Add(str);
                }
            }
            return listMatched;
        }
        public bool isMatch(string fileSuffix, string strContained)
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
    }
}
