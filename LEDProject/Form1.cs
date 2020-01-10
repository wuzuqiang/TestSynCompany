using Fusion.Project.SC.LZ.LED;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public virtual LedCardType LedCardType { get { return LedCardType.EQ2013; } }
        public LEDUtil LEDUtil = new LEDUtil();
        private void Set_LED()
        { 
            IList<LEDData> ledDataList = new List<LEDData>();
            for (int i = 0; i < 1; i++)
            {
                LEDData ledData = new LEDData();
                ledData.CardNum = 1;
                ledData.ColorFont = false ? EQ2008.EQ2008.GREEN : EQ2008.EQ2008.RED;
                ledData.Content = "test" + textBox1.Text.ToString();
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

                ledDataList.Add(ledData);
            }
            if (ledDataList.Count() > 0)
            {
                LEDUtil.Sending(ledDataList.ToArray());
            }}

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
