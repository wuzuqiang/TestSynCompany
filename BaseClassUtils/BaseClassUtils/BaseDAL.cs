using System;
using System.Data.SQLite;

namespace BaseClassUtils
{
	public class BaseDAL
	{
		public static T Execute<T>(string connectionString, Func<SQLiteConnection, T> func)
		{
			using (SQLiteConnection con = new SQLiteConnection(connectionString))
			{
				return func(con);
			}
		}
		public static T ExecuteTransaction<T>(string connectionString, Func<SQLiteConnection, SQLiteTransaction, T> func)
		{
			using (var con = new SQLiteConnection(connectionString))
			{
				con.Open();
				using (var trans = con.BeginTransaction())
				{
					return func(con, trans);
				}
			}
		}
		public static void ExecuteTransaction(string connectionString, Action<SQLiteConnection, SQLiteTransaction> func)
		{
			using (var con = new SQLiteConnection(connectionString))
			{
				con.Open();
				using (var trans = con.BeginTransaction())
				{
					func(con, trans);
				}
			}
		}
	}

}