using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.Integration.Helper
{
    /// <summary>
    /// 传递Xml规范的消息头类定义
    /// </summary>
    public class XMLHead
    {
        /// <summary>
        /// 消息编码
        /// </summary>
        public string msg_id;

        /// <summary>
        /// Webservice服务名
        /// </summary>
        public string ws_mark;

        /// <summary>
        /// Webservice方法名
        /// </summary>
        public string ws_method;

        /// <summary>
        /// Webservice方法中的参数值
        /// </summary>
        public string ws_param;

        /// <summary>
        /// 消息发送时间
        /// </summary>
        public string curr_time;

        /// <summary>
        /// 消息User
        /// </summary>
        public string curr_user;

        /// <summary>
        ///<!--反馈用（0-成功，1失败）-->
        /// </summary>
        public string state_code;

        /// <summary>
        ///<!---失败原因-）-->
        /// </summary>
        public string state_desc;
    }
}
