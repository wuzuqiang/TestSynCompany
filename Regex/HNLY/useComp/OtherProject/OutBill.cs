using System;
using System.Collections.Generic;
using System.Linq;

namespace Fusion.Context.Warehouse.Domain.Models.Bill.OutBills
{
    public class OutBill
    {
        public OutBill()
        {
        }

        public OutBill(
            string OutBillNo,
            string BillTypeCode,
            string WarehouseCode,
            string Maker,
            DateTime MakeTime,
            //OutBillStatus OutBillStatus = OutBillStatus.Entered,
            //OutBillOrigin OutBillOrigin = OutBillOrigin.Hand,

            string OriginBillNo = "",
            string Auditor = "",
            DateTime? AuditTime = null,
            string SyncMoveBillNo = "",
            string StationCode = "",
            string InBatch = "",
            string CargoOwnerCode = "",
            string CargoOwnerName = "",
           string Remark = "")
        {
            this.OutBillNo = OutBillNo;
            this.OriginBillNo = OriginBillNo;
            this.BillTypeCode = BillTypeCode;
            this.WarehouseCode = WarehouseCode;
            this.Maker = Maker;
            if (MakeTime == DateTime.MinValue)
            {
                this.MakeTime = DateTime.Now;
            }
            else
            {
                this.MakeTime = MakeTime;
            }
            this.Auditor = Auditor;
            this.AuditTime = AuditTime;
            this.SyncMoveBillNo = SyncMoveBillNo;
            this.StationCode = StationCode;
            this.InBatch = InBatch;
            this.CargoOwnerCode = CargoOwnerCode;
            this.CargoOwnerName = CargoOwnerName;
            //this.OutBillStatus = OutBillStatus;
            //this.OutBillOrigin = OutBillOrigin;
            this.Remark = Remark;

            //this.OutBillDetails = new List<OutBillDetail>();
        }

        public string OutBillNo { get; private set; }
        public string OriginBillNo { get; private set; }
        public string BillTypeCode { get; private set; }
        public string WarehouseCode { get; private set; }
        public string Maker { get; private set; }
        public DateTime MakeTime { get; private set; }
        public string Auditor { get; private set; }
        public DateTime? AuditTime { get; private set; }
        public string SyncMoveBillNo { get; private set; }
        public string StationCode { get; private set; }
        public string InBatch { get; private set; }
        public string CargoOwnerCode { get; private set; }
        public string CargoOwnerName { get; private set; }
        //public OutBillStatus OutBillStatus { get; private set; }
        //public OutBillOrigin OutBillOrigin { get; private set; }
        public string Remark { get; private set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }

        public void Modify(OutBill outBill)
        {
            if (this.RowVersion.Except(outBill.RowVersion).Count() > 0)
            {
                throw new Exception("记录已被修改，请刷新！");
            }

            this.BillTypeCode = outBill.BillTypeCode;
            this.WarehouseCode = outBill.WarehouseCode;
            this.Maker = outBill.Maker;
            this.MakeTime = outBill.MakeTime;
            this.StationCode = outBill.StationCode;
            this.InBatch = outBill.InBatch;
            this.CargoOwnerCode = outBill.CargoOwnerCode;
            this.CargoOwnerName = outBill.CargoOwnerName;
            this.Remark = outBill.Remark;
        }
    }
}
