using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseClassUtils
{
	internal class SqliteSchemaReader : SchemaReader
	{
		private string _connstr { get; set; }

		public override Tables ReadSchema(string connstr, string tableFilter)
		{
			_connstr = connstr;
			var result = new Tables();
			//pull the tables in a reader 
			using (IDataReader rdr = ExecuteReader(TABLE_SQL + tableFilter)) // SQLitehelper.
			{
				while (rdr.Read())
				{
					Table tbl = new Table();
					tbl.Name = rdr["name"].ToString();
					//tbl.Schema = rdr["TABLE_SCHEMA"].ToString();
					//tbl.IsView = string.Compare(rdr["TABLE_TYPE"].ToString(), "View", true) == 0;
					tbl.CleanName = CleanUp(tbl.Name);
					// tbl.CleanName = T4Generator.CleanUp(tbl.Name);
					if (tbl.CleanName.StartsWith("tbl_")) tbl.CleanName = tbl.CleanName.Replace("tbl_", "");
					if (tbl.CleanName.StartsWith("tbl")) tbl.CleanName = tbl.CleanName.Replace("tbl", "");
					tbl.CleanName = tbl.CleanName.Replace("_", "");
					tbl.ClassName = tbl.CleanName;

					result.Add(tbl);
				}
			}

			foreach (var tbl in result)
			{
				tbl.Columns = LoadColumns(tbl);

				//Mark the primary key
				//string PrimaryKey = GetPK(tbl.Schema, tbl.Name);
				//var pkColumn = tbl.Columns.SingleOrDefault(x => x.Name.ToLower().Trim() == PrimaryKey.ToLower().Trim());
				//if (pkColumn != null)
				//{
				//    pkColumn.IsPK = true;
				//}
			}


			return result;
		}

		List<Column> LoadColumns(Table tbl)
		{
			var result = new List<Column>();
			using (IDataReader rdr = ExecuteReader(COLUMN_SQL.Replace("@tableName", tbl.Name))) // SQLitehelper.
			{
				while (rdr.Read())
				{
					Column col = new Column();
					col.Name = rdr["name"].ToString();
					col.PropertyName = CleanUp(col.Name);
					//col.PropertyName = T4Generator.CleanUp(col.Name);
					col.PropertyType = base.GetPropertyType(rdr["type"].ToString().ToLower());
					col.IsNullable = rdr["notnull"].ToString() != "1";
					//col.IsAutoIncrement = false; //((int)rdr["IsIdentity"]) == 1;
					col.IsPK = rdr["pk"].ToString() == "1";
					result.Add(col);
				}
			}

			return result;
		}
		
		static Regex rxCleanUp = new Regex(@"[^\w\d_]", RegexOptions.Compiled);

		static Func<string, string> CleanUp = (str) =>
		{
			str = rxCleanUp.Replace(str, "_");
			if (char.IsDigit(str[0])) str = "_" + str;

			return str;
		};

		string Table_Filter = " ";

		const string TABLE_SQL = " select name from sqlite_master where type = 'table' ";

		const string COLUMN_SQL = " PRAGMA table_info(@tableName) ";

		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="slPars">参数</param>
		/// <returns>发挥SQLiteDataReader</returns>
		public SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] slPars)
		{
			SQLiteConnection conn = new SQLiteConnection(_connstr);
			using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
			{
				if (slPars != null)
				{
					cmd.Parameters.AddRange(slPars);
				}
				try
				{
					conn.Open();
					return cmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
				catch (Exception ex)
				{
					conn.Close();
					conn.Dispose();
					throw ex;
				}

			}

		}

	}



	internal abstract class SchemaReader
	{
		public abstract Tables ReadSchema(string connstr, string tableFilter);
		//public GeneratedTextTransformation outer;
		//public void WriteLine(string o)
		//{
		//	outer.WriteLine(o);
		//}

		public string GetPropertyType(string sqlType)
		{
			string sysType = "string";
			switch (sqlType)
			{
				case "bigint":
					sysType = "long";
					break;
				case "smallint":
					sysType = "short";
					break;
				case "int":
				case "number":
				case "integer":
					sysType = "int";
					break;
				case "uniqueidentifier":
					sysType = "Guid";
					break;
				case "smalldatetime":
				case "datetime":
				case "date":
				case "time":
					sysType = "DateTime";
					break;
				case "float":
					sysType = "double";
					break;
				case "real":
					sysType = "float";
					break;
				case "numeric":
				case "smallmoney":
				case "decimal":
				case "money":
					sysType = "decimal";
					break;
				case "tinyint":
					sysType = "byte";
					break;
				case "bit":
					sysType = "bool";
					break;
				case "image":
				case "binary":
				case "varbinary":
				case "timestamp":
					sysType = "byte[]";
					break;
				case "geography":
					sysType = "Microsoft.SqlServer.Types.SqlGeography";
					break;
				case "geometry":
					sysType = "Microsoft.SqlServer.Types.SqlGeometry";
					break;
			}
			return sysType;
		}
	}

	public class Table
	{
		public List<Column> Columns;
		public string Name;
		public string Schema;
		public bool IsView;
		public string CleanName;
		public string ClassName;
		public string SequenceName;
		public bool Ignore;

		public Column PK
		{
			get
			{
				return this.Columns.SingleOrDefault(x => x.IsPK);
			}
		}

		public Column GetColumn(string columnName)
		{
			return Columns.Single(x => string.Compare(x.Name, columnName, true) == 0);
		}

		public Column this[string columnName]
		{
			get
			{
				return GetColumn(columnName);
			}
		}

	}

	public class Column
	{
		public string Name;
		public string PropertyName;
		public string PropertyType;
		public string DbType;
		public bool IsPK;
		public bool IsNullable;
		public bool IsAutoIncrement;
		public bool Ignore;
	}

	public class Tables : List<Table>
	{
		public Tables()
		{
		}

		public Table GetTable(string tableName)
		{
			return this.Single(x => string.Compare(x.Name, tableName, true) == 0);
		}

		public Table this[string tableName]
		{
			get
			{
				return GetTable(tableName);
			}
		}

	}
}
