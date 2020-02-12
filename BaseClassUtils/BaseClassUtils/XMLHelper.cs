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

        #region 使用linq操作xml数据
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
        #endregion

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
                    //如何得到value1的T类型呢？
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

        public string serialXml<T>(T model)
        {
            #region //方法1
            //FileStream fs = new FileStream(filePath, FileMode.Create);
            //XmlSerializer xs = new XmlSerializer(typeof(T));
            //xs.Serialize(fs, model);
            //fs.Close();
            //showAllData<T>(model);
            #endregion
            #region 方法2
            MemoryStream ms = new MemoryStream();
            // XmlTextWriter textWriter = new XmlTextWriter(ms, Encoding.GetEncoding("UTF-8"));
            StreamWriter textWriter = new StreamWriter(ms, Encoding.GetEncoding("gb2312"));
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(textWriter, model);
            string xmlMessage = Encoding.UTF8.GetString(ms.GetBuffer());
            ms.Close();
            textWriter.Close();
            return xmlMessage;
            #endregion
        }

        #region 使用原始的方法操作xml，创建xml，然后添加节点、属性啊什么的

        public static void Main()
        {
            try
            {
                //xml文件存储路径
                string myXMLFilePath = filePath;
                //生成xml文件
                GenerateXMLFile(myXMLFilePath);
                //遍历xml文件的信息
                GetXMLInformation(myXMLFilePath);
                //修改xml文件的信息
                ModifyXmlInformation(myXMLFilePath);
                //向xml文件添加节点信息
                AddXmlInformation(myXMLFilePath);
                //删除指定节点信息
                //DeleteXmlInformation(myXMLFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void GenerateXMLFile(string xmlFilePath)
        {
            try
            {
                //初始化一个xml实例
                XmlDocument myXmlDoc = new XmlDocument();
                //创建xml的根节点
                XmlElement rootElement = myXmlDoc.CreateElement("Computers");
                //将根节点加入到xml文件中（AppendChild）
                myXmlDoc.AppendChild(rootElement);

                //初始化第一层的第一个子节点
                XmlElement firstLevelElement1 = myXmlDoc.CreateElement("Computer");
                //填充第一层的第一个子节点的属性值（SetAttribute）
                firstLevelElement1.SetAttribute("ID", "11111111");
                firstLevelElement1.SetAttribute("Description", "Made in China");
                //将第一层的第一个子节点加入到根节点下
                rootElement.AppendChild(firstLevelElement1);
                //初始化第二层的第一个子节点
                XmlElement secondLevelElement11 = myXmlDoc.CreateElement("name");
                //填充第二层的第一个子节点的值（InnerText）
                secondLevelElement11.InnerText = "Lenovo";
                firstLevelElement1.AppendChild(secondLevelElement11);
                XmlElement secondLevelElement12 = myXmlDoc.CreateElement("price");
                secondLevelElement12.InnerText = "5000";
                firstLevelElement1.AppendChild(secondLevelElement12);


                XmlElement firstLevelElement2 = myXmlDoc.CreateElement("Computer");
                firstLevelElement2.SetAttribute("ID", "2222222");
                firstLevelElement2.SetAttribute("Description", "Made in USA");
                rootElement.AppendChild(firstLevelElement2);
                XmlElement secondLevelElement21 = myXmlDoc.CreateElement("name");
                secondLevelElement21.InnerText = "IBM";
                firstLevelElement2.AppendChild(secondLevelElement21);
                XmlElement secondLevelElement22 = myXmlDoc.CreateElement("price");
                secondLevelElement22.InnerText = "10000";
                firstLevelElement2.AppendChild(secondLevelElement22);

                //将xml文件保存到指定的路径下
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void GetXMLInformation(string xmlFilePath)
        {
            try
            {
                //初始化一个xml实例
                XmlDocument myXmlDoc = new XmlDocument();
                //加载xml文件（参数为xml文件的路径）
                myXmlDoc.Load(xmlFilePath);
                //获得第一个姓名匹配的节点（SelectSingleNode）：此xml文件的根节点
                XmlNode rootNode = myXmlDoc.SelectSingleNode("Computers");
                //分别获得该节点的InnerXml和OuterXml信息
                string innerXmlInfo = rootNode.InnerXml.ToString();
                string outerXmlInfo = rootNode.OuterXml.ToString();
                //获得该节点的子节点（即：该节点的第一层子节点）
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //获得该节点的属性集合
                    XmlAttributeCollection attributeCol = node.Attributes;
                    foreach (XmlAttribute attri in attributeCol)
                    {
                        //获取属性名称与属性值
                        string name = attri.Name;
                        string value = attri.Value;
                        Console.WriteLine("{0} = {1}", name, value);
                    }

                    //判断此节点是否还有子节点
                    if (node.HasChildNodes)
                    {
                        //获取该节点的第一个子节点
                        XmlNode secondLevelNode1 = node.FirstChild;
                        //获取该节点的名字
                        string name = secondLevelNode1.Name;
                        //获取该节点的值（即：InnerText）
                        string innerText = secondLevelNode1.InnerText;
                        Console.WriteLine("{0} = {1}", name, innerText);

                        //获取该节点的第二个子节点（用数组下标获取）
                        XmlNode secondLevelNode2 = node.ChildNodes[1];
                        name = secondLevelNode2.Name;
                        innerText = secondLevelNode2.InnerText;
                        Console.WriteLine("{0} = {1}", name, innerText);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void ModifyXmlInformation(string xmlFilePath)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                XmlNode rootNode = myXmlDoc.FirstChild;
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //修改此节点的属性值
                    if (node.Attributes["Description"].Value.Equals("Made in USA"))
                    {
                        node.Attributes["Description"].Value = "Made in HongKong";
                    }
                }
                //要想使对xml文件所做的修改生效，必须执行以下Save方法
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void AddXmlInformation(string xmlFilePath)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                //添加一个带有属性的节点信息
                foreach (XmlNode node in myXmlDoc.FirstChild.ChildNodes)
                {
                    XmlElement newElement = myXmlDoc.CreateElement("color");
                    newElement.InnerText = "black";
                    newElement.SetAttribute("IsMixed", "Yes");
                    node.AppendChild(newElement);
                }
                //保存更改
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void DeleteXmlInformation(string xmlFilePath)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                foreach (XmlNode node in myXmlDoc.FirstChild.ChildNodes)
                {
                    //记录该节点下的最后一个子节点（简称：最后子节点）
                    XmlNode lastNode = node.LastChild;
                    //删除最后子节点下的左右子节点
                    lastNode.RemoveAll();
                    //删除最后子节点
                    node.RemoveChild(lastNode);
                }
                //保存对xml文件所做的修改
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion

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

