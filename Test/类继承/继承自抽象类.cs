using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类继承
{
    class 继承自抽象类:抽象类
    {
        public override void Fun2()
        {
            Console.WriteLine("Fun2 in 继承自抽象类:抽象类！");
        }
        new void Fun1()
        {
            Console.WriteLine("Fun1 in 继承自抽象类:抽象类！");
        }
        //public abstract void Fun3() { }     //错误 CS0513	“继承自抽象类.Fun3()”是抽象的，但它包含在非抽象类“继承自抽象类”中
        public void FunEvent()
        {
            Console.WriteLine("FuncEvent in 继承自抽象类：抽象类！");
        }
    }
}
