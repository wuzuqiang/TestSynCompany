using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程ThreadOrAnother
{
    class Program
    {
        static void Main(string[] args)
        {
            //SemaphoreSlimCustomDefine.MainFun();
            //CusDefTask.MainFun();
            //CusDefTask.TaskCompareWithThread();
            //AsyncLeftObliqueLineAwait.MainFun();
            while(true)
            (new SimpleThread()).ShowThread();

            Console.ReadLine();
        }
    }
    public class SemaphoreSlimCustomDefine
    {
        static SemaphoreSlim semLim = new SemaphoreSlim(2); //3表示最多只能有三个线程同时访问
        public static void MainFun()
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(SemaphoreTest).Start();
            }
            Console.Read();
        }
        static void SemaphoreTest()
        {
            semLim.Wait();
            Console.WriteLine("线程" + Thread.CurrentThread.ManagedThreadId.ToString() + "开始执行==>>>>");
            Thread.Sleep(2000);
            Console.WriteLine("线程" + Thread.CurrentThread.ManagedThreadId.ToString() + "执行完毕<<<<==");
            semLim.Release();
        }
    }

    public class CusDefTask
    {
        public static void MainFun()
        {
            Console.WriteLine("主线程启动");
            //Task.Run启动一个线程
            //Task启动的是后台线程，要在主线程中等待后台线程执行完毕，可以调用Wait方法
            //Task task = Task.Factory.StartNew(() => { Thread.Sleep(1500); Console.WriteLine("task启动"); });
            Task task = Task.Run(() => {
                Thread.Sleep(1500);
                Console.WriteLine("task启动");
            });
            Thread.Sleep(300);
            task.Wait();
            Console.WriteLine("主线程结束");
        }

        public static void TaskCompareWithThread()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Run1).Start();
            }
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() => { Run2(); });
            }
        }
        static void Run1()
        {
            Console.WriteLine("Thread Id =" + Thread.CurrentThread.ManagedThreadId);
        }
        static void Run2()
        {
            Console.WriteLine("Task调用的Thread Id =" + Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class AsyncLeftObliqueLineAwait
    {
        public static void MainFun()
        {
            Console.WriteLine("-------主线程启动-----");
            Task<int> task = GetStrLengthAsync();
            //GetStrLengthAsync().Wait();
            //GetStrLengthSync();
            Console.WriteLine("等待Task返回的值");
            Console.WriteLine("主线程继续执行");
            Console.WriteLine("Task返回的值" + task.Result);
            Console.WriteLine("-------主线程结束-----");
        }

        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            /*
            在遇到await关键字后，没有继续执行GetStrLengthAsync方法后面的操作
            ，也没有返回到main函数中，而是执行了GetString的第一行
            ，以此可以判断await这里并没有开启新的线程去执行GetString方法，而是以同步的方式让GetString方法执行
            ，等到执行GetString方法中的Task<string>.Run()的时候才由Task开启了后台线程！
            此处返回的<string>中的字符串类型，而不是Task<string>
            */
            /*await和wait类似，同样是等待，等待Task<string>.Run()开始的后台线程执行完毕，不同的是await不会阻塞主线程
             ，只会让GetStrLengthAsync方法暂停执行。*/
            //string str = await GetString();
            Console.WriteLine("GetStrLengthAsync方法执行结束");
            return 23;// str.Length;
        }

        static void GetStrLengthSync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            //GetString().Wait();
            string str = GetString().Result;    //若取值的时候，后台线程还没执行完，则会等待其执行完毕
            Console.WriteLine("GetStrLengthAsync方法执行结束");
        }

        static Task<string> GetString()
        {
            Console.WriteLine("GetString方法开始执行");
            return Task<string>.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine("GetString方法开始Run");
                return "GetString的返回值";
            });
        }
    }
}
