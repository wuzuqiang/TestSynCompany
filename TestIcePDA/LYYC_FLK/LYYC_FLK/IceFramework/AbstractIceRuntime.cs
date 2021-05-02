using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ice;

namespace Fusion.LYYC.PDA.Scanner.IceFramework
{
    public abstract class AbstractIceRuntime : IIceRuntime
    {
        private Communicator communicator = null;

        public abstract string Locator { get; }

        public AbstractIceRuntime()
        {
            if (communicator == null)
            {
                InitializationData initdata = new InitializationData();

                initdata.properties = Util.createProperties();
                initdata.properties.setProperty("Ice.Default.Locator", this.Locator);
                initdata.properties.setProperty("Ice.MessageSizeMax", "102400");
                initdata.properties.setProperty("Ice.ACM.Client", "0");

                communicator = Util.initialize(initdata);
            }
        }

        public Communicator Communicator()
        {
            return communicator;
        }

        public ServicePrx getProxy<ServicePrx, ServicePrxHelper>(string identity)
            where ServicePrxHelper : ObjectPrxHelperBase, new()
            where ServicePrx : class
        {

            ObjectPrx obj = Communicator().stringToProxy(identity);
            return uncheckedCast<ServicePrx, ServicePrxHelper>(obj);

        }

        public ServicePrx uncheckedCast<ServicePrx, ServicePrxHelper>(ObjectPrx objPrx)
            where ServicePrxHelper : ObjectPrxHelperBase, new()
            where ServicePrx : class
        {
            if (objPrx == null)
            {
                return null;
            }
            ServicePrx r = objPrx as ServicePrx;
            if (r == null)
            {
                ServicePrxHelper h = new ServicePrxHelper();
                h.copyFrom__(objPrx);
                r = h as ServicePrx;
            }
            return r;
        }
    }
}
