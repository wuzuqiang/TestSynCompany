using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HN.Integration.Helper
{
    /// <summary>
    /// 传递Xml规范的消息体类定义
    /// </summary>
    /// <typeparam name="T">泛型类型</typeparam>
    public class XMLBody<T>
    {
        /// <summary>
        /// 数据数组
        /// </summary>
        [XmlElement("data")]
        public List<T> objects;
    }
}
