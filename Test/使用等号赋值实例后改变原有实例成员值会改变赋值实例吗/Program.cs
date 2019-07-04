using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用等号赋值实例后改变原有实例成员值会改变赋值实例吗
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassA classA = new ClassA();
            classA.a = "dfsfds";
            ClassA classA_ = new ClassA();
            classA_ = classA;
            classA.a = "23323223";
            Console.WriteLine(classA.a.ToString());
            Console.WriteLine(classA_.a.ToString());

            Console.ReadLine();
        }
    }
    class ClassA
    {
        public object a;
    }
}
