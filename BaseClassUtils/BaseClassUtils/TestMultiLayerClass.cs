using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
    public class TestMultiLayerClass
    {

    }

    public class Student
    {
        public Student(string name)
        {
            Name = name;
        }
        public string Name;
        public string Sex;
    }

    public class Grade
    {
        public Guid ID = Guid.NewGuid();
        public string Name;
        public string Code;
        public List<Student> students = new List<Student>();
        public void addStudent(Student student)
        {
            students.Add(student);
        }
    }

    public class School
    {
        public string Code;
        public string Name;
        public string Region;
        public List<Grade> grades = new List<Grade>();
        public void addGrade(Grade grade)
        {
            grades.Add(grade);
        }
    }
}
