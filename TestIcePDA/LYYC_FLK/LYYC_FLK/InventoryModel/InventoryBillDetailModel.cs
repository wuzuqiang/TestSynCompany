using System;

/*
* 2017-08-08 Create by 刘雅婷
*/

namespace Fusion.LYYC.PDA.Scanner.Model
{
    public class InventoryBillDetailModel
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }
        public string InventoryBillNo { get; set; }
        public Guid? RecordPalletId { get; set; }
        public Guid? RecordStorageId { get; set; }
        public string RecordLocationCode { get; set; }
        public string RecordLocationName { get; set; }
        public string RecordProductCode { get; set; }
        public string RecordProductName { get; set; }
        public string RecordBarcodes { get; set; }
        public string RecordProductUnitCode { get; set; }
        public string RecordProductUnitName { get; set; }
        public int? RecordTransferRate { get; set; }
        public decimal? RecordQuantity { get; set; }
        public Guid? RealPalletId { get; set; }
        public Guid? RealStorageId { get; set; }
		public string RealUniqueId { get; set; }
		public string RealLocationCode { get; set; }
        public string RealLocationName { get; set; }
        public string RealProductCode { get; set; }
        public string RealProductName { get; set; }
        public string RealBarcodes { get;  set; }
        public string RealProductUnitCode { get; set; }
        public string RealProductUnitName { get; set; }
        public int? RealTransferRate { get; set; }
        public decimal? RealQuantity { get; set; }
        public string InBatch { get; set; }
        public string UniqueId { get; set; }
        public InventoryBillDetailStatus InventoryBillDetailStatus { get; set; }
        public string InventoryUser { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }
        public string InventoryBillDetailStatusName { get; set; }
    }
}
