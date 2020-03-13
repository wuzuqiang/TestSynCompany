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
    [XmlRoot("string", Namespace = "", DataType = "string", IsNullable = false)]
    public class XMLFeedBackResult
    {
        public XMLFeedBackResult()
        {
            retNodeHead = new RetNodeHead();
        }
        /// <remarks/>
        [XmlElement("Msg")]
        public RetNodeHead retNodeHead { get; set; }
    }
    public class RetNodeHead
    {
        public RetNodeHead()
        {
            Head = new _RetHead();
        }
        /// <remarks/>
        [XmlElement("Head")]
        public _RetHead Head { get; set; }
    }

    public class _RetHead
    {
        public string InterfaceCode { get; set; }
        public string InterfaceDescription { get; set; }
        public string MsgID { get; set; }
        public string Source { get; set; }
        public string MsgMark { get; set; }
        public string WsMethod { get; set; }
        public string Date { get; set; }
        public string Cryp { get; set; }
        public string User { get; set; }
        public string StateCode { get; set; }
        public string StateDesription { get; set; }
    }
}
