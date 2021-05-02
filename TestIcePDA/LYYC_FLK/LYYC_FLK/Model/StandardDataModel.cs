using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class StandardDataModel<T>
    {
        public bool success = false;

        public bool exception = false;

        public IDictionary<string, string> errors = new Dictionary<string, string>();

        public string msg = string.Empty;

        public int total = 0;

        public T data = default(T);
    }

    public class StandardDataModel : StandardDataModel<object>
    {
    }
}
