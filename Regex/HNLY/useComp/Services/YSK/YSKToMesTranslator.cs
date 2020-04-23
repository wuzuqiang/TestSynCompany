using Fusion.Context.Warehouse.Domain.Models.Bill.OutBills;
using Fusion.Context.Warehouse.Domain.Models.Warehouse.Locations;
using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models;
using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.YSKModel;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Services.YSK
{
    [Export(typeof(YSKToMesTranslator))]
    public class YSKToMesTranslator
    {
        /// <summary>
        /// 服务标识
        /// </summary>
        internal const string server_mark = "ESB_LYMES_JBSC";
        internal const string tableName = "T_WLPT_YSK_GDZXQK";

        #region 烟丝库上传工单执行情况
        /// <summary>
        /// 烟丝库上传工单执行情况 
        /// </summary>
        /// <returns></returns>
        public List<TransOutbillStateModel> GetTransOutbillStateModel(OutBill outBill, List<Storage> storages)
        {
            var transOutbillStateModel = new List<TransOutbillStateModel>();
            for(int i = 0; i < 3; i++)
            {
                var temp = new TransOutbillStateModel
                {
                    ID = Guid.NewGuid().ToString(),
                    WO_NO = outBill.OriginBillNo,
                    WO_STATUS = "2",
                    BOX_NO = i++.ToString(),
                    OP_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    WEIGHT_AMOUNT = "WEIGHT_AMOUNT",
                };
                transOutbillStateModel.Add(temp);
            }
            return transOutbillStateModel.ToList();
        }
        #endregion

        #region New
        internal XmlOutput RequestHeaderXml(string interfaceCode, string methodName, string methodDesc, string stateCode = "600", string stateDesc = "正常发送")
        {
            return new XmlOutput
            {
                InterfaceCode = interfaceCode,
                InterfaceDescription = methodDesc,
                MsgID = Guid.NewGuid().ToString(),
                Source = "ESB",
                MsgMark = server_mark,
                WsMethod = methodName,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                User = "WLPTYSK",
                Cryp = "",
                StateCode = stateCode,
                StateDesription = stateDesc,
            };
        }
        #endregion
    }
}
