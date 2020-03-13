using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HN.Integration.Helper
{
    /// <summary>
    /// 传递Xml规范的消息包类定义
    /// </summary>
    /// <typeparam name="T">泛型类型</typeparam>
    [XmlRoot("dataset")]
    public class XMLPackage<T>
    {
        /// <summary>
        /// 消息头
        /// </summary>
        [XmlElement("head")]
        public XMLHead messagehead;

        /// <summary>
        /// 消息体
        /// </summary>
        [XmlElement("datalist")]
        public XMLBody<T> messagebody;

        public List<T> getBody()
        {
            return this.messagebody.objects;
        }
    }
}
