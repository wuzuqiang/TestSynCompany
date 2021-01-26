using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClassUtils;

namespace ReplaceString
{
	public partial class FrmCommonTransfer : Form
	{
		public FrmCommonTransfer()
		{
			InitializeComponent();
		}

		private void btnPadLeftInputText_Click(object sender, EventArgs e)
		{   //用txtPadStrToInputText中内容左补足至txtInputNeedLength.Text中长度
			var padMaxLength = Convert.ToInt32(txtInputNeedLength.Text);
			var padChar = txtPadStrToInputText.Text.ToCharArray()[0];
			txtInput.Text = txtInput.Text.ToString().PadLeft(padMaxLength, padChar);
		}

		private void btnPadRightTxtInput_Click(object sender, EventArgs e)
		{	//用txtPadStrToInputText中内容右补足至txtInputNeedLength.Text中长度
			var padMaxLength = Convert.ToInt32(txtInputNeedLength.Text);
			var padChar = txtPadStrToInputText.Text.ToCharArray()[0];
			txtInput.Text = txtInput.Text.ToString().PadRight(padMaxLength, padChar);
		}

		private void btnTransfer_Click(object sender, EventArgs e)
		{
			txtResult.Text = getBarCode(txtInput.Text);
		}

		private string getBarCode(string input)
		{
			StringBuilder sbBarCode = new StringBuilder();
			var index00 = txtArrayIndexLength00.Text.ToInt32();
			var index01 = txtArrayIndexLength01.Text.ToInt32();
			var index02 = txtArrayIndexLength02.Text.ToInt32();
			var index03 = txtArrayIndexLength03.Text.ToInt32();
			sbBarCode.Append($"{input.Substring(0, index00)},");
			sbBarCode.Append($"{input.Substring(0 + index00, index01)},");
			sbBarCode.Append($"{input.Substring(0 + index00 + index01, index02)},");
			sbBarCode.Append($"{input.Substring(0 + index00 + index01 + index02, index03)},");

			return sbBarCode.ToString();
		}
	}
}
