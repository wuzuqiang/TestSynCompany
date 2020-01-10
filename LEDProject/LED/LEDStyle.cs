using LED.EQ2013;

/*
* 2018-04-25 Create by 刘雅婷
*/

namespace Fusion.Project.SC.LZ.LED
{
    public class LEDStyle
    {
        public int areaNo;
        public int fontColor;
        public int isVCenter;
        public string info;
        public int ledLeft;
        public int ledTop;
        public int ledWidth;
        public int ledHeight;

        public LEDStyle(int fontColor = LedDll.COLOR_RED, int isVCenter = 0, string info = "数据读取出错",
            int ledLeft = 0, int ledTop = 0, int ledWidth = 192, int ledHeight = 128)
        {
            this.fontColor = fontColor;
            this.isVCenter = isVCenter;
            this.info = info;
            this.ledLeft = ledLeft;
            this.ledTop = ledTop;
            this.ledWidth = ledWidth;
            this.ledHeight = ledHeight;
        }
    }
}
