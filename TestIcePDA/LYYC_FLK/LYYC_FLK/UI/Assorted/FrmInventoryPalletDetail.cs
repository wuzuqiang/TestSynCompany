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
        private FrmGetMatchPalletCode FrmScanBarCode;
        private AssortedService AssortedService = new AssortedService();
        public FrmInventoryPalletDetail()
        {
            InitializeComponent();
        }

        public FrmInventoryPalletDetail(FrmMain frmMain)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();

            FrmMain = frmMain;

            PageModel.Init();
            this.GetMatchPalletPlan(null);
            try
            {
                Glob.SetFacturer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据异常，异常信息：" + ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetMatchPalletPlan(this.txtSearch.Text.Trim());
            try
            {
                Glob.SetFacturer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取数据异常，异常信息：" + ex.Message);
            }
        }

        private void GetMatchPalletPlan(string mathPallet)
        {
            lvwMathPalletList.Items.Clear();
            try   
            {
                AssortedService.GetMathPalletPlanByIce(mathPallet).ForEach(it =>
                {
                    var matchPalletPlanNo = it.MatchPalletPlanNo;
                    var matchPalletCode = it.MatchPalletCode;
                    var planDate = it.PlanDate;
                    var mathName = it.MatchPalletName;
                    ListViewItem lvi = new ListViewItem(new string[] { mathName, planDate.ToString("yyyy-MM-dd"), matchPalletPlanNo, matchPalletCode });
                    lvwMathPalletList.Items.Add(lvi);
                });
                TotalPage.Text = PageModel.PageCount.ToString();
                PageCount.Text = PageModel.Page.ToString();
            }
            catch (Exception e)
            {
                var result = MessageBox.Show("获取数据异常，异常信息：" + e.Message + " .  是否重连?", "消息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    GetMatchPalletPlan(mathPallet);
                }
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            BeforePage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void lvwMathPalletList_ItemActivate(object sender, EventArgs e)
        {
            if (this.lvwMathPalletList.Activation == ItemActivation.Standard)
            {
                CreateFrmScanBar();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMain.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmMain.Close();
            this.Close();
        }

        private void lvwMathPalletList_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (e.KeyValue == 245)
                {
                    CreateFrmScanBar();
                }
                else if (e.KeyValue == 39)
                {
                    NextPage();
                }
                else if (e.KeyValue == 37)
                {
                    BeforePage();
                }
            }
        }

        private void BeforePage()
        {
            if (PageModel.ToBeforePage())
            {
                PageModel.PageOperator(false);
                this.GetMatchPalletPlan(null);
            }
        }

        private void NextPage()
        {
            if (PageModel.ToNextPage())
            {
                PageModel.PageOperator(true);
                GetMatchPalletPlan(null);
            }
        }

        private void CreateFrmScanBar()
        {
            string mathchPalletName = this.lvwMathPalletList.FocusedItem.SubItems[0].Text.ToString();
            FrmScanBarCode = new FrmGetMatchPalletCode(this, AssortedService, mathchPalletName);

            StaticModel.ScanBarCode = "";
            StaticModel.MathchPalletName = mathchPalletName;
            StaticModel.MathchPalletPlanNo = this.lvwMathPalletList.FocusedItem.SubItems[2].Text;
            StaticModel.MathchPalletCode = this.lvwMathPalletList.FocusedItem.SubItems[3].Text.ToString();

            FrmScanBarCode.Show();
            this.Hide();
        }

        private void FrmAssorted_Closed(object sender, EventArgs e)
        {
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int totalPage = Convert.ToInt32(TotalPage.Text);
            int currentPage = Convert.ToInt32(PageCount.Text);

            if (totalPage - currentPage == 1)
            {
                BtnNextPage.Enabled = false;
                btnBeforePage.Enabled = true;
            }
            else {
                BtnNextPage.Enabled = true;
                btnBeforePage.Enabled = true;
            }
          
            if (PageModel.ToNextPage())
            {
                PageModel.PageOperator(true);
                PageCount.Text = PageModel.Page.ToString();
                GetMatchPalletPlan(null);
            }
        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {
            int totalPage = Convert.ToInt32(TotalPage.Text);
            int currentPage = Convert.ToInt32(PageCount.Text);

            if (totalPage-currentPage-1==1)
            {
                btnBeforePage.Enabled = false;
                BtnNextPage.Enabled = true;
            }
            else
            {
                BtnNextPage.Enabled = true;
                btnBeforePage.Enabled = true;
            }

            if (PageModel.ToBeforePage())
            {
                PageModel.PageOperator(false);
                PageCount.Text = PageModel.Page.ToString();
                this.GetMatchPalletPlan(null);
            }
        }
    }
}