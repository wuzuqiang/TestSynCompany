////using HN.Framework.Server;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace HN.Integration.Helper
//{
//    /// <summary>
//    /// 信息打包和解包
//    /// </summary>
//    public class MessagePackage //: BaseLogic
//    {
//        /// <summary>
//        /// 消息对像
//        /// </summary>
//        private MessageSerialXml serialXmlObject;
//        public MessageSerialXml SerialXmlObject
//        {
//            get { return serialXmlObject; }
//            set { serialXmlObject = value; }
//        }

//        public MessagePackage(string interfaceCode, string desc)
//        {
//            string xmlPath = @"Configs\TaskConfig.xml";
//            XmlDocument xmlDoc = new XmlDocument();
//            xmlDoc.Load(xmlPath);
//            string taskConfigXml = xmlDoc.OuterXml;

//            // 读取与当前任务相关的配置
//            xmlDoc.LoadXml(taskConfigXml);
//            string xpath = "/Configuration/TaskList/Task[@No = '" + interfaceCode + "']";
//            XmlNode taskNode = xmlDoc.SelectSingleNode(xpath);
//            if (taskNode == null)
//                throw new Exception("找不到接口代码为：" + interfaceCode + "的配置.");
//            string Description = taskNode.Attributes["Description"].Value;
//            string XmlPath = @"Configs\Xml\" + taskNode.Attributes["xmlFile"].Value;
//            xmlDoc.Load(XmlPath);
//            string xml = xmlDoc.OuterXml;
//            this.serialXmlObject = MessageSerialXml.DeSerialClassFromXML(xmlDoc.OuterXml);

//        }

//        public MessagePackage(string xml)
//        {
//            // 加载接口对应的消息包结构
//            this.serialXmlObject = MessageSerialXml.DeSerialClassFromXML(xml);
//        }

//        #region 数据解包

//        /// <summary>
//        /// 解包_返回数据集
//        /// </summary>
//        /// <param name="xml">消息数据包</param>
//        /// <returns></returns>
//        public DataSet UnpackToDataSet()
//        {
//            // 创建表结构
//            DataSet dataSetStruct = CreateDataSetStruct(serialXmlObject.Head);

//            // 导入数据
//            DataSet importDataSet = ImportDataSet(serialXmlObject.Data, dataSetStruct);

//            return importDataSet;
//        }

//        /// <summary>
//        /// 解包_返回执行结果XML
//        /// </summary>
//        /// <returns></returns>
//        public string UnpackToResultXml()
//        {
//            try
//            {
//                // 创建表结构
//                DataSet dataSetStruct = CreateDataSetStruct(serialXmlObject.Head);
//                // 导入数据
//                DataSet importDataSet = ImportDataSet(serialXmlObject.Data, dataSetStruct);
//                //插入数据库
//                InsertDataSet(importDataSet);
//                return ReturnSuccess();
//            }
//            catch (Exception ex)
//            {

//                return ReturnFailure(ex);
//            }

//        }

//        /// <summary>
//        /// 插入数据
//        /// </summary>
//        /// <param name="ds">数据集合</param>
//        /// <returns></returns>
//        public int InsertDataSet(DataSet ds)
//        {
//            using (var session = NHDB.OpenSession())
//            {
//                string strsqlDel = string.Empty;
//                string strsqlAdd = string.Empty;
//                try
//                {
//                    //获取数据库表用户
//                    string DataTableUser = System.Configuration.ConfigurationManager.AppSettings["DataTableUser"].ToString();
//                    int j = 0;

//                    foreach (DataTable dt in ds.Tables)
//                    {
//                        string tableName = dt.TableName;
//                        foreach (DataRow dr in dt.Rows)
//                        {
//                            string del = "delete from " + DataTableUser + "." + tableName + " where ";
//                            string Add = "insert into " + DataTableUser + "." + tableName + "(";
//                            string AddCl = "";
//                            string AddValue = "";
//                            string delWhere = "";
//                            foreach (DataColumn dc in dt.Columns)
//                            {
//                                string clName = dc.ColumnName;
//                                string clValue = dr[clName].ToString();

