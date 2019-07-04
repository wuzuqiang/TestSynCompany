using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 定时器
{
    class Program
    {
        static System.Timers.Timer _timer;
        static void Main(string[] args)
        {
            SetTimer();
            StartTimer();
            System.Threading.Thread.Sleep(1000);
            StopTimer();

            Console.ReadLine();
        }

        static void SetTimer()
        {
            Console.WriteLine("请输入定时器间隔毫秒数：");
            string strConsole = Console.ReadLine();
            _timer = new System.Timers.Timer(Convert.ToInt32(strConsole));  //实例化Timer类，设置间隔时间为strConsole毫秒
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = true;    //设置是执行一次还是执行多次
            //_timer.Enabled = true;  //是否执行System.Timers.Timer.Elapsed事件；  //Start函数也会使得Enabled为ture
        }

        static void StartTimer()
        {
            _timer.Start();
        }

        static void StopTimer()
        {
            _timer.Stop();
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("抱歉！定时器超时！");
        }
    }
}
