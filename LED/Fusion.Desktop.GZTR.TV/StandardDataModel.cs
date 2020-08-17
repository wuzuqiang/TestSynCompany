using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public class StandardDataModel<T>
	{
		public bool success;
		public bool exception;
		public IDictionary<string, string> errors;
		public string msg;
		public int total;
		public T data;

		public StandardDataModel() { }
	}
}