//                                if (clName != "Action")
//                                {
//                                    AddCl += clName + ",";
//                                    if (dc.DataType == typeof(DateTime))
//                                        AddValue += "to_date('" + clValue + "','yyyy-mm-dd hh24:mi:ss'),";
//                                    else
//                                        AddValue += "'" + clValue + "',";
//                                }
//                                foreach (DataColumn dcPK in dt.PrimaryKey)
//                                {
//                                    if (clName == dcPK.ColumnName)
//                                    {
//                                        delWhere += clName + "='" + clValue + "' and ";
//                                    }
//                                }
//                            }
//                            strsqlDel += del + delWhere.Substring(0, delWhere.Length - 5) + ";";
//                            strsqlAdd += Add + AddCl.Substring(0, AddCl.Length - 1) + ") values(" + AddValue.Substring(0, AddValue.Length - 1) + ");";
//                        }
//                    }
//                    //执行数据库操作
//                    session.BeginTransAction();
//                    j = session.ExecuteNonQuery("begin " + strsqlDel + strsqlAdd + " end;");
//                    session.Commit();
//                    return j;
//                }
//                catch (Exception ex)
//                {
//                    session.Rollback();
//                    GlobalManager.MainVM.LogServerInfo("执行SQL语句保存数据异常；异常语句：" + strsqlDel + strsqlAdd + "，具体异常信息：" + ex.ToString(), "保存数据异常" + Guid.NewGuid().ToString());
//                    throw new Exception("执行SQL语句保存数据异常；异常语句：" + strsqlDel + strsqlAdd + "，具体异常信息：" + ex.Message);
//                }
//            }
//        }

//        /// <summary>
//        /// 插入数据
//        /// </summary>
//        /// <param name="ds">数据集合</param>
//        /// <param name="DataTableUser">表所在的用户</param>
//        /// <returns></returns>
//        public int InsertDataSet(DataSet ds, string DataTableUser)
//        {
//            using (var session = NHDB.OpenSession())
//            {
//                string strsqlDel = string.Empty;
//                string strsqlAdd = string.Empty;
//                try
//                {
//                    int j = 0;

//                    foreach (DataTable dt in ds.Tables)
//                    {
//                        string tableName = dt.TableName;
//                        foreach (DataRow dr in dt.Rows)
//                        {
//                            string del = "delete from " + DataTableUser + "." + tableName + " where ";
//                            string Add = "insert into " + DataTableUser + "." + tableName + "(";
//                            string AddCl = "";
//                            string AddValue = "";
//                            string delWhere = "";
//                            foreach (DataColumn dc in dt.Columns)
//                            {
//                                string clName = dc.ColumnName;
//                                string clValue = dr[clName].ToString();
//                                if (clName != "Action")
//                                {
//                                    AddCl += clName + ",";
//                                    if (dc.DataType == typeof(DateTime))
//                                        AddValue += "to_date('" + clValue + "','yyyy-mm-dd hh24:mi:ss'),";
//                                    else
//                                        AddValue += "'" + clValue + "',";
//                                }
//                                foreach (DataColumn dcPK in dt.PrimaryKey)
//                                {
//                                    if (clName == dcPK.ColumnName)
//                                    {
//                                        delWhere += clName + "='" + clValue + "' and ";
//                                    }
//                                }
//                            }
//                            strsqlDel += del + delWhere.Substring(0, delWhere.Length - 5) + ";";
//                            strsqlAdd += Add + AddCl.Substring(0, AddCl.Length - 1) + ") values(" + AddValue.Substring(0, AddValue.Length - 1) + ");";
//                        }
//                    }
//                    //执行数据库操作
//                    session.BeginTransAction();
//                    j = session.ExecuteNonQuery("begin " + strsqlDel + strsqlAdd + " end;");
//                    session.Commit();
//                    return j;
//                }
//                catch (Exception ex)
//                {
//                    session.Rollback();
//                    GlobalManager.MainVM.LogServerInfo("执行SQL语句保存数据异常；异常语句：" + strsqlDel + strsqlAdd + "，具体异常信息：" + ex.ToString(), "保存数据异常" + Guid.NewGuid().ToString());
//                    throw new Exception("执行SQL语句保存数据异常；异常语句：" + strsqlDel + strsqlAdd + "，具体异常信息：" + ex.Message);
//                }
//            }
//        }

//        /// <summary>
//        /// 导入数据集
//        /// </summary>
//        /// <param name="xmlDataSet">xml数据集</param>
//        /// <param name="dataSetStruct">数据集结构</param>
//        /// <returns></returns>
//        private DataSet ImportDataSet(_Data xmlDataSet, DataSet dataSetStruct)
//        {
//            if (xmlDataSet == null || xmlDataSet.DataTableSet == null)
//                return dataSetStruct;

