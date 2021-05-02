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

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmScanPalletBarcode : Form
    {
        public InventoryService InventoryService = new InventoryService();

        public FrmScanPalletBarcode()
        {
            InitializeComponent();
            this.txtScanCode.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtScanCode.Text = "";
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //ͨ�������ȡ������ϸ�����û��ȡ������� ���������ȡ����
            var listModel = InventoryService.GetInventoryBillDetail(txtScanCode.Text);
            if (listModel == null)
            {
                (new FrmGetInventoryBarCode()).Show();
            }
            else
            {
                FrmInventoryPalletDetail dlg = new FrmInventoryPalletDetail();
                dlg.listInventoryBillDetail = listModel;
                dlg.Show();
            }
        }
    }
}