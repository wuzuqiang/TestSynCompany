using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MyLib
{
    [ComVisible(true)]
    [Guid("35A5CE1E-551C-41EC-81D4-005318550119")]
    public interface IMyClass
    {
        void Initialize();
        void Dispose();
        int Add(int x, int y);
    }
    [ComVisible(true)]
    [Guid("F0239BF9-0A6E-49A6-8853-BADE1B95E66F")]
    [ProgId("MyLib.MyClass")]
    public class MyClass : IMyClass
    {
        public void Initialize()
        {
            //nonthing to do
        }
        public void Dispose()
        {
            //nothing to do
        }
        public int Add(int x, int y)
        {
            return x + y;
        }

    }
}
