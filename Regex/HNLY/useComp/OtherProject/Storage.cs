using System;
using System.Collections.Generic;
using System.Linq;

namespace Fusion.Context.Warehouse.Domain.Models.Warehouse.Locations
{
    public class Storage
    {
        public Storage() { }

        public Storage(
         Guid id,
         string locationCode,
         Guid palletId,
         string productCode,
         string productName,
         DateTime storageTime,
         string inBillNo,
         decimal storageQuantity = 0,
         decimal inFrozenQuantity = 0,
         decimal outFrozenQuantity = 0,
         bool sampling = false,

         string freezeBillNos = null,
         string lockTag = null,
         string barcodes = null,
         string boxNos = null,
         string cargoOwnerCode = null,
         string cargoOwnerName = null,
         string userDefine = null,
         string inBatch = null,
         string productYear = null,
         string workOrder = null,
         string colorCode = null,
         string colorName = null,
         string sizeCode = null,
         string sizeName = null
        )
        {
            this.Id = id;
            this.PalletId = palletId;
            this.LocationCode = locationCode;
            this.ProductCode = productCode;
            this.ProductName = productName;
            this.ProductYear = productYear;
            //this.Barcodes = barcodes.ReAggregate();
            //this.BoxNos = boxNos.ReAggregate();
            this.Sampling = sampling;
            this.StorageQuantity = storageQuantity;
            if (storageTime == DateTime.MinValue)
            {
                this.StorageTime = new DateTime(1990, 1, 1, 0, 0, 0);
            }
            else
            {
                this.StorageTime = storageTime;
            }
            this.InFrozenQuantity = inFrozenQuantity;
            this.OutFrozenQuantity = outFrozenQuantity;
            this.FreezeBillNos = freezeBillNos;
            this.LockTag = lockTag;
            this.CargoOwnerCode = cargoOwnerCode;
            this.CargoOwnerName = cargoOwnerName;
            this.UserDefine = userDefine;
            this.InBatch = inBatch;
            this.InBillNo = inBillNo;
            this.WorkOrder = workOrder;
            this.ColorCode = colorCode;
            this.ColorName = colorName;
            this.SizeCode = sizeCode;
            this.SizeName = sizeName;
            
        }

        public Guid Id { get; private set; }
        public Guid PalletId { get; private set; }
        public string LocationCode { get; private set; }
        public string ProductCode { get; private set; }
        public string ProductName { get; private set; }
        public string ProductYear { get; private set; }
        public string Barcodes { get; private set; }
        public string BoxNos { get; private set; }
        public bool Sampling { get; private set; }
        public decimal StorageQuantity { get; private set; }
        public DateTime StorageTime { get; private set; }
        public decimal InFrozenQuantity { get; private set; }
        public decimal OutFrozenQuantity { get; private set; }
        public string FreezeBillNos { get; private set; }
        public string LockTag { get; private set; }
        public string IdentityTag { get; private set; }
        public string UnlockTag { get; private set; }
        public string CargoOwnerCode { get; private set; }
        public string CargoOwnerName { get; private set; }
        public string UserDefine { get; private set; }
        public string InBatch { get; private set; }
        public string InBillNo { get; private set; }
        public string WorkOrder { get; private set; }
        public string ColorCode { get; private set; }
        public string ColorName { get; private set; }
        public string SizeCode { get; private set; }
        public string SizeName { get; private set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }
        
    }
}