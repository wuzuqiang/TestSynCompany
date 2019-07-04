using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类继承
{
    delegate void SelectHandler();
    interface iInterface
    {
        int this[int index]
        {
            get;
            set;
        }
        event SelectHandler SelectId;
        //public void Fun1(); //错误 CS0106  修饰符“public”对该项无效
        void Fun1();
    }
}
