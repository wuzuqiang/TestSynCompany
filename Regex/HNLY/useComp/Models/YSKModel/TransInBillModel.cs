using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.Utils;
using System.Collections.Generic;
using System.ComponentModel;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.YSKModel
{
    [Description("T_WLPT_YSRK_M")]
    public class TransInBillModel
    {
        [HeadFieldItemModel("ID", "True", "必传(主键)", "30", "CHAR")]
        public string ID { get; set; }

        [HeadFieldItemModel("单据编号", "False", "必传(主键)", "50", "CHAR")]
        public string ORDER_NO { get; set; }

        [HeadFieldItemModel("烟丝类型", "False", "必传1=成品、2=膨丝、3=薄片", "10", "CHAR")]
        public string SILK_TYPE { get; set; }

        [HeadFieldItemModel("发货工厂代码", "False", "必传", "20", "CHAR")]
        public string FROM_FAC_CD { get; set; }

        [HeadFieldItemModel("接收人姓名", "False", "必传", "50", "CHAR")]
        public string RECEIVER { get; set; }

        [HeadFieldItemModel("入库日期", "False", "必传(格式:yyyy-MM-dd hh24:mi:ss)", "19", "DATE")]
        public string PRODUCTDATE { get; set; }

        [Description("T_WLPT_YSRK_D")]
        public virtual IList<TransInBillDetailModel> TransInBillDetailModels { get; set; } = new List<TransInBillDetailModel>();
    }
}
