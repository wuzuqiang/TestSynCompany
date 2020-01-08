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

namespace LinqOper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Test1()
        {
            List<string> list1 = new List<string>() { "1", "3", "5", "7" };
            List<string> list2 = new List<string>() { "2", "4", "5", "8" };
            var ret = list1.Except(list2).ToList();
            richTextBox1.Text = "";
            foreach (string str in ret)
            {
                richTextBox1.Text += str + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var b00 = TypeConverterUtil.GetParameterValueBy<Boolean>("true", false);
            Student student = new Student("zhangsan");
            Student student1 = new Student("lisi");
            Student student2 = new Student("lisi001");
            Student student3 = new Student("lisi003");
            Student student4 = new Student("lisi005");
            Grade grade = new Grade();
            grade.Name = "gradeName01"+ "_~_";
            School school = new School();
            school.addGrade(grade);
            richTextBox1.Text += $"p.students.Any()：{grade.students.Any()}";
            var a = school.grades.Where(p => p.students.Any()).All(p => p.Name == "gradeName01"); //如果grades的students没有数据，那么它的所有数据都是满足条件的，最终结果为true，要这么理解All
            var b = school.grades.All(p => p.Name == "gradeName01"); //结果为false
            var c = school.grades.Where(p => p.students.Any()).Count(); //结果为0
            grade.addStudent(student);
            grade.addStudent(student1);
            grade.addStudent(student2);
            grade.addStudent(student3);
            var a1 = school.grades.Where(p => p.students.Any()).All(p => p.Name == "gradeName01"); //结果为false
            /*
            foreach(var tempVar in a)
            {
                addRichTextBoxContent(tempVar.ID.ToString());
            }
            */
        }

        private void addRichTextBoxContent(string content)
        {
            richTextBox1.Text += $"{content}\n";
        }
    }
}
