using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Fusion.LYYC.PDA.Scanner.Model;
using Fusion.LYYC.PDA.Scanner.Tools;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.Factories;
using Fusion.LYYC.PDA.Scanner.Proxy;
using Fusion.LYYC.PDA.Scanner.Service;
using Fusion.LYYC.PDA.Scanner;

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmInventoryPalletDetail : Form
    {
        private FrmMain FrmMain;
        public List<InventoryBillDetailModel> listInventoryBillDetail;
        public FrmInventoryPalletDetail()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain.Show();
            this.Hide();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //foreach(Inventory)
        }

        private void FrmInventoryPalletDetail_Load(object sender, EventArgs e)
        {
        }
    }
}