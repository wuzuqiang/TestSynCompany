using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BaseClassUtils
{
    public class XMLUtils
    {
        public bool isUseConsoleProject = true;
        public static string filePath = "";
        public string GetElementValue(string eleKey)
        {
            string eleValue = "";
            XElement xe = XElement.Load(filePath);
            IEnumerable<XElement> elements = from ele in xe.Elements("HeadNode") select ele;
            foreach (var ele in elements)
            {
                eleValue = ele.Element("").Value;
            }
            return eleValue;
        }

        //直接找到元素为eleKey的这个结点,然后遍历读取所有的结果.
        public void readAll(string eleKey)
        {
            XElement xe = XElement.Load(filePath);
            IEnumerable<XElement> elements = from ele in xe.Elements(eleKey)
                                             select ele;
            showInfoByElements(elements);
        }
        //先定义 一个方法显示查询出来的数据
        public void showInfoByElements(IEnumerable<XElement> elements)
        {
            List<BookModel> modelList = new List<BookModel>();
            foreach (var ele in elements)
            {
                BookModel model = new BookModel();
                model.BookAuthor = ele.Element("author").Value;
                model.BookName = ele.Element("title").Value;
                model.BookPrice = Convert.ToDouble(ele.Element("price").Value);
                model.BookISBN = ele.Attribute("ISBN").Value;
                model.BookType = ele.Attribute("Type").Value;

                modelList.Add(model);
                showAllData<BookModel>(model);
            }
        }

        public void showAllData<T>(T model)
        {
            if (isUseConsoleProject)
            {
                //Type t = typeof(T);
                //showData<T>(t, model);

                showData(model);
            }
        }
        public void showData<T>(Type t, T model)
        {
            //Type t = model.GetType();//获得该类的Type

            //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
            foreach (PropertyInfo pi in t.GetProperties()) //如果model为HNLY的MessageSerialXml，.GetProperties()得到的为行为0，原来是因为没有使用{ get; set; }
            {
                object value1 = pi.GetValue(model, null);//用pi.GetValue获得值
                string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                                      //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数
                if (!(value1.GetType() == typeof(int) && value1.GetType() == typeof(string)))
                {
                    //如果得到value1的T类型呢。
                    showData<T>(value1.GetType(), model);
                }
                Console.Write(name + ":" + value1 + "\t");
            }
            Console.WriteLine();
        }
        public void showData(object model)
        {
            Type t = model.GetType();//获得该类的Type

            //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
            foreach (PropertyInfo pi in t.GetProperties()) //如果model为HNLY的MessageSerialXml，.GetProperties()得到的为行为0，原来是因为没有使用{ get; set; }
            {
                object value1 = pi.GetValue(model, null);//用pi.GetValue获得值
                string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                                      //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数
                if (!(value1.GetType() == typeof(int) || value1.GetType() == typeof(string)))
                {
                    //如果得到value1的T类型呢。
                    //showData(value1.GetType().Assembly.CreateInstance(value1.GetType().ToString()));
                }
                Console.Write(name + ":" + value1 + "\t");
            }
            Console.WriteLine();
        }

        public void deSerialXmlByXmlFile<T>()
        {
            //反序列化
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            T model = (T)xs.Deserialize(fs);
            showAllData<T>(model);
        }

        public void deSerialXmlByXmlString<T>(string xmlStr)
        {
            XmlReader xmlReader = null;
            try
            {
                MemoryStream memStream = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(memStream);
                Regex.Replace(xmlStr, @"<!-- *.* -->", "", RegexOptions.IgnoreCase);
                xmlStr = xmlStr.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "");
                xmlStr = xmlStr.Replace("<?xml version=\"1.0\" encoding=\"GBK\"?>", "");
                xmlStr = xmlStr.Replace("<?xml version=\"1.0\"", "");
                //xmlStr = xmlStr.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                //xmlStr = xmlStr.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", ""); //不替换这些也行
                //string xmlStr = "<Person><Name>张三</Name><Sex>男</Sex><Age>20</Age></Person>"; //XmlWriter要写入这类数据xmlReader才能正确读取出来
                writer.WriteRaw(xmlStr);
                writer.Flush();
                writer.Close();
                memStream.Position = 0;
                xmlReader = XmlReader.Create(memStream);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                T model = (T)xs.Deserialize(xmlReader);
                showAllData<T>(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }

        public void serialXml<T>(T model)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            xs.Serialize(fs, model);
            fs.Close();
            showAllData<T>(model);
        }


    }
    public class BookModel
    {
        public BookModel()
        { }
        /// <summary>
        /// 所对应的课程类型
        /// </summary>
        private string bookType;

        public string BookType
        {
            get { return bookType; }
            set { bookType = value; }
        }

        /// <summary>
        /// 书所对应的ISBN号
        /// </summary>
        private string bookISBN;

        public string BookISBN
        {
            get { return bookISBN; }
            set { bookISBN = value; }
        }

        /// <summary>
        /// 书名
        /// </summary>
        private string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        /// <summary>
        /// 作者
        /// </summary>
        private string bookAuthor;

        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        /// <summary>
        /// 价格
        /// </summary>
        private double bookPrice;

        public double BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }
    }
}

