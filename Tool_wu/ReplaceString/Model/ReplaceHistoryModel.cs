using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceString.Model
{
	public class ReplaceHistoryModel
	{
		public ReplaceHistoryModel(string ActionCode, string ActionParamJson, string ActionName="", string GroupCode = "Group01", string TabCode = "TabCode01", string InputText = "", string ResultText = "")
		{
			this.ActionCode = ActionCode;
			this.ActionName = ActionName;
			this.ActionParamJson = ActionParamJson;
			this.GroupCode = GroupCode;
			this.TabCode = TabCode;
			this.InputText = InputText;
			this.ResultText = ResultText;
		}
		/// <summary>
		/// 动作编码
		/// </summary>
		public string ActionCode { get; set; }
		/// <summary>
		/// 动作名称
		/// </summary>
		public string ActionName { get; set; }
		/// <summary>
		/// 动作用到的参数，使用Json字符串保存
		/// </summary>
		public string ActionParamJson { get; set; }
		/// <summary>
		/// 所属分组编码(暂使用同一个分组，比如定义为Group01)
		/// </summary>
		public string GroupCode { get; set; }
		/// <summary>
		/// 所属组里页面编码(暂使用同一个分页，比如定义为TabCode01)	
		/// </summary>
		public string TabCode { get; set; }
		/// <summary>
		/// 替换日期
		/// </summary>
		public string ReplaceDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
		public string InputText { get; set; }
		public string ResultText { get; set; }
	}
}
