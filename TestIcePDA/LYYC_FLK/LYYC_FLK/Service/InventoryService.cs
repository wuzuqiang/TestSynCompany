using System;
using System.Collections.Generic;
using Fusion.LYYC.PDA.Scanner.Tools;
using Fusion.LYYC.PDA.Scanner.Model;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.Proxy;
using Fusion.LYYC.PDA.Scanner.Interface;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner.Service
{
    public class InventoryService
    {
        PDAServiceIceProxy PDAServiceIceProxy = null;
        public InventoryService()
        {
            PDAServiceIceProxy = new PDAServiceIceProxy();
        }


        public List<FacturerModel> GetFacturers()
        {
            var list = new List<FacturerModel>();
            try
            {
                var standardDataModel = PDAServiceIceProxy.GetFacturers();
                if (!standardDataModel.success)
                {
                    throw new Exception(standardDataModel.msg);
                }
                //PageModel.TotalCount = standardDataModel.total;
                //PageModel.PageCount = (int)Math.Ceiling((double)PageModel.TotalCount / PageModel.Limit);
                list = standardDataModel.data;
            }
            catch (Exception e)
            {
                throw new Exception("出现异常，异常信息：" + e.Message);
            }
            return list;
        }


        public List<MatchPalletPlanModel> GetMathPalletPlanByIce(string mathPalletCode)
        {
            var list = new List<MatchPalletPlanModel>();
            try
            {
                var standardDataModel = PDAServiceIceProxy.GetMatchPalletPlan(mathPalletCode, PageModel.Page, 0, PageModel.Limit, "", (string.IsNullOrEmpty(mathPalletCode) ? "" : SearchTool.JsonSerialzable("MatchPalletCode," + mathPalletCode)));
                if (!standardDataModel.success)
                {
                    throw new Exception(standardDataModel.msg);
                }
                PageModel.TotalCount = standardDataModel.total;
                PageModel.PageCount = (int)Math.Ceiling((double)PageModel.TotalCount / PageModel.Limit);
                list = standardDataModel.data;
            }
            catch (Exception e)
            {
                throw new Exception("出现异常，异常信息：" + e.Message);
            }
            return list;
        }

        public List<MatchPalletPlanDetailModel> GetMathPalletPlanDetailByIce(string mathPalletCode)
        {
            var list = new List<MatchPalletPlanDetailModel>();
            try
            {
                var standardDataModel = PDAServiceIceProxy.GetMatchPalletDetail(mathPalletCode, 1, 0, 200, "", "");
                if (!standardDataModel.success)
                {
                    throw new Exception(standardDataModel.msg);
                }
                PageModel.TotalCount = standardDataModel.total;
                PageModel.PageCount = (int)Math.Ceiling((double)PageModel.TotalCount / PageModel.Limit);
                list = standardDataModel.data;
            }
            catch (Exception e)
            {
                throw new Exception("出现异常，异常信息：" + e.Message);
            }
            return list;
        }

        public void AddAssortedByIce(string mathPallet, string barCode, string matchPalletPlanNo, List<ProductBarCodeModel> productBarCodes)
        {
            var stringBar = JsonConvert.SerializeObject(productBarCodes);
            var standardDataModel = PDAServiceIceProxy.AddAssertedAndDetail(mathPallet, barCode, matchPalletPlanNo, stringBar);
            if (!standardDataModel.success)
            {
                throw new Exception(standardDataModel.msg);
            }
        }


        public AssortedBillModel GetAssortedBillByBarcode(string barCode)
        {

            var standardDataModel = PDAServiceIceProxy.GetAssortedBillByBarcode(barCode);
            return standardDataModel;

        }

        public LocationModel GetPalletByBarcode(string barCode)
        {

            var standardDataModel = PDAServiceIceProxy.GetPalletByBarcode(barCode);
            return standardDataModel;

        }

        public List<FormulaOutModel> GetFormulaOutByIce(string formulaOutCode)
        {
            var list = new List<FormulaOutModel>();
            try
            {
                var standardDataModel = PDAServiceIceProxy.GetFormulaOut(formulaOutCode, PageModel.Page, 0, PageModel.Limit, "", (string.IsNullOrEmpty(formulaOutCode) ? "" : SearchTool.JsonSerialzable("FormulaCode," + formulaOutCode)));
                if (!standardDataModel.success)
                {
                    throw new Exception(standardDataModel.msg);
                }
                PageModel.TotalCount = standardDataModel.total;
                PageModel.PageCount = (int)Math.Ceiling((double)PageModel.TotalCount / PageModel.Limit);
                list = standardDataModel.data;
            }
            catch (Exception e)
            {
                throw new Exception("出现异常，异常信息：" + e.Message);
            }
            return list;
        }

        public IList<FormulaOutDetailModel> GetFormulaOutDetailByIce(string formulaCode)
        {
            var list = new List<FormulaOutDetailModel>();
            try
            {
                var standardDataModel = PDAServiceIceProxy.GetFormulaOutDetail(formulaCode);
                if (standardDataModel.success)
                {
                    list = standardDataModel.data;
                }
            }
            catch (Exception e)
            {
                throw new Exception("出现异常，异常信息：" + e.Message);
            }
            return list;
        }

        public void UpdateFormulaOutDetailByIce(string formulaCode, FormulaOutDetailModel detailModel)
        {
            var standardDataModel = PDAServiceIceProxy.UpdateFormulaOutDetail(formulaCode, detailModel);
            if (!standardDataModel.success)
            {
                throw new Exception(standardDataModel.msg);
            }
        }

        public void CreateAssortedBillByScanBarcode(string uniqueId, string matchPalletCode, string matchPalletPlanNo, List<AssortedProductModelModel> assortedProductModels)
        {
            var list = new List<MatchPalletPlanDetailModel>();
            try
            {
                var standardDataModel = PDAServiceIceProxy.CreateAssortedBillByScanBarcode(uniqueId, matchPalletCode, matchPalletPlanNo, JsonConvert.SerializeObject(assortedProductModels));
                if (!standardDataModel.success)
                {
                    throw new Exception(standardDataModel.msg);
                }
            }
            catch (Exception e)
            {
                throw new Exception("出现异常，异常信息：" + e.Message);
            }
        }
    }
}
