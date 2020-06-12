using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HN.Integration.Helper
{
    [Serializable]
    [XmlType(Namespace = "", IncludeInSchema = false)]
    [XmlRoot("Msg", Namespace = "", DataType = "string", IsNullable = false)]
    public class MessageSerialXmlV1
    {
        public MessageSerialXmlV1()
        {
            this.Head = new _HeadV1();
        }

        /// <remarks/>
        [XmlElement("Head")]
        public _HeadV1 Head { get; set; }

        /// <remarks/>
        [XmlElement("Data")]
        public string Data { get; set; }
    }

    #region Head
    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "")]
    [XmlRoot("Head", Namespace = "", IsNullable = false)]
    public class _HeadV1
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
        public string DataDefine;

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

}
