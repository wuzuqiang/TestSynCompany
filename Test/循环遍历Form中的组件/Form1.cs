using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 循环遍历Form中的组件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var aa = txtClassName
            //var aa1 = label1.f
            foreach (Control ctrl in this.Controls)
            {
            }
            getCtrlControl(this);
            richTextBox1.Text += sb.ToString();
        }
        StringBuilder sb = new StringBuilder();
        public void getCtrlControl(Control ctrl)
        {
            if (ctrl is TableLayoutPanel || ctrl is System.Windows.Forms.Form)
            {
                sb.Append(string.Format("XXXX====x:{0},y:{1},控件名称:{2}，width:{3},height:{4},font-size:{5},文本内容{6}\n"
                            , ctrl.Location.X, ctrl.Location.Y, ctrl.Name, ctrl.Width, ctrl.Height, ctrl.Font.Size, ctrl.Text));
                foreach (Control ctrlOne in ctrl.Controls)
                {
                    getCtrlControl(ctrlOne);
                }
            }
            else
            {
                sb.Append(string.Format("x:{0},y:{1},控件名称:{2}，width:{3},height:{4},font-size:{5},文本内容{6},字体颜色{7}\n"
                            , ctrl.Location.X, ctrl.Location.Y, ctrl.Name, ctrl.Width, ctrl.Height, ctrl.Font.Size, ctrl.Text, ctrl.ForeColor.ToArgb()));
            }
        }
    }
}
