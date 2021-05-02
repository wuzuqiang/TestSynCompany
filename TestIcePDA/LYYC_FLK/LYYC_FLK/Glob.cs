using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fusion.LYYC.PDA.Scanner.Model;
using Fusion.LYYC.PDA.Scanner.Service;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner
{
    public class Glob
    {
        private static AssortedService AssortedService = new AssortedService();
        private static List<AssortedProductModelModel> AssortedProductModelList = new List<AssortedProductModelModel>();
        private static object lockObj = new object();
        public static string CurrentMatchPalletCode = "";

        public static bool isOnePalletOneFacturer = true;

        public static void AddOrUpdateAssortedProductModel(AssortedProductModelModel assortedProductModel)
        {   //在拼盘时，一个产品只能对应一个厂商
            lock (lockObj)
            {
                AssortedProductModelModel finalModel = null;
                var isExistAssortProductCode = AssortedProductModelList.Any(m => m.ProductCode == assortedProductModel.ProductCode);
                if (isExistAssortProductCode)
                {
                    finalModel = AssortedProductModelList.Where(w => w.ProductCode == assortedProductModel.ProductCode).First();
                    finalModel.FacturerCode = assortedProductModel.FacturerCode;
                    finalModel.FacturerName = assortedProductModel.FacturerName;
                    //AssortedProductModelList.Remove(AssortedProductModelList.Where(w => w.ProductCode == assortedProductModel.ProductCode).First());
                }
                if (!isExistAssortProductCode)
                {
                    AssortedProductModelList.Add(assortedProductModel);
                }
            }
        }

        public static List<AssortedProductModelModel> GetAssortedProductModelList()
        {
            return AssortedProductModelList;
        }

        public static void ClearAssortedProductModelList()
        {
            AssortedProductModelList = new List<AssortedProductModelModel>();
        }

        public static List<FacturerModel> ListFacturerModel = new List<FacturerModel>();
        public static void SetFacturer()
        {
            ListFacturerModel = AssortedService.GetFacturers();
        }
    }
}
