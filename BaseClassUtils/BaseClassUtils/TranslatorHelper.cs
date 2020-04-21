using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Composition;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

/*
*2018-6-11 create by chendl
*/
namespace BaseClassUtils
{
    public class TranslatorHelper
    {
        public static Dictionary<Type, List<PropertyInfo>> ModelTypeDics = new Dictionary<Type, List<PropertyInfo>>();
        
        /// <summary>
        /// 解析xml 接收主表的Data数据
        /// </summary>
        /// <typeparam name="T">构造数据的目标对象并返回对象</typeparam>
        /// <param name="reqXml"></param>
        /// <param name="nodePath">获取阶级</param>
        /// <returns></returns>
        public static List<T> AnalysicInputData<T>(string reqXml, string nodePath = "/DATASETS/DATA/ITEM")
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(reqXml);
            XmlNodeList rootList = document.SelectNodes(nodePath);
            var list = new List<T>();

            var t = RegisteModelTypeDics(typeof(T));
            var propertityList = ModelTypeDics[typeof(T)];
            var ass = Assembly.GetAssembly(t);

            for (int r = 0; r < rootList.Count; r++)
            {
                var childlist = rootList[r].ChildNodes;
                var _obj = ass.CreateInstance(t.FullName, true);

                for (int i = 0; i < childlist.Count; i++)
                {
                    foreach (XmlNode xnl in childlist[i].ChildNodes)
                    {
                        if (xnl.ParentNode.Attributes.Count > 0)
                        {
                            var p = propertityList.
                                    Where(it => it.Name == xnl.ParentNode.Attributes?[0]?.Value.Trim()).
                                    FirstOrDefault();
                            if (p != null)
                            {
                                p.SetValue((T)_obj, xnl.Value);
                            }
                        }
                    }
                }
                list.Add((T)_obj);
            }
            return list;
        }

