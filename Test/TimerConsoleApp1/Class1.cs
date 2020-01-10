using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerConsoleApp1
{
    class Class1
    {
        private static readonly System.Timers.Timer Timer = new System.Timers.Timer(); //初始化。
        private static DateTime dt = new DateTime(); //固定时间。
        private static int num = 0;
        /// <summary>
        /// 程序入口（自行调用）
        /// </summary>
        /// <param name="timing">定时时间（格式：年月日时分秒）</param>
        public void Init()
        {
            dt = DateTime.Now;
            SetInterval();
            Timer.Elapsed += new System.Timers.ElapsedEventHandler((s, e) => SetInterval()); //达到间隔时间发生
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="timing">定时时间（格式：年月日时分秒）</param>
        private void SetInterval()
        {
            Timer.Stop();
            var now = DateTime.Now;
            if (now >= dt)//如果当前时间>=定时时间
            {
                //定时结束之后，你要执行的代码
                print(now);
                //----------------------------------------------------------
                //此处可修改dt。更改需求。
                //----------------------------------------------------------
                dt = DateTime.Now.Date.AddDays(1).AddHours(12); //重新计算定时时间，第二天12点再执行。
                                                                //dt = DateTime.Now.AddMinutes(0.1);//重新计算定时时间，每分钟执行一次。
                SetInterval();
            }
            else//如果当前时间<定时时间
            {
                Timer.Interval = dt.Subtract(now).TotalMilliseconds;//重新计算定时时间，按毫秒计算。
                Timer.Start();
            }
        }

        /// <summary>
        /// 测试输出
        /// </summary>
        public void print(DateTime dt)
        {
            num++;
            Console.WriteLine("执行第{0}次，时间：{1}", num, dt);
        }

    }
}
