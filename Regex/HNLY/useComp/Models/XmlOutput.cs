namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models
{
    /// <summary>
    /// 输出xml
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class XmlOutput : XmlBase
    {
        /// <summary>
        /// 状态编码
        /// </summary>
        public string StateCode { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string StateDesription { get; set; }
    }
}
