using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类继承
{
    class 继承自接口:iInterface
    {
        public event SelectHandler SelectId;
        int[] arry = new int[5];
        public int this[int index]
        {
            get
            {
                return arry[index];
            }
            set
            {
                arry[index] = value;
            }
        }
        //void Fun1() { }   //ERROR，会导致继承类无法实现接口成员
        public void Fun1() { }
        public int Fun1(int a) { return 1; }
        public void Fire()
        {
            SelectId();
        }
    }
}
