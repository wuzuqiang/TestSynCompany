using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClassAbs abs = new ClassAbs();  //错误 CS0144  无法创建抽象类或接口“ClassAbs”的实例
            Class2 class2 = new Class2("");
            //class2.a = "";  //错误 CS0122	“ClassPublic.a”不可访问，因为它具有一定的保护级别            :因为proctected
            class2.strPublic = "";
        }
    }
    internal class ClassInternal { }
    abstract class ClassAbs { }
    sealed class ClassSeal { }
    public class ClassPublic { public ClassPublic(string b) { a = b; } protected string a; public string strPublic = "fff"; }
    static class ClassStatic { }
    //protected internal class ClassXXX1 { }  //错误 CS1527  命名空间中定义的元素无法显式声明为 private、protected、protected internal 或 private protected
    //sealed abstract class ClassXXX2 { } //错误 CS0418  “ClassXXX2”: 抽象类不能是密封的或静态的

    //public class Class1 : ClassInternal { }     //错误  CS0060 可访问性不一致: 基类“ClassInternal”的可访问性低于类“Class1”
    class Class2:ClassPublic
    {
        public Class2(string str):base("2")
        {

        }
        void Func()
        {
            strPublic = "ffsds";
            a = "kfdsfds";
        }
    }
}
