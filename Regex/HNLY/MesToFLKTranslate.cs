using BaseClassUtils;
using HN.Integration.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HNLY
{
    public class MesToFLKTranslate
    {
        private static Dictionary<Type, List<PropertyInfo>> XmlTypeDics = new Dictionary<Type, List<PropertyInfo>>();
        internal static string CreateResXml<TModel, TXmlOutPut>(TModel dataList, TXmlOutPut xmloutput)
        {
            MessageSerialXmlV1 messageSerialXmlV1 = new MessageSerialXmlV1();
            var ret = (new XMLUtils()).serialXml<MessageSerialXmlV1>(messageSerialXmlV1);
            return ret;
        }

        public string GetHeadDataDefine()
        {
            return "";
        }
    }
}
