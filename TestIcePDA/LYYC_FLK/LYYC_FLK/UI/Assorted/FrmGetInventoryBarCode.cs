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
    public partial class FrmGetInventoryBarCode : Form
    {
        private FrmAssorted FrmAssorted;
        private AssortedService AssortedService;

        public FrmGetInventoryBarCode()
        {
            InitializeComponent();
            this.txtScanCode.Text = "";
        }
        public FrmGetInventoryBarCode(FrmAssorted frmAssorted, AssortedService assortedService, string mathchPalletName)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();

            FrmAssorted = frmAssorted;
            AssortedService = assortedService;
            labInfo.Text = "�������ƣ�" + mathchPalletName;
            Cursor.Current = Cursors.Default;
            txtScanCode.Focus();
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
                MessageBox.Show(e.Message, "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
            string palletBarcode = this.txtScanCode.Text.Trim().ToString();
            StaticModel.ScanBarCode = palletBarcode;
            txtScanCode.Focus();

            if (string.IsNullOrEmpty(palletBarcode))
            {
                MessageBox.Show("��ɨ�������룡", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            if (txtScanCode.Text.Length != 8)
            {
                MessageBox.Show("8λ�������볤�ȣ�����ɨ��");
                txtScanCode.Text = "";
                return;
            }

            var locationBarcode = AssortedService.GetPalletByBarcode(palletBarcode);

            if (locationBarcode != null)
            {
                MessageBox.Show("��������  " + palletBarcode + "����⣬��λ����:" + locationBarcode.LocationName);
                this.txtScanCode.Text = "";
                return;
            }

            var assortedBill = AssortedService.GetAssortedBillByBarcode(palletBarcode);

            if (assortedBill != null)
            {
                MessageBox.Show("��������  " + palletBarcode + "��ƴ�̣�ƴ�̵���:" + assortedBill.AssortedBillNo);
                this.txtScanCode.Text = "";
                return;
            }
            this.txtScanCode.Text = "";
            if (Glob.CurrentMatchPalletCode != StaticModel.MathchPalletCode)
            {
                Glob.ClearAssortedProductModelList();
                AssortedService.GetMathPalletPlanDetailByIce(StaticModel.MathchPalletCode).ForEach(each =>
                {
                    Glob.AddOrUpdateAssortedProductModel(new AssortedProductModelModel()
                    {
                        ProductCode = each.ProductCode,
                        ProductName = each.ProductName,
                        Quantity = each.WorkshopQuantity * each.WorkshopTransferRate, //������������ת���ʣ���Ϊ�����ԭ��ϵͳ��Ҳ��ֹС����
                        UnitCode = each.WorkshopUnitCode,
                        UnitName = each.WorkshopUnitName,
                        TransferRate = 1
                    });
                });
                Glob.CurrentMatchPalletCode = StaticModel.MathchPalletCode;
            }

            var frmAssortedDetail = new FrmAssortedDetail(this, FrmAssorted, AssortedService);
            frmAssortedDetail.Show();
            this.Hide();
            this.txtScanCode.Text = "";

            //var dlg = new FrmProductFacture();
            //if (DialogResult.OK == dlg.ShowDialog())
            //{
            //    var frmAssortedDetail = new FrmAssortedDetail(this, FrmAssorted, AssortedService);
            //    frmAssortedDetail.Show();
            //}
            //dlg.Dispose();
        }

        private void labInfo_Click(object sender, EventArgs e)
        {

        }
    }
}