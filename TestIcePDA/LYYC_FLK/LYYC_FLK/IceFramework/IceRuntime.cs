
namespace Fusion.LYYC.PDA.Scanner.IceFramework
{
    public class IceRuntime : AbstractIceRuntime
    {
        public override string Locator
        {
            get
            {
                //return "IceGrid/Locator:default -h 172.30.20.54 -p 12000:default -h 172.30.20.55 -p 12000";
                return "IceGrid/Locator:default -h 172.30.10.22 -p 12000:default -h 199.199.180.6 -p 12000"; //本地ICE服务
            }
        }
    }
}
