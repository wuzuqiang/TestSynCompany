using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ice;

namespace Fusion.LYYC.PDA.Scanner.IceFramework
{
    public interface IIceRuntime
    {
        Communicator Communicator();

        ServicePrx getProxy<ServicePrx, ServicePrxHelper>(string identity)
            where ServicePrxHelper : ObjectPrxHelperBase, new()
            where ServicePrx : class;
    }
}
