using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.IceFramework;
using Warehouse;
using Fusion.LYYC.PDA.Scanner.Model;

namespace Fusion.LYYC.PDA.Scanner.Proxy
{
    public class PartsOfAndroidServiceIceProxy
    {
        public IIceRuntime IceRuntime { get; set; }

        public PartsOfAndroidServiceIceProxy()
        {
            IceRuntime = new IceRuntime();
        }

        private PartsOfAndroidServicePrx getProxy()
        {
            return IceRuntime.getProxy<PartsOfAndroidServicePrx, PartsOfAndroidServicePrxHelper>("PartsOfAndroidService");
        }

        public StandardDataModel GetInventoryBillDetail(string barCode, int page, int start, int limit, string sort, string filter)
        {
            string result = getProxy().GetInventoryBillDetail(barCode, page, start, limit, sort, filter);
            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }

        public StandardDataModel UpdateInventoryBillDetail(string inventoryBillNo, string inventoryBillDetails)
        {
            string result = getProxy().UpdateInventoryBillDetail(inventoryBillNo, inventoryBillDetails);
            return JsonConvert.DeserializeObject<StandardDataModel>(result);
        }

    }
}
