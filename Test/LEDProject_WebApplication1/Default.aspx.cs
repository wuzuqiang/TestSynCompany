using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using EQ2008_DataStruct;

namespace LEDProject_WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
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
        [DllImport("EQ2008_Dll.dll", SetLastError = true, CharSet = CharSet.Ansi)]
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

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static int g_iCardNum = 1;      //控制卡地址
        public static int g_iGreen = 0xFF00; //绿色
        public static int g_iYellow = 0xFFFF; //黄色
        public static int g_iRed = 0x00FF; //红色
        public static int g_iProgramIndex = 0;
        public static int g_iProgramCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            //string str = $"当前g_iCardNum：{g_iCardNum}\t";
            //this.label1.Text = str;

        }

        protected void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_iCardNum = comboBox1.SelectedIndex + 1;
        }



        //添加节目
        protected void Button1_Click(object sender, EventArgs e)
        {
            g_iProgramIndex = User_AddProgram(g_iCardNum, false, 10);

            //提示信息
            string str = "当前节目号：";
            g_iProgramCount++;
            string strProgramCount = Convert.ToString(g_iProgramCount);
            str = str + strProgramCount;
            this.label1.Text = str;

            //提示信息
            //string str = $"当前g_iProgramIndex：{g_iProgramIndex}\t";
            //str += $"当前g_iCardNum：{g_iCardNum}\t";
            //this.label1.Text = str;
        }

        //删除所有节目
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (User_DelAllProgram(g_iCardNum) == false)
            {
                txtResult.Text = ("删除节目失败！");
            }
            else
            {
                //提示信息
                g_iProgramCount = 0;
                this.label1.Text = "请先添加节目！";
            }
        }

        //添加文本
        protected void Button3_Click(object sender, EventArgs e)
        {
            User_Text Text = new User_Text();

            Text.BkColor = 0;
            Text.chContent = ZoneText.Text.Replace("\\n", "\n");

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
                txtResult.Text = ("添加文本失败！");
            }
            else
            {
                txtResult.Text = ("添加文本成功！");
            }
        }



        //添加单行文本
        protected void Button4_Click(object sender, EventArgs e)
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
                txtResult.Text = ("添加单行文本失败！");
            }
            else
            {
                txtResult.Text = ("添加单行文本成功！");
            }
        }

        //发送数据
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (User_SendToScreen(g_iCardNum) == false)
            {
                txtResult.Text = ("发送节目失败！");
            }
            else
            {
                txtResult.Text = ("发送节目成功！");
            }
        }
    }
}