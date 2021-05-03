/*
* 2021-3-4 Create by 曾旺华
*/

#pragma once
module Warehouse
{
    sequence<string> partsTaskStrings;
	interface PartsOfAndroidService
	{
		idempotent string GetInTaskDetailForAndroid(string barcode) ; //根据条码查询入库信息
		idempotent string GetOutTaskDetailForAndroid(string barcode) ;//根据条码查询出库信息

		void ApplyTaskForAndroid(string billNo, string user, partsTaskStrings taskIds,int billType) ; //根据单据号、操作人员、ID、单据类型 1入库2出库 申请作业
        void CompleteTaskForAndroid(string billNo, partsTaskStrings taskIds,int billType) ; //根据单据号、操作人员、ID、单据类型 1入库2出库 完成任务
		//盘点单据
		idempotent string GetInventoryBillDetail(string barCode, int page, int start, int limit, string sort, string filter) ;
		idempotent string UpdateInventoryBillDetail(string inventoryBillNo, string inventroyBillDetails) ;
	};
};