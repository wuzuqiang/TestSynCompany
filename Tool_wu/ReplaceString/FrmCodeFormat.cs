using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplaceString
{
    public partial class FrmCodeFormat : Form
    {
        public FrmCodeFormat()
        {
            InitializeComponent();
            listBox1.Items.AddRange(new string[] { "Deafault", "ASCII", "UTF8", "UTF8"  });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> listStr = new List<string>();
            txtResult.Text = "";
            switch (listBox1.SelectedItem.ToString())
            {
                case "ASCII":
                    foreach(byte temp in Encoding.ASCII.GetBytes(txtInput.Text).ToArray())
                    {
                        txtResult.Text += (temp.ToString());
                    }
                    break;
                case "UTF8":
                    foreach (byte temp in Encoding.UTF8.GetBytes(txtInput.Text).ToArray())
                    {
                        txtResult.Text += (temp.ToString());
                    }
                    break;
                case "Deafault":
                    foreach (byte temp in Encoding.Default.GetBytes(txtInput.Text).ToArray())
                    {
                        txtResult.Text += (temp.ToString());
                    }
                    break;
            }
        }
    }
}
