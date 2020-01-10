//using Common.Logging;
using LED.EQ2013;

namespace Fusion.Project.SC.LZ.LED
{
    public class LedHelper
    {
        private string ip;
        private int ledWidth;
        private int ledHeight;

        LedDll.COMMUNICATIONINFO communicationInfo;
        LedDll.AREARECT areaRect;
        LedDll.PLAYPROP playProp;
        LedDll.FONTPROP fontProp;

        //private ILog Logger { get { return LogManager.GetLogger<LedHelper>(); } }

        public LedHelper(string ip, int ledWidth, int ledHeight)
        {
            if (string.IsNullOrEmpty(ip))
            {
                throw new System.Exception("IP不能为空！");
            }

            this.ip = ip;
            this.ledWidth = ledWidth;
            this.ledHeight = ledHeight;

            this.Init();
        }

        private void Init()
        {
            communicationInfo = new LedDll.COMMUNICATIONINFO();

            communicationInfo.SendType = 0;
            communicationInfo.IpStr = this.ip;
            communicationInfo.LedNumber = 1;

            string errorInfo;
            var result = LedDll.LV_SetBasicInfo(ref communicationInfo, 1, ledWidth, ledHeight);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                ////Logger.Error(errorInfo);;
            }

            fontProp = new LedDll.FONTPROP();

            fontProp.FontName = "宋体";
            fontProp.FontSize = 12;
            fontProp.FontColor = LedDll.COLOR_RED;
            fontProp.FontBold = 0;

            playProp = new LedDll.PLAYPROP();

            playProp.InStyle = 0;
            playProp.DelayTime = 3;
            playProp.Speed = 4;

            areaRect = new LedDll.AREARECT();

            areaRect.left = 0;
            areaRect.top = 0;
            areaRect.width = this.ledWidth;
            areaRect.height = this.ledHeight;
        }

        public void SendInfo(string info)
        {
            string errorInfo;
            int hProgram = LedDll.LV_CreateProgram(this.ledWidth, this.ledHeight, 1);

            var result = LedDll.LV_AddProgram(hProgram, 1, 0, 1);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                ////Logger.Error(errorInfo);;
            }

            result = LedDll.LV_AddImageTextArea(hProgram, 1, 1, ref areaRect, 0);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                ////Logger.Error(errorInfo);;
            }

            result = LedDll.LV_AddMultiLineTextToImageTextArea(hProgram, 1, 1, LedDll.ADDTYPE_STRING, info, ref fontProp, ref playProp, 0, 0);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                ////Logger.Error(errorInfo);;
            }

            result = LedDll.LV_Send(ref communicationInfo, hProgram);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                ////Logger.Error(errorInfo);;
            }

            LedDll.LV_DeleteProgram(hProgram);
        }
    }
}