using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace Fusion.Desktop.GZTR.TV
{
    public partial class StoreInLEDForm : Form
    {

        #region 节目操作函数
        //删除所有节目
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_DelAllProgram(int CardNum);
        //添加节目
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddProgram(int CardNum, Boolean bWaitToEnd, int iPlayTime);
        //添加单行文本区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddSingleText(int CardNum, ref User_SingleText pSingleText, int iProgramIndex);
        //添加文本区
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern int User_AddText(int CardNum, ref User_Text pText, int iProgramIndex);
        //发送数据
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_SendToScreen(int CardNum);
        //开屏
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_OpenScreen(int CardNum);
        //关机
        [DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
        public static extern Boolean User_CloseScreen(int CardNum);

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
        #endregion


        /// <summary>
        /// 单行文本区参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct User_SingleText
        {
            public string chContent;            //显示内容
            public User_PartInfo PartInfo;      //分区信息
            public int BkColor;                 //背景颜色
            public User_FontSet FontInfo;       //字体设置
            public User_MoveSet MoveSet;        //动作方式设置
        }
        /// <summary>
        /// 文本区参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct User_Text
        {
            public string chContent;            //显示内容
            public User_PartInfo PartInfo;      //分区信息
            public int BkColor;                 //背景颜色
            public User_FontSet FontInfo;       //字体设置
            public User_MoveSet MoveSet;        //动作方式设置
        }

        /// <summary>
        /// 节目区域参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct User_PartInfo
        {
            public int iX;                    //窗口的起点X
            public int iY;                    //窗口的起点Y
            public int iWidth;                //窗体的宽度
            public int iHeight;               //窗体的高度
            public int iFrameMode;            //边框的样式
            public int FrameColor;            //边框颜色
        }

        /// <summary>
        /// 字体参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct User_FontSet
        {
            public string strFontName;       //字体的名称
            public int iFontSize;            //字体的大小
            public bool bFontBold;           //字体是否加粗
            public bool bFontItaic;          //字体是否是斜体
            public bool bFontUnderline;      //字体是否带下划线
            public int colorFont;            //字体的颜色
            public int iAlignStyle;          //左右对齐方式，0－ 左对齐，1－居中，2－右对齐
            public int iVAlignerStyle;       //上下对齐方式，0-顶对齐，1-上下居中，2-底对齐    
            public int iRowSpace;            //行间距
        }

        /// <summary>
        /// 动画方式参数
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct User_MoveSet
        {
            public int iActionType;             //节目变换方式
            public int iActionSpeed;            //节目的播放速度
            public bool bClear;                 //是否需要清除背景
            public int iHoldTime;               //在屏幕上停留的时间
            public int iClearSpeed;             //清除显示屏的速度
            public int iClearActionType;        //节目清除的变换方式
            public int iFrameTime;              //每帧时间
        }

        public enum Color
        {
            RED = 0xFFFF,
            YELLOW = 0xFF00
        }

        public enum LedCardType
        {
            EQ2013,
            EQ2008
        }

        private class LEDChannel
        {
            public int LedGroup { get; set; }
            public int MaxSortAddress { get; set; }
            public IList<AllChannel> AllChannels { get; set; }

            public class AllChannel
            {
                //public ChannelModel Channel { get; set; }
                //public ChannelAllotModel ChannelAllot { get; set; }
            }
        }

        private System.Timers.Timer triggerTimer = new System.Timers.Timer();
        private bool inElapsed = false;
        private string serverCode = "";
        private string groupCode = "";

        public StoreInLEDForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void StoreInLEDForm_Load(object sender, EventArgs e)
        {
            triggerTimer.Elapsed += TriggerTimer_Elapsed;
            triggerTimer.Interval = Convert.ToInt32(txtRefreshInterval.Text);
            
        }
        int ss = 1100;

        private void TriggerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            ss = ss + 2;
            if (!inElapsed)
            {
                inElapsed = true;
                try
                {
                    foreach (var item in storeInRequest)
                    {
                        
                        int[] storeInRequest = HttpUtil.HttpRequest<int[]>(item.RequestCode);
                        var requestData = this.getRequestData(storeInRequest);
                        //var requestData = new RequestData { Sign=1,PalletBarcode="05011337",WorkPositionNo=1 };
                        var billUrl = "/Api/AssortedBill/GetAssortedBillOfAudited?uniqueId=";
                        if (requestData.PalletBarcode!= item.OldPalletcode|| requestData.Sign!=item.Sign)
                        {
                            if (requestData.Sign == 0)
                            {
                                var delstate = User_RealtimeScreenClear(item.CardNum);
                            }
                            if (requestData.Sign == 1)
                            {
                                var delstate = User_DelAllProgram(item.CardNum);
                                if (delstate == false)
                                {
                                    listLogger.Items.Add("删除节目失败！");
                                    inElapsed = false;
                                    return;
                                }
                                listLogger.Items.Add("清屏成功");
                                var programIndex = User_AddProgram(item.CardNum, false, 10);
                                User_Text SingleText = new User_Text();
                                billUrl = billUrl + requestData.PalletBarcode;
                                var billUrlRequest = HttpUtil.HttpRequest<AssortedBillModel>(billUrl);
                                var LEDtest = "";
                                if (billUrlRequest == null)
                                {
                                    LEDtest = $"唯一码：" + requestData.PalletBarcode + "，不存在已审核的拼盘单据，请核查！";
                                }
                                else
                                {
                                    LEDtest = "托盘条码：" + billUrlRequest.UniqueId + "  配盘名称：" + billUrlRequest.MatchPalletName +
                                             "\n牌号：" + billUrlRequest.BrandNames + " 托盘类型：" + billUrlRequest.PalletTypeName;
                                }

                                SingleText.BkColor = 0;
                                SingleText.chContent = LEDtest;
                                SingleText.PartInfo.iFrameMode = 0;
                                SingleText.PartInfo.iHeight = 96;
                                SingleText.PartInfo.iWidth = 192;
                                SingleText.PartInfo.iX = 0;
                                SingleText.PartInfo.iY = 0;
                                SingleText.FontInfo.bFontBold = false;
                                SingleText.FontInfo.bFontItaic = false;
                                SingleText.FontInfo.bFontUnderline = false;
                                SingleText.FontInfo.colorFont = 0xFF;
                                SingleText.FontInfo.iFontSize = 9;
                                SingleText.PartInfo.FrameColor = 0xFF;
                                SingleText.FontInfo.strFontName = "宋体";
                                SingleText.MoveSet.bClear = false;
                                SingleText.MoveSet.iActionSpeed = 6;
                                SingleText.MoveSet.iActionType = 1;
                                SingleText.MoveSet.iHoldTime = 20;
                                SingleText.MoveSet.iClearActionType = 0;
                                SingleText.MoveSet.iClearSpeed = 0;
                                SingleText.MoveSet.iFrameTime = 20;

                                var addint = User_AddText(item.CardNum, ref SingleText, programIndex);

                                if (-1 == addint)
                                {
                                    listLogger.Items.Add("添加文本失败！");
                                }

                                var sendstate = User_SendToScreen(item.CardNum);
                                if (sendstate == false)
                                {
                                    listLogger.Items.Add("发送节目失败！");
                                }
                                else
                                {
                                    listLogger.Items.Add("发送节目成功！");
                                }
                            }
                            if (requestData.Sign == 2)
                            {
                                billUrl = "/Api/AssortedBill/GetAssortedBillOfAllocated?uniqueId=" + requestData.PalletBarcode;
                                var delstate = User_DelAllProgram(item.CardNum);
                                if (delstate == false)
                                {
                                    listLogger.Items.Add("删除节目失败！");
                                    inElapsed = false;
                                    return;
                                }
                                listLogger.Items.Add("清屏成功");
                                var programIndex = User_AddProgram(item.CardNum, false, 10);
                                User_Text SingleText = new User_Text();
                                billUrl = billUrl + requestData.PalletBarcode;
                                var billUrlRequest = HttpUtil.HttpRequest<AssortedBillModel>(billUrl);
                                var LEDtest = "";
                                if (billUrlRequest == null)
                                {
                                    LEDtest = $"唯一码：" + requestData.PalletBarcode + "，不存在已审核的拼盘单据，请核查！";
                                }
                                else
                                {
                                    LEDtest = "托盘条码：" + billUrlRequest.UniqueId + "  配盘名称：" + billUrlRequest.MatchPalletName +
                                             "\n牌号：" + billUrlRequest.BrandNames + " 托盘类型：" + billUrlRequest.PalletTypeName;
                                }

                                SingleText.BkColor = 0;
                                SingleText.chContent = LEDtest;
                                SingleText.PartInfo.iFrameMode = 0;
                                SingleText.PartInfo.iHeight = 96;
                                SingleText.PartInfo.iWidth = 192;
                                SingleText.PartInfo.iX = 0;
                                SingleText.PartInfo.iY = 0;
                                SingleText.FontInfo.bFontBold = false;
                                SingleText.FontInfo.bFontItaic = false;
                                SingleText.FontInfo.bFontUnderline = false;
                                SingleText.FontInfo.colorFont = 0xFF;
                                SingleText.FontInfo.iFontSize = 9;
                                SingleText.PartInfo.FrameColor = 0xFF;
                                SingleText.FontInfo.strFontName = "宋体";
                                SingleText.MoveSet.bClear = false;
                                SingleText.MoveSet.iActionSpeed = 6;
                                SingleText.MoveSet.iActionType = 1;
                                SingleText.MoveSet.iHoldTime = 20;
                                SingleText.MoveSet.iClearActionType = 0;
                                SingleText.MoveSet.iClearSpeed = 0;
                                SingleText.MoveSet.iFrameTime = 20;

                                var addint = User_AddText(item.CardNum, ref SingleText, programIndex);

                                if (-1 == addint)
                                {
                                    listLogger.Items.Add("添加文本失败！");
                                }

                                var sendstate = User_SendToScreen(item.CardNum);
                                if (sendstate == false)
                                {
                                    listLogger.Items.Add("发送节目失败！");
                                }
                                else
                                {
                                    listLogger.Items.Add("发送节目成功！");
                                }
                            }
                            item.OldPalletcode = requestData.PalletBarcode;
                            item.Sign = requestData.Sign;
                        }
                        

                    }
                }
                catch (Exception ex)
                {
                    listLogger.Items.Add(ex.Message);
                }

                inElapsed = false;
            }
        }
        List<LEDData> storeInRequest = new List<LEDData>();
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.serverCode = "WCSServer";
            this.groupCode = "Led";
            storeInRequest = new List<LEDData>();
            if (checkBox1.Checked)
            {
                storeInRequest.Add(new LEDData { CardNum = 1,OldPalletcode="0", RequestCode = "/Api/DataMonitoring/ReadValue?serverCode=" + this.serverCode + "&groupCode=" + this.groupCode + "&tagCode=Led01" });
            }
            if (checkBox2.Checked)
            {
                storeInRequest.Add(new LEDData { CardNum = 2, OldPalletcode = "0", RequestCode = "/Api/DataMonitoring/ReadValue?serverCode=" + this.serverCode + "&groupCode=" + this.groupCode + "&tagCode=Led02" });
            }
            if (checkBox3.Checked)
            {
                storeInRequest.Add(new LEDData { CardNum = 3, OldPalletcode = "0", RequestCode = "/Api/DataMonitoring/ReadValue?serverCode=" + this.serverCode + "&groupCode=" + this.groupCode + "&tagCode=Led03" });
            }
            triggerTimer.Interval = Convert.ToInt32(txtRefreshInterval.Text);
            triggerTimer.Start();
            txtRefreshInterval.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            triggerTimer.Stop();
            txtRefreshInterval.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
        }

        private class RequestData
        {
            public int WorkPositionNo { get; set; }
            public string PalletBarcode { get; set; }
            public int Sign { get; set; }
        }

        private class LEDData
        {
            public int CardNum { get; set; }
            public string RequestCode { get; set; }
            public string OldPalletcode { get; set; }
            public int Sign { get; set; }
        }

        public class AssortedBillModel
        {
            public string AssortedBillNo { get; set; }
            public string Maker { get; set; }
            public DateTime MakeTime { get; set; }
            public string Auditor { get; set; }
            public DateTime? AuditTime { get; set; }
            public string UniqueId { get; set; }
            public string MatchPalletCode { get; set; }
            public string MatchPalletName { get; set; }
            public string MatchPalletPlanNo { get; set; }
            public int DetailCount { get; set; }
            public int ProductCount { get; set; }
            public string Barcodes { get; set; }
            //public AssortedBillStatus AssortedBillStatus { get; set; }
            public string SyncBillNo { get; set; }
            public string Remark { get; set; }
            public string BrandCodes { get; set; }
            public string BrandNames { get; set; }
            public string PalletTypeCode { get; set; }
            public string PalletTypeName { get; set; }
            public DateTime CreateTime { get; set; }
            public DateTime UpdateTime { get; set; }
            public byte[] RowVersion { get; set; }

            public string AssortedBillStatusName { get; set; }

            public IList<AssortedBillDetailModel> AssortedBillDetails { get; set; }
        }
        public class AssortedBillDetailModel
        {
            public Guid Id { get; set; }
            public string AssortedBillNo { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public string ProductYear { get; set; }
            public string Barcode { get; set; }
            public string ProductUnitCode { get; set; }
            public string ProductUnitName { get; set; }
            public int TransferRate { get; set; }
            public decimal Quantity { get; set; }
            public decimal? DefaultWeight { get; set; }
            public decimal? ActualWeight { get; set; }
            public DateTime CreateTime { get; set; }
            public DateTime UpdateTime { get; set; }
            public byte[] RowVersion { get; set; }
        }


        private RequestData getRequestData(int[] data)
        {
            var requestData = new RequestData();

            requestData.WorkPositionNo = data[0];
            requestData.PalletBarcode = data[1].ToString().PadLeft(8, '0');
            requestData.Sign = data[2];
            return requestData;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            User_OpenScreen(1);
            User_OpenScreen(2);
            User_OpenScreen(3);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            User_CloseScreen(1);
            User_CloseScreen(2);
            User_CloseScreen(3);

        }
    }
}
