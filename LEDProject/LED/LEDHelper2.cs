using System.Collections.Generic;
using Common.Logging;
using LED.EQ2013;

/*
* 2018-04-25 Create by 刘雅婷
*/

namespace Fusion.Project.SC.LZ.LED
{
    public class LEDHelper2
    {
        private string ip;
        private int ledWidth;
        private int ledHeight;

        LedDll.COMMUNICATIONINFO communicationInfo;
        LedDll.AREARECT areaRect;
        LedDll.PLAYPROP playProp;
        LedDll.FONTPROP fontProp;

        private ILog Logger { get { return LogManager.GetLogger<LedHelper>(); } }


        public LEDHelper2(string ip, int ledWidth, int ledHeight)
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
            var result = LedDll.LV_SetBasicInfo(ref communicationInfo, 2, ledWidth, ledHeight);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
            }

            playProp = new LedDll.PLAYPROP();

            playProp.InStyle = 0;
            playProp.DelayTime = 3;
            playProp.Speed = 4;
        }

        public void SendInfo(IList<LEDStyle> ledStyles)
        {
            string errorInfo;
            int hProgram = LedDll.LV_CreateProgram(this.ledWidth, this.ledHeight, 2);

            var result = LedDll.LV_AddProgram(hProgram, 1, 0, 1);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                Logger.Error(errorInfo);
            }

            areaRect = new LedDll.AREARECT();
            fontProp = new LedDll.FONTPROP();
            int areaNo = 1;
            foreach (var ledStyle in ledStyles)
            {
                areaRect.left = ledStyle.ledLeft;
                areaRect.top = ledStyle.ledTop;
                areaRect.width = ledStyle.ledWidth;
                areaRect.height = ledStyle.ledHeight;

                fontProp.FontName = "宋体";
                fontProp.FontSize = 12;
                fontProp.FontColor = ledStyle.fontColor;
                fontProp.FontBold = 0;

                result = LedDll.LV_AddImageTextArea(hProgram, 1, areaNo, ref areaRect, 0);
                if (result != 0)
                {
                    errorInfo = LedDll.LS_GetError(result);
                    Logger.Error(errorInfo);
                }

                result = LedDll.LV_AddMultiLineTextToImageTextArea(hProgram, 1, areaNo++, LedDll.ADDTYPE_STRING, ledStyle.info, ref fontProp, ref playProp, 0, ledStyle.isVCenter);
                if (result != 0)
                {
                    errorInfo = LedDll.LS_GetError(result);
                    Logger.Error(errorInfo);
                }
            }

            result = LedDll.LV_Send(ref communicationInfo, hProgram);

            if (result != 0)
            {
                errorInfo = LedDll.LS_GetError(result);
                Logger.Error(errorInfo);
            }

            LedDll.LV_DeleteProgram(hProgram);
        }
    }
}
