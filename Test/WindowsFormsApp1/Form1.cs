using BaseClassUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HttpGet();
            //LogHelper.WriteLog("tedsfsdfssdsf");
            //Fun1();
            test();
        }

        private void test()
        {
            int a;
        }

        private void HttpGet()
        {
            HttpItem item = new HttpItem()
            {
                URL = "http://localhost",
                Method = "Get",
                Accept = "/",
                Referer = "http://localhost",
                ContentType = "application/json",
            };
            item.Header.Add("Origin", "*");
            HttpResult result = new HttpHelper().GetHtml(item);
            Console.Write(result.Html);
        }

        public void Fun1()
        {
            var result = GetAction(0, ActionType.Get);
            byte[] byteRet = BitConverter.GetBytes(256);
            int a1 = (int)((Int64)1+(Int64)2);
            Int64 o1 = (Int64)1;
        }
        private int GetAction(int forkExtension, ActionType actionType)
        {
            byte[] action = new byte[4];

            switch (forkExtension)
            {
                case 0://单左伸
                    action[1] = 0;
                    action[2] = 1;
                    break;
                case 1://单右
                    action[1] = 0;
                    action[2] = 0;
                    break;
                case 2://双左
                    action[1] = 1;
                    action[2] = 1;
                    break;
                case 3://双右
                    action[1] = 1;
                    action[2] = 0;
                    break;
            }
            action[3] = 0;
            action[2] = 0;
            action[1] = 0;
            action[0] = 255;
            //action[0] = (byte)actionType;

            return BitConverter.ToInt32(action, 0);
        }
        private enum ActionType : byte
        {
            None = 0,
            Get = 1,
            Put = 2
        }
    }
}
