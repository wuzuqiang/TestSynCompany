using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class ProductBarCodeModel
    {
        public string ProductCode { get; set; }
        public string ProductBarCodes { get; set; }

        public void UpdateBarCode(string productBarCode)
        {
            ProductBarCodes += "," + productBarCode;
        }
    }
}
