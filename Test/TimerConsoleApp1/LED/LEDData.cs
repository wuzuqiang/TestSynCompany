using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using EQ2008;

namespace Fusion.Project.SC.LZ.LED
{
    public class LEDData
    {
        public LEDData()
        {
            Text.BkColor = 0;

            Text.FontInfo.bFontBold = false;
            Text.FontInfo.bFontItaic = false;
            Text.FontInfo.bFontUnderline = false;
            Text.FontInfo.iFontSize = 12;
            Text.FontInfo.iAlignStyle = 0;
            Text.FontInfo.iVAlignerStyle = 0;
            Text.FontInfo.iRowSpace = 0;

            Text.MoveSet.iActionType = 20;
            Text.MoveSet.iActionSpeed = 0;
            Text.MoveSet.iHoldTime = 50;

            Text.MoveSet.bClear = false;
            Text.MoveSet.iClearActionType = 0;
            Text.MoveSet.iClearSpeed = 0;
            Text.MoveSet.iFrameTime = 30;

            SingleText.BkColor = 0;

            SingleText.FontInfo.bFontBold = false;
            SingleText.FontInfo.bFontItaic = false;
            SingleText.FontInfo.bFontUnderline = false;
            SingleText.FontInfo.iFontSize = 12;
            SingleText.FontInfo.iAlignStyle = 0;
            SingleText.FontInfo.iVAlignerStyle = 0;
            SingleText.FontInfo.iRowSpace = 0;

            SingleText.MoveSet.iActionType = 20;
            SingleText.MoveSet.iActionSpeed = 0;
            SingleText.MoveSet.iHoldTime = 50;

            SingleText.MoveSet.bClear = false;
            SingleText.MoveSet.iClearActionType = 0;
            SingleText.MoveSet.iClearSpeed = 0;
            SingleText.MoveSet.iFrameTime = 30;

            PartInfo.FrameColor = 0;
            PartInfo.iFrameMode = 0;

            MoveSet.iActionType = 20;
            MoveSet.iActionSpeed = 0;
            MoveSet.iHoldTime = 50;

            MoveSet.bClear = false;
            MoveSet.iClearActionType = 0;
            MoveSet.iClearSpeed = 0;
            MoveSet.iFrameTime = 30;
        }

        public int CardNum { get; set; }

        public MethodType MethodType { get; set; }

        public User_Text Text;

        public User_SingleText SingleText;

        public User_Bmp Image;

        public User_PartInfo PartInfo;		

        public User_MoveSet MoveSet;

        public int X
        {
            get { return PartInfo.iX; }
            set { PartInfo.iX = value; }
        }

        public int Y
        {
            get { return PartInfo.iY; }
            set { PartInfo.iY = value; }
        }

        public int Height
        {
            get { return PartInfo.iHeight; }
            set { PartInfo.iHeight = value; }
        }

        public int Width
        {
            get { return PartInfo.iWidth; }
            set { PartInfo.iWidth = value; }
        }

        public string Content { get; set; }

        public string FontName { get; set; }

        public int ColorFont { get; set; }

        public Bitmap Bitmap { get; set; }

        public bool IsMove { get; set; }        
    }
}
