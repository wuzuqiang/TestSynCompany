using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.Utils;
using System.ComponentModel;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.YSKModel
{
    [Description("T_WLPT_YSK_GDZXQK")]
    public class TransOutbillStateModel
    {
        [HeadFieldItemModel("ID", "True", "必传(主键)", "30", "CHAR")]
        public string ID { get; set; }

        [HeadFieldItemModel("工单号", "False", "必传", "30", "CHAR")]
        public string WO_NO { get; set; }

        [HeadFieldItemModel("工单状态", "False", "必传", "25", "CHAR")]
        public string WO_STATUS { get; set; }

        [HeadFieldItemModel("烟丝箱号", "False", "必传", "25", "CHAR")]
        public string BOX_NO { get; set; }

        [HeadFieldItemModel("发生时间", "False", "必传(格式:yyyy-MM-dd hh24:mi:ss)", "19", "DATE")]
        public string OP_TIME { get; set; }

        [HeadFieldItemModel("重量", "False", "必传(单位为万支)", "16.2", "NUMBER")]
        public string WEIGHT_AMOUNT { get; set; }
    }
}
