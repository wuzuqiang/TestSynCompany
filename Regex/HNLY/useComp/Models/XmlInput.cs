using System.Collections.Generic;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models
{
    /// <summary>
    /// 输入Xml
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class XmlInput : XmlBase
    {
        /// <summary>
        /// 输入条件
        /// </summary>
        public Dictionary<string, string> CONDITION { get; set; }

        public static implicit operator XmlOutput(XmlInput xmlInput)
        {
            var xmlOutput = new XmlOutput()
            {
                MsgID = xmlInput.MsgID,
                InterfaceCode = xmlInput.InterfaceCode,
                InterfaceDescription = xmlInput.InterfaceDescription,
                Source = xmlInput.Source,
                MsgMark = xmlInput.MsgMark,
                WsMethod = xmlInput.WsMethod,
                Date = xmlInput.Date,
                User = "WLPTYSK",
                StateCode = "600",
                StateDesription = "正常发送"
            };
            return xmlOutput;
        }
    }
}
