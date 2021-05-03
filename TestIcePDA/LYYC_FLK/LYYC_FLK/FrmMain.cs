using System;
using System.Windows.Forms;
using Fusion.LYYC.PDA.Scanner.UI;
using Fusion.LYYC.PDA.Scanner.UI.Assorted;
namespace Fusion.LYYC.PDA.Scanner
{
    public partial class FrmMain : Form
    {
        private FrmAssorted FrmAssorted;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAssorted_Click(object sender, EventArgs e)
        {
            FrmAssorted = new FrmAssorted(this);
            FrmAssorted.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {   //货物盘点
            (new FrmScanPalletBarcode()).Show();
        }
    }
}