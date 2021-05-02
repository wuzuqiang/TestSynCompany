using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Interface
{
    public interface IScanBar
    {
        void Close();
        string ScanBarcode();
        void Dispose();
    }
}
