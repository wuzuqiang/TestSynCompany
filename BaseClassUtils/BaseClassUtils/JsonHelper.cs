using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BaseClassUtils
{
    public static class JsonHelper
    {
        public static T DeserializeObject<T>(string json) where T: class
        {

            T p = (T)JsonConvert.DeserializeObject(json, typeof(T));
            return p;
        }

        public static string SerializeObject<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public static void Func01()
        {
            string strJson2 = @"{ ""student"": { ""Name1"": ""小明"" , ""Name2"": ""小花"" , ""Name3"": ""小红""} }";

            JObject jsonObj = JObject.Parse(strJson2);

            Console.WriteLine(jsonObj["student"]["Name1"].ToString());
            Console.WriteLine(jsonObj["student"]["Name2"].ToString());
            Console.WriteLine(jsonObj["student"]["Name3"].ToString());
        }

        public static JObject DeSerilizeToJObject(string strJson2)
        {
            JObject jsonObj = JObject.Parse(strJson2);
            return jsonObj;
        }
    }
}