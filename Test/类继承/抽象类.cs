using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类继承
{
    internal abstract class 抽象类
    {
        public string ID { get; set; }
        public void Fun1()
        {
            Console.WriteLine("Fun1 in 抽象类");
        }
        public abstract void Fun2();
        //public abstract void Fun2()     //错误 CS0500	“抽象类.Fun2()”无法声明主体，因为它标记为 abstract
        //{
        //    Console.WriteLine("Fun2 in 抽象类！");
        //}
    }
}
