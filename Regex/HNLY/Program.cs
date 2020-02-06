using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClassUtils;

namespace HNLY
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.xml");
            XMLUtils.filePath = filePath;
            (new XMLUtils()).readAll("book");
            Console.ReadLine();
        }
    }
}
