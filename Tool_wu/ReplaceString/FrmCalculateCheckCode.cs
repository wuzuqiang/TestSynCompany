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
    public partial class FrmCalculateCheckCode : Form
    {
        public FrmCalculateCheckCode()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //由最终校验码反推中间数据
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取最终校验码
            //清除文本框中多余的左右方括号
            txtArraysBeforeArray.Text = txtArraysBeforeArray.Text.Replace("[", "").Replace("]", "");
            txtArraysAfterArray.Text = txtArraysAfterArray.Text.Replace("[", "").Replace("]", "");
            List<int> listInt = new List<int>();
            foreach(string str in txtArraysBeforeArray.Text.GetSplitLineWithoutEmpty(','))
            {
                listInt.Add(str.ToInt32());
            }
            foreach (string str in txtArraysAfterArray.Text.GetSplitLineWithoutEmpty(','))
            {
                listInt.Add(str.ToInt32());
            }
            txtFinalCheckedCode.Text = CheckCodeHelper.CalculateCheckCode(listInt.ToArray()).ToString();
        }
    }
    /// <summary>
    /// 校验码帮助类。
    /// </summary>
    public static class CheckCodeHelper
    {
        /// <summary>
        /// 计算校验码。
        /// </summary>
        /// <param name="data">需要计算的int数组</param>
        /// <returns>返回计算后的校验码</returns>
        public static int CalculateCheckCode(int[] data)
        {
            int temp = 0;

            foreach (var item in data)
            {
                temp = ((temp & 65535) + (item & 65535)) & 65535;
            }

            return temp & 65535;
        }
    }
}
