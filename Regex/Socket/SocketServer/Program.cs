using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            (new ServerSocket()).Fun1();
            Console.WriteLine("============");
            Console.ReadLine();
        }
    }
}
