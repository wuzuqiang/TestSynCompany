﻿using System;
using System.Windows.Forms;
using System.Management;
using Splash.IO.PORTS;
using System.Text;

namespace Splash
{
    public partial class Form1 : Form
    {
        USB ezUSB = new USB();
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ezUSB.AddUSBEventWatcher(USBEventHandler, USBEventHandler, new TimeSpan(0, 0, 3));
            //Fun1();

        }
        public void Fun1()
        {
            StringBuilder sb = new StringBuilder();
            // Get the WMI class
            ManagementClass processClass =
                new ManagementClass("Win32_Process");
            processClass.Options.UseAmendedQualifiers = true;

            // Get the properties in the class
            PropertyDataCollection properties =
                processClass.Properties;

            // display the properties
            sb.AppendLine("Win32_Process Property Names: ");
            foreach (PropertyData property in properties)
            {
                sb.AppendLine(property.Name);

                foreach (QualifierData q in property.Qualifiers)
                {
                    if (q.Name.Equals("Description"))
                    {
                        sb.AppendLine(
                            processClass.GetPropertyQualifierValue(
                            property.Name, q.Name).ToString());
                    }

                }
                sb.AppendLine();

            }
            textBox1.AppendText(sb.ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ezUSB.RemoveUSBEventWatcher();
        }

        private void USBEventHandler(Object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
            {
                this.SetText("USB插入时间：" + DateTime.Now + "\r\n");
            }
            else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent") 
            {
                this.SetText("USB拔出时间：" + DateTime.Now + "\r\n");
            }

            foreach (USBControllerDevice Device in USB.WhoUSBControllerDevice(e))
            {
                this.SetText("\tAntecedent：" + Device.Antecedent + "\r\n");
                this.SetText("\tDependent：" + Device.Dependent + "\r\n");
            }
        }

        // 对 Windows 窗体控件进行线程安全调用
        private void SetText(String text)
        {
            if (this.textBox1.InvokeRequired)
            {
                this.textBox1.BeginInvoke(new Action<String>((msg) =>  
                {
                    this.textBox1.AppendText(msg);  
                }), text);  
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }
    }
}
