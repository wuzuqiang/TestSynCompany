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
            //Console.WriteLine("(new DateTime()).ToString(\"yyyy - MM - dd HH: mm:ss\")：" + (new DateTime()).ToString("yyyy-MM-dd HH:mm:ss"));
            //Console.WriteLine("DateTime.Now.ToString()：" + DateTime.Now.ToString());
            //Console.WriteLine("DateTime.Now.ToString(\"yyyy-MM-dd HH: mm:ss\")：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //Console.WriteLine("DateTime.Now.ToLongDateString()：" + DateTime.Now.ToLongDateString());
            //Console.WriteLine("DateTime.Now.ToShortTimeString()：" + DateTime.Now.ToShortTimeString());
            //Console.WriteLine("DateTime.Now.ToShortDateString()：" + DateTime.Now.ToShortDateString());
            //Console.WriteLine("DateTime.Now.ToShortTimeString()：" + DateTime.Now.ToShortTimeString());
            //Console.WriteLine("DateTime.Now.ToUniversalTime()：" + DateTime.Now.ToUniversalTime());
            //Console.WriteLine("DateTime.Now.ToOADate()：" + DateTime.Now.ToOADate());
            //Console.WriteLine("DateTime.Now.ToLocalTime()：" + DateTime.Now.ToLocalTime());

            Func1();

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
