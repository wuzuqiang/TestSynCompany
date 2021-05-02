using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fusion.LYYC.PDA.Scanner.UI.Assorted
{
    public partial class FrmSimuScanCode : Form
    {
        public FrmSimuScanCode()
        {
            InitializeComponent();
        }

        private void FrmSimuScanCode_Load(object sender, EventArgs e)
        {
            txtScanBarCode.Focus();
        }

        public string barCode;
        private void txtScanBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                barCode = txtScanBarCode.Text;
                this.Hide();
                txtScanBarCode.Text = "";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            txtScanBarCode.Text = "";
            this.DialogResult = DialogResult.Cancel;
        }
    }
}