//using Integration.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HN.Integration.Helper
{
    public class XmlHelper
    {
        /// <summary>
        /// 返回结果成功
        /// </summary>
        /// <param name="xml">XML文本</param>
        /// <returns>执行结果XML文本</returns>
        public static string ReturnSuccess(string xml)
        {
            XMLHead head = ResultXML(xml);
            head.curr_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            head.state_code = "000";
            head.state_desc = "调用成功！";
            return SendResultXML(head);
        }

        /// <summary>
        /// 返回结果失败
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="head">消息头</param>
        /// <param name="Error">错误内容</param>
        /// <returns>执行结果XML文本</returns>
        public static string ReturnError(string xml, string Error)
        {
            XMLHead head = ResultXML(xml);
            head.curr_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            head.state_code = "999";
            head.state_desc = Error;
            return SendResultXML(head);
        }

        /// <summary>
        /// 获取消息头
        /// </summary>
        /// <param name="xml">XML文本</param>
        /// <returns>消息头</returns>
        public static XMLHead ResultXML(string xml)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(XMLPackage<string>));
            TextReader tr = new StringReader(xml);
            XMLPackage<string> xmlpackage = (XMLPackage<string>)xmlser.Deserialize(tr);
            return xmlpackage.messagehead;
        }

        ///// <summary>
        ///// 获取NC消息头
        ///// </summary>
        ///// <param name="xml">XML文本</param>
        ///// <returns>消息头</returns>
        //public static NCHead GetNcHead(string xml)
        //{
        //    XmlSerializer xmlser = new XmlSerializer(typeof(NCPackage<string>));
        //    TextReader tr = new StringReader(xml);
        //    NCPackage<string> ncpackage = (NCPackage<string>)xmlser.Deserialize(tr);
        //    return ncpackage.messagehead;
        //}

        public static string SendResultXML(XMLHead head)
        {
            string strXml = "";
            XMLPackage<string> xmlpackage = new XMLPackage<string>();
            XMLBody<string> xmlbody = new XMLBody<string>();
            xmlpackage.messagehead = head;
            xmlpackage.messagebody = xmlbody;
            xmlpackage.messagebody.objects = null;
            //序列化
            XmlSerializer xmlser = new XmlSerializer(typeof(XMLPackage<string>));
            StringWriter writer = new StringWriter();
            try
            {
                xmlser.Serialize(writer, xmlpackage);
                writer.GetStringBuilder().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"GBK\"?>");
                writer.GetStringBuilder().Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                writer.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                strXml = writer.ToString();
                writer.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                writer.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 序列化XML
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="DataList">List对象</param>
        /// <param name="head">消息头</param>
        /// <returns>XML文本</returns>
        public static string SendData<T>(List<T> DataList, XMLHead head)
        {
            string strXml = "";
            XMLPackage<T> xmlpackage = new XMLPackage<T>();
            XMLBody<T> body = new XMLBody<T>();
            xmlpackage.messagehead = head;
            xmlpackage.messagebody = body;
            xmlpackage.messagebody.objects = new List<T>();
            xmlpackage.messagebody.objects = DataList;
            //序列化
            XmlSerializer xmlser = new XmlSerializer(typeof(XMLPackage<T>));
            StringWriter writer = new StringWriter();
            try
            {
                xmlser.Serialize(writer, xmlpackage);
                writer.GetStringBuilder().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"GBK\"?>");
                writer.GetStringBuilder().Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                writer.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                strXml = writer.ToString();
                writer.Close();
                //EsbService.ESBServiceClient client = new EsbService.ESBServiceClient();
                ////调用ESB并返回执行结果
                //return client.tranESBService(strXml);
                return "";
            }
            catch (Exception ex)
            {
                writer.Close();
                throw ex;
            }
        }

        //public static string CreateNcXml<T>(List<T> DataList, NCHead head)
        //{
        //    string strXml = "";
        //    NCPackage<T> xmlpackage = new NCPackage<T>();
        //    XMLBody<T> body = new XMLBody<T>();
        //    xmlpackage.messagehead = head;
        //    xmlpackage.messagebody = new List<T>();
        //    xmlpackage.messagebody = DataList;
        //    //序列化
        //    XmlSerializer xmlser = new XmlSerializer(typeof(NCPackage<T>));
        //    StringWriter writer = new StringWriter();
        //    try
        //    {
        //        xmlser.Serialize(writer, xmlpackage);
        //        writer.GetStringBuilder().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"GBK\"?>");
        //        writer.GetStringBuilder().Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
        //        writer.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
        //        strXml = writer.ToString();
        //        writer.Close();
        //        return strXml;                
        //    }
        //    catch (Exception ex)
        //    {
        //        writer.Close();
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 反序列化XML
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="xml">XML文本</param>
        /// <returns>List对象</returns>
        public static List<T> ConvertXmlToObject<T>(string xml)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(XMLPackage<T>));
            TextReader tr = new StringReader(xml);
            XMLPackage<T> xmlpackage = (XMLPackage<T>)xmlser.Deserialize(tr);
            return xmlpackage.messagebody.objects;
        }
    }
}
