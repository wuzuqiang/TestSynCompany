using System;
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
//using Fusion.Project.HN.LY.FLK.Activities.AGV.Models;
using HN.Integration.Helper;
using Serializable;

namespace HNLY
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func1();
            ////Func0();
            //TestTranslatorHelper();
            ////test2deSerialXmlByXmlString();
            //serialXml();
            ////deSerialXmlByXmlFile();   //一切可正常序列化xml和反解析
            ////deSerialXmlByXmlString();

            ////testHNLY_mess();
            ////testBaseOperXml();
            //SerialMessageSerialXmlV1Xml();
            Func3();
            Console.ReadLine();
        }

        public static void Func3()
		{
			string strMiddle = "^_^";
			string strTest = "<HM>  <ID>30</ID>  <TC>MS</TC>  <LY>    <ID>4</ID>    <LO>      <ID>0001</ID>    </LO>    <NA>      <ID>0002</ID>    </NA>    <SS>      <ID>0300</ID>    </SS>    <EB>      <ID>0004</ID>    </EB>    <BL>      <ID>5000</ID>    </BL>    <LB>      <ID>0006</ID>    </LB>    <SR>      <ID>0070</ID>    </SR>    <SSF>      <ID>0800</ID>    </SSF>    <SRS>      <ID>0009</ID>    </SRS>    <FE>      <ID>1000</ID>    </FE>  </LY></HM>";

			#region listAgvAlarmCode、listAgvStatus
			strTest = strTest.Replace("<ID>1</ID>", strMiddle + "1");
			strTest = strTest.Replace("<ID>2</ID>", strMiddle + "2");
			strTest = strTest.Replace("<ID>3</ID>", strMiddle + "3");
			strTest = strTest.Replace("<ID>4</ID>", strMiddle + "4");
			strTest = new Regex("<HM>|</HM>|<ID>30</ID>|<TC>MS</TC>|<ID>|</ID>").Replace(strTest, "");
			strTest = strTest.Replace("<ID>1</ID>", strMiddle).Replace("LY>", "AGVStatus>");
			strTest = strTest.Replace(strMiddle + "1", "<ID>1</ID>");
			strTest = strTest.Replace(strMiddle + "2", "<ID>2</ID>");
			strTest = strTest.Replace(strMiddle + "3", "<ID>3</ID>");
			strTest = strTest.Replace(strMiddle + "4", "<ID>4</ID>");
			AGVStatus agvStatus = XMLUtils.XmlDeSerializer<AGVStatus>(strTest);

			var agvCode = $"AGV{agvStatus.ID.PadLeft(2, '0')}";

			//检查设备都有哪些信息反馈
			List<string> listAgvAlarmCode = new List<string>();
			AGVStatus temp = new AGVStatus();

			var tempAgvStatus = new string[] { "", agvStatus.LO, agvStatus.NA, agvStatus.SS, agvStatus.EB, agvStatus.BL, agvStatus.LB, agvStatus.SR, agvStatus.SSF, agvStatus.SRS, agvStatus.FE };
			var listAgvStatus = new List<string>();

			foreach (string str in tempAgvStatus)
			{
				listAgvStatus.Add(str.Trim());
				if (!string.IsNullOrEmpty(str))
				{
					listAgvAlarmCode.Add("AGV_" + str.Trim());
				}
			}
			#endregion

			var agvStatusToWriteDataservice = new Boolean[10];
			for (int i = 0; i < listAgvAlarmCode.Count(); i++)
			{
				agvStatusToWriteDataservice[i] = listAgvAlarmCode[i] != "AGV_" + "0000";
			}
			string agvStatusInData = string.Join("、", listAgvAlarmCode);
		}

        public static void Func2()
        {
            string strTest = "  <LY>    <ID>1</ID>    <LO>      <ID>0000</ID>    </LO>    <NA>      <ID>0002</ID>    </NA>    <SS>      <ID>0000</ID>    </SS>    <EB>      <ID>0000</ID>    </EB>    <BL>      <ID>0000</ID>    </BL>    <LB>      <ID>0000</ID>    </LB>    <SR>      <ID>0000</ID>    </SR>    <SSF>      <ID>0000</ID>    </SSF>    <SRS>      <ID>0009</ID>    </SRS>    <FE>      <ID>0000</ID>    </FE>  </LY>";

            AGVStatus agvStatus = XMLUtils.XmlDeSerializer<AGVStatus>(strTest.Replace("LY>", "AGVStatus>"));
        }

        public static void SerialMessageSerialXmlV1Xml()
        {
            MessageSerialXmlV1 messageSerialXmlV1 = new MessageSerialXmlV1();
            messageSerialXmlV1.Data = "testDataInMessageSerialXmlV1";
            var ret = (new XMLUtils()).serialXml<MessageSerialXmlV1>(messageSerialXmlV1);
            Console.WriteLine(ret);
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
            string reqXml = fileUtils.ReadFileByFileStream(filePath);
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
            Console.WriteLine("最终序列化为：\n" + (new XMLUtils()).serialXml<Person>(p1)
                .Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "")
                .Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", ""));
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
	
	public class AGVStatus
	{
		/// <summary>
		/// 车号
		/// </summary>
		public string ID = "ID";
		/// <summary>
		/// 有货--[loaded]
		/// </summary>
		public string LO = "0001";
		/// <summary>
		/// 手动--[noAuto]
		/// </summary>
		public string NA = "0002";
		/// <summary>
		/// 软停--[stopSoft]
		/// </summary>
		public string SS = "0003";
		/// <summary>
		/// 急停--[stopEstopButton]
		/// </summary>
		public string EB = "0004";
		/// <summary>
		/// 排队--[blocked]
		/// </summary>
		public string BL = "0005";
		/// <summary>
		/// 电量低--[lowBattery]
		/// </summary>
		public string LB = "0006";
		/// <summary>
		/// 后方障碍--[stopRear]
		/// </summary>
		public string SR = "0007";
		/// <summary>
		/// 前方SICK障碍--[stopSafety]
		/// </summary>
		public string SSF = "0008";
		/// <summary>
		/// AGV需要复位--[stopReset]
		/// </summary>
		public string SRS = "0009";
		/// <summary>
		/// 举升编码器错误 --[stopForkEncoder]
		/// </summary>
		public string FE = "0010";
	}

}
