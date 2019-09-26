using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualResetEventSlim_Test
{
    public class Class1
    {
        static ManualResetEventSlim manualRestEvnetSlim = new ManualResetEventSlim(false);
        static void TravelThroughGates(string threadName, int second)
        {
            Console.WriteLine("--{0} begin to sleep in function TravelThroughGates", threadName);
            Thread.Sleep(TimeSpan.FromSeconds(second));
            Console.WriteLine("--{0} waits for the gate open", threadName);
            manualRestEvnetSlim.Wait();
            Console.WriteLine("--{0} enter the gates", threadName);
        }

        public static void SimuMain()
        {
            var t1 = new Thread(() => TravelThroughGates("T1", 5));
            var t2 = new Thread(() => TravelThroughGates("T2", 6));
            var t3 = new Thread(() => TravelThroughGates("T3", 12));
            t1.Start();
            t2.Start();
            t3.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            Console.WriteLine("the Gates is open");
            manualRestEvnetSlim.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            manualRestEvnetSlim.Reset();
            Console.WriteLine("the gate has been closed");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("the gates opend second times");
            manualRestEvnetSlim.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("the gates closed angin");
            manualRestEvnetSlim.Reset();

        }
        static void Main()
        {
            var t1 = new Thread(() => TravelThroughGates("T1", 5));
            var t2 = new Thread(() => TravelThroughGates("T2", 6));
            var t3 = new Thread(() => TravelThroughGates("T3", 12));
            t1.Start();
            t2.Start();
            t3.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("the Gates is open");
            manualRestEvnetSlim.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            manualRestEvnetSlim.Reset();
            Console.WriteLine("the gate has been closed");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("the gates opend second times");
            manualRestEvnetSlim.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("the gates closed angin");
            manualRestEvnetSlim.Reset();


            //Thread.Sleep(13);
            Console.Write("Begin close this program");
            Console.ReadLine();
        }
    }
}
