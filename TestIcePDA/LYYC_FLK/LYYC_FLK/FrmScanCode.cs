using System;
using System.Windows.Forms;
using Fusion.LYYC.PDA.Scanner.Tools;
using System.Collections.Generic;
using Fusion.LYYC.PDA.Scanner.Model;
using System.Threading;

namespace Fusion.LYYC.PDA.Scanner
{
    public partial class FrmScanCode : Form
    {

        ScanBarTool ScanBarTool;

        List<ScanBarModel> modelList = null;

        bool doMoreRead = false;

        private Thread thread;


        private delegate void SetMessageDelegate(ListView control);


        public FrmScanCode()
        {
            InitializeComponent();

            Cursor.Current = Cursors.WaitCursor;
            ScanBarTool = new ScanBarTool();
            Cursor.Current = Cursors.Default;
            modelList = new List<ScanBarModel>();
        }

        private void FrmScanCode_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void FrmScanCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (e.KeyValue == 245)
                {
                    ScanCode();
                }
            }
        }

        private void FrmScanCode_Closed(object sender, EventArgs e)
        {
            ScanBarTool.Close();
        }

        private void btnOnce_Click(object sender, EventArgs e)
        {
            ScanCode();
            NewList(this.listScan);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            listScan.Items.Clear();
            modelList = new List<ScanBarModel>();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (!doMoreRead)
            {
                this.btnMore.Text = "取    消";
                doMoreRead = true;
                ChangeBtnStatus(false);
            }
            else
            {
                this.btnMore.Text = "多次扫码";
                doMoreRead = false;
                ChangeBtnStatus(true);
            }


            thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ChangeBtnStatus(bool isopen)
        {
            btnOnce.Enabled = isopen;
            btnClean.Enabled = isopen;
        }

        private void Run()
        {
            try
            {
                while (true)
                {
                    ScanCode();
                    var p = this.listScan.BeginInvoke(new SetMessageDelegate(this.NewList), this.listScan);
                    this.listScan.EndInvoke(p);
                    if (!doMoreRead)
                    {
                        break;
                    }

                    Thread.Sleep(10);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void ScanCode()
        {
            var scanCode = ScanBarTool.ScanBarcode();
            if (string.IsNullOrEmpty(scanCode))
                return;

            new ScanBarModel(scanCode).Add(ref modelList);

        }

        private void NewList(ListView Scan)
        {
            Scan.Items.Clear();
            modelList.ForEach(it =>
            {
                ListViewItem lvi = new ListViewItem(new string[] { it.BarCode, it.Count.ToString() });
                Scan.Items.Add(lvi);
            });
        }
    }
}