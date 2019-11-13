using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaseClassUtils
{
    public class XMLHelper
    {
        public string GetElementValue(string path, string eleKey)
        {
            string eleValue = "";
            XElement xe = XElement.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"temp.xml"));
            IEnumerable<XElement> elements = from ele in xe.Elements("HeadNode") select ele;
            foreach(var ele in elements)
            {
                eleValue = ele.Element("").Value;
            }
            return eleValue;
        }
    }
}
