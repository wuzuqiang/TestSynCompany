﻿using System;
using System.Collections.Generic;
using Fusion.LYYC.PDA.Scanner.Tools;
using Fusion.LYYC.PDA.Scanner.Model;
using Newtonsoft.Json;
using Fusion.LYYC.PDA.Scanner.Proxy;
using Fusion.LYYC.PDA.Scanner.Interface;

namespace Fusion.LYYC.PDA.Scanner.Service
{
    public class InventoryService
    {
        PartsOfAndroidServiceIceProxy PartsOfAndroidServiceIceProxy = null;
        public InventoryService()
        {
            PartsOfAndroidServiceIceProxy = new PartsOfAndroidServiceIceProxy();
        }

        public List<InventoryBillDetailModel> GetInventoryBillDetail(string barCode)
        {
            var list = new List<InventoryBillDetailModel>();
            try
            {
                var standardDataModel = PartsOfAndroidServiceIceProxy.GetInventoryBillDetail(barCode, 1, 0, int.MaxValue, "", "");
                if (!standardDataModel.success)
                {
                    throw new Exception(standardDataModel.msg);
                }
                list = (List<InventoryBillDetailModel>)standardDataModel.data;
            }
            catch (Exception ex)
            {
                throw new Exception("出现异常，异常信息：" + ex.Message);
            }

            return list;
        }

    }
}
