using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            foreach(var ele in elements)
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

                if (isUseConsoleProject)
                {
                    Type t = model.GetType();//获得该类的Type

                    //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
                    foreach (PropertyInfo pi in t.GetProperties())
                    {
                        object value1 = pi.GetValue(model, null);//用pi.GetValue获得值
                        string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                                              //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数
                        if (value1.GetType() == typeof(int))
                        {
                            //进行你想要的操作
                        }
                        Console.WriteLine(value1 + "\t");
                    }
                    Console.WriteLine();
                }
            }
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

