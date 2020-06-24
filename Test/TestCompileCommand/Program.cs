
#define DEBUG
#define VC_V7
#pragma warning disable 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompileCommand
{
    public class Program
    {
        static void Main()
        {
#if (DEBUG && !VC_V7)
            Console.WriteLine("only DEBUG is defined");
#elif (!DEBUG && VC_V7)
            Console.WriteLine("only VC_V7 is defined");
#elif (DEBUG && VC_V7)
            Console.WriteLine("DEBUG and VC_V7 are defined");
#else
            Console.WriteLine("DEBUG and VC_V7 are not defined");
#endif
            Console.ReadLine();
        }
    }

}