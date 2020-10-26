using System;
using System.Text;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace BaseClassUtils
{
	public static class SQLiteHelper
	{
		private static readonly object WriteLock = new object();
		static readonly object writeLock = new object();
		private static char[] SplitChars = new char[] { ',', ' ', ')', '(', '+', '-', '*', '/' };

		static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[0].ToString();
		public static string ConnectionString
		{
			get
			{
				return connectionString;
			}
			set
			{
				connectionString = value;
			}
		}

		private static bool SureOpen(DbConnection conn)
		{
			return Open(conn);
		}
		private static bool Open(DbConnection conn)
		{
			if (conn != null && conn.State != ConnectionState.Open)
			{
				conn.Open();
				return true;
			}
			return false;
		}
		private static bool SureClose(DbConnection conn)
		{
			return Close(conn);
		}
		private static bool Close(DbConnection conn)
		{
			if (conn != null && conn.State != ConnectionState.Closed)
			{
				conn.Close();
				return true;
			}
			return false;
		}

		private static object GetDbValue(object o)
		{
			if (o == null)
				return DBNull.Value;
			return o;
		}

		private static string GetSortString(Dictionary<string, bool> dic, bool isReverse)
		{
			StringBuilder sb = new StringBuilder();
			System.Collections.IEnumerator ienum = dic.GetEnumerator();
			while (ienum.MoveNext())
			{
				KeyValuePair<string, bool> kvp = (KeyValuePair<string, bool>)ienum.Current;
				sb.Append(kvp.Key + " " + (isReverse ? (kvp.Value ? "desc" : "asc") : (kvp.Value ? "asc" : "desc")) + ",");
			}
			string temp = sb.ToString();
			return temp.Substring(0, temp.Length - 1);
		}

		//static readonly SQLiteTransaction singleton = GetSQLiteTransaction();
		//private static SQLiteTransaction Singleton
		//{
		//    get
		//    {
		//        return singleton;
		//    }
		//}

		/// <summary>
		/// 获得连接对象
		/// </summary>
		/// <returns></returns>
		private static SQLiteConnection GetSQLiteConnection(string connectionString)
		{
			return new SQLiteConnection(connectionString);
		}
		private static SQLiteConnection GetSQLiteConnection()
		{
			return GetSQLiteConnection(ConnectionString);
		}
		private static SQLiteConnection CreateConnection(string connectionString)
		{
			return new SQLiteConnection(connectionString);
		}
		private static SQLiteConnection CreateConnection()
		{
			return CreateConnection(ConnectionString);
		}
		private static SQLiteTransaction GetSQLiteTransaction(string connectionString)
		{
			SQLiteConnection conn = GetSQLiteConnection(connectionString);
			conn.Open();
			return conn.BeginTransaction();
		}
		private static SQLiteTransaction GetSQLiteTransaction()
		{
			return GetSQLiteTransaction(ConnectionString);
		}
		private static SQLiteTransaction CreateTransaction(string connectionString)
		{
			SQLiteConnection conn = GetSQLiteConnection(connectionString);
			conn.Open();
			return conn.BeginTransaction(true);
		}
		private static SQLiteTransaction CreateTransaction()
		{
			return CreateTransaction(ConnectionString);
		}

		private static SQLiteCommand PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
		{
			//if (conn.State != ConnectionState.Open)
			//    conn.Open();
			cmd.Parameters.Clear();
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			//cmd.CommandType = CommandType.Text;
			//cmd.CommandTimeout = 30;

			if (cmd.CommandType == CommandType.Text && !cmdText.Contains(" "))
			{
				cmd.CommandType = CommandType.StoredProcedure;
			}

			if (p != null && p.Length > 0)
			{
				List<object> list = new List<object>();
				for (int i = 0; i < p.Length; i++)
				{
					if (p[i] is IList)
					{
						IList l = p[i] as IList;
						for (int j = 0; j < l.Count; j++)
						{
							list.Add(l[j]);
						}
					}
					else
					{
						list.Add(p[i]);
					}
				}

				if (cmd.CommandText.Contains("?"))
				{
					string[] temp = cmd.CommandText.Split('?');
					for (int i = 0; i < temp.Length - 1; i++)
					{
						temp[i] = temp[i] + "@p" + (i + 1).ToString();
					}
					StringBuilder sb = new StringBuilder();
					for (int i = 0; i < temp.Length; i++)
					{
						sb.Append(temp[i]);
					}
					cmd.CommandText = sb.ToString();
				}

				//comm.CommandText = "select * from Users where UserName=@UserName";
				////传值 username，不指定参数长度
				////查询计划为(@UserName varchar(8))select * from Users where UserName=@UserName
				//comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar) { Value = "username" });
				string[] tempStr = cmd.CommandText.Split('@');
				for (int i = 0; i < list.Count; i++)
				{
					DbParameter parameter = cmd.CreateParameter();
					if (tempStr[i + 1].IndexOfAny(SplitChars) > -1)
					{
						if (cmd.Parameters.Contains("@" + tempStr[i + 1].Substring(0, tempStr[i + 1].IndexOfAny(SplitChars))))
							continue;
						parameter.ParameterName = "@" + tempStr[i + 1].Substring(0, tempStr[i + 1].IndexOfAny(SplitChars));
					}
					else
					{
						if (cmd.Parameters.Contains("@" + tempStr[i + 1]))
							continue;
						parameter.ParameterName = "@" + tempStr[i + 1];
					}
					parameter.Value = GetDbValue(list[i]);
					cmd.Parameters.Add(parameter);
				}
			}
			return cmd;
		}
		private static SQLiteCommand PrepareCommand(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return PrepareCommand(PrepareCommand(trans), cmdText, p);
		}
		private static SQLiteCommand PrepareCommand(this SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			cmd.CommandType = commandType;
			return PrepareCommand(cmd, cmd.Connection, cmdText, p);
		}
		private static SQLiteCommand PrepareCommand(this SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return PrepareCommand(cmd, cmd.Connection, cmdText, p);
		}
		private static SQLiteCommand PrepareCommand(this SQLiteConnection conn, string cmdText, params object[] p)
		{
			return PrepareCommand(conn.CreateCommand(), cmdText, p);
		}
		private static SQLiteCommand PrepareCommand(this SQLiteCommand cmd, params object[] p)
		{
			return PrepareCommand(cmd, cmd.Connection, cmd.CommandText, p);
		}
		private static SQLiteCommand PrepareCommand(this SQLiteTransaction trans)
		{
			if (trans == null)
			{
				return GetSQLiteConnection().CreateCommand();
			}
			else
			{
				SQLiteCommand cmd = trans.Connection.CreateCommand();
				cmd.Transaction = trans;
				return cmd;
			}
		}

		private static DataSet ExecuteDataSet(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return ExecuteDataSet(PrepareCommand(trans), cmdText, p);
		}
		private static DataSet ExecuteDataSet(SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			DataSet ds = new DataSet();
			PrepareCommand(cmd, commandType, cmdText, p);
			SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
			da.Fill(ds);
			return ds;
		}
		private static DataSet ExecuteDataSet(SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return ExecuteDataSet(cmd, CommandType.Text, cmdText, p);
		}
		private static DataSet ExecuteDataSet(SQLiteCommand cmd, params object[] p)
		{
			return ExecuteDataSet(cmd, cmd.CommandText, p);
		}
		private static DataSet ExecuteDataSet(CommandType commandType, string cmdText, params object[] p)
		{
			DataSet ds = new DataSet();
			SQLiteCommand cmd = new SQLiteCommand();
			cmd.CommandType = commandType;
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				PrepareCommand(cmd, connection, cmdText, p);
				SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
				da.Fill(ds);
			}
			return ds;
		}

		private static DataTable ExecuteDataTable(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return ExecuteDataTable(PrepareCommand(trans), cmdText, p);
		}
		private static DataTable ExecuteDataTable(SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			return ExecuteDataSet(cmd, commandType, cmdText, p).Tables[0];
		}
		private static DataTable ExecuteDataTable(SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return ExecuteDataSet(cmd, cmdText, p).Tables[0];
		}
		private static DataTable ExecuteDataTable(SQLiteCommand cmd, params object[] p)
		{
			return ExecuteDataTable(cmd, cmd.CommandText, p);
		}
		private static DataTable ExecuteDataTable(CommandType commandType, string cmdText, params object[] p)
		{
			return ExecuteDataSet(commandType, cmdText, p).Tables[0];
		}
		private static DataTable ExecuteDataTable(string cmdText, params object[] p)
		{
			return ExecuteDataSet(cmdText, p).Tables[0];
		}

		private static DataRow ExecuteDataRow(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return ExecuteDataRow(PrepareCommand(trans), cmdText, p);
		}
		private static DataRow ExecuteDataRow(SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			DataSet ds = ExecuteDataSet(cmd, commandType, cmdText, p);
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				return ds.Tables[0].Rows[0];
			return null;
		}
		private static DataRow ExecuteDataRow(SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return ExecuteDataRow(cmd, CommandType.Text, cmdText, p);
		}
		private static DataRow ExecuteDataRow(SQLiteCommand cmd, params object[] p)
		{
			return ExecuteDataRow(cmd, cmd.CommandText, p);
		}
		private static DataRow ExecuteDataRow(CommandType commandType, string cmdText, params object[] p)
		{
			DataSet ds = ExecuteDataSet(commandType, cmdText, p);
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				return ds.Tables[0].Rows[0];
			return null;
		}
		private static DataRow ExecuteDataRow(string cmdText, params object[] p)
		{
			return ExecuteDataRow(CommandType.Text, cmdText, p);
		}

		private static int ExecuteNonQuery(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return ExecuteNonQuery(PrepareCommand(trans), cmdText, p);
		}
		private static int ExecuteNonQuery(SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			PrepareCommand(cmd, commandType, cmdText, p);
			if (cmd.Transaction == null)
			{
				int i = 0;
				//if (cmd.SureOpen())
				//{
				//	lock (writeLock)
				//		i = cmd.ExecuteNonQuery();
				//	cmd.SureClose();
				//}
				//else
				//{
				//	lock (writeLock)
				//		i = cmd.ExecuteNonQuery();
				//}
				return i;
			}
			else
			{
				return cmd.ExecuteNonQuery();
			}
		}
		private static int ExecuteNonQuery(SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return ExecuteNonQuery(cmd, CommandType.Text, cmdText, p);
		}
		private static int ExecuteNonQuery(SQLiteCommand cmd, params object[] p)
		{
			return ExecuteNonQuery(cmd, cmd.CommandText, p);
		}
		private static int ExecuteNonQuery(CommandType commandType, string cmdText, params object[] p)
		{
			SQLiteCommand cmd = new SQLiteCommand();
			cmd.CommandType = commandType;
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				PrepareCommand(cmd, connection, cmdText, p);
				//connection.SureOpen();
				lock (writeLock)
					return cmd.ExecuteNonQuery();
			}
		}
		private static int ExecuteNonQuery(string cmdText, params object[] p)
		{
			return ExecuteNonQuery(CommandType.Text, cmdText, p);
		}

		private static SQLiteDataReader ExecuteReader(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return ExecuteReader(PrepareCommand(trans), cmdText, p);
		}
		private static SQLiteDataReader ExecuteReader(SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			PrepareCommand(cmd, commandType, cmdText, p);
			//if (cmd.SureOpen())
			//	return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			//else
				return cmd.ExecuteReader();
		}
		private static SQLiteDataReader ExecuteReader(SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return ExecuteReader(cmd, CommandType.Text, cmdText, p);
		}
		private static SQLiteDataReader ExecuteReader(SQLiteCommand cmd, params object[] p)
		{
			return ExecuteReader(cmd, cmd.CommandText, p);
		}
		private static SQLiteDataReader ExecuteReader(CommandType commandType, string cmdText, params object[] p)
		{
			SQLiteCommand cmd = new SQLiteCommand();
			cmd.CommandType = commandType;
			SQLiteConnection connection = GetSQLiteConnection();
			try
			{
				PrepareCommand(cmd, connection, cmdText, p);
				//if (cmd.SureOpen())
				//	return cmd.ExecuteReader(CommandBehavior.CloseConnection);
				//else
					return cmd.ExecuteReader();
			}
			catch
			{
				connection.Close();
				throw;
			}
		}
		private static SQLiteDataReader ExecuteReader(string cmdText, params object[] p)
		{
			return ExecuteReader(CommandType.Text, cmdText, p);
		}

		private static object ExecuteScalar(this SQLiteTransaction trans, string cmdText, params object[] p)
		{
			return ExecuteScalar(PrepareCommand(trans), cmdText, p);
		}
		private static object ExecuteScalar(SQLiteCommand cmd, CommandType commandType, string cmdText, params object[] p)
		{
			PrepareCommand(cmd, commandType, cmdText, p);
			object o = null;
			//if (cmd.SureOpen())
			//{
			//	o = cmd.ExecuteScalar();
			//	cmd.SureClose();
			//}
			//else
			//{
			//	o = cmd.ExecuteScalar();
			//}
			return o;
		}
		private static object ExecuteScalar(SQLiteCommand cmd, string cmdText, params object[] p)
		{
			return ExecuteScalar(cmd, CommandType.Text, cmdText, p);
		}
		private static object ExecuteScalar(SQLiteCommand cmd, params object[] p)
		{
			return ExecuteScalar(cmd, cmd.CommandText, p);
		}
		private static object ExecuteScalar(CommandType commandType, string cmdText, params object[] p)
		{
			SQLiteCommand cmd = new SQLiteCommand();
			cmd.CommandType = commandType;
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				PrepareCommand(cmd, connection, cmdText, p);
				//connection.SureOpen();
				return cmd.ExecuteScalar();
			}
		}
		private static object ExecuteScalar(string cmdText, params object[] p)
		{
			return ExecuteScalar(CommandType.Text, cmdText, p);
		}


		private static int ExecuteInsert(this SQLiteTransaction trans, string tableName, params Dictionary<string, object>[] dic)
		{
			return ExecuteInsert(PrepareCommand(trans), tableName, dic);
		}
		private static int ExecuteInsert(this SQLiteCommand cmd, string tableName, params Dictionary<string, object>[] dic)
		{
			cmd.Parameters.Clear();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from " + tableName + " where 1=2";
			SQLiteDataAdapter a = new SQLiteDataAdapter(cmd);
			SQLiteCommandBuilder b = new SQLiteCommandBuilder(a);
			DataSet ds = new DataSet();
			a.Fill(ds);
			for (int i = 0; i < dic.Length; i++)
			{
				DataRow dr = ds.Tables[0].NewRow();
				IDictionaryEnumerator Mycollection = dic[i].GetEnumerator();
				while (Mycollection.MoveNext())
				{
					dr[Mycollection.Key.ToString()] = Mycollection.Value != null ? (Mycollection.Value.ToString() != "" ? Mycollection.Value : DBNull.Value) : DBNull.Value;
				}
				ds.Tables[0].Rows.Add(dr);
			}
			if (cmd.Transaction == null)
			{
				lock (writeLock)
					a.Update(ds);
			}
			else
			{
				a.Update(ds);
			}
			return dic.Length;
		}

		public static int ExecuteInsert(string tableName, params Dictionary<string, object>[] dic)
		{
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				SQLiteDataAdapter a = new SQLiteDataAdapter("select * from " + tableName + " where 1=2", connection);
				SQLiteCommandBuilder b = new SQLiteCommandBuilder(a);
				DataSet ds = new DataSet();
				a.Fill(ds);
				for (int i = 0; i < dic.Length; i++)
				{
					DataRow dr = ds.Tables[0].NewRow();
					IDictionaryEnumerator Mycollection = dic[i].GetEnumerator();
					while (Mycollection.MoveNext())
					{
						dr[Mycollection.Key.ToString()] = Mycollection.Value != null ? (Mycollection.Value.ToString() != "" ? Mycollection.Value : DBNull.Value) : DBNull.Value;
					}
					ds.Tables[0].Rows.Add(dr);
				}
				lock (writeLock)
					a.Update(ds);
				return dic.Length;
			}
		}

		private static void ExecuteUpdate(this SQLiteTransaction trans, Dictionary<string, object> dic, string tableName, string pkName)
		{
			ExecuteUpdate(PrepareCommand(trans), dic, tableName, pkName);
		}
		private static void ExecuteUpdate(this SQLiteCommand cmd, Dictionary<string, object> dic, string tableName, string pkName)
		{
			cmd.Parameters.Clear();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from " + tableName + " where " + pkName + "=@p";
			cmd.Parameters.AddWithValue("@p", dic[pkName]);
			SQLiteDataAdapter a = new SQLiteDataAdapter(cmd);
			SQLiteCommandBuilder b = new SQLiteCommandBuilder(a);
			DataSet ds = new DataSet();
			a.Fill(ds);
			DataRow dr = ds.Tables[0].Rows[0];
			IDictionaryEnumerator Mycollection = dic.GetEnumerator();
			while (Mycollection.MoveNext())
			{
				dr[Mycollection.Key.ToString()] = Mycollection.Value != null ? (Mycollection.Value.ToString() != "" ? Mycollection.Value : DBNull.Value) : DBNull.Value;
			}
			if (cmd.Transaction == null)
			{
				lock (writeLock)
					a.Update(ds);
			}
			else
			{
				a.Update(ds);
			}
		}

		public static void ExecuteUpdate(this Dictionary<string, object> dic, string tableName, string pkName)
		{
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				SQLiteCommand command = new SQLiteCommand();
				PrepareCommand(command, connection, "select * from " + tableName + " where " + pkName + "=@p", dic[pkName]);
				SQLiteDataAdapter a = new SQLiteDataAdapter(command);
				SQLiteCommandBuilder b = new SQLiteCommandBuilder(a);
				DataSet ds = new DataSet();
				a.Fill(ds);
				DataRow dr = ds.Tables[0].Rows[0];
				IDictionaryEnumerator Mycollection = dic.GetEnumerator();
				while (Mycollection.MoveNext())
				{
					dr[Mycollection.Key.ToString()] = Mycollection.Value != null ? (Mycollection.Value.ToString() != "" ? Mycollection.Value : DBNull.Value) : DBNull.Value;
				}
				lock (writeLock)
					a.Update(ds);
			}
		}




		/// <summary>  
		/// 查询数据库中的所有数据类型信息  
		/// </summary>  
		/// <returns></returns>  
		public static DataTable GetSchema()
		{
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				connection.Open();
				DataTable data = connection.GetSchema("TABLES");
				connection.Close();
				//foreach (DataColumn column in data.Columns)  
				//{  
				//    Console.WriteLine(column.ColumnName);  
				//}  
				return data;
			}
		}

		private static string GetPageSql(string tableName, string columns, int pageSize, int currentPageIndex, string condition, Dictionary<string, bool> dic)
		{
			return "select " + columns + " from " + tableName + " where " + condition + " order by " + GetSortString(dic, false) + " LIMIT " + (currentPageIndex * pageSize).ToString() + "," + ((currentPageIndex + 1) * pageSize).ToString();
		}
		private static string GetPageSql(string tableName, string columns, int pageSize, int currentPageIndex, string condition, string sort)
		{
			return "select " + columns + " from " + tableName + " where " + condition + " order by " + sort + " LIMIT " + (currentPageIndex * pageSize).ToString() + "," + ((currentPageIndex + 1) * pageSize).ToString();
		}

		private static string GetPageSql(string tableName, string columns, int currentSize, int pageSize, int currentPageIndex, string condition, Dictionary<string, bool> dic)
		{
			return "select " + columns + " from " + tableName + " where " + condition + " order by " + GetSortString(dic, false) + " LIMIT " + (currentPageIndex * pageSize).ToString() + "," + ((currentPageIndex * pageSize) + currentSize).ToString();
		}
		private static string GetPageSql(string tableName, string columns, int currentSize, int pageSize, int currentPageIndex, string condition, string sort)
		{
			return "select " + columns + " from " + tableName + " where " + condition + " order by " + sort + " LIMIT " + (currentPageIndex * pageSize).ToString() + "," + ((currentPageIndex * pageSize) + currentSize).ToString();
		}


		public static bool CreateDB(string dbFilePath)
		{
			ConnectionString = "Data Source=" + dbFilePath + ";";
			if (System.IO.File.Exists(dbFilePath))
			{
				return false;
			}
			else
			{
				System.Data.SQLite.SQLiteConnection.CreateFile(dbFilePath);
				return true;
			}
		}

		public static bool CreateTable(string dbFilePath, string tableName, List<string> listColumn)
		{
			using (SQLiteConnection connection = GetSQLiteConnection())
			{
				connection.Open();
				using (SQLiteCommand command = new SQLiteCommand(connection))
				{
					try
					{
						string commandText = "CREATE TABLE IF NOT EXISTS " + tableName + " (id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE";
						foreach(string columnName in listColumn)
						{
							commandText += $", {columnName} TEXT";
						}
						commandText = commandText + "); ";
						command.CommandText = commandText;
						command.ExecuteNonQuery();
						//command.CommandText = "DROP TABLE Demo";
						//command.ExecuteNonQuery();
						return true;
					}
					catch(Exception ex)
					{
						return false;
					}
				}
			}
		}
		public static DataSet ExecuteDataSet(string cmdText, params object[] p)
		{
			//comm.CommandText = "select * from Users where UserName=@UserName";
			////传值 username，不指定参数长度
			////查询计划为(@UserName varchar(8))select * from Users where UserName=@UserName
			//comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar) { Value = "username" });
			return ExecuteDataSet(CommandType.Text, cmdText, p);
		}
		public static bool CloseConnect()
		{
			SQLiteConnection connection = GetSQLiteConnection();
			connection.Close();
			return true;
		}


		private static bool CreateLogInfo(string dbPath)
		{
			SQLiteHelper.CreateDB(dbPath);
			using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbPath + ";"))
			{
				using (SQLiteCommand cmd = new SQLiteCommand(conn))
				{
					cmd.CommandText = "select count(*) from sqlite_master where type='table' and tbl_name='LogInfo'";
					lock (writeLock)
					{
						conn.Open();
						int i = int.Parse(cmd.ExecuteScalar().ToString());
						if (i == 1) return false;
						cmd.CommandText = "CREATE TABLE LogInfo (LogID integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,UserName nvarchar(60),LogGroup TINYINT,LogType nvarchar(100),LogLevel TINYINT,LogTarget nvarchar(100),LogContent nvarchar(4000),Comment nvarchar(2000), TheTime datetime DEFAULT (datetime(CURRENT_TIMESTAMP,'localtime')) ,Status TINYINT);";
						cmd.ExecuteNonQuery();
					}
					return true;
				}
			}
		}

		private static SQLiteDataReader GetLogInfo(int pageSize, int currentPageIndex, string condition, string sort)
		{
			return ExecuteReader(GetPageSql("LogInfo", "*", pageSize, currentPageIndex, condition, sort));
		}

	}
}