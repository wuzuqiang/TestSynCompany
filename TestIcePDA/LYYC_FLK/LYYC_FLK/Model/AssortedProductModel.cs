using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class AssortedProductModelModel
    {
        public AssortedProductModelModel()
        {
            ProducedDate = DateTime.Now;
            ProductCode = "";
            ProductName = "";
            UnitCode = "";
            UnitName = "";
            BigBarcode = "";
            SmallBarcodes = "";
            FacturerCode = "";
            FacturerName = "";
            BatchNo = "";
        }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public int TransferRate { get; set; }
        public decimal Quantity { get; set; }
        public string BigBarcode { get; set; }
        public string SmallBarcodes { get; set; }
        public string FacturerCode { get; set; }
        public string FacturerName { get; set; }
        public DateTime? ProducedDate { get; set; }
        public string BatchNo { get; set; }

        public void UpdateBarCode(string assortedProductModel)
        {
            //AssortedProductModels += "," + assortedProductModel;
        }
    }
}
