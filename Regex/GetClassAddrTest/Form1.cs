using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetClassAddrTest
{
    public partial class Form1 : Form
    {
        [DllImport("mydll.dll")]
        public static extern int add(int a, int b);
        public Form1()
        {
            InitializeComponent();
            button1.Text = add(1, 2).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (new RAM()).Test();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    public class RAM
    {

        public void Test()
        {
            try
            {
                int num_Size = 100000000;
                // 获取整型的地址
                var addr = getMemory(num_Size);
                Console.WriteLine("num_Size addr = " + addr);

                Person pp = new Person();
                pp.Id = 99;
                pp.Name = "test";
                pp.Sex = "nan";
                // 获取对象的地址
                var addr2 = getMemory(pp);
                Console.WriteLine("num_Size addr = " + addr2);

            }
            catch (Exception ex)
            {

            }
        }


        public string getMemory(object o) // 获取引用类型的内存地址方法    
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.WeakTrackResurrection);

            IntPtr addr = GCHandle.ToIntPtr(h);

            return "0x" + addr.ToString("X");
        }

    }


    [StructLayout(LayoutKind.Sequential)]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
