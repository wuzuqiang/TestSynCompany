using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BaseClassUtils;
using HN.Integration.Helper;

namespace Client_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TestWebSvcCaller();
                TestHNLYFLKToMes();
                //TestWebserviceBySoap11();
                //Console.WriteLine("----------------------------------------");
                //TestWebserviceBySoap12();
                //Console.WriteLine("----------------------------------------");
                //TestWebserviceByHTTP();
            }
            catch(Exception ex)
            {
                Console.WriteLine("------->出现错误：" + ex.Message);
            }

            Console.Write("按回车键退出！");
            Console.ReadLine();
        }

        public static void TestWebSvcCaller()
        {
            Hashtable ht = new Hashtable();
            ht.Add("theEmail", "test@qq.com");
            //XmlDocument xdoc = WebSvcCaller.QuerySoapWebService("http://www.webxml.com.cn/WebServices/ValidateEmailWebService.asmx?wsdl", "ValidateEmailAddress", ht);
            XmlDocument xdoc = WebSvcCaller.QuerySoapWebService("http://www.webxml.com.cn/WebServices/ValidateEmailWebService.asmx?wsdl", "ValidateEmailAddress", ht);

            Console.WriteLine(xdoc.InnerText);
        }

        public static void TestHNLYFLKToMes()
        {
            MessageSerialXml messageSerialXml = new MessageSerialXml();
            MessageSerialXml obj = new MessageSerialXml();
            _FieldItem[] headFieldItems = new _FieldItem[7];
            for (int i = 0; i < 7; i++)
            {
                headFieldItems[i] = new _FieldItem();
            }
            #region 添加头部headFieldItems信息
            headFieldItems[0].isPrimaryKey = "True";
            headFieldItems[0].Remark = "必传(外键，复合主键)";
            headFieldItems[0].FieldLength = "30";
            headFieldItems[0].FieldType = "CHAR";
            headFieldItems[0].Caption = "工单号";
            headFieldItems[0].FieldName = "WO_NO";

            headFieldItems[1].isPrimaryKey = "False";
            headFieldItems[1].Remark = "必传(格式:yyyy-MM-dd)";
            headFieldItems[1].FieldLength = "19";
            headFieldItems[1].FieldType = "DATE";
            headFieldItems[1].Caption = "生产日期";
            headFieldItems[1].FieldName = "PRODUCTION_DATE";

            headFieldItems[2].isPrimaryKey = "False";
            headFieldItems[2].Remark = "必传(1:夜,2:白,3:中)";
            headFieldItems[2].FieldLength = "25";
            headFieldItems[2].FieldType = "CHAR";
            headFieldItems[2].Caption = "班次";
            headFieldItems[2].FieldName = "SHIFT_CD";

            headFieldItems[3].isPrimaryKey = "False";
            headFieldItems[3].Remark = "必传(1:甲,2:乙,3:丙,4:丁)";
            headFieldItems[3].FieldLength = "25";
            headFieldItems[3].FieldType = "CHAR";
            headFieldItems[3].Caption = "班组";
            headFieldItems[3].FieldName = "TEAM_CD";

            headFieldItems[4].isPrimaryKey = "False";
            headFieldItems[4].Remark = "必传";
            headFieldItems[4].FieldLength = "25";
            headFieldItems[4].FieldType = "CHAR";
            headFieldItems[4].Caption = "机台";
            headFieldItems[4].FieldName = "MACHINE_CD";

            headFieldItems[5].isPrimaryKey = "False";
            headFieldItems[5].Remark = "必传";
            headFieldItems[5].FieldLength = "25";
            headFieldItems[5].FieldType = "CHAR";
            headFieldItems[5].Caption = "牌号";
            headFieldItems[5].FieldName = "MAT_CD";

            headFieldItems[6].isPrimaryKey = "False";
            headFieldItems[6].Remark = "必传(格式:yyyy-MM-dd hh24:mi:ss)";
            headFieldItems[6].FieldLength = "19";
            headFieldItems[6].FieldType = "DATE";
            headFieldItems[6].Caption = "工单开始时间";
            headFieldItems[6].FieldName = "WO_START_DATETIME";
            #endregion
            obj.Head = new _Head();
            obj.Head.DataDefine = new _DataDefine();
            obj.Head.DataDefine.TableSet = new _Table[1];
            obj.Head.DataDefine.TableSet[0] = new _Table();
            obj.Head.DataDefine.TableSet[0].FieldItemSet = headFieldItems;

            _DataItem[] dataFieldItems = new _DataItem[7];
            for (int i = 0; i < 7; i++)
            {
                dataFieldItems[i] = new _DataItem();
            }
            #region 添加数据dataFieldItems
            dataFieldItems[0].FieldName = "MACHINE_CD";
            dataFieldItems[0].FieldValue = "";
            dataFieldItems[1].FieldName = "MAT_CD";
            dataFieldItems[1].FieldValue = "";
            dataFieldItems[2].FieldName = "PRODUCTION_DATE";
            dataFieldItems[2].FieldValue = "";
            dataFieldItems[3].FieldName = "WO_NO";
            dataFieldItems[3].FieldValue = "";
            dataFieldItems[4].FieldName = "TEAM_CD";
            dataFieldItems[4].FieldValue = "";
            dataFieldItems[5].FieldName = "SHIFT_CD";
            dataFieldItems[5].FieldValue = "";
            dataFieldItems[6].FieldName = "WO_END_DATETIME";
            dataFieldItems[6].FieldValue = "";
            dataFieldItems[6].FieldName = "WO_START_DATETIME";
            dataFieldItems[6].FieldValue = "";
            #endregion
            obj.Data = new _Data();
            obj.Data.DataTableSet = new _DataTable[1];
            obj.Data.DataTableSet[0] = new _DataTable();
            obj.Data.DataTableSet[0].RowSet = new _Row[1];
            obj.Data.DataTableSet[0].RowSet[0] = new _Row();
            obj.Data.DataTableSet[0].RowSet[0].Header = new _Header();
            obj.Data.DataTableSet[0].RowSet[0].Header.DataItemSet = dataFieldItems;

            obj.Head.InterfaceCode = "HNZY_ESB_AYMES_JBSC_SCGL_GDKS";
            obj.Head.InterfaceDescription = "工单开始";
            obj.Head.MsgID = "CC14702D-B610-470D-B267-4474A5D8D7DD";
            obj.Head.Source = "AYJBSC";
            obj.Head.MsgMark = "HNZY_ESB_AYMES_JBSC";
            obj.Head.WsMethod = "JBSC_SCGL_GDKS";
            obj.Head.Date = DateTime.Now.ToString();
            obj.Head.User = "MES";
            obj.Head.StateCode = "600";
            obj.Head.StateDesription = "正常发送";


            var reqXml = (new XMLUtils()).serialXml<MessageSerialXml>(obj);
            Console.WriteLine("<Result：");
            Console.WriteLine(reqXml);
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
            //WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085/MesToFLKService.asmx");
            WebServiceCallHelper webServiceCall = new WebServiceCallHelper("http://localhost:8085/MesToFLKService.asmx?wsdl");
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
