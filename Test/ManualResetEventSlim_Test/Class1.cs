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
        private static ManualResetEventSlim mre = new ManualResetEventSlim(false);

        static void SumuMain_1()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
                              "\nto release all the threads.\n");
            Console.ReadLine();

            mre.Set();

            Thread.Sleep(500);
            Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
                              "\ndo not block. Press Enter to show this.\n");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
                              "\nwhen they call WaitOne().\n");
            Console.ReadLine();

            mre.Reset();

            // Start a thread that waits on the ManualResetEvent.
            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Thread_5";
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
            Console.ReadLine();

            mre.Set();

            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }


        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls mre.WaitOne()");

            mre.Set();

            Console.WriteLine(name + " ends.");
        }

        ManualResetEventSlim mres1 = new ManualResetEventSlim(false); // initialize as unsignaled
        public void TestMaualResetEventSlim()
        {
            bool isReadData = false;
            mres1.Set();
            //创建三个线程，并后一个线程要等前一个线程执行完才可以继续执行
            // Start an asynchronous Task 。。。
            var task_1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"线程1开始执行");
                Thread.Sleep(18);
                Console.WriteLine($"线程1结束执行");
                mres1.Wait();
                mres1.Reset();
            });
            // Start an asynchronous Task 。。。
            //var task_2 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"线程2开始执行");
            //    Thread.Sleep(6);
            //    mres1.Wait();
            //    mres1.Reset();
            //    Console.WriteLine($"线程2结束执行");
            //});
            var task_3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"线程3开始执行");
                mres1.Wait();
                mres1.Reset();
                Console.WriteLine($"线程3结束执行");
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
