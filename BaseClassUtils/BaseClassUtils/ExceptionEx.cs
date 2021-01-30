using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
	public class ExceptionEx : Exception
	{
		public ExceptionEx() : base()
		{
			this.MessageEx = base.Message + "test";
		}
		public ExceptionEx(string message) : base(message)
		{
			this.MessageEx = message + "testEx";
		}

		public string MessageEx { get; set; }
	}
}
