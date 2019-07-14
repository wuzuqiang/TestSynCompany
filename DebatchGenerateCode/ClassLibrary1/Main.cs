using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FrmOperFile()).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file1 = AppDomain.CurrentDomain.BaseDirectory + @"Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\Brand1s\Brand1Model.cs";
            string content = @"hanzi汉子123\##@#@())@))@)(@#328$(3209$(32";
            (new FileUtils()).writeToFile(file1, content);
        }
    }
}
