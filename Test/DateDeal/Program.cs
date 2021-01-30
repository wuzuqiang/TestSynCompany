using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateUtils
{
    class Program
    {
        static void Main(string[] args)
        {   //时间处理DateTime
			Console.WriteLine("(new DateTime()).ToString(\"yyyy - MM - dd HH: mm:ss\")：" + (new DateTime()).ToString("yyyy-MM-dd HH:mm:ss"));//(new DateTime()).ToString("yyyy - MM - dd HH: mm:ss")：0001-01-01 00:00:00
			Console.WriteLine("DateTime.Now.ToString()：" + DateTime.Now.ToString());//DateTime.Now.ToString()：2021/1/27 18:19:59
			Console.WriteLine("DateTime.Now.ToString(\"yyyy-MM-dd HH: mm:ss\")：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss")：2021-01-27 18:19:59
			Console.WriteLine("DateTime.Now.ToLongDateString()：" + DateTime.Now.ToLongDateString());//DateTime.Now.ToLongDateString()：2021年1月27日
			Console.WriteLine("DateTime.Now.ToShortTimeString()：" + DateTime.Now.ToShortTimeString());//DateTime.Now.ToShortTimeString()：18:19
			Console.WriteLine("DateTime.Now.ToShortDateString()：" + DateTime.Now.ToShortDateString());//DateTime.Now.ToShortDateString()：2021/1/27
			Console.WriteLine("DateTime.Now.ToShortTimeString()：" + DateTime.Now.ToShortTimeString());//DateTime.Now.ToShortTimeString()：18:19
			Console.WriteLine("DateTime.Now.ToUniversalTime()：" + DateTime.Now.ToUniversalTime());//DateTime.Now.ToUniversalTime()：2021/1/27 10:19:59
			Console.WriteLine("DateTime.Now.ToOADate()：" + DateTime.Now.ToOADate());//DateTime.Now.ToOADate()：44223.7638785069
			Console.WriteLine("DateTime.Now.ToLocalTime()：" + DateTime.Now.ToLocalTime());//DateTime.Now.ToLocalTime()：2021/1/27 18:19:59


			//Func1();

			Console.ReadLine();
        }
        static void Func1()
        {
            List<TestClass> listTestClass = new List<TestClass>();
            listTestClass.Add(new TestClass());

            var a = listTestClass.Where(w => (w.dtimeStart).Date == DateTime.Now.Date).ToList();
            Console.WriteLine(a);
        }
    }

    class TestClass
    {
        public DateTime dtimeStart = new DateTime();
    }
}
