using System;
using System.Xml.Serialization;

namespace Serializable
{
    [Serializable] //不可少！ 
    [XmlRoot("Test")]
    public class Person
    {
        private String name;
        private String sex;
        private int age;

        public Person() //XmlSerializer序列化要求一定要有无参数构造函数 
        {
            name = "";
            sex = "";
            age = 0;
        }

        public Person(String n, String s, int a)
        {
            name = n;
            sex = s;
            age = a;
        }

        [XmlElement("Ele01")]
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public String Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}