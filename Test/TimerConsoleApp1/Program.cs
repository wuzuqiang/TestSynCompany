using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = (new Class1());
            a.Init();
            a.print(DateTime.Now);
            Console.ReadLine();
        }
    }
}
