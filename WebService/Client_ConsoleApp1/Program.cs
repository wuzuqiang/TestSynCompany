using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClassUtils;

namespace Client_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TestWebserviceBySoap11();
                //Console.WriteLine("----------------------------------------");
                //TestWebserviceBySoap12();
                //Console.WriteLine("----------------------------------------");
                TestWebserviceByHTTP();
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
            WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085/MesToFLKService.asmx");
            //WebServiceCallHelper webServiceCall = new WebServiceCallHelper("localhost:8085"); //ERROR:无法识别该 URI 前缀。
            //WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085"); //ERROR:好像得到一个完整的HTML，但是看着数据很不对，具体还待分析
            //WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085/MesToFLKService.asmx?op=JBSC_SCGL_GDQX");
            var ret = webServiceCall.callWebServiceBySOAP11("localhost", "transManufacturingFormula", "JBSC_SCGL_JBGD", "reqXmlTest", "test");
            Console.WriteLine(ret);
        }

        public static void TestWebserviceBySoap12()
        {
            WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085/MesToFLKService.asmx");
            var ret = webServiceCall.callWebServiceBySOAP12("localhost", "transManufacturingFormula", "JBSC_SCGL_JBGD", "reqXmlTest", "test");
            Console.WriteLine(ret);
        }

        public static void TestWebserviceByHTTP()
        {
            WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085/MesToFLKService.asmx");
            var ret = webServiceCall.callWebServiceByHTTP("localhost", "JBSC_SCGL_JBGD", "reqXmlTest", "test");
            XMLUtils xMLUtils = new XMLUtils();
            //xMLUtils.deSerialXmlByXmlString<LYYCRetVal>(ret.Replace("&gt;", ">").Replace("&lt;", "<"));
            string strTest = "<string xmlns=\"http://tempuri.org/\"><Msg xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"> <Head> <InterfaceCode>HNZY_ESB_AYMES_JBSC_SCGL_JBGD</InterfaceCode> <InterfaceDescription>卷包工单；错误：XML 文档(1,39)中有错误。</InterfaceDescription> <MsgID>2bdf8746812c46479d46e23520ed33fa</MsgID> <Source>AYJBSC</Source> <MsgMark>HNZY_ESB_AYMES_JBSC</MsgMark> <WsMethod>JBSC_SCGL_JBGD</WsMethod> <Date>2020-03-05 10:25:03</Date> <StateCode>000</StateCode> <StateDesription>正常调用</StateDesription> </Head></Msg></string>";
            strTest = "<string><Msg> <Head> <InterfaceCode>HNZY_ESB_AYMES_JBSC_SCGL_JBGD</InterfaceCode> <InterfaceDescription>卷包工单；错误：XML 文档(1,39)中有错误。</InterfaceDescription> <MsgID>2bdf8746812c46479d46e23520ed33fa</MsgID> <Source>AYJBSC</Source> <MsgMark>HNZY_ESB_AYMES_JBSC</MsgMark> <WsMethod>JBSC_SCGL_JBGD</WsMethod> <Date>2020-03-05 10:25:03</Date> <StateCode>000</StateCode> <StateDesription>正常调用</StateDesription> </Head></Msg></string>";
            xMLUtils.deSerialXmlByXmlString<LYYCRetVal>(strTest);
            //Console.WriteLine(ret);
    }


        public static void Test00()
        {
            //直接使用引用服务的方式来调用
            ServiceReference1.WebService1SoapClient webService = new ServiceReference1.WebService1SoapClient();
            Console.WriteLine(webService.SayHello("wu zu qiang"));
        }
    }
}