//            foreach (_DataTable xmlDataTable in xmlDataSet.DataTableSet)
//            {
//                ImportDataTable(xmlDataTable, dataSetStruct);
//            }

//            return dataSetStruct;
//        }

//        /// <summary>
//        /// 从XML文件中导入数据表
//        /// </summary>
//        /// <param name="xmlDataTable">Xml数据表</param>
//        /// <param name="dataSet">Xml数据集</param>
//        /// <returns></returns>
//        public DataTable ImportDataTable(_DataTable xmlDataTable, DataSet dataSet)
//        {
//            DataTable dt = dataSet.Tables[xmlDataTable.TableName.Trim()];
//            if (dt == null)
//                throw new Exception(string.Format("消息头中的表（｛0｝）,在消息数据体中找不到，请查看消息头中的表名与消息体中的表名是否一致。"
//                    , xmlDataTable.TableName.Trim()));

//            if (xmlDataTable.RowSet == null)
//                return dt;

//            try
//            {
//                foreach (_Row xmlRow in xmlDataTable.RowSet)
//                {
//                    // 导入数据行
//                    DataRow newDataRow = dt.NewRow();
//                    newDataRow["Action"] = xmlRow.Header.Action; // 设置记录状态
//                    foreach (_DataItem xmlDataItem in xmlRow.Header.DataItemSet)
//                    {
//                        string fieldName = xmlDataItem.FieldName;
//                        if (dt.Columns.Contains(fieldName))
//                        {
//                            if (!xmlDataItem.FieldValue.Equals("null"))
//                                newDataRow[fieldName] = GetDataTableFieldValue(dt.Columns[fieldName].DataType,
//                                    xmlDataItem.FieldValue);
//                        }
//                        else
//                        {
//                            throw new Exception(string.Format("消息体中的字段{0}在消息头{1}表结构中找不到。", fieldName, dt.TableName));
//                        }
//                    }
//                    dt.Rows.Add(newDataRow);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(string.Format("Xml数据行导入Net数据表DataTable过程中，出现异常:{0}", ex.Message));
//            }

//            return dt;
//        }

//        /// <summary>
//        /// 创建数据集结构
//        /// </summary>
//        /// <returns></returns>
//        public DataSet CreateDataSetStruct()
//        {
//            return CreateDataSetStruct(this.serialXmlObject.Head);
//        }

//        /// <summary>
//        /// 创建数据集结构
//        /// </summary>
//        /// <param name="messageXmlHead">消息头（包含有表结构）</param>
//        /// <returns></returns>
//        public DataSet CreateDataSetStruct(_Head messageXmlHead)
//        {
//            try
//            {
//                if (messageXmlHead.DataDefine != null)
//                {
//                    DataSet ds = new DataSet();
//                    foreach (_Table table in messageXmlHead.DataDefine.TableSet)
//                    {
//                        ds.Tables.Add(CreateDataTableStruct(table));
//                    }
//                    return ds;
//                }
//                else
//                {
//                    throw new Exception("Xml Head中【DataDefine】不能为空！");
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.ToString());
//            }

//        }

//        /// <summary>
//        /// 创建数据表结构
//        /// </summary>
//        /// <param name="table"></param>
//        /// <returns></returns>
//        private DataTable CreateDataTableStruct(_Table table)
//        {
//            DataTable dt = new DataTable(table.TableName);

//            System.Collections.Generic.List<DataColumn> primaryKeylist = new List<DataColumn>();
//            foreach (_FieldItem fieldItem in table.FieldItemSet)
//            {
//                DataColumn col = dt.Columns.Add();
//                col.ColumnName = fieldItem.FieldName;
//                col.Caption = fieldItem.Caption;
//                col.DataType = GetFieldType(fieldItem.FieldType.Trim(), fieldItem.FieldLength);

//                // 记录主键
//                if (fieldItem.isPrimaryKey.ToUpper() == "TRUE")
//                {
//                    primaryKeylist.Add(col);
//                }
//            }
//            dt.PrimaryKey = primaryKeylist.ToArray();
//            dt.Columns.Add("Action", typeof(string));

//            return dt;
//        }

//        /// <summary>
//        /// 获取字段类型
//        /// </summary>
//        /// <param name="xmlType">xml类型</param>
//        /// <param name="fieldLength">字段长度</param>
//        /// <returns></returns>
//        private Type GetFieldType(string xmlType, string fieldLength)
//        {
//            Type type = typeof(string);

