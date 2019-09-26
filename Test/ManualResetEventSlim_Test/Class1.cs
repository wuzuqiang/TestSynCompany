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

        ManualResetEventSlim mres1 = new ManualResetEventSlim(false); // initialize as unsignaled
        public void TestMaualResetEventSlim()
        {
            mres1.Set();
            bool isReadData = false;
            //创建三个线程，并后一个线程要等前一个线程执行完才可以继续执行
            // Start an asynchronous Task 。。。
            var task_1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"线程1开始执行");
                Thread.Sleep(12);
                Console.WriteLine($"线程1结束执行");
                mres1.Wait();
                mres1.Reset();
            });
            mres1.Set();
            var task_2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"线程2开始执行");
                Thread.Sleep(6);
                Console.WriteLine($"线程2结束执行");
                mres1.Wait();
                mres1.Reset();
            });
            var task_3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"线程3开始执行");
                Thread.Sleep(7);
                Console.WriteLine($"线程3结束执行");
                mres1.Wait();
                mres1.Reset();
            });

            Console.ReadLine();
        }
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
        static void Main111()
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
