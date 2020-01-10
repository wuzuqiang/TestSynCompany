using Fusion.Project.SC.LZ.LED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerConsoleApp1
{
    class SimuActivityInThok
    {
        private static readonly System.Timers.Timer Timer = new System.Timers.Timer(); //初始化。
        private static DateTime dt = new DateTime(); //固定时间。
        private static int num = 0;
        public virtual double MaxInterval { get; protected set; }
        public virtual double MinInterval { get; protected set; }
        public virtual double Interval { get; protected set; }
        /// <summary>
        /// 程序入口（自行调用）
        /// </summary>
        /// <param name="timing">定时时间（格式：年月日时分秒）</param>
        public void Init(int iInterval)
        {
            dt = DateTime.Now;
            SetInterval(iInterval);
            Timer.Elapsed += new System.Timers.ElapsedEventHandler((s, e) => Excute()); //达到间隔时间发生
        }

        private void Excute()
        {
            Set_LED();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMilSecond"></param>
        private void SetInterval(int iMilliSecond)
        {
            Timer.Stop();
            Timer.Interval = iMilliSecond;
            Timer.Start();
        }
        public virtual LedCardType LedCardType { get { return LedCardType.EQ2013; } }
        public LEDUtil LEDUtil = new LEDUtil();
        private void Set_LED()
        {
            IList<LEDData> ledDataList = new List<LEDData>();
            LEDData ledData = new LEDData();
            ledData.CardNum = 1;
            ledData.ColorFont = false ? EQ2008.EQ2008.GREEN : EQ2008.EQ2008.RED;
            ledData.Content = num++.ToString();
            ledData.FontName = "@宋体";
            ledData.SingleText.FontInfo.iFontSize = 9;
            //if (LedCardType == LedCardType.EQ2013)
            //{
            //    ledData.SingleText.MoveSet.iActionType = 2;
            //    ledData.SingleText.MoveSet.iHoldTime = 15;
            //    ledData.SingleText.MoveSet.iActionSpeed = 10;
            //}
            ledData.X = 0;
            ledData.Y = 0;
            ledData.Width = 192;
            ledData.Height = 32;
            ledData.IsMove = true;
            ledData.MethodType = MethodType.AddSingleText;
            Console.WriteLine(DateTime.Now.ToString() + "\t" + LEDUtil.Sending(ledData));
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
