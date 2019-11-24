using BaseClassUtils;
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

namespace ReplaceString
{
    public partial class FrmExcel : Form
    {
        public FrmExcel()
        {
            InitializeComponent();
        }

        private void FrmExcel_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取数据
            if (string.IsNullOrEmpty(txtSheetnames.Text))
            {
                MessageBox.Show("请选择工作簿！");
                txtSheetnames.Focus();
                return;
            }
            DataSet ds = new DataSet();
            if(ExcelUtils.getExcelExtesion(ExcelUtils.ExceType.Excel2003) == Path.GetExtension(txtFilePath.Text))
            {
                ds = FileUtils.getXlsData(txtFilePath.Text, txtSheetnames.Text);
            }
            else
            {
                ds = FileUtils.getXlsxExcelData(txtFilePath.Text, txtSheetnames.Text);
            }

            #region 将DataSet中内容转换为insert sql
            //Excel的第一行第一列是表名，
            //Excel的第三行是表中的所有列名
            //Excel第四行起是每列对应的数据
            StringBuilder sbInsertSql = new StringBuilder();
            string tableName = ds.Tables[0].Rows[0][0].ToString();
            List<string> listTableColumn = new List<string>();
            string insertCol = "(";
            DataTable dtExcel = ds.Tables[0];
            for(int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                listTableColumn.Add(dtExcel.Rows[3-1][i].ToString());
                insertCol += dtExcel.Rows[3 - 1][i].ToString() + ",";
            }
            insertCol = insertCol.Substring(0, insertCol.Length - 1 - 1) + ")";
            for(int rowIndex = 0; rowIndex < dtExcel.Rows.Count; rowIndex++)
            {
                string insertColVal = "(";
                for (int colIndex = 0; colIndex < dtExcel.Columns.Count; colIndex++)
                {
                    insertColVal += dtExcel.Rows[rowIndex][colIndex].ToString() + ",";
                }
                insertColVal = insertColVal.Substring(0, insertColVal.Length - 1 - 1) + ")";
                sbInsertSql.AppendLine($"insert into {tableName}{insertCol} \n    values {insertColVal};");
            }
            richShowData.Text = sbInsertSql.ToString();
            #endregion

            //怀疑要考虑到连接数据库，去数据库里查看表中各个列名的类型，然后Excel中对应的列数据。
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打开Excel文件
            string filePath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(Microsoft Excel 2013;Microsoft Excel 2007)|*.xlsx;*.xls";
            DialogResult dialogResult = dialog.ShowDialog();
            if (DialogResult.Cancel == dialogResult)
            {
                return;
            }
            else if (DialogResult.OK == dialogResult)
            {
                filePath = dialog.FileName;
                txtFilePath.Text = filePath;
            }
            //将Excel的表名称绑定上以供选择
            string result = "";
            List<string> vs = FileUtils.GetSheetnames(filePath, out result);
            foreach (var sheetname in vs)
            {

            }
            txtSheetnames.Items.AddRange(FileUtils.GetSheetnames(filePath, out result).ToArray());
        }

        private void txtSheetnames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFreshSheetnamse_Click(object sender, EventArgs e)
        {
            string result = "";
            //List<string> vs = FileUtils.GetSheetnames(txtFilePath.Text, out result);
            txtSheetnames.Items.Clear();
            txtSheetnames.Items.AddRange(FileUtils.GetSheetnames(txtFilePath.Text, out result).ToArray());
            //DataSet ds = FileUtils.getXlsxExcelData(txtFilePath.Text, txtSheetnames.SelectedText);
        }
    }
}
