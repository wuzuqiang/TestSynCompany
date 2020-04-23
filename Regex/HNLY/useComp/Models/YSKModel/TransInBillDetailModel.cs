using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.Utils;
using System.ComponentModel;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.YSKModel
{
    public class TransInBillDetailModel
    {
        [HeadFieldItemModel("主键", "True", "必传(复合主键)", "30", "CHAR")]
        public string WLPT_YSRK_D_ID { get; set; }

        [HeadFieldItemModel("主表ID", "False", "必传(复合主键)", "30", "CHAR")]
        public string ParentID { get; set; }

        [HeadFieldItemModel("烟箱编号", "False", "必传(复合主键)", "30", "CHAR")]
        public string BOX_NO { get; set; }

        [HeadFieldItemModel("烟丝生产批次号", "False", "必传", "50", "CHAR")]
        public string BATCH_CODE { get; set; }

        [HeadFieldItemModel("烟丝编码", "False", "必传", "20", "CHAR")]
        public string MAT_ID { get; set; }

        [HeadFieldItemModel("烟丝名称", "False", "必传", "50", "CHAR")]
        public string MAT_NAME { get; set; }

        [HeadFieldItemModel("储丝柜编号", "False", "必传发货厂储丝柜，可选", "50", "CHAR")]
        public string CABINET_NO { get; set; }

        [HeadFieldItemModel("烟丝净重", "False", "公斤，小数点前四位，后两位", "10.4", "NUMBER")]
        public string NET_WEIGHT { get; set; }

        [HeadFieldItemModel("烟箱实际总重量", "False", "公斤，小数点前四位，后两位", "10.4", "NUMBER")]
        public string GROSS_WEIGHT { get; set; }

        [HeadFieldItemModel("烟箱入库顺序号", "False", "必传", "20", "CHAR")]
        public string IN_SEQ { get; set; }

        [HeadFieldItemModel("车牌号", "False", "必传", "10", "CHAR")]
        public string VEHICLE_NUM { get; set; }

        [HeadFieldItemModel("烟丝装箱开始时间", "False", "必传(格式:yyyy-MM-dd hh24:mi:ss)", "19", "DATE")]
        public string PACK_START_TIME { get; set; }

        [HeadFieldItemModel("烟丝装箱结束时间", "False", "必传(格式:yyyy-MM-dd hh24:mi:ss)", "19", "DATE")]
        public string PACK_END_TIME { get; set; }

        [HeadFieldItemModel("烟丝外运开始时间", "False", "必传(格式:yyyy-MM-dd hh24:mi:ss)", "19", "DATE")]
        public string SHIP_START_TIME { get; set; }

        [HeadFieldItemModel("烟丝外运结束时间", "False", "必传(格式:yyyy-MM-dd hh24:mi:ss)", "19", "DATE")]
        public string SHIP_END_TIME { get; set; }

        [HeadFieldItemModel("烟丝生产日期", "False", "必传(格式:yyyy-MM-dd)", "19", "DATE")]
        public string PROD_DATE { get; set; }
    }
}
