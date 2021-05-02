using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScanDemo.UI.Assorted
{
    public partial class FrmPalletBar : Form
    {
        public FrmPalletBar()
        {
            InitializeComponent();
        }

        private void FrmPalletBar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.Default;
            this.txtBarCode.Focus();
        }

        private void FrmPalletBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (e.KeyValue == 245)
                {

                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}