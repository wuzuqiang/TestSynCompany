using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasic
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("123456789".Substring(2, 2)); //34//索引是从0开始的。
			Console.WriteLine("123456789".Substring(0, 1)); //1
			Console.ReadLine();


			string[] array = new string[] { "1", "2", "one", "two"};
			Console.WriteLine(string.Join("、", array));
			Console.WriteLine(string.Join("、", new string[] { }));
			Console.WriteLine(string.Join("、", new string[] { "1"}));


			Console.ReadLine();
		}
	}
}
