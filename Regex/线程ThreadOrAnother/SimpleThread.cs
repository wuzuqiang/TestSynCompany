using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程ThreadOrAnother
{
    public class SimpleThread
    {
        public void ShowThread()
        {
            //Task task = new Task();
            Thread _thread = new Thread(new ThreadStart(DoThing));
            _thread.Start();
            Console.WriteLine("是否结束线程！Y代表结束，其他代表不结束。");
            string str = Console.ReadLine();
            if ("Y" == str)
            {
                _thread.Abort();
                Console.WriteLine("手动关闭了线程，线程ID为：" + _thread.ManagedThreadId);
            }
        }

        public void DoThing()
        {
            int i = 6000;
            Console.WriteLine("开启线程" + Thread.CurrentThread.ManagedThreadId + "并休眠" + i + "毫秒");
            Thread.Sleep(i);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "线程" + Thread.CurrentThread.ManagedThreadId + "执行完毕");
        }
    }
}
