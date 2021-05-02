using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner.Tools
{
    public static class SearchTool
    {
        public static string JsonSerialzable(params string[] searchObj)
        {
            var list = new List<SearchModel>();

            for (int i = 0; i < searchObj.Length; i++)
            {
                var val = searchObj[i].Split(',');
                if (string.IsNullOrEmpty(val[1]) || val[1] == "null")
                    continue;
                var temp = new SearchModel()
                {
                    property = val[0],
                    @operator = "Contains",
                    value = val[1],
                };
                list.Add(temp);
            }
            return JsonConvert.SerializeObject(list);
        }
    }
}
