using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
    public class HttpHelper
    {
        //默认的编码
        private Encoding encoding = Encoding.Default;
        //
        public HttpHelper()
        {

        }

        private static readonly ILog logger = LogManager.GetLogger<HttpHelper>();
        //public HttpResult GetHtml(HttpItem item)
        //{

        //}

        public static void Test()
        {
            logger.Info("test--------------------");
        }
    }
}
