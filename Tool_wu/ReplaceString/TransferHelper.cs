using BaseClassUtils;
using ReplaceString.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceString
{
	public class TransferHelper
	{

		public static Dictionary<string, object> ReplaceHistoryModelToDic(ReplaceHistoryModel model)
		{
			Dictionary<string, object> dicTableColumnData = new Dictionary<string, object>();
			dicTableColumnData.Add("ActionCode", model.ActionCode);
			dicTableColumnData.Add("ActionName", model.ActionName);
			dicTableColumnData.Add("ActionParamJson", model.ActionParamJson);
			dicTableColumnData.Add("GroupCode", model.GroupCode);
			dicTableColumnData.Add("TabCode", model.TabCode);
			dicTableColumnData.Add("ReplaceDate", model.ReplaceDate);
			return dicTableColumnData;
		}

		public static void ExecuteInsert(string actionCode, string actionParamJson="", string tableName= "ReplaceString")
		{
			var i = SQLiteHelper.ExecuteInsert(tableName, ReplaceHistoryModelToDic(new ReplaceHistoryModel(actionCode, actionParamJson)));

		}
	}
}
