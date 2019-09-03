using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassUtils
{
    public class HttpHelper_V0
    {
        //默认的编码
        private Encoding encoding = Encoding.Default;
        //
        public HttpHelper_V0()
        {
            //最大连接数
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
        }


    }

    #region public class
    public class HttpItem_V0
    {
        //请求URL，必须填写
        public string URL { get; set; }
        string _Method = "GET";
        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }
        int _Timeout = 100000;
        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }
        int _ReadWriteTimeout = 30000;
        public int ReadWriteTimeout
        {
            get { return _ReadWriteTimeout; }
        }
    }
    #endregion
}