//            switch (xmlType.ToUpper())
//            {
//                case "CHAR":
//                    type = typeof(string);
//                    break;
//                case "NUMBER":
//                    if (fieldLength.Contains('.'))
//                        type = typeof(double);
//                    else
//                        type = typeof(Int64);
//                    break;
//                case "INTEGER":
//                    type = typeof(Int32);
//                    break;
//                case "DATETIME":
//                    type = typeof(DateTime);
//                    break;
//                case "DATE":
//                    type = typeof(DateTime);
//                    break;
//                case "BOOL":
//                    type = typeof(bool);
//                    break;
//            }

//            return type;
//        }

//        /// <summary>
//        /// 转换为DataTable数据表中的列值
//        /// </summary>
//        /// <param name="columnType"></param>
//        /// <param name="fieldValue"></param>
//        /// <returns></returns>
//        private object GetDataTableFieldValue(Type columnType, string fieldValue)
//        {
//            object tableFieldValue = fieldValue;
//            if (columnType != typeof(string) && fieldValue == string.Empty)
//                return DBNull.Value;

//            return tableFieldValue;
//        }

//        /// <summary>
//        /// 获取反馈内容的消息头信息
//        /// </summary>
//        /// <param name="xml">反馈的XML</param>
//        /// <returns></returns>
//        public _Head ResultXml(string xml)
//        {
//            MessageSerialXml messageSerXml = MessageSerialXml.DeSerialClassFromXML(xml);
//            return messageSerXml.Head;
//        }
//        #endregion

//        #region 数据打包

//        /// <summary>
//        /// 数据打包
//        /// </summary>        
//        /// <param name="messageDataSet">消息数据</param>
//        /// <returns></returns>
//        public string Pack(DataSet messageDataSet)
//        {
//            if (messageDataSet == null)
//                throw new Exception("数据集为空！");
//            // 当没有记录状态的时候,增加默认的记录状态:Unchange
//            AddDefaultAction(messageDataSet);
//            serialXmlObject.Head.MsgID = Guid.NewGuid().ToString().Replace("-", "");
//            serialXmlObject.Head.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//            serialXmlObject.Head.User = "MES";
//            serialXmlObject.Data = GenerateXmlData(messageDataSet, serialXmlObject);
//            string strXml = MessageSerialXml.SerialClassToXML(serialXmlObject);
//            //调用ESB并返回执行结果
//            EsbService.ESBServiceClient client = new EsbService.ESBServiceClient();
//            return client.tranESBService(strXml);
//        }

//        /// <summary>
//        /// 增加默认的记录状态(Unchange),当没有记录状态的时候
//        /// </summary>
//        /// <param name="messageDateSet"></param>
//        private void AddDefaultAction(DataSet messageDateSet)
//        {
//            string actionColumnName = "Action";
//            foreach (DataTable dt in messageDateSet.Tables)
//            {
//                if (!dt.Columns.Contains(actionColumnName))
//                {
//                    dt.Columns.Add(actionColumnName, typeof(string));
//                    foreach (DataRow row in dt.Rows)
//                    {
//                        row[actionColumnName] = "Unchange";
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// 产生数据
//        /// </summary>
//        /// <param name="dataSet">数据集</param>
//        /// <param name="serialXmlObject">xml序列化对象</param>
//        /// <returns></returns>
//        private _Data GenerateXmlData(DataSet dataSet, MessageSerialXml serialXmlObject)
//        {
//            _Data xmlData = new _Data();

//            _Table[] xmlTableStructSet = serialXmlObject.Head.DataDefine.TableSet;
//            xmlData.DataTableSet = new _DataTable[serialXmlObject.Head.DataDefine.TableSet.Length];
//            for (int i = 0; i < xmlTableStructSet.Length; i++)
//            {
//                _Table xmlTableStruct = xmlTableStructSet[i];
//                _DataTable xmlDataTable = new _DataTable();
//                DataTable dt = null;
//                if (xmlTableStructSet.Length <= 1)
//                {
//                    dt = dataSet.Tables[0];
//                    dt.TableName = xmlTableStruct.TableName;
//                }
//                else
//                {
//                    dt = dataSet.Tables[xmlTableStruct.TableName];
//                }

//                if (dt.Rows.Count <= 0)
//                    continue;

//                xmlData.DataTableSet[i] = GenerateXmlDataTable(dt, xmlTableStruct, xmlDataTable);
//            }

//            return xmlData;
//        }

