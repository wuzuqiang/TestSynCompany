//using Common.Logging;
using Fusion.Context.Warehouse.Domain.Models.Bill.OutBills;
using Fusion.Context.Warehouse.Domain.Models.Warehouse.Locations;
using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Models.YSKModel;
using Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Utils;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Services.YSK
{
    //[Export]
    public class YSKToMesAdapter
    {
        //static ILog Logger = LogManager.GetLogger(typeof(YSKToMesAdapter));
        //[Import]
        public YSKToMesTranslator Translator = new YSKToMesTranslator();

        /// <summary>
        /// 烟丝立库上传工单执行情况
        /// </summary>
        /// <returns></returns>
        public void AdapterTransOutBillState(OutBill outBill, List<Storage> storages)
        {
            try
            {
                var requestHeaderXml = Translator.RequestHeaderXml("ESB_LYMES_WLPT_YSK_GDZXQK", "transSilkOutDetail", "立库工单执行情况");
                var translaEnt = Translator.GetTransOutbillStateModel(outBill, storages);

                var reqXml = TranslatorHelper.CreateResXml(translaEnt, requestHeaderXml);

               //Logger.Debug("烟丝立库上传reqXml：" + reqXml);
                //var resXml = WebServiceImport.ServiceInstance.transSilkOutDetail(reqXml);
               //Logger.Debug("烟丝立库上传resXml：" + resXml);

                //var xmlHeader = TranslatorHelper.AnalysisHeaderXml(resXml);

                //if (!xmlHeader.StateCode.Contains("600"))
                //{
                //    throw new Exception(xmlHeader.StateDesription);
                //}
            }
            catch (Exception e)
            {
               //Logger.Error(e);
                throw;
            }
        }
    }
}

