using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NetWorkConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var hostAddress = HttpContext.Current.Request.UserHostAddress;	//失败.Current.Request为null会导致异常
			Console.WriteLine($"当前地址为：{hostAddress}");

			Console.ReadLine();
		}
	}
}
