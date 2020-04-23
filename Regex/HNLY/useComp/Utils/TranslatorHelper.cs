using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models;
using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
/*
*2019-05-29 create by 吴淑婉
*/
namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Utils
{
    internal class TranslatorHelper
    {
        public static Dictionary<Type, List<PropertyInfo>> ModelTypeDics = new Dictionary<Type, List<PropertyInfo>>();
        private static Dictionary<Type, List<PropertyInfo>> XmlTypeDics = new Dictionary<Type, List<PropertyInfo>>();

        /// <summary>
        /// 生成Xml结构=>每次返回数据结构Data
        /// </summary>
        /// <typeparam name="TModel">数据Type</typeparam>
        /// <typeparam name="TDic">头部字段描述Type</typeparam>
        /// <typeparam name="TXmlOutPut">头部返回Type</typeparam>
        /// <param name="dataList">字段数值</param>
        /// <param name="dataDefine">字段描述</param>
        /// <param name="xmloutput">头部返回</param>
        /// <returns></returns>
        internal static string CreateResXml<TModel, TXmlOutPut>(TModel dataList, TXmlOutPut xmloutput)
        {
            //注册类型字典
            //RegisteModelTypeDics(typeof(TModel));
            RegisteXmlTypeDics(typeof(TXmlOutPut));

            //创建XML文档
            var xmldoc = new XmlDocument();

            //Element-xml
            var elDeclar = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(elDeclar);

            //Element-dataset
            var elDataSets = xmldoc.CreateElement("Msg");
            var elHead = xmldoc.CreateElement("Head");
            var xmlProperties = XmlTypeDics[typeof(TXmlOutPut)];
            foreach (var property in xmlProperties)
            {
                var el = xmldoc.CreateElement(property.Name);
                el.InnerText = property.GetValue(xmloutput).ToString();
                elHead.AppendChild(el);
            }

            //Element-dataDefine
            MakeHeadDataXml(xmldoc, elHead, dataList);
            elDataSets.AppendChild(elHead);
            //Element-data
            var xmlNode = xmldoc.CreateElement("Data");
            MakeDataXml(dataList, xmldoc, xmlNode);

            elDataSets.AppendChild(xmlNode);
            xmldoc.AppendChild(elDataSets);

            return xmldoc.InnerXml;
        }

        #region Private Method
        private static void RegisteXmlTypeDics(Type xmlType)
        {
            if (XmlTypeDics.ContainsKey(xmlType))
            {
                return;
            }

            List<PropertyInfo> properties = new List<PropertyInfo>();
            GetPropertyInfos(xmlType, properties);
            XmlTypeDics.Add(xmlType, properties);
        }

        private static void GetPropertyInfos(Type type, List<PropertyInfo> propertyInfos)
        {
            if (type.BaseType != null)
            {
                GetPropertyInfos(type.BaseType, propertyInfos);
            }
            var properties = type.GetProperties().Where(e => e.DeclaringType == type);
            propertyInfos.AddRange(properties);
        }

        public static Type RegisteModelTypeDics(Type modelType)
        {
            if (ModelTypeDics.ContainsKey(modelType))
            {
                return modelType;
            }
            var allProperties = modelType.GetProperties().ToList();
            ModelTypeDics.Add(modelType, allProperties);
            return modelType;
        }

        #endregion

        #region MakeHeadDataXml
        private static void MakeHeadDataXml<TModel>(XmlDocument xmldoc, XmlElement element, TModel datas)
        {
            var modelType = datas.GetType();
            var isList = datas.GetType().IsGenericType;
            object detailList = new object();
            if (isList)
            {
                modelType = modelType.GenericTypeArguments[0];
                detailList = (datas as IEnumerable<object>).FirstOrDefault();
            }
            else
            {
                detailList = datas;
            }
            RegisteModelTypeDics(modelType);
            var modelProperties = ModelTypeDics[modelType];
            var xmlNode = xmldoc.CreateElement("DataDefine");
            var attrs = modelType.GetCustomAttributes(typeof(DescriptionAttribute), false);
            PropertyMakeXmlElement(modelProperties, attrs, detailList, xmldoc, xmlNode);
            element.AppendChild(xmlNode);
        }

        public static void PropertyMakeXmlElement<TModel>(List<PropertyInfo> modelProperties, object[] attrs, TModel datas, XmlDocument xmldoc, XmlElement element)
        {
            var elTableName = xmldoc.CreateElement("Table");
            elTableName.SetAttribute("TableName", attrs.Count() > 0 ? ((DescriptionAttribute)attrs[0]).Description : "");
            var isChild = false;
            modelProperties.ForEach(property =>
            {
                var IsGenericType = property.PropertyType.IsGenericType;
                var list = property.PropertyType.GetInterface("IEnumerable", false);
                if (IsGenericType && list != null)
                {
                    element.AppendChild(elTableName);
                    var listVal = property.GetValue(datas) as IEnumerable<object>;
                    if (listVal == null) { return; }
                    var detail = listVal.FirstOrDefault();
                    RegisteModelTypeDics(detail.GetType());
                    var modelDetailProperties = ModelTypeDics[detail.GetType()];
                    var descriptions = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    PropertyMakeXmlElement(modelDetailProperties, descriptions, detail, xmldoc, element);
                    isChild = true;
                }
                else
                {
                    var desp = GetAttribute(property);
                    if (desp != null)
                    {
                        var elField = xmldoc.CreateElement("FieldItem");
                        var dpropertys = desp.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                        foreach (var dproperty in dpropertys)
                        {
                            elField.SetAttribute(dproperty.Name, GetValue(dproperty.GetValue(desp), property.Name));
                        }
                        elTableName.AppendChild(elField);
                    }
                    else
                    {
                        InputCreateMethod(datas, xmldoc, elTableName);
                    }
                }
            });
            if (!isChild)
            {
                element.AppendChild(elTableName);
            }
        }

        public static void InputCreateMethod<TModel>(TModel datas, XmlDocument xmldoc, XmlElement element)
        {
            var active = Activator.CreateInstance(datas.GetType());
            active = datas;
            datas.GetType()?.GetMethod("Create")?.Invoke(active, new object[] { xmldoc, element });
        }

        public static HeadFieldItemModel GetAttribute(PropertyInfo p)
        {
            return p.GetCustomAttribute(typeof(HeadFieldItemModel)) as HeadFieldItemModel;
        }
        #endregion

        #region MakeDataXml
        private static void MakeDataXml<TModel>(TModel model, XmlDocument xmldoc, XmlElement element)
        {
            var modelType = model.GetType();
            var isList = model.GetType().IsGenericType;
            var elTableName = xmldoc.CreateElement("DataTable");
            List<object> detailList = new List<object>();
            if (isList)
            {
                modelType = modelType.GenericTypeArguments[0];
                detailList = (model as IEnumerable<object>).ToList();
            }
            else
            {
                detailList.Add(model);
            }

            var modelProperties = ModelTypeDics[modelType];
            var attrs = modelType.GetCustomAttributes(typeof(DescriptionAttribute), false);
            elTableName.SetAttribute("TableName", attrs.Count() > 0 ? ((DescriptionAttribute)attrs[0]).Description : "");
            for (int i = 0; i < detailList.Count(); i++)
            {
                PropertyMakeDataXmlElement(modelProperties, i, detailList[i], xmldoc, elTableName, element);
            }
        }

        private static void PropertyMakeDataXmlElement<TModel>(List<PropertyInfo> modelProperties, int dataCount, TModel datas, XmlDocument xmldoc, XmlElement elTableName, XmlElement element)
        {
            var properties = modelProperties.Where(a => a.PropertyType.IsGenericType == false).ToList();
            MakeDataXmlElement(properties, dataCount, datas, xmldoc, elTableName);
            element.AppendChild(elTableName);

            var isList = modelProperties.Any(a => a.PropertyType.IsGenericType);
            if (isList)
            {
                var property = modelProperties.FirstOrDefault(a => a.PropertyType.IsGenericType);
                var list = property.PropertyType.GetInterface("IEnumerable", false);
                var listVal = property.GetValue(datas) as IEnumerable<object>;
                if (listVal == null) { return; }
                var descriptions = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var elDetailTableName = xmldoc.CreateElement("DataTable");
                elDetailTableName.SetAttribute("TableName", descriptions.Count() > 0 ? ((DescriptionAttribute)descriptions[0]).Description : "");
                var detailList = listVal.ToList();
                for (int i = 0; i < detailList.Count(); i++)
                {
                    var model = ModelTypeDics[detailList[i].GetType()];
                    MakeDataXmlElement(model, i, detailList[i], xmldoc, elDetailTableName);
                }
                element.AppendChild(elDetailTableName);
            }
        }

        private static void MakeDataXmlElement<TModel>(List<PropertyInfo> modelProperties, int dataCount, TModel datas, XmlDocument xmldoc, XmlElement elTableName)
        {
            var elRow = xmldoc.CreateElement("Row");
            elRow.SetAttribute("Index", dataCount.ToString());
            var elHeader = xmldoc.CreateElement("Header");
            elHeader.SetAttribute("Action", "Unchange");
            modelProperties.ForEach(property =>
            {
                var fieldItem = xmldoc.CreateElement("DataItem");
                fieldItem.SetAttribute("FieldName", property.Name);
                fieldItem.SetAttribute("FieldValue", GetValue(property.GetValue(datas)));
                elHeader.AppendChild(fieldItem);
            });
            elRow.AppendChild(elHeader);
            elTableName.AppendChild(elRow);
        }
        #endregion

        internal static string GetValue(object obj, string defaultValue = " ")
        {
            return obj == null ? defaultValue :
                (string.IsNullOrEmpty(obj.ToString()) ? defaultValue : obj.ToString());
        }

        /// <summary>
        /// 解析头部信息
        /// </summary>
        /// <param name="reqXml"></param>
        /// <returns></returns>
        internal static XmlOutput AnalysisHeaderXml(string xml)
        {
            XElement xl = XElement.Parse(xml);
            var xmlOutput = (xl.Descendants("head")
                .Select(e => new XmlOutput
                {
                    InterfaceCode = e.Element("InterfaceCode").Value,
                    InterfaceDescription = e.Element("InterfaceDescription").Value,
                    MsgID = e.Element("MsgID").Value,
                    Source = e.Element("Source").Value,
                    MsgMark = e.Element("MsgMark").Value,
                    WsMethod = e.Element("WsMethod").Value,
                    User = e.Element("User").Value,
                    Date = e.Element("Date").Value,
                    StateCode = e.Element("StateCode").Value,
                    StateDesription = e.Element("StateDesription").Value,
                })
                ).FirstOrDefault();

            return xmlOutput;
        }
    }
}
