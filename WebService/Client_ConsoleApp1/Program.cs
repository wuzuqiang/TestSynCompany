using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //直接使用引用服务的方式来调用
            ServiceReference1.WebService1SoapClient webService = new ServiceReference1.WebService1SoapClient();
            Console.WriteLine(webService.SayHello("wu zu qiang"));

            //直接通过Http访问WebService服务
            WebServiceCall webServiceCall = new WebServiceCall("http://localhost:9090/WebService1.asmx");
            var dicTemp = new Dictionary<string, string>();
            dicTemp.Add("name", "wuzuqiang");
            var ret = webServiceCall.callWebService("SayHello", dicTemp);

            Console.ReadLine();
        }
    }
}
