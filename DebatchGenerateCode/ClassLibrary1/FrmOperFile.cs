using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class FrmOperFile : Form
    {
        public FrmOperFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(DialogResult.OK == dlg.ShowDialog())
            {
                txtFolder.Text = dlg.SelectedPath;
            }
            foreach(FileInfo info in (new DirUtil()).recycleGetFile(txtFolder.Text))
            {
                txtFiles.Text += info.FullName + ";\n";
            }
            (new DirUtil()).recycleChangeDir(txtFolder.Text.Trim(), "23", "wu");
        }
    }
}
