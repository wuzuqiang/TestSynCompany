using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseFileDirOperProject
{
    public partial class FrmCopyFile : Form
    {
        public FrmCopyFile()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(cbxIsNeedAddBaseDir.Checked)
            { }
        }
        private void CopyFile(string src, string des)
        { //将这些路径下的文件都复制相应目录下
            //如果是绝对路径？？？
        }
    }
}
