using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClassUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var strJson = @"[{""property"":""CallTime"",""operator"":"">="",""value"":""2020/05/18 08:21:48""},{""property"":""CallTime"",""operator"":""<="",""value"":""2020/05/18 14:22:00""}]";
            var tempJson = strJson.Replace("property", "property" + "_").Replace("operator", "operator" + "_").Replace("value", "value" + "_");

            var result = Fun1(tempJson);

            result[0].operator_ = "test";
            string result1 = JsonHelper.SerializeObject<FilterClass[]>(result);
            Console.WriteLine(result1);

            Console.ReadKey();
        }
        public static FilterClass[] Fun1(string JSonArray)
        {
            var result = JsonHelper.DeserializeObject<FilterClass[]>(JSonArray); //已证明很好用,就是要了解要转换的是数组还是对象什么的
            return result;
            //下面的可以后再整理
            JArray jArrayTest = JArray.Parse(JSonArray);
            var a1 = JsonConvert.DeserializeObject<FilterClass[]>(JSonArray);

            foreach (var jsonitem in jArrayTest)
            {
                JObject job = (JObject)jsonitem;
            }
        }
        public static void Fun0(string strJson)
        {
            Product product = new Product()
            {
                Name = "android",
                Expiry = DateTime.Now,
                Price = 2000,
                Sizes = new string[] { "1.5", "2.2", "4.1" }
            };
            //Console.WriteLine(JsonHelper.SerializeObject(product)); //结果为{"Name":"android","Expiry":"2020-05-18T16:33:57.351457+08:00","Price":2000.0,"Sizes":["1.5","2.2","4.1"]}
            //Product productBySerialize = JsonHelper.DeserializeObject<Product>(JsonHelper.SerializeObject(product));
            //Console.WriteLine(productBySerialize.ToString());

            CallStorageStatic callStorageStatic = new CallStorageStatic();
            callStorageStatic.products.Add(product);
            var ret1 = JsonHelper.SerializeObject(callStorageStatic);   //{"products":[{"Name":"android","Expiry":"2020-05-18T16:59:57.4425247+08:00","Price":2000.0,"Sizes":["1.5","2.2","4.1"]}]}
            Console.WriteLine(JsonHelper.DeSerilizeToJObject(ret1)["products"][0]["Name"]);
            Console.WriteLine(JsonHelper.DeSerilizeToJObject(ret1)["products"][0]["Expiry"]);


            //JsonHelper.Func01();
            string testJson = @"{""test"":" + strJson + @"}";
            foreach (var jsonItem in JsonHelper.DeSerilizeToJObject(testJson))
            {
                foreach (var temp in jsonItem.Value)
                {
                    Console.WriteLine(temp);
                }
            }
            Console.WriteLine(JsonHelper.DeSerilizeToJObject(testJson)["test"][0]["property"]);
            //Console.WriteLine(JsonHelper.DeSerilizeToJObject(testJson)[0]["operator"]);
            //Console.WriteLine(JsonHelper.DeSerilizeToJObject(testJson)[0]["value"]);
        }
    }
    public class FilterClass
    {
        public string property_ { get; set; }
        public string operator_ { get;set;}
        public string value_ { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0},Expiry:{1},Price:{2},SizesCount:{3}"
                , Name, Expiry, Price, Sizes.Length);
        }
    }

    public class CallStorageStatic
    {
        public List<Product> products = new List<Product>();
    }
    public class SubItem
    {
        //public string property { get; set; }
        //public string operator { get; set; }
        //public string value { get; set; }

    }

}
