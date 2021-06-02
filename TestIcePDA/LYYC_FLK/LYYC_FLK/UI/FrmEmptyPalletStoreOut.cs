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
    public partial class FrmEmptyPalletStoreOut : Form
    {
        private FrmMain FrmMain;
        private FrmGetMatchPalletCode FrmScanBarCode;
        private AssortedService AssortedService = new AssortedService();
        private PartsOfAndroidService AdService = new PartsOfAndroidService();
        public FrmEmptyPalletStoreOut()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                AdService.StoreOutMutiPallet("EmptyPallet", Convert.ToInt32(txtPalletQuatity.Value), 2114);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}