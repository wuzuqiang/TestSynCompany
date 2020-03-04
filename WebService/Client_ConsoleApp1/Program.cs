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
            try
            {
                TestWebserviceBySoap11();
                Console.WriteLine("----------------------------------------");
                TestWebserviceBySoap12();
            }
            catch(Exception ex)
            {
                Console.WriteLine("------->出现错误：" + ex.Message);
            }

            Console.Write("按回车键退出！");
            Console.ReadLine();
        }


        public static void TestWebserviceBySoap11()
        {
            //直接通过Http访问WebService服务
            WebServiceCall webServiceCall = new WebServiceCall("http://localhost:8085/MesToFLKService.asmx");
            //WebServiceCall webServiceCall = new WebServiceCall("localhost:8085"); //ERROR:无法识别该 URI 前缀。
            //WebServiceCall webServiceCall = new WebServiceCall("http://localhost:8085"); //ERROR:好像得到一个完整的HTML，但是看着数据很不对，具体还待分析
            //WebServiceCall webServiceCall = new WebServiceCall("http://localhost:8085/MesToFLKService.asmx?op=JBSC_SCGL_GDQX");
            var ret = webServiceCall.callWebServiceBySOAP11("localhost", "transManufacturingFormula", "test");
            Console.WriteLine(ret);
        }

        public static void TestWebserviceBySoap12()
        {
            //WebServiceCall webServiceCall = new WebServiceCall("http://localhost:8085/MesToFLKService.asmx?op=JBSC_SCGL_GDQX");
            WebServiceCall webServiceCall = new WebServiceCall("http://localhost:8085/MesToFLKService.asmx");
            var ret = webServiceCall.callWebServiceBySOAP12("localhost", "transManufacturingFormula", "test");
            Console.WriteLine(ret);
        }


        public static void Test00()
        {
            //直接使用引用服务的方式来调用
            ServiceReference1.WebService1SoapClient webService = new ServiceReference1.WebService1SoapClient();
            Console.WriteLine(webService.SayHello("wu zu qiang"));
        }
    }
}
