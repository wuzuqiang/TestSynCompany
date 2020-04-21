using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HN.Integration.Helper
{
    /// <summary>
    /// SerialDBData 的摘要说明。接口数据的序列化对象
    /// </summary>

    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "", IncludeInSchema = false)]
    [XmlRoot("Msg", Namespace = "", DataType = "string", IsNullable = false)]
    public class MessageSerialXml
    {
        public MessageSerialXml()
        {
            this.Head = new _Head();
            this.Data = new _Data();
        }

        #region //序列化和反序列化实例
        public static void SerialClass(MessageSerialXml SourceObj, string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MessageSerialXml));
            System.IO.StringWriter writer = new System.IO.StringWriter();
            ser.Serialize(writer, SourceObj);
            writer.GetStringBuilder().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"GB2312\"?>");
            writer.GetStringBuilder().Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            writer.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            System.IO.File.SetAttributes(FileName, System.IO.FileAttributes.Normal);//去除只读属性
            System.IO.FileStream fs = new System.IO.FileStream(FileName, System.IO.FileMode.Create);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            sw.Write(writer.GetStringBuilder().ToString());
            sw.Close();
            writer.Close();
            fs.Close();
        }

        public static string SerialClassToXML(MessageSerialXml SourceObj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MessageSerialXml));
            System.IO.StringWriter writer = new System.IO.StringWriter();
            ser.Serialize(writer, SourceObj);
            writer.GetStringBuilder().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            writer.GetStringBuilder().Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            writer.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            return writer.GetStringBuilder().ToString();
        }

        public static MessageSerialXml DeSerialClass(string FileName)
        {
            MessageSerialXml result;
            XmlSerializer ser = new XmlSerializer(typeof(MessageSerialXml));
            System.IO.FileStream fs = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            result = (MessageSerialXml)ser.Deserialize(fs);
            fs.Close();
            return result;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="XMLString"></param>
        /// <returns></returns>
        public static MessageSerialXml DeSerialClassFromXML(string XMLString)
        {
            MessageSerialXml result;
            XmlSerializer ser = new XmlSerializer(typeof(MessageSerialXml));
            System.IO.StringWriter writer = new System.IO.StringWriter();
            writer.Write(XMLString);
            System.IO.TextReader tr = new System.IO.StringReader(writer.GetStringBuilder().ToString());
            result = (MessageSerialXml)ser.Deserialize(tr);
            tr.Close();
            writer.Close();
            return result;
        }
        #endregion

        /// <remarks/>
        [XmlElement("Head")]
        public _Head Head { get; set; }

        /// <remarks/>
        [XmlElement("Data")]
        public _Data Data { get; set; }
    }

    #region Head
    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("Head", Namespace = "", IsNullable = false)]
    public class _Head
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlElement("MsgID")]
        public string MsgID;

        /// <summary>
        /// 接口标识
        /// </summary>
        [XmlElement("InterfaceCode")]
        public string InterfaceCode;

        /// <summary>
        /// 接口描述
        /// </summary>
        [XmlElement("InterfaceDescription")]
        public string InterfaceDescription;

        /// <summary>
        /// 发送源
        /// </summary>
        [XmlElement("Source")]
        public string Source;

        /// <summary>
        /// 服务标识
        /// </summary>
        /// <remarks>用于在ESB企业总线中标识Webservice服务</remarks>
        [XmlElement("MsgMark")]
        public string MsgMark;

        /// <summary>
        /// 服务方法
        /// </summary>
        [XmlElement("WsMethod")]
        public string WsMethod;

        /// <summary>
        /// 消息发送时间
        /// </summary>
        [XmlElement("Date")]
        public string Date;

        /// <summary>
        /// 状态
        /// </summary>
        [XmlElement("StateCode")]
        public string StateCode;

        /// <summary>
        /// 状态描述
        /// </summary>
        [XmlElement("StateDesription")]
        public string StateDesription;

        /// <summary>
        /// 数据定义
        /// </summary>
        [XmlElement("DataDefine")]
        public _DataDefine DataDefine;

        /// <summary>
        /// 密钥，预留
        /// </summary>
        [XmlElement("Cryp")]
        public string Cryp;

        /// <summary>
        /// 发送用户
        /// </summary>
        /// <remarks>为ESB总线保留</remarks>
        [XmlElement("User")]
        public string User;
    }
    #endregion

    #region DataDefine
    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("DataDefine", Namespace = "", IsNullable = false)]
    public class _DataDefine
    {
        /// <summary>
        /// 表结构
        /// </summary>
        [XmlElement("Table")]
        public _Table[] TableSet;
    }

    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("Table", Namespace = "", IsNullable = false)]
    public class _Table
    {
        /// <summary>
        /// 表名称
        /// </summary>
        [XmlAttribute("TableName")]
        public string TableName;

        /// <remarks/>
        [XmlElement("FieldItem")]
        public _FieldItem[] FieldItemSet;
    }

    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("FieldItem", Namespace = "", IsNullable = false)]
    public class _FieldItem
    {
        /// <remarks/>
        [XmlAttribute("FieldName")]
        public string FieldName;

        /// <remarks/>
        [XmlAttribute("Caption")]
        public string Caption;

        /// <remarks/>
        [XmlAttribute("FieldType")]
        public string FieldType;

        /// <remarks/>
        [XmlAttribute("FieldLength")]
        public string FieldLength;

        /// <remarks/>
        [XmlAttribute("Remark")]
        public string Remark;

        /// <remarks/>
        [XmlAttribute("isPrimaryKey")]
        public string isPrimaryKey;
    }
    #endregion

    #region Data

    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("Data", Namespace = "", IsNullable = false)]
    public class _Data
    {
        /// <summary>
        /// 数据表
        /// </summary>
        [XmlElement("DataTable")]
        public _DataTable[] DataTableSet { get; set; }
    }

    /// <summary>
    /// 数据表
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("DataTable", Namespace = "", IsNullable = false)]
    public class _DataTable
    {
        /// <summary>
        /// 表名
        /// </summary>
        [XmlAttribute("TableName")]
        public string TableName { get; set; }

        /// <summary>
        /// 数据行
        /// </summary>
        [XmlElement("Row")]
        public _Row[] RowSet { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("Row", Namespace = "", IsNullable = false)]
    public class _Row
    {
        /// <remarks/>
        [XmlAttribute("Index")]
        public string Index;

        /// <remarks/>
        [XmlElement("Header")]
        public _Header Header;
    }

    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("Header", Namespace = "", IsNullable = false)]
    public class _Header
    {
        /// <remarks/>
        [XmlAttribute("Action")]
        public string Action;

        /// <remarks/>
        [XmlElement("DataItem")]
        public _DataItem[] DataItemSet;
    }

    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("DataItem", Namespace = "", IsNullable = false)]
    public class _DataItem
    {
        /// <remarks/>
        [XmlAttribute("FieldName")]
        public string FieldName;

        /// <remarks/>
        [XmlAttribute("FieldValue")]  
        public string FieldValue;
    }

    #endregion

}
