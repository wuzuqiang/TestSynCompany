using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fusion.LYYC.PDA.Scanner.Model;
using Fusion.LYYC.PDA.Scanner;

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class MatchPalletPlanDetailModel
    {
        public MatchPalletPlanDetailModel() { }

        public MatchPalletPlanDetailModel(string assortedProductModel)
        {
            this.AssortedProductModel = assortedProductModel;
        }
        private string AssortedProductModel { get; set; }

        public string MatchPalletCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string WarehouseUnitCode { get; set; }
        public string WarehouseUnitName { get; set; }
        public decimal WarehouseQuantity { get; set; }
        public string WorkshopUnitCode { get; set; }
        public string WorkshopUnitName { get; set; }
        public decimal WorkshopQuantity { get; set; }
        public int WorkshopTransferRate { get; set; }
        public int ScanCount { get; set; }

        public List<AssortedProductModelModel> BarCodeDetail = new List<AssortedProductModelModel>();

        public void Add(ref List<MatchPalletPlanDetailModel> model)
        {
            //if (model.Count > 0)
            //{
            //    //切割规则，获取产品
            //    var productCode = AssortedProductModel;//.Substring();

            //    var scModel = model.FirstOrDefault(it => it.ProductCode == productCode);
            //    if (scModel == null)
            //    {
            //        throw new Exception("产品不存在");
            //    }
            //    else
            //    {
            //        if (scModel.ScanCount == scModel.WarehouseQuantity)
            //        {
            //            throw new Exception("产品：【" + scModel.ProductName + "】 已扫满");
            //        }
            //        scModel.ScanCount++;

            //        var barModel = BarCodeDetail.FirstOrDefault(it => it.ProductCode == productCode);
            //        if (barModel == null)
            //        {
            //            var newBarModel = new AssortedProductModelModel()
            //            {
            //                ProductCode = productCode,
            //                //AssortedProductModels = AssortedProductModel
            //            };
            //            BarCodeDetail.Add(newBarModel);
            //        }
            //        else
            //        {
            //            barModel.UpdateBarCode(AssortedProductModel);
            //        }
            //        Glob.AddOrUpdateAssortedProductModel(BarCodeDetail);
            //    }
            //}
            //else
            //{
            //    throw new Exception("未获取当前产品集信息，请重新确认");
            //}
        }

        public void ScanCountEquWorkShopQuantity()
        {
            if (ScanCount == WorkshopQuantity)
            {
                return;
            }
            ScanCount = (int)WorkshopQuantity;
        }
    }
}
