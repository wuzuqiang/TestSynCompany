using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 两个类继承自同一接口会如何
{
    public class InheritTest1 : ITest
    {
        public string ShowName()
        {
            return "InheritTest1";
        }
    }
}
