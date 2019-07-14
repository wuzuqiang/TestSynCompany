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
            string content;
            #region 
            string file = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\" + "{0}s\\{0}Model.cs"
                , cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            string fileAppStore = AppDomain.CurrentDomain.BaseDirectory 
                + string.Format(@"E:\useful\Thkj-Resource\origin\Fussion\src\Application\Fusion.Context.BasicInfo.Application\Services\Interfaces\Product\"
                + "I{0}Service.cs", cN);

            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Application\Fusion.Context.BasicInfo.Application\Models\Product\_左括号_0_右括号_s\_左括号_0_右括号_Model.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Application\Fusion.Context.BasicInfo.Application\Services\Interfaces\Product\I_左括号_0_右括号_Service.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Application\Fusion.Context.BasicInfo.Application\Services\Product\_左括号_0_右括号_Service.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #region 
            #endregion
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Domain\Fusion.Context.BasicInfo.Domain\Models\Product\_左括号_0_右括号_s\_左括号_0_右括号_.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #region 
            #endregion
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Domain\Fusion.Context.BasicInfo.Domain\Repositories\Product\I_左括号_0_右括号_Repository.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Infrastructure\Fusion.Infrastructure.Mapping.BasicInfo\Models\Product\_左括号_0_右括号_s\_左括号_0_右括号_Map.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\Infrastructure\Fusion.Infrastructure.Repository.BasicInfo\Repositories\Product\_左括号_0_右括号_Repository.cs	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\model\Product\_左括号_0_右括号_s\_左括号_0_右括号_Model.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\store\Product\_左括号_0_右括号_s\_左括号_0_右括号_Store.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\view\Product\_左括号_0_右括号_s\_左括号_0_右括号_.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\view\Product\_左括号_0_右括号_s\_左括号_0_右括号_Controller.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\view\Product\_左括号_0_右括号_s\_左括号_0_右括号_Toolbar.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\view\Product\_左括号_0_右括号_s\Find_左括号_0_右括号_.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 
            file = AppDomain.CurrentDomain.BaseDirectory + string.Format(
                @"	Fussion\src\User Interface\Fusion\Extjs\Fusion\classic\src\BasicInfo\view\Product\_左括号_0_右括号_s\Modify_左括号_0_右括号_.js	", cN);
            content = (new ClassApplication()).GetApplicationModel(listMember).Replace("_左括号_", "{").Replace("_右括号_", "}");
            (new FileUtils()).writeToFile(file, content);
            System.Diagnostics.Process.Start(file);
            #endregion
            #region 

        }
    }
}
