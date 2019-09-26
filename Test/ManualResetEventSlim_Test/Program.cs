using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualResetEventSlim_Test
{

    class ProgramTest
    {
        static void Main(string[] args)
        {
            var t1 = new Thread(() => TravelThroughGates("Thread1", 5));
            var t2 = new Thread(() => TravelThroughGates("Thread2", 6));
            var t3 = new Thread(() => TravelThroughGates("Thread3", 12));
            t1.Start();
            t2.Start();
            t3.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("The gates are now open!");
            _mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _mainEvent.Reset();
            Console.WriteLine("The gates have been closed!");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("The gates are now open for the second time!");
            _mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("The gates have been closed!");
            _mainEvent.Reset();

            Console.Write("begin cloase program");
            Console.ReadKey();
        }

        static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);

        static void TravelThroughGates(string threadName, int seconds)
        {
            Console.WriteLine("{0} beigin to sleep in function TravelThroughGates", threadName);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} waits for the gates to open!", threadName);
            _mainEvent.Wait();  //等待set信息，得到了才
            Console.WriteLine("{0} enters the gates!", threadName);
        }
    }
}
