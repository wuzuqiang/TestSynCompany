using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 遍历静态类中的所有静态成员
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            try
            {
                Type _type = typeof(PinCategory);
                foreach (System.Reflection.FieldInfo p in _type.GetFields())
                {
                    var _var = p.GetValue(null);
                }
            }
            catch
            {
                //Func<int>
            }
            #endregion
        }
    }
    public static class PinCategory
    {
        public static Guid A;
        public static Guid B;
    }
}
