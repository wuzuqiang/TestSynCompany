using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ClassLibrary1.ApplicationTemplate;

namespace ClassLibrary1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FrmOperFile()).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //先这里构建原始数据，后期再动态
            string cN = txtClassName.Text;
            List<MemberFromInfo> listMember = new List<MemberFromInfo>();
            listMember.Add(new MemberFromInfo("TBUper", cN));
            listMember.Add(new MemberFromInfo("Id", "Guid"));
            listMember.Add(new MemberFromInfo(cN + "Code", "string"));
            listMember.Add(new MemberFromInfo(cN + "Name", "string"));
            listMember.Add(new MemberFromInfo("Active", "bool"));
            listMember.Add(new MemberFromInfo("Remark", "string"));
            listMember.Add(new MemberFromInfo("CreateTime", "DateTime"));
            listMember.Add(new MemberFromInfo("UpdateTime", "DateTime"));
            listMember.Add(new MemberFromInfo("RowVersion", "byte[]"));
            string file1 = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\"+"{0}s\\{0}Model.cs"
                , cN);
            string content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file1, content);
            System.Diagnostics.Process.Start(file1);
            string fileAppStore = AppDomain.CurrentDomain.BaseDirectory 
                + string.Format(@"E:\useful\Thkj-Resource\origin\Fussion\src\Application\Fusion.Context.BasicInfo.Application\Services\Interfaces\Product\"
                + "I{0}Service.cs", cN);
        }
    }
}