//        /// <summary>
//        /// 创建消息表结构       
//        /// </summary>
//        /// <param name="dt">数据表</param>
//        /// <param name="xmlTableStruct">表结构</param>
//        /// <param name="xmlDataTable">xml数据表</param>
//        /// <returns></returns>
//        private _DataTable GenerateXmlDataTable(DataTable dt, _Table xmlTableStruct, _DataTable xmlDataTable)
//        {
//            xmlDataTable.TableName = xmlTableStruct.TableName;

//            xmlDataTable.RowSet = new _Row[dt.Rows.Count];
//            for (int index = 0; index < dt.Rows.Count; index++)
//            {
//                DataRow dr = dt.Rows[index];
//                _Row xmlRow = new _Row();
//                xmlRow.Index = index.ToString(); // 设置行顺序
//                xmlRow.Header = new _Header();
//                xmlRow.Header.Action = dr["Action"].ToString();  // 设置记录状态
//                xmlRow.Header.DataItemSet = new _DataItem[xmlTableStruct.FieldItemSet.Length];
//                for (int fieldIndex = 0; fieldIndex < xmlTableStruct.FieldItemSet.Length; fieldIndex++)
//                {
//                    _DataItem xmlDataItem = new _DataItem();
//                    string fieldName = xmlTableStruct.FieldItemSet[fieldIndex].FieldName;
//                    xmlDataItem.FieldName = fieldName;
//                    xmlDataItem.FieldValue = GetXmlFieldValue(dr[fieldName], dt.Columns[fieldName].DataType);
//                    xmlRow.Header.DataItemSet[fieldIndex] = xmlDataItem;
//                }

//                xmlDataTable.RowSet[index] = xmlRow;
//            }

//            return xmlDataTable;
//        }

//        /// <summary>
//        /// 获取xml字段值
//        /// </summary>
//        /// <param name="fieldValue">字段值</param>
//        /// <param name="type">字段类型</param>
//        /// <returns></returns>
//        private string GetXmlFieldValue(object fieldValue, Type type)
//        {
//            if (fieldValue == null || fieldValue == DBNull.Value)
//                return string.Empty;

//            if (type == typeof(DateTime))
//            {
//                return Convert.ToDateTime(fieldValue).ToString("yyyy-MM-dd HH:mm:ss");
//            }
//            if (type == typeof(bool) || type == typeof(Boolean))
//            {
//                if (Convert.ToBoolean(fieldValue))
//                    return "True";
//                else
//                    return "False";
//            }

//            return fieldValue.ToString();
//        }
//        #endregion

//        /// <summary>
//        /// 返回“成功”的消息包
//        /// </summary>
//        /// <returns></returns>
//        public string ReturnSuccess()
//        {
//            // 复制当前的消息对象
//            MessageSerialXml returnResutlXml = MessageSerialXml.DeSerialClassFromXML(MessageSerialXml.SerialClassToXML(serialXmlObject));
//            returnResutlXml.Head.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//            returnResutlXml.Head.MsgID = serialXmlObject.Head.MsgID + "+RET";
//            returnResutlXml.Head.StateCode = "000";
//            returnResutlXml.Head.StateDesription = "成功";
//            returnResutlXml.Head.DataDefine = new _DataDefine();
//            returnResutlXml.Data = new _Data();
//            return MessageSerialXml.SerialClassToXML(returnResutlXml);
//        }

//        /// <summary>
//        /// 返回“失败”的消息包
//        /// </summary>
//        /// <param name="ex">异常信息</param>
//        /// <returns></returns>
//        public string ReturnFailure(Exception ex)
//        {
//            // 复制当前的消息对象
//            string Error = string.Empty;
//            if (ex.InnerException != null && ex.InnerException.Message != null)
//            {
//                Error = ex.InnerException.Message;

//            }
//            else if (ex.Message != null)
//            {
//                Error = ex.Message;
//            }
//            else
//            {
//                Error = ex.ToString();
//            }
//            MessageSerialXml returnResutlXml = MessageSerialXml.DeSerialClassFromXML(MessageSerialXml.SerialClassToXML(serialXmlObject));
//            returnResutlXml.Head.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//            returnResutlXml.Head.MsgID = serialXmlObject.Head.MsgID + "+RET";
//            returnResutlXml.Head.StateCode = "999";
//            returnResutlXml.Head.StateDesription = Error;
//            returnResutlXml.Head.DataDefine = new _DataDefine();
//            returnResutlXml.Data = new _Data();
//            return MessageSerialXml.SerialClassToXML(returnResutlXml);
//        }

//    }
//}
