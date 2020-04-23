using System;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.Utils
{
    /// <summary>
    /// 头部信息属性
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class HeadFieldItemModel : Attribute
    {
        public HeadFieldItemModel(string caption, string isPrimaryKey, string remark, string fieldLength, string fieldType)
        {
            this.isPrimaryKey = isPrimaryKey;
            this.Remark = remark;
            this.FieldLength = fieldLength;
            this.FieldType = fieldType;
            this.Caption = caption;
        }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public string isPrimaryKey { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string FieldLength { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 字段编码
        /// </summary>
        public string FieldName { get; set; }
    }
}
