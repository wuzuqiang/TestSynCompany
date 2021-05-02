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

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmProductFacture : Form
    {
        public FrmProductFacture()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            Cursor.Current = Cursors.Default;
        }

        private void FrmProductFacture_Load(object sender, EventArgs e)
        {
            updateListView();
        }

        private void updateListView()
        {
            List<AssortedProductModelModel> assortedProductModelList = Glob.GetAssortedProductModelList();
            lvwProductFacture.Items.Clear();
            assortedProductModelList.ForEach(it => {
                var productCode = it.ProductCode;
                var productName = it.ProductName;
                var facturerCode = it.FacturerCode;
                var facturerName = it.FacturerName;
                ListViewItem lvi = new ListViewItem(new string[]{productName, facturerName, productCode, facturerCode});
                lvwProductFacture.Items.Add(lvi);
            });
        }

        private void lvwProductFacture_ItemActivate(object sender, EventArgs e)
        {
            if (this.lvwProductFacture.Activation == ItemActivation.Standard)
            {
                FrmFactureSelect dlg = new FrmFactureSelect();
                try
                {
                    dlg.SelectAssortedModel += new FrmFactureSelect.SelectEventHanlderAssortedModel(selectProductFacturer);
                    dlg.strProductCode = lvwProductFacture.FocusedItem.SubItems[2].Text;
                    dlg.strProductName = lvwProductFacture.FocusedItem.SubItems[0].Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误，错误："+ ex.Message + "\n请重试！");
                    return;
                }
                //MessageBox.Show("");
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    dlg.SelectAssortedModel -= new FrmFactureSelect.SelectEventHanlderAssortedModel(selectProductFacturer);
                    updateListView();
                }
            }
        }

        private void selectProductFacturer(string productCode, string productName, string facturerCode, string factruerName)
        {
            AssortedProductModelModel assortProductModel = new AssortedProductModelModel();
            assortProductModel.ProductCode = productCode;
            assortProductModel.ProductName = productName;
            assortProductModel.FacturerCode = facturerCode;
            assortProductModel.FacturerName = factruerName;
            Glob.AddOrUpdateAssortedProductModel(assortProductModel);

            if (Glob.isOnePalletOneFacturer)
            {
                var tempProductModelList = Glob.GetAssortedProductModelList();
                tempProductModelList.ForEach(each =>
                {
                    AssortedProductModelModel tempModel = new AssortedProductModelModel();
                    tempModel.ProductCode = each.ProductCode;
                    tempModel.ProductName = each.ProductName;
                    tempModel.FacturerCode = facturerCode;
                    tempModel.FacturerName = factruerName;
                    Glob.AddOrUpdateAssortedProductModel(tempModel);
                });
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var isNotEveryProductHasFacturerName = Glob.GetAssortedProductModelList().Any(any => string.IsNullOrEmpty(any.FacturerName));
            if (isNotEveryProductHasFacturerName)
            {
                MessageBox.Show("抱歉！请为每个产品选择厂商");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

    }
}