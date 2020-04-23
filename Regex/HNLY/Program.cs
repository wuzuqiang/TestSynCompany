﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BaseClassUtils;
using Fusion.Context.Warehouse.Domain.Models.Bill.OutBills;
using Fusion.Context.Warehouse.Domain.Models.Warehouse.Locations;
using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Services.YSK;
using HN.Integration.Helper;
using Serializable;

namespace HNLY
{
    class Program
    {
        static void Main(string[] args)
        {
            Func1();
            ////Func0();
            //TestTranslatorHelper();
            ////test2deSerialXmlByXmlString();
            ////serialXml();
            ////deSerialXmlByXmlFile();   //一切可正常序列化xml和反解析
            ////deSerialXmlByXmlString();

            ////testHNLY_mess();
            ////testBaseOperXml();
            Console.ReadLine();
        }

        public static void Func1()
        {
            var temp = new OutBill("OutBillNo", "BillTypeCode", "WarehouseCode", "Maker", DateTime.Now);
            var temp2 = new Storage(Guid.NewGuid(),"locationCode", Guid.NewGuid(), "productCode", "productName", DateTime.Now,"inBillNo");
            var temp3 = new Storage(Guid.NewGuid(), "locationCode02", Guid.NewGuid(), "productCode02", "productName02", DateTime.Now, "inBillNo");
            List<Storage> storages = new List<Storage>();
            storages.Add(temp2);
            storages.Add(temp3);
            var main01 = new YSKToMesAdapter();
            main01.AdapterTransOutBillState(temp, storages);
        }

        public static void TestTranslatorHelper()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.xml");
            FileUtils fileUtils = new FileUtils();
            string reqXml = fileUtils.ReadFile(filePath);
            var a = TranslatorHelper.AnalysicInputData<Person>(reqXml, "/bookstore/book/title");
        }
        public static void Func0()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.xml");
            XMLUtils.filePath = filePath;
            (new XMLUtils()).readAll("book");
        }

        public static void serialXml()
        {
            XMLUtils.filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test1.xml");
            Person p1 = new Person();
            p1.Name = "test";
            Console.WriteLine("最终序列化为：" + (new XMLUtils()).serialXml<Person>(p1));
        }

        public static void deSerialXmlByXmlFile()
        {
            XMLUtils.filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test1.xml");
            (new XMLUtils()).deSerialXmlByXmlFile<Person>();
        }

        public static void deSerialXmlByXmlString()
        {
            test1();
            //string xmlStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Person xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Name>张三</Name><Sex>男</Sex><Age>20</Age></Person>";
            //(new XMLUtils()).deSerialXmlByXmlString<Person>(xmlStr);
        }
        static void test0()
        {
            //假如类中的变量名是Person，但实际上得到的xml字符串中使用的是Test，可以使用xmlRoot来自动转换吗？
            //经测试，是可以的。^ _ ^XmlRoot也一样可以
            string xmlStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Test xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Name1>张三</Name1><Sex>男</Sex><Age>20</Age></Test>";
            //如下，如果不存在xmlElement中的属性名称，得到的Name是为空字符串的。
            //string xmlStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Test xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Name2>张三</Name2><Sex>男</Sex><Age>20</Age></Test>";
            (new XMLUtils()).deSerialXmlByXmlString<Person>(xmlStr);
        }
        static void test1()
        {
            //Name中就算有好几个Item，反解析得到的只能是第一个<>中的内容，即test张三
            string xmlStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Test xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Ele01><Item>test张三</Item><Item2>01张三</Item2></Ele01><Sex>男</Sex><Age>20</Age></Test>";
            (new XMLUtils()).deSerialXmlByXmlString<Person>(xmlStr);
        }
        static void test2deSerialXmlByXmlString()
        {
            //Name中就算有好几个Item，反解析得到的只能是第一个<>中的内容，即test张三
            string xmlStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Msg><Head><InterfaceCode>HNZY_ESB_AYMES_JBSC_SCGL_JBGD</InterfaceCode><InterfaceDescription>卷包工单</InterfaceDescription><MsgID>0f12d34d71b640b1a8441a088255bc87+RET</MsgID><Source>MES</Source><MsgMark>HNZY_ESB_AYMES_JBSC</MsgMark><WsMethod>JBSC_SCGL_JBGD</WsMethod><Date>2020-02-27 07:47:41.44</Date><Cryp></Cryp><User>AYJBSC</User><StateCode>000</StateCode><StateDesription>调用成功</StateDesription></Head></Msg>";
            (new XMLUtils()).deSerialXmlByXmlString<RetNodeHead>(xmlStr);
        }

        static void testHNLY_mess()
        {
            XMLUtils.filePath = "E:\\THOK\\MESS对接\\卷包工单及消耗归集xml\\工单下达.xml";
            (new XMLUtils()).deSerialXmlByXmlFile<MessageSerialXml>();
        }

        static void testBaseOperXml()
        {
            XMLUtils.filePath = "E:\\THOK\\MESS对接\\卷包工单及消耗归集xml\\testBaseOperXml.xml";
            XMLUtils.Main();
        }
    }
}
