using System;
using System.Collections;
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
			//Fun01();
			TestHashTable();

			Console.ReadLine();
		}

		public void Fun()
		{
			Console.WriteLine("123456789".Substring(2, 2)); //34//索引是从0开始的。
			Console.WriteLine("123456789".Substring(0, 1)); //1
			Console.ReadLine();


			string[] array = new string[] { "1", "2", "one", "two" };
			Console.WriteLine(string.Join("、", array));
			Console.WriteLine(string.Join("、", new string[] { }));
			Console.WriteLine(string.Join("、", new string[] { "1" }));
		}

		public static void Fun01()
		{
			bool isExist = false;
			Console.WriteLine(isExist.ToString());
		}

		public static void TestHashTable()
		{
			Hashtable hs = new Hashtable();
			hs.Add("01", "01");
			hs.Add("02", "02");
			var val01 = hs[0];	//结果为null
			Console.WriteLine(val01);
		}
	}
}
