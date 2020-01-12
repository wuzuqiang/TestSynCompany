using EQ2008;
using Fusion.Project.SC.LZ.LED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
        public void Init(int iInterval)
        {
            dt = DateTime.Now;
            Excute();
            //SetInterval(iInterval);
            //Timer.Elapsed += new System.Timers.ElapsedEventHandler((s, e) => Excute()); //达到间隔时间发生
        }
        public void Excute()
        {
            //Set_LED();
            var classLED = new EQ2008();
            classLED.删除所有节目();
            classLED.添加节目();
            classLED.添加单行文本();
            classLED.发送数据();
            classLED.打开显示屏();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iMilSecond"></param>
        public void SetInterval(int iMilliSecond)
        {
            Timer.Stop();
            Timer.Interval = iMilliSecond;
            Timer.Start();
        }
        public virtual LedCardType LedCardType { get { return LedCardType.EQ2013; } }
        public LEDUtil LEDUtil = new LEDUtil();
        public void Set_LED()
        {
            IList<LEDData> ledDataList = new List<LEDData>();
            LEDData ledData = new LEDData();
            ledData.CardNum = 1;
            //ledData.ColorFont = false ? EQ2008.GREEN : EQ2008.RED;
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
    public class EQ2008
    {
        private string ZoneH;
        private string ZoneW;
        private string ZoneY;
        private string ZoneX;
        #region 添加EQ2008函数
        //==========================1、节目操作函数======================//
        //添加节目
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddProgram(int CardNum, Boolean bWaitToEnd, int iPlayTime);
        //删除所有节目
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_DelAllProgram(int CardNum);
        //添加单行文本区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddSingleText(int CardNum, ref User_SingleText pSingleText, int iProgramIndex);
        //添加文本区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddText(int CardNum, ref User_Text pText, int iProgramIndex);
        //添加时间区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddTime(int CardNum, ref User_DateTime pdateTime, int iProgramIndex);
        //添加图文区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddBmpZone(int CardNum, ref User_Bmp pBmp, int iProgramIndex);
        //指定图像句柄添加图片
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern bool User_AddBmp(int CardNum, int iBmpPartNum, IntPtr hBitmap, ref User_MoveSet pMoveSet, int iProgramIndex);
        //指定图像路径添加图片
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern bool User_AddBmpFile(int CardNum, int iBmpPartNum, string strFileName, ref User_MoveSet pMoveSet, int iProgramIndex);
        //添加计时区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddTimeCount(int CardNum, ref User_Timer pTimeCount, int iProgramIndex);
        //添加温度区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddTemperature(int CardNum, ref User_Temperature pTemperature, int iProgramIndex);
        //发送数据
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_SendToScreen(int CardNum);
        //====================================================================//       
        //=======================2、实时发送数据（高频率发送）=================//
        //实时建立连接
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_RealtimeConnect(int CardNum);
        //实时发送图片数据
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_RealtimeSendData(int CardNum, int x, int y, int iWidth, int iHeight, IntPtr hBitmap);
        //实时发送图片文件
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_RealtimeSendBmpData(int CardNum, int x, int y, int iWidth, int iHeight, string strFileName);
        //实时发送文本
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_RealtimeSendText(int CardNum, int x, int y, int iWidth, int iHeight, string strText, ref User_FontSet pFontInfo);
        //实时关闭连接
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_RealtimeDisConnect(int CardNum);
        //实时发送清屏
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_RealtimeScreenClear(int CardNum);
        //====================================================================//
        //==========================3、显示屏控制函数组=======================//
        //校正时间
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_AdjustTime(int CardNum);
        //开屏
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_OpenScreen(int CardNum);
        //关屏
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_CloseScreen(int CardNum);
        //亮度调节
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_SetScreenLight(int CardNum, int iLightDegreen);
        //Reload参数文件
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern void User_ReloadIniFile(string strEQ2008_Dll_Set_Path);
        //====================================================================//
        #endregion
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        public static int g_iCardNum = 1;      //控制卡地址
        public static int g_iGreen = 0xFF00; //绿色
        public static int g_iYellow = 0xFFFF; //黄色
        public static int g_iRed = 0x00FF; //红色
        public static int g_iProgramIndex = 0;
        public static int g_iProgramCount = 0;

        public EQ2008()
        {
            ZoneX = "0";
            ZoneY = "0";
            ZoneW = "192";
            ZoneH = "32";
            Init();
        }
        //选择控制卡地址
        public void Init()
        {
            g_iCardNum = 0 + 1;
        }
        //添加节目
        public void 添加节目()
        {
            g_iProgramIndex = User_AddProgram(g_iCardNum, false, 10);
            //提示信息
            string str = "当前节目号：";
            g_iProgramCount++;
            string strProgramCount = Convert.ToString(g_iProgramCount);
            str = str + strProgramCount;
            Console.WriteLine(str);
        }
        //删除所有节目
        public void 删除所有节目()
        {
            if (User_DelAllProgram(g_iCardNum) == false)
            {
                Console.WriteLine("删除节目失败！");
            }
            else
            {
                //提示信息
                g_iProgramCount = 0;

            }
        }
        //添加文本
        public void 添加文本()
        {
            User_Text Text = new User_Text();
            Text.BkColor = 0;
            Text.chContent = "test00000";
            Text.PartInfo.FrameColor = 0;
            Text.PartInfo.iFrameMode = 0;
            Text.PartInfo.iHeight = 32;
            Text.PartInfo.iWidth = 64;
            Text.PartInfo.iX = 0;
            Text.PartInfo.iY = 0;
            Text.FontInfo.bFontBold = false;
            Text.FontInfo.bFontItaic = false;
            Text.FontInfo.bFontUnderline = false;
            Text.FontInfo.colorFont = g_iYellow;
            Text.FontInfo.iFontSize = 12;
            Text.FontInfo.strFontName = "宋体";
            Text.FontInfo.iAlignStyle = 0;
            Text.FontInfo.iVAlignerStyle = 0;
            Text.FontInfo.iRowSpace = 2;
            Text.MoveSet.bClear = false;
            Text.MoveSet.iActionSpeed = 5;
            Text.MoveSet.iActionType = 0;
            Text.MoveSet.iHoldTime = 20;
            Text.MoveSet.iClearActionType = 0;
            Text.MoveSet.iClearSpeed = 4;
            Text.MoveSet.iFrameTime = 20;
            if (-1 == User_AddText(g_iCardNum, ref Text, g_iProgramIndex))
            {
                Console.WriteLine("添加文本失败！");
            }
            else
            {
                Console.WriteLine("添加文本成功！");
            }
        }
        //添加单行文本
        public void 添加单行文本()
        {
            User_SingleText SingleText = new User_SingleText();
            SingleText.BkColor = 0;
            SingleText.chContent = "欢迎使用EQ2008型控制卡动态库!";
            SingleText.PartInfo.iFrameMode = 0;
            SingleText.PartInfo.iHeight = 32;
            SingleText.PartInfo.iWidth = 64;
            SingleText.PartInfo.iX = 0;
            SingleText.PartInfo.iY = 0;
            SingleText.FontInfo.bFontBold = false;
            SingleText.FontInfo.bFontItaic = false;
            SingleText.FontInfo.bFontUnderline = false;
            SingleText.FontInfo.colorFont = 0xFF;
            SingleText.FontInfo.iFontSize = 16;
            SingleText.PartInfo.FrameColor = 0xFF;
            SingleText.FontInfo.strFontName = "宋体";
            SingleText.MoveSet.bClear = false;
            SingleText.MoveSet.iActionSpeed = 6;
            SingleText.MoveSet.iActionType = 2;
            SingleText.MoveSet.iHoldTime = 20;
            SingleText.MoveSet.iClearActionType = 0;
            SingleText.MoveSet.iClearSpeed = 0;
            SingleText.MoveSet.iFrameTime = 20;
            if (-1 == User_AddSingleText(g_iCardNum, ref SingleText, g_iProgramIndex))
            {
                Console.WriteLine("添加单行文本失败！");
            }
            else
            {
                Console.WriteLine("添加单行文本成功！");
            }
        }
        //添加时间
        public void 添加时间()
        {
            User_DateTime DateTime = new User_DateTime();
            DateTime.bDay = false;
            DateTime.bHour = true;
            DateTime.BkColor = 0;
            DateTime.bMin = true;
            DateTime.bMouth = false;
            DateTime.bMulOrSingleLine = false;
            DateTime.bSec = true;
            DateTime.bWeek = false;
            DateTime.bYear = false;
            DateTime.bYearDisType = false;
            DateTime.chTitle = "";
            DateTime.PartInfo.iFrameMode = 1;
            DateTime.iDisplayType = 1;
            DateTime.PartInfo.FrameColor = 0xFFFF;
            DateTime.PartInfo.iHeight = 32;
            DateTime.PartInfo.iWidth = 64;
            DateTime.PartInfo.iX = 0;
            DateTime.PartInfo.iY = 0;
            DateTime.FontInfo.bFontBold = false;
            DateTime.FontInfo.bFontItaic = false;
            DateTime.FontInfo.bFontUnderline = false;
            DateTime.FontInfo.colorFont = 0xFF;
            DateTime.FontInfo.iAlignStyle = 1;
            DateTime.FontInfo.iFontSize = 12;
            DateTime.FontInfo.strFontName = "宋体";
            if (-1 == User_AddTime(g_iCardNum, ref DateTime, g_iProgramIndex))
            {
                Console.WriteLine("添加时间失败！");
            }
            else
            {
                Console.WriteLine("添加时间成功！");
            }
        }
        //添加计时
        public void 添加计时()
        {
            User_Timer TimeCount = new User_Timer();
            TimeCount.bDay = true;
            TimeCount.bHour = false;
            TimeCount.BkColor = 0;
            TimeCount.bMin = false;
            TimeCount.bMulOrSingleLine = true;
            TimeCount.bSec = false;
            TimeCount.chTitle = "距离国庆";
            TimeCount.FontInfo.bFontBold = false;
            TimeCount.FontInfo.bFontItaic = false;
            TimeCount.FontInfo.bFontUnderline = false;
            TimeCount.FontInfo.colorFont = 0xFFFF;
            TimeCount.FontInfo.iAlignStyle = 2;
            TimeCount.FontInfo.iFontSize = 16;
            TimeCount.FontInfo.strFontName = "宋体";
            TimeCount.PartInfo.FrameColor = 0xFF00;
            TimeCount.PartInfo.iFrameMode = 0;
            TimeCount.PartInfo.iHeight = 32;
            TimeCount.PartInfo.iWidth = 64;
            TimeCount.PartInfo.iX = 0;
            TimeCount.PartInfo.iY = 0;
            TimeCount.ReachTimeYear = 2010;
            TimeCount.ReachTimeMonth = 10;
            TimeCount.ReachTimeDay = 1;
            TimeCount.ReachTimeHour = 12;
            TimeCount.ReachTimeMinute = 0;
            TimeCount.ReachTimeSecond = 0;
            if (-1 == User_AddTimeCount(g_iCardNum, ref TimeCount, g_iProgramIndex))
            {
                Console.WriteLine("添加计时失败！");
            }
            else
            {
                Console.WriteLine("添加计时成功！");
            }
        }
        //添加温度
        public void 添加温度()
        {
            User_Temperature Temperature = new User_Temperature();
            Temperature.BkColor = 0;
            Temperature.chTitle = "";
            Temperature.DisplayType = 0;
            Temperature.PartInfo.FrameColor = 0xFF00;
            Temperature.PartInfo.iFrameMode = 1;
            Temperature.PartInfo.iHeight = 32;
            Temperature.PartInfo.iWidth = 64;
            Temperature.PartInfo.iX = 0;
            Temperature.PartInfo.iY = 0;
            Temperature.FontInfo.bFontBold = false;
            Temperature.FontInfo.bFontItaic = false;
            Temperature.FontInfo.bFontUnderline = false;
            Temperature.FontInfo.colorFont = 0xFFFF;
            Temperature.FontInfo.iAlignStyle = 0;
            Temperature.FontInfo.iFontSize = 12;
            Temperature.FontInfo.strFontName = "宋体";
            if (-1 == User_AddTemperature(g_iCardNum, ref Temperature, g_iProgramIndex))
            {
                Console.WriteLine("添加温度失败！");
            }
            else
            {
                Console.WriteLine("添加温度成功！");
            }
        }
        //添加图片
        public void 添加图片()
        {
        }
        //发送数据
        public void 发送数据()
        {
            if (User_SendToScreen(g_iCardNum) == false)
            {
                Console.WriteLine("发送节目失败！");
            }
            else
            {
                Console.WriteLine("发送节目成功！");
            }
        }
        //打开显示屏
        public void 打开显示屏()
        {
            Console.WriteLine("打开显示屏" + g_iCardNum);
            if (User_OpenScreen(g_iCardNum) == false)
            {
                Console.WriteLine("打开显示屏失败！");
            }
            else
            {
                Console.WriteLine("打开显示屏成功！");
            }
        }
        //关闭显示屏
        public void 关闭显示屏()
        {
            if (User_CloseScreen(g_iCardNum) == false)
            {
                Console.WriteLine("关闭显示屏失败！");
            }
            else
            {
                Console.WriteLine("关闭显示屏成功！");
            }
        }
        //校准时间
        public void 校准时间()
        {
            if (User_AdjustTime(g_iCardNum) == false)
            {
                Console.WriteLine("校准时间失败！");
            }
            else
            {
                Console.WriteLine("校准时间成功！");
            }
        }
        //实时连接
        public void 实时连接()
        {
            if (!User_RealtimeConnect(g_iCardNum))
            {
                Console.WriteLine("连接实时通信失败！");
            }
            else
            {
                Console.WriteLine("连接实时通信成功！");
            }
        }
        //实时关闭
        public void 实时关闭()
        {
            if (!User_RealtimeDisConnect(g_iCardNum))
            {
                Console.WriteLine("关闭实时通信失败！");
            }
            else
            {
                Console.WriteLine("关闭实时通信成功！");
            }
        }
        //实时发送文本内容
        public void 实时发送文本内容()
        {
            int iX = Convert.ToInt32(ZoneX);
            int iY = Convert.ToInt32(ZoneY);
            int iW = Convert.ToInt32(ZoneW);
            int iH = Convert.ToInt32(ZoneH);
            string strText = "实时发送文本测试!";
            User_FontSet FontInfo = new User_FontSet();
            FontInfo.bFontBold = false;
            FontInfo.bFontItaic = false;
            FontInfo.bFontUnderline = false;
            FontInfo.colorFont = 0xFFFF;
            FontInfo.iFontSize = 12;
            FontInfo.strFontName = "宋体";
            FontInfo.iAlignStyle = 0;
            FontInfo.iVAlignerStyle = 0;
            FontInfo.iRowSpace = 0;
            if (!User_RealtimeSendText(g_iCardNum, iX, iY, iW, iH, strText, ref FontInfo))
            {
                Console.WriteLine("发送实时文本失败！");
            }
            else
            {
                Console.WriteLine("发送实时文本成功！");
            }
        }
        //清空显示屏原有节目
        public void 清空显示屏原有节目()
        {
            if (!User_RealtimeScreenClear(g_iCardNum))
            {
                Console.WriteLine("清空控制卡节目失败！");
            }
            else
            {
                Console.WriteLine("清空控制卡节目成功！");
            }
        }
    }
}

