using System;
using System.Windows.Forms;
using System.Linq;
using Fusion.LYYC.PDA.Scanner.Tools;
using System.Collections.Generic;
using Fusion.LYYC.PDA.Scanner.Model;
using System.Threading;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.Factories;
using Fusion.LYYC.PDA.Scanner.Service;
using Fusion.LYYC.PDA.Scanner;
using Fusion.LYYC.PDA.Scanner.UI.Assorted;

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmFactureSelect : Form
    {
        public delegate void SelectEventHanlderAssortedModel(string productCode, string productName, string facturerCode, string factruerName);
        public event SelectEventHanlderAssortedModel SelectAssortedModel;
        private AssortedService AssortedService = new AssortedService();


        public string strProductCode;
        public string strProductName;
        public FrmFactureSelect()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            Cursor.Current = Cursors.Default;
        }
        private void FrmAssortedDetail_Load(object sender, EventArgs e)
        {
            lvwProductFacture.Items.Clear();
            Glob.ListFacturerModel.ForEach(each => {
                lvwProductFacture.Items.Add(new ListViewItem(new string[]{each.FacturerName, each.FacturerCode}));
            });
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void istviewProductFacture_ItemActivate(object sender, EventArgs e)
        {
            if (this.lvwProductFacture.Activation == ItemActivation.Standard)
            {
                var focusedSubItems = this.lvwProductFacture.FocusedItem.SubItems;
                SelectAssortedModel(strProductCode, strProductName, focusedSubItems[1].Text, focusedSubItems[0].Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {

        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    }
}