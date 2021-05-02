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
using System.Collections.Generic;

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmGetInventoryBarCode : Form
    {
        public InventoryService InventoryService = new InventoryService();
        public List<InventoryBillDetailModel> listInventoryBillDetail;
        public FrmGetInventoryBarCode()
        {
            InitializeComponent();

            listInventoryBillDetail = InventoryService.GetInventoryBillDetail("");
            if (listInventoryBillDetail == null)
            {
                MessageBox.Show("抱歉！当前无盘点信息！");
            }
            foreach (var model in listInventoryBillDetail)
            {
                cbxBarcode.Items.Add(model.RecordBarcodes);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FrmInventoryPalletDetail dlg = new FrmInventoryPalletDetail();
            dlg.listInventoryBillDetail = listInventoryBillDetail;
            dlg.Show();
        }

    }
}