using Fusion.Project.SC.LZ.LED;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace EQ2008
{
    public class EQ2008Collection
    {
        private Dictionary<int, string> Leds = new Dictionary<int, string>();
        private Dictionary<int, int> Programs = new Dictionary<int, int>();

        ~EQ2008Collection()
        {
            foreach (int CardNum in Leds.Keys)
            {
                if (Leds[CardNum] == "OPEN")
                    EQ2008.User_CloseScreen(CardNum);
            }
            Leds.Clear();
            Programs.Clear();
        }


        private bool AddLed(int cardNum)
        {
            int key = cardNum;

            if (!Leds.ContainsKey(key))
            {
                if (EQ2008.User_OpenScreen(cardNum))
                    Leds.Add(key, "OPEN");
            }
            else
            {
                if (Leds[key] != "OPEN")
                {
                    if (EQ2008.User_OpenScreen(cardNum))
                        Leds[key] = "OPEN";
                }
            }

            return Leds.ContainsKey(key) && Leds[key] == "OPEN";
        }

        private bool RemoveLed(int cardNum)
        {
            int key = cardNum;

            if (Leds.ContainsKey(key))
            {
                if (Leds[key] == "OPEN")
                {
                    if (EQ2008.User_CloseScreen(cardNum))
                        Leds[key] = "CLOSE";
                }
                return Leds[key] == "CLOSE";
            }
            else
            {
                return true;
            }
        }

        private void AddProgram(int cardNum)
        {
            if (AddLed(cardNum))
            {
                if (!Programs.ContainsKey(cardNum))
                {
                    int programIndex = EQ2008.User_AddProgram(cardNum, false, 10);
                    Programs.Add(cardNum, programIndex);
                }
            }
        }

        private void RemoveProgram(int cardNum)
        {
            if (Programs.ContainsKey(cardNum))
            {
                Programs.Remove(cardNum);
                EQ2008.User_DelAllProgram(cardNum);
            }
        }


        private void AddTextToProgram(int cardNum, LEDData data)
        {
            if (AddLed(cardNum))
            {
                AddProgram(cardNum);

                User_Text text = data.Text;

                text.PartInfo = data.PartInfo;
                text.chContent = data.Content;
                text.FontInfo.colorFont = data.ColorFont;
                text.FontInfo.strFontName = data.FontName;
                if (!data.IsMove)
                {
                    text.MoveSet.iHoldTime = -1;
                }

                if (Programs.ContainsKey(cardNum))
                {
                    int m_iProgramIndex = (int)Programs[cardNum];
                    EQ2008.User_AddText(cardNum, ref text, m_iProgramIndex);
                }
            }
        }

        private void AddSingleTextToProgram(int cardNum, LEDData data)
        {
            if (AddLed(cardNum))
            {
                AddProgram(cardNum);

                User_SingleText singleText = data.SingleText;

                singleText.PartInfo = data.PartInfo;
                singleText.chContent = data.Content;
                singleText.FontInfo.colorFont = data.ColorFont;
                singleText.FontInfo.strFontName = data.FontName;
                if (!data.IsMove)
                {
                    singleText.MoveSet.iHoldTime = -1;
                }

                if (Programs.ContainsKey(cardNum))
                {
                    int m_iProgramIndex = (int)Programs[cardNum];
                    EQ2008.User_AddSingleText(cardNum, ref  singleText, m_iProgramIndex);
                }
            }
        }

        private void AddImageToProgram(int cardNum, LEDData data, Bitmap bitmap)
        {
            if (AddLed(cardNum))
            {
                AddProgram(cardNum);
                int m_iProgramIndex = -1;
                int BmpZoneIndex = -1;

                User_Bmp bmp = data.Image;

                bmp.PartInfo = data.PartInfo;

                User_MoveSet moveset = data.MoveSet;
                if (!data.IsMove)
                {
                    moveset.iHoldTime = -1;
                }
            
                if (Programs.ContainsKey(cardNum))
                {
                    m_iProgramIndex = (int)Programs[cardNum];
                    BmpZoneIndex = EQ2008.User_AddBmpZone(cardNum, ref bmp, m_iProgramIndex);

                    HandleRef hr = new HandleRef(bitmap, bitmap.GetHicon());
                    IntPtr hBitmap = bitmap.GetHbitmap();
                    EQ2008.User_AddBmp(cardNum, BmpZoneIndex, hBitmap, ref  moveset, m_iProgramIndex);
                }
            }
        }

        public bool AddToProgram(LEDData data)
        {
            switch (data.MethodType)
            {
                case MethodType.AddText:
                    AddTextToProgram(data.CardNum, data);
                    break;
                case MethodType.AddSingleText:
                    AddSingleTextToProgram(data.CardNum, data);
                    break;
                case MethodType.AddImage:
                    AddImageToProgram(data.CardNum, data, data.Bitmap);
                    break;
                default:
                    throw new Exception("EQ2008Collection.AddToProgram失败，未实现的节目添加方法！");
            }

            return true;
        }


        public void ClearScreen()
        {
            foreach (int CardNum in Leds.Keys)
            {
                RemoveProgram(CardNum);
            }
        }

        public bool SendToScreen()
        {
            foreach (int CardNum in Leds.Keys)
            {
                if (Programs.ContainsKey(CardNum) && Leds.ContainsKey(CardNum) && Leds[CardNum] == "OPEN")
                {
                    if (!EQ2008.User_SendToScreen(CardNum))
                    {
                        throw new Exception("EQ2008Collection.SendToScreen失败，发送节目到LED出现错误！");
                    }
                }
            }
            return true;
        }
    }
}
