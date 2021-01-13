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
			string[] array = new string[] { "1", "2", "one", "two"};
			Console.WriteLine(string.Join("、", array));
			Console.WriteLine(string.Join("、", new string[] { }));
			Console.WriteLine(string.Join("、", new string[] { "1"}));

			Console.ReadLine();
		}
	}
}
