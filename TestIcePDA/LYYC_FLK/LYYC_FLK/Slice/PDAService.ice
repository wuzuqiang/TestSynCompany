/*
* 2018-08-14 Create by luyajin
*/

module PDA
{
	sequence<string> taskStrings;
	interface PDAService
	{
			idempotent string GetFacturers();
	        string ApplyStoreIn(string productCode, string billTypeCode, string barcode, string inBatch);
            string ApplyStoreOut(string productCode, string billTypeCode, string barcode, string inBatch);
			string ApplyRelocation(string productCode, string billTypeCode, string barcode);
			idempotent string GetPalletByBarcode(string barcode);

		    idempotent string GetMatchPalletPlan(string matchPalletPlanNo,int page, int start, int limit, string sort, string filter);
		    idempotent string GetMatchPalletPlanDetail(string matchPalletCode, int page, int start, int limit, string sort, string filter);
			string AddAssertedAndDetail(string mathPalletCode , string barCode,string matchPalletPlanNo,string productBarCodes);
			string CreateAssortedBillByScanBarcode(string uniqueId, string matchPalletCode, string matchPalletPlanNo, string assortedProductModels);   

			idempotent string GetAssortedBillByBarcode(string barcode);
			
			idempotent string GetFormulaOut(string formulaCode,int page, int start, int limit, string sort, string filter);
		    idempotent string GetFormulaOutDetail(string formulaCode);
		    string UpdateFormulaOutDetail(string formulaCode, string data); 
	};
};