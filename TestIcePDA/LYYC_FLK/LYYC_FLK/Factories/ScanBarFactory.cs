using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fusion.LYYC.PDA.Scanner.Interface;
using Fusion.LYYC.PDA.Scanner.Tools;

namespace Fusion.LYYC.PDA.Scanner.Factories
{
    public class ScanBarFactory
    {
        private IScanBar ScanBar;

        public ScanBarFactory()
        {
            if (ScanBar == null)
            {
                ScanBar = new ScanBarTool();
            }
        }

        public IScanBar GetScanBar()
        {
            return ScanBar;
        }

        public void Close()
        {
            ScanBar.Close();
        }

        public void Dispose() {
            ScanBar.Dispose();
        }
    }
}
