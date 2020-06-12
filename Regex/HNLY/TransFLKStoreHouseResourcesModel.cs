using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fusion.WebService.ChinaSoft.MES.V2.Models.Utils;

namespace Fusion.WebService.ChinaSoft.MES.V2.Models.FLKModel
{
    [Description("T_WLPT_FLK_KGZY")]
    public class TransFLKStoreHouseResourcesModel
    {
        [HeadFieldItemModel("主键", "True", "必传(主键)", "30", "CHAR")]
        public string ID { get; set; }

        [HeadFieldItemModel("总货位数", "False", "", "10.4", "NUMBER")]
        public string TOTAL_GOODS_AMOUNT { get; set; }

        [HeadFieldItemModel("总托盘数", "False", "", "10.4", "NUMBER")]
        public string TOTAL_TRAY_AMOUNT { get; set; }

        [HeadFieldItemModel("已用货位数", "False", "", "10.4", "NUMBER")]
        public string USED_GOODS_AMOUNT { get; set; }

        [HeadFieldItemModel("已用托盘数", "False", "", "10.4", "NUMBER")]
        public string USED_TRAY_AMOUNT { get; set; }
    }
}
