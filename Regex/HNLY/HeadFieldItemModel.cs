using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fusion.WebService.ChinaSoft.MES.V2.Models.Utils
{
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
        /// 字段编码
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string FieldLength { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public string isPrimaryKey { get; set; }
    }
}
