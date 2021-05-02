using System;
using System.Windows.Forms;
using Fusion.LYYC.PDA.Scanner.Tools;
using Fusion.LYYC.PDA.Scanner.Interface;
using Fusion.LYYC.PDA.Scanner.Factories;
using Fusion.LYYC.PDA.Scanner.Service;
using Fusion.LYYC.PDA.Scanner.Proxy;
using Fusion.LYYC.PDA.Scanner.Model;
using Fusion.LYYC.PDA.Scanner.UI.Assorted;
using Fusion.LYYC.PDA.Scanner;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmScanPalletBarcode : Form
    {
        private FrmAssorted FrmAssorted;
        private AssortedService AssortedService;

        public FrmScanPalletBarcode()
        {
            InitializeComponent();
            this.txtScanCode.Text = "";
        }

        private void FrmScanBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (e.KeyValue == 245 || e.KeyValue == 241 || e.KeyValue == 242)
                {
                    MessageBox.Show("e.KeyValue:" + e.KeyValue);
                    ScanCode();
                }
                else if (e.KeyValue == 13)
                {
                    btnNext_Click(sender, e);
                }
            }
        }

        private void ScanCode()
        {
            try
            {
                string scanCode = "";
                var dlg = new FrmSimuScanCode();
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    scanCode = dlg.barCode;
                    dlg.Dispose();
                }
                if (string.IsNullOrEmpty(scanCode))
                    return;
                this.txtScanCode.Text = scanCode;
                StaticModel.ScanBarCode = scanCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtScanCode.Text = "";
            StaticModel.MathchPalletCode = "";
            StaticModel.MathchPalletName = "";
            StaticModel.MathchPalletPlanNo = "";
            FrmAssorted.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //通过条码获取配盘明细，如果没获取到则进入 托盘条码获取界面
        }
    }
}