using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BaseClassUtils;
using HN.Integration.Helper;
using Serializable;

namespace HNLY
{
    class Program
    {
        static void Main(string[] args)
        {
            Func0();

            //serialXml();
            //deSerialXmlByXmlFile();   //一切可正常序列化xml和反解析
            //deSerialXmlByXmlString();

            testHNLY_mess();
            Console.ReadLine();
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
            Person p1 = new Person("张三", "男", 20);
            (new XMLUtils()).serialXml<Person>(p1);
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

        static void testHNLY_mess()
        {
            XMLUtils.filePath = "E:\\THOK\\MESS对接\\卷包工单及消耗归集xml\\工单下达.xml";
            (new XMLUtils()).deSerialXmlByXmlFile<MessageSerialXml>();
        }
    }
}
