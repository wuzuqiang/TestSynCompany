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
    public partial class FrmAssortedDetail : Form
    {
        List<MatchPalletPlanDetailModel> modelList = null;
        private delegate void SetMessageDelegate(ListView control);
        private FrmGetMatchPalletCode FrmScanBarCode;
        private AssortedService AssortedService;
        private FrmSimuScanCode frmSimuScanCode = new FrmSimuScanCode();

        private FrmAssorted FrmAssorted;

        public FrmAssortedDetail()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            Cursor.Current = Cursors.Default;
        }
        public FrmAssortedDetail(FrmGetMatchPalletCode frmScanBarCode, FrmAssorted frmAssorted, AssortedService assortedService)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();

            FrmAssorted = frmAssorted;
            modelList = new List<MatchPalletPlanDetailModel>();
            FrmScanBarCode = frmScanBarCode;
            AssortedService = assortedService;

            ShowAssortedDetailAndSyncModelList();
            Cursor.Current = Cursors.Default;
        }

        private void FrmAssortedDetail_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void FrmAssortedDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (e.KeyValue == 245 || e.KeyValue == 241 || e.KeyValue == 242)
                {
                    ScanCode(ref isRecycleScan);
                    UpdateListView(this.listviewScan);
                }
            }
        }

        private void FrmAssortedDetail_Closed(object sender, EventArgs e)
        {
            frmSimuScanCode.Dispose();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            buttonForceComplete_Click(null, null);
            if (modelList.Any(it => it.ScanCount != it.WorkshopQuantity))
            {
                MessageBox.Show("存在条码未扫完", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            var result = MessageBox.Show("确认-配盘名称【" + StaticModel.MathchPalletName + "】完成拼盘?", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                AssortedService.CreateAssortedBillByScanBarcode(StaticModel.ScanBarCode, StaticModel.MathchPalletCode, StaticModel.MathchPalletPlanNo, Glob.GetAssortedProductModelList());
                FrmScanBarCode.Show();
                this.Dispose();
                this.Close();
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            //thread = new Thread(Run);
            //thread.Start();
            Run();
            this.Show();
        }

        private void ChangeBtnStatus(bool isopen)
        {
            btnComplete.Enabled = isopen;
        }

        private bool isRecycleScan = true;
        private void Run()
        {
            try
            {

                do
                {
                    ScanCode(ref isRecycleScan);
                    UpdateListView(listviewScan);
                    //var p = this.listviewScan.BeginInvoke(new SetMessageDelegate(this.UpdateListView), this.listviewScan);
                    //this.listviewScan.EndInvoke(p);
                } while (isRecycleScan);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void ScanCode(ref bool isRecycleScan)
        {
            try
            {
                string scanCode = "";
                var dlg = frmSimuScanCode;
                dlg.ShowDialog();
                if (DialogResult.OK == dlg.DialogResult)
                {
                    scanCode = dlg.barCode;
                    isRecycleScan = true;
                }
                else if (DialogResult.Cancel == dlg.DialogResult)
                {
                    isRecycleScan = false;
                    return;
                }
                if (string.IsNullOrEmpty(scanCode))
                    return;

                new MatchPalletPlanDetailModel(scanCode).Add(ref modelList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void NewList(ListView Scan)
        {
            Scan.Items.Clear();
            modelList.ForEach(it =>
            {
                ListViewItem lvi = new ListViewItem(new string[] { it.ProductCode, it.WorkshopQuantity.ToString(), it.ScanCount.ToString(), it.ProductName });
                listviewScan.Items.Add(lvi);
            });
        }

        private void UpdateListView(ListView Scan)
        {
            Scan.Items.Clear();
            modelList.ForEach(it =>
            {
                ListViewItem lvi = new ListViewItem(new string[] { it.ProductCode, it.WorkshopQuantity.ToString(), it.ScanCount.ToString(), it.ProductName });
                listviewScan.Items.Add(lvi);
            });
        }

        private void ShowAssortedDetailAndSyncModelList()
        {
            listviewScan.Items.Clear();
            try
            {
                AssortedService.GetMathPalletPlanDetailByIce(StaticModel.MathchPalletCode).ForEach(it =>
                {
                    var mathchPalletDetail = new MatchPalletPlanDetailModel
                    {
                        ProductCode = it.ProductCode,
                        ProductName = it.ProductName,
                        MatchPalletCode = it.MatchPalletCode,
                        WarehouseQuantity = it.WarehouseQuantity,
                        WarehouseUnitCode = it.WarehouseUnitCode,
                        WorkshopQuantity = it.WorkshopQuantity,
                        WorkshopUnitCode = it.WorkshopUnitCode,
                        WorkshopUnitName = it.WorkshopUnitName
                    };
                    modelList.Add(mathchPalletDetail);
                    ListViewItem lvi = new ListViewItem(new string[] { mathchPalletDetail.ProductName, mathchPalletDetail.WorkshopQuantity.ToString(), "0", mathchPalletDetail.ProductCode });
                    listviewScan.Items.Add(lvi);
                });
            }
            catch (Exception e)
            {
                MessageBox.Show("出现异常，异常信息：" + e.Message);
                this.Hide();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmScanBarCode.Show();
            this.Dispose();
            this.Close();
        }

        private void buttonForceComplete_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("强制完成扫码数量等于配盘数量?", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                modelList.ForEach(it =>
                {
                    it.ScanCountEquWorkShopQuantity();
                });
                UpdateListView(this.listviewScan);
            }
        }

        private void listviewScan_ItemActivate(object sender, EventArgs e)
        {

        }

    }
}