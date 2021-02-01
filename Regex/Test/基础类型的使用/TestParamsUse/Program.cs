using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParamsUse
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array_a = ToArray(1, 2, 3, 4);
			ShowData(array_a);

			int[] array_b = ToArray(array_a);
			ShowData(array_b);

			Console.ReadLine();
		}

		public static int[] ToArray(params int[] arr)
		{
			return arr;
		}

		public static void ShowData(int[] arr)
		{
			foreach(var data in arr)
			{
				Console.Write($"{data}\t");
			}
			Console.WriteLine();
		}
	}
}
