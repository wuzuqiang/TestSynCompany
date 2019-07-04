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

namespace DealPath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string imageUrl = "https://img.huxiucdn.com/moment/201807/05/114144772520.jpg";
                //+ "?watermark/3/text/QOi_meivneaIkeacjQ==/fill/I0ZGRkZGRg==/gravity/SouthEast/dx/20/dy/20/fontsize/15/font/5b6u6L2v6ZuF6buR/image/aHR0cHM6Ly9pbWcuaHV4aXVjZG4uY29tL2xvY2FsL2FydGljbGUvY29udGVudC8yMDE4MDQvMTcvMTcwNTQ0MTk4NTAyLnBuZw==/dx/20/dy/40/gravity/SouthEast/ws/0.08|imageMogr2/thumbnail/220x146%3E";

            string imageUrlExt = Path.GetExtension(imageUrl);
            string str = imageUrlExt.ToLowerInvariant();
        }
    }
}
