using BaseClassUtils;
using ReplaceString.Model;
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
	public partial class FrmDatabase : Form
	{
		public FrmDatabase()
		{
			InitializeComponent();
		}

		private void FrmDatabase_Load(object sender, EventArgs e)
		{

		}

		public static void InsertDatabase(ReplaceHistoryModel replaceHistoryModel)
		{

			try
			{
				TransferHelper.ExecuteInsert(replaceHistoryModel);
			}
			catch (ExceptionEx ex)
			{
				MessageBox.Show(ex.MessageEx);
			}
		}
	}
}