        /// <summary>
        /// 解析xml 接收主细表的Data数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static List<T> AnalysicInputData<T, DetailT>(string xmlData, string nodePath = "/DATASETS/DATA/ITEM")
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData);
            var list = new List<T>();

            XmlElement element = xmlDoc.DocumentElement;
            var childNodes = element.SelectNodes(nodePath);

            foreach (XmlNode childNode in childNodes)
            {
                T objModel = Activator.CreateInstance<T>();
                SetProperty<DetailT>(objModel, childNode);
                list.Add(objModel);
            }

            return list;
        }

        private static void SetProperty<DetailT>(object objModel, XmlNode xmlNode)
        {
            XmlNodeList childs = xmlNode.ChildNodes;
            foreach (XmlNode item in childs)
            {
                XmlNode node = item;
                if (item.Name == "ITEM_1")
                {
                    DetailT objDetailModel = Activator.CreateInstance<DetailT>();
                    SetProperty<DetailT>(objDetailModel, node);

                    var detail = objModel.GetType().GetProperty("Detail");
                    if (detail == null) continue;
                    var detailListValue = detail.GetValue(objModel);
                    var detailList = detailListValue as List<DetailT>;
                    if (detailList == null)
                    {
                        detailList = new List<DetailT>();
                    }
                    detailList.Add(objDetailModel);
                    detail.SetValue(objModel, detailList);
                }
                else
                {
                    var name = node.Attributes?[0]?.Value.Trim();
                    PropertyInfo pi = objModel.GetType().GetProperty(name);
                    if (pi == null) continue;
                    if (!string.IsNullOrEmpty(node.InnerXml.Trim()))
                        pi.SetValue(objModel, node.InnerXml);
                }
            }
        }

        /// <summary>
        /// 生成反馈头部xml
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="xmloutput"></param>
        /// <returns></returns>
        internal static string CreateResXml<TXmlOutPut>(TXmlOutPut xmloutput)
        {
            var xmldoc = new XmlDocument();
            var elDeclar = xmldoc.CreateXmlDeclaration("1.0", "GBK", null);
            xmldoc.AppendChild(elDeclar);
            var elDataSets = xmldoc.CreateElement("DATASETS");
            var elHead = xmldoc.CreateElement("HEAD");
            MakeHeadXml(xmloutput, xmldoc, elHead);
            elDataSets.AppendChild(elHead);
            xmldoc.AppendChild(elDataSets);
            return xmldoc.InnerXml;
        }

        /// <summary>
        /// 生成Xml结构=>返回数据结构一级ITEM
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="xmloutput"></param>
        /// <returns></returns>
        public static string CreateResXml<TModel, TXmlOutPut>(IList<TModel> datas, TXmlOutPut xmloutput)
        {
            //注册类型字典
            RegisteModelTypeDics(typeof(TModel));
            RegisteModelTypeDics(typeof(TXmlOutPut));

            //创建XML文档
            var xmldoc = new XmlDocument();

            //Element-xml
            var elDeclar = xmldoc.CreateXmlDeclaration("1.0", "GBK", null);
            xmldoc.AppendChild(elDeclar);

            //Element-DATASETS
            var elDataSets = xmldoc.CreateElement("DATASETS");
            var elHead = xmldoc.CreateElement("HEAD");
            MakeHeadXml(xmloutput, xmldoc, elHead);
            elDataSets.AppendChild(elHead);
            xmldoc.AppendChild(elDataSets);

            //Element-DATA
            var elData = xmldoc.CreateElement("DATA");

            //Element-DESC
            var elDesc = xmldoc.CreateElement("DESC");
            var elDescItem = xmldoc.CreateElement("ITEM");
            var modelProperties = ModelTypeDics[typeof(TModel)];
            foreach (var property in modelProperties)
            {
                var elField = xmldoc.CreateElement("FIELD");
                elField.SetAttribute("NAME", property.Name);
                elField.InnerText = (property.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute).Description;
                elDescItem.AppendChild(elField);
            }
            elDesc.AppendChild(elDescItem);
            elData.AppendChild(elDesc);

            //Element-ITEM
            datas.ToList().ForEach(model =>
            {
                var elItem = xmldoc.CreateElement("ITEM");
                PropertyMakeXmlElement(modelProperties, model, xmldoc, elItem, false);
                elData.AppendChild(elItem);
            });
            elDataSets.AppendChild(elData);

            return xmldoc.InnerXml;
        }
        /// <summary>
        /// 生成Xml结构=>返回数据结构多级，递归关联细表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TXmlOutPut"></typeparam>
        /// <param name="datas"></param>
        /// <param name="xmloutput"></param>
        /// <returns></returns>
        internal static string CreateResXml<TModel, TXmlOutPut>(TModel datas, TXmlOutPut xmloutput)
        {
            var xmldoc = new XmlDocument();
            //Element-Declaration
            var elDeclar = xmldoc.CreateXmlDeclaration("1.0", "GBK", null);
            xmldoc.AppendChild(elDeclar);
            //Element-DATASETS
            var elDataSets = xmldoc.CreateElement("DATASETS");
            xmldoc.AppendChild(elDataSets);
            //Element-DATASETS-HEAD
            var elHead = xmldoc.CreateElement("HEAD");
            elDataSets.AppendChild(elHead);
            MakeHeadXml(xmloutput, xmldoc, elHead);
            //Element-DATASETS-DATA
            var elData = xmldoc.CreateElement("DATA");
            elDataSets.AppendChild(elData);
            //Element-DATASETS-DATA-DESC
            var elDesc = xmldoc.CreateElement("DESC");
            elData.AppendChild(elDesc);
            //Element-DATASETS-DATA-ITEM
            MakeDataXml(xmldoc, elData, datas, false);
            MakeDataXml(xmldoc, elDesc, datas, true);
            return xmldoc.InnerXml;
        }
        internal static string CreateResXml<TModel, TXmlOutPut>(List<TModel> datas, TXmlOutPut xmloutput)
        {
            var xmldoc = new XmlDocument();
            //Element-Declaration
            var elDeclar = xmldoc.CreateXmlDeclaration("1.0", "GBK", null);
            xmldoc.AppendChild(elDeclar);
            //Element-DATASETS
            var elDataSets = xmldoc.CreateElement("DATASETS");
            xmldoc.AppendChild(elDataSets);
            //Element-DATASETS-HEAD
            var elHead = xmldoc.CreateElement("HEAD");
            elDataSets.AppendChild(elHead);
            MakeHeadXml(xmloutput, xmldoc, elHead);
            //Element-DATASETS-DATA
            var elData = xmldoc.CreateElement("DATA");
            elDataSets.AppendChild(elData);
            //Element-DATASETS-DATA-DESC
            var elDesc = xmldoc.CreateElement("DESC");
            elData.AppendChild(elDesc);
            //Element-DATASETS-DATA-ITEM
            MakeDataXml(xmldoc, elDesc, datas[0], true);
            datas.ForEach(it =>
            {
                MakeDataXml(xmldoc, elData, it, false);
            });
            return xmldoc.InnerXml;
        }
        /// <summary>
        /// 生成头部信息
        /// </summary>
        /// <typeparam name="TXmlOutPut"></typeparam>
        /// <param name="xmloutput"></param>
        /// <param name="xmldoc"></param>
        /// <param name="element"></param>
        private static void MakeHeadXml<TXmlOutPut>(TXmlOutPut xmloutput, XmlDocument xmldoc, XmlElement element)
        {
            RegisteModelTypeDics(typeof(TXmlOutPut));
            var outputProperties = ModelTypeDics[typeof(TXmlOutPut)];
            foreach (var property in outputProperties)
            {
                var el = xmldoc.CreateElement(property.Name);
                el.InnerText = GetValue(property.GetValue(xmloutput));
                element.AppendChild(el);
            }
        }
        /// <summary>
        /// 生成数据信息
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="xmldoc"></param>
        /// <param name="element"></param>
        /// <param name="datas"></param>
        /// <param name="isGetDescription">是否要获取描述</param>
        private static void MakeDataXml<TModel>(XmlDocument xmldoc, XmlElement element, TModel datas, bool isGetDescription)
        {
            RegisteModelTypeDics(typeof(TModel));
            var modelProperties = ModelTypeDics[typeof(TModel)];
            var xmlNode = xmldoc.CreateElement("ITEM");
            PropertyMakeXmlElement(modelProperties, datas, xmldoc, xmlNode, isGetDescription);
            element.AppendChild(xmlNode);
        }
        public static void PropertyMakeXmlElement<TModel>(List<PropertyInfo> modelProperties, TModel datas, XmlDocument xmldoc, XmlElement element, bool isGetDescription)
        {
            modelProperties.ForEach(property =>
            {
                var desp = GetAttribute(property);
                if (desp != null)
                {
                    var elField = xmldoc.CreateElement("FIELD");
                    elField.SetAttribute("NAME", property.Name);
                    elField.InnerText = isGetDescription ? desp.Description : GetValue(property.GetValue(datas));
                    element.AppendChild(elField);
                }
                else
                {
                    InputCreateMethod(datas, xmldoc, element, isGetDescription);
                }
            });
        }

        public static void InputCreateMethod<TModel>(TModel datas, XmlDocument xmldoc, XmlElement element, bool isGetDescription)
        {
            var active = Activator.CreateInstance(datas.GetType());
            active = datas;
            datas.GetType()?.GetMethod("Create")?.Invoke(active, new object[] { xmldoc, element, isGetDescription });
        }

        public static DescriptionAttribute GetAttribute(PropertyInfo p)
        {
            return p.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
        }

        internal static string GetErrorInfo(Exception exception)
        {
            return (new XElement("Error", new XCData("获取异常，请联系负责人。" + exception.Message)).ToString());
        }

        internal static string GetValue(object obj, string defaultValue = "无")
        {
            return obj == null ? defaultValue :
                (string.IsNullOrEmpty(obj.ToString()) ? defaultValue : obj.ToString());
        }

        internal static DateTime GetEndTime(bool active)
        {
            return active ? DateTime.MaxValue : DateTime.Now;
        }

        #region Private Method
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

        private static void DeserializeObject(IEnumerable<XElement> xElements, Tuple<string, Type> tuples)
        {
            var type = tuples.Item2;

            RegisteModelTypeDics(type);

            var fields = xElements
                .Descendants(tuples.Item1)
                 .Select(b => new
                 {
                     Name = b.Element("FIELD").Attribute("NAME").Value,
                     Value = b.Element("FIELD").Value
                 })
                .ToDictionary(c => c.Name, c => c.Value);

            var propertyInfos = ModelTypeDics[type];
            var properties = from property in propertyInfos
                             join field in fields on property.Name equals field.Key
                             select new { property, field.Value };

            Assembly assembly = Assembly.GetExecutingAssembly();
            object obj = assembly.CreateInstance(type.FullName, true);

        }
        #endregion
    }

    /// <summary>
    /// 若有细表，则用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AnalysisDetail<T>
    {
        public abstract List<T> Details { get; set; }

        public void Create(XmlDocument xmldoc, XmlElement element, bool isGetDescription)
        {
            TranslatorHelper.RegisteModelTypeDics(typeof(T));
            if (Details == null || Details.Count < 1)
                return;

            foreach (var item in Details)
            {
                var xmlNode = xmldoc.CreateElement(element.Name + "_1");
                element.AppendChild(xmlNode);
                var pro = TranslatorHelper.ModelTypeDics[typeof(T)];
                TranslatorHelper.PropertyMakeXmlElement(pro, item, xmldoc, xmlNode, isGetDescription);

                if (isGetDescription)
                {
                    return;
                }
            }
        }
    }
}
