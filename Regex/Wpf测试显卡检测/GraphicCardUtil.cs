using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;

namespace Wpf测试显卡检测
{
    public class GraphicCardUtil
    {

        public void InnerCheck()
        {
            string CheckStatusText;
            ManagementObjectCollection objs = new ManagementObjectSearcher("select * from Win32_VideoController").Get();
            if (objs.Count <= 0)
            {//有待证实是否会不存在这个设备
                //2018年8月14日14:52:57，当在设备管理器中看不到显卡时，是会进入这里的。
                CheckStatusText = Application.Current.FindResource("Lang.Menu.Driver.Fail") as string;
                return; // ItemCheckResult.ERROR;
            }
            foreach (ManagementObject obj in objs)
            {
                if (obj["DriverVersion"] != null)
                {
                    CheckStatusText = "显卡驱动版本: " + obj["DriverVersion"].ToString();
                    return; // ItemCheckResult.Well;
                }
            }
            CheckStatusText = Application.Current.FindResource("Lang.Menu.Driver.Fail") as string;
            //return ItemCheckResult.Error;
        }
    }
}
