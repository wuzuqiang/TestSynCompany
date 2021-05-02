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
			idempotent string GetLocationByBarcode(string barcode);

		    idempotent string GetMatchPalletPlan(string matchPalletPlanNo,int page, int start, int limit, string sort, string filter);
			idempotent string GetMatchPalletPlanDetail(string matchPalletCode, int page, int start, int limit, string sort, string filter);
			string AddAssertedAndDetail(string mathPalletCode,string barCode,string matchPalletPlanNo,string productBarCodes);
			string CreateAssortedBillByScanBarcode(string uniqueId, string matchPalletCode, string matchPalletPlanNo, string assortedProductModels);

			idempotent string GetAssortedBillByBarcode(string barcode);
			idempotent string GetPalletByBarcode(string barcode);

			string GetBigSmallBar(string barCode);
			//�̵㵥��
			idempotent string GetInventoryBillDetail(string barCode, int page, int start, int limit, string sort, string filter);
			idempotent string UpdateInventoryBillDetail(string inventoryBillNo, string inventroyBillDetails);

			/*
			* ͭ��Ƭ�̿�
			*/
			idempotent string GetFormulaOut(string fromulaCode,int page, int start, int limit, string sort, string filter);
			idempotent string GetFormulaOutDetail(string fromulaCode);
			string UpdateFormulaOutDetail(string fromulaCode,string data);		
			/*
			* ͭ�ʸ��Ͽ�
			*/
			idempotent string WarehouseRemovalOrder(string barcode);
			string UpdateWarehouseRemovalOrder(string billNo);

			/*
			*���ݸ���
			*/
			string CreateOutBill(taskStrings barcodes);
			idempotent string GetInventorySurplusDetail(string barcode);
		    string SyncRealProductInfo(taskStrings recordBarcodes, string productCode, int quantity,taskStrings realBarcodes);
		    string CreateAssortedBill(taskStrings barcodes);

			//����  
			//ƴ��
			idempotent string GetMatchPallet(int page, int start, int limit, string sort, string filter);
			idempotent string GetMatchPalletDetail(string matchPalletCode, int page, int start, int limit, string sort, string filter);
			string AddAssortedBillAndDetail(string mathPalletCode,string mathpalletDetails); 
			//���
			idempotent string GetStations(string stationClassify);
			idempotent string GetRegions();
			string StoreInByPda(int workPositionNo, string uniqueId, taskStrings equipmentCodes, taskStrings regionCodes);
			//��̨����
			idempotent string GetProductionPlan(int page, int start, int limit, string sort, string filter);
			idempotent string GetProductionPlanDetail(string productionPlanNo,int page, int start, int limit, string sort, string filter);
			idempotent string GetMachines(string ip);
			idempotent string GetMachinePallets(string machineCode);
			string MachineCall(string userName, string productionPlanNo, int palletPosition, string clientIp);
			string MachineInit(int palletPosition,string clientIp);
			//����
			string GetProduct(string productCode);
			string AddKeepAccountBillIncludeTask(string keepAccountBillModel, int origionPosition, int targetPosition);

			/*
			*��Ʒ������
			*/
			//ֱ�����
			string GetProducts(string productCode);
			string GetCanInLocationPalletList(int page, int start, int limit, string product);
			string DirectInBill(string productCode, string quantity, string locationCode);
			//ֱ�ӳ���
			string GetCanOutLocationStoragePalletList(bool onlyLocationInfo, string locationName, string workOrder, string cargoOwnerName, int page, int start, int limit);
			string DirectOutBill(string productCode,string quantity, string locationCode);
			
			//�������
			idempotent string FindInBillByPda(string inBillNo, int page, int start, int limit);
			idempotent string FindInBillAllot(string inBillNo, int page, int start, int limit, string sort, string filter, out int total);
			string CompleteInBill(string productCode, string inBillNo);
			//���ݳ���
			idempotent string FindOutBillByPda(string outBillNo, int page, int start, int limit);
			idempotent string FindOutBillAllot(string outBillNo, int page, int start, int limit, string sort, string filter, out int total);
			string CompleteOutBill(string productCode, string outBillNo);

			//Ѯ��������
			idempotent string GetInTaskDetail(string barcode);
			idempotent string GetOutTaskDetail(string barcode);
		    void ApplyTask(string billNo, string user, taskStrings taskIds,int billType);
		    void CancelTask(string billNo, taskStrings taskIds,int billType);
		    void CompleteTask(string billNo, taskStrings taskIds,int billType);	 
			
			//Ѯ��������
			idempotent string GetStockInTaskDetails();
			idempotent string GetStockOutTaskDetails();
			void UpdateBillBarcodes(int billType,string billNo,taskStrings taskIds,taskStrings barcodes);
	};
};