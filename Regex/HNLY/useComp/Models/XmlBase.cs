namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models
{
    /// <summary>
    /// xml基本参数
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class XmlBase
    {
        /// <summary>
        /// 接口编码
        /// </summary>
        public string InterfaceCode { get; set; }
        /// <summary>
        /// 接口描述
        /// </summary>
        public string InterfaceDescription { get; set; }
        /// <summary>
        /// XML唯一性标识
        /// </summary>
        public string MsgID { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 服务标识
        /// </summary>
        public string MsgMark { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string WsMethod { get; set; }
        /// <summary>
        /// 系统当前时间
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 额外
        /// </summary>
        public string Cryp { get; set; }
        /// <summary>
        /// 服务提供方
        /// </summary>
        public string User { get; set; }
    }
}