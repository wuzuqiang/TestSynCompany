using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.IceFramework;
using PDA;
using Fusion.LYYC.PDA.Scanner.Model;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner.Proxy
{
    public class PDAServiceIceProxy
    {
        public IIceRuntime IceRuntime { get; set; }

        public PDAServiceIceProxy()
        {
            IceRuntime = new IceRuntime();
        }

        private PDAServicePrx getProxy()
        {
            return IceRuntime.getProxy<PDAServicePrx, PDAServicePrxHelper>("PDAService");
        }

        public StandardDataModel<List<FacturerModel>> GetFacturers()
        {
            string result = getProxy().GetFacturers();

            return JsonConvert.DeserializeObject<StandardDataModel<List<FacturerModel>>>(result);
        }

        public StandardDataModel ApplyStoreIn(string productCode, string billTypeCode, string barcode, string inBatch)
        {
            string result = getProxy().ApplyStoreIn(productCode, billTypeCode, barcode, inBatch);

            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }

        public StandardDataModel ApplyStoreOut(string productCode, string billTypeCode, string barcode, string inBatch)
        {
            string result = getProxy().ApplyStoreOut(productCode, billTypeCode, barcode, inBatch);

            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }

        public StandardDataModel<RelocationModel> ApplyRelocation(string productCode, string billTypeCode, string barcode)
        {
            string result = getProxy().ApplyRelocation(productCode, billTypeCode, barcode);

            return JsonConvert.DeserializeObject<StandardDataModel<RelocationModel>>(result);
        }

        public LocationModel GetPalletByBarcode(string barcode)
        {
            string result = getProxy().GetPalletByBarcode(barcode);

            return JsonConvert.DeserializeObject<LocationModel>(result);
        }

        public StandardDataModel<List<MatchPalletPlanModel>> GetMatchPalletPlan(string matchPalletPlanNo, int page, int start, int limit, string sort, string filter)
        {
            string result = getProxy().GetMatchPalletPlan(matchPalletPlanNo, page, start, limit, sort, filter);

            return JsonConvert.DeserializeObject<StandardDataModel<List<MatchPalletPlanModel>>>(result);
        }


        public StandardDataModel<List<MatchPalletPlanDetailModel>> GetMatchPalletDetail(string matchPalletCode, int page, int start, int limit, string sort, string filter)
        {
            string result = getProxy().GetMatchPalletPlanDetail(matchPalletCode, page, start, limit, sort, filter);

            return JsonConvert.DeserializeObject<StandardDataModel<List<MatchPalletPlanDetailModel>>>(result);
        }


        public StandardDataModel AddAssertedAndDetail(string mathPalletCode, string barCode, string matchPalletPlanNo, string productBarCodes)
        {
            string result = getProxy().AddAssertedAndDetail(mathPalletCode, barCode, matchPalletPlanNo, productBarCodes);

            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }


        public AssortedBillModel GetAssortedBillByBarcode(string barcode)
        {
            string result = getProxy().GetAssortedBillByBarcode(barcode);

            return JsonConvert.DeserializeObject<AssortedBillModel>(result);
        }

        public StandardDataModel<List<FormulaOutModel>> GetFormulaOut(string formulaCode, int page, int start, int limit, string sort, string filter)
        {
            string result = getProxy().GetFormulaOut(formulaCode, page, start, limit, sort, filter);

            return JsonConvert.DeserializeObject<StandardDataModel<List<FormulaOutModel>>>(result);
        }

        public StandardDataModel<List<FormulaOutDetailModel>> GetFormulaOutDetail(string formulaCode)
        {
            string result = getProxy().GetFormulaOutDetail(formulaCode);

            return JsonConvert.DeserializeObject<StandardDataModel<List<FormulaOutDetailModel>>>(result);
        }

        public StandardDataModel UpdateFormulaOutDetail(string formulaCode, FormulaOutDetailModel FormulaOutDetailModel)
        {
            string result = getProxy().UpdateFormulaOutDetail(formulaCode, JsonConvert.SerializeObject(FormulaOutDetailModel));
            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }

        public StandardDataModel CreateAssortedBillByScanBarcode(string uniqueId, string matchPalletCode, string matchPalletPlanNo, string assortedProductModels)
        {
            string result = getProxy().CreateAssortedBillByScanBarcode(uniqueId, matchPalletCode, matchPalletPlanNo, assortedProductModels);
            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }

    }
}
