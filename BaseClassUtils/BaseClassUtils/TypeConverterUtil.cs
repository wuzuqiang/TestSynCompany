using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
    public class TypeConverterUtil
    {
        public static T GetParameterValueBy<T>(string value, T defaultValue)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
