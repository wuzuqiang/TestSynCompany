using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client_ConsoleApp1
{
    public class WebServiceCall
    {
        public static string mUrl = string.Empty;
        public WebServiceCall(string url)
        {
            mUrl = url;
        }
        
        
        /// <summary>
        /// 使用SOAP 1.1访问WebService
        /// </summary>
        /// <param name="host">主机IP，可为localhost</param>
        /// <param name="methodName"></param>
        /// <param name="strReqXml"></param>
        /// <returns></returns>
        public string callWebServiceBySOAP11(string host, string methodName, string strReqXml)
        {
            ///获取请求数据
            StringBuilder requestData = new StringBuilder();
            requestData.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            requestData.Append("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://tempuri.org/\" xmlns:types=\"http://tempuri.org/encodedTypes\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            requestData.Append("  <soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            requestData.Append("    <tns:JBSC_SCGL_GDQX>");
            requestData.Append("      <reqXml xsi:type=\"xsd:string\">" + strReqXml + "</reqXml>");
            requestData.Append("    </tns:JBSC_SCGL_GDQX>");
            requestData.Append("  </soap:Body>");
            requestData.Append("</soap:Envelope>");
            
            byte[] data = Encoding.UTF8.GetBytes(requestData.ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrl);
            request.Method = "POST";
            request.Host = host;
            request.ContentType = "text/xml; charset=utf-8";
            string mSoapAction = "http://tempuri.org/" + methodName;
            request.Headers.Add("SOAPAction", mSoapAction);
            //request.ProtocolVersion = HttpVersion.Version11;
            //request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentLength = data.Length;
            Stream rStream = request.GetRequestStream();
            rStream.Write(data, 0, data.Length);
            rStream.Close();

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string result = reader.ReadToEnd();

            dataStream.Close();
            response.Close();
            return result;
        }
        public string callWebServiceBySOAP12(string host, string methodName, string strReqXml)
        {
            ///获取请求数据
            StringBuilder requestData = new StringBuilder();
            requestData.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            requestData.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenc=\"http://www.w3.org/2003/05/soap-encoding\" xmlns:tns=\"http://tempuri.org/\" xmlns:types=\"http://tempuri.org/encodedTypes\" xmlns:rpc=\"http://www.w3.org/2003/05/soap-rpc\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
            requestData.Append("  <soap12:Body soap12:encodingStyle=\"http://www.w3.org/2003/05/soap-encoding\">");
            requestData.Append("    <tns:JBSC_SCGL_GDQX>");
            requestData.Append("      <reqXml xsi:type=\"xsd:string\">" + strReqXml + "</reqXml>");
            requestData.Append("    </tns:JBSC_SCGL_GDQX>");
            requestData.Append("  </soap12:Body>");
            requestData.Append("</soap12:Envelope>");
            
            byte[] data = Encoding.UTF8.GetBytes(requestData.ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrl);
            request.Method = "POST";
            request.Host = host;
            request.ContentType = "application/soap+xml; charset=utf-8";
            request.ContentLength = data.Length;
            Stream rStream = request.GetRequestStream();
            rStream.Write(data, 0, data.Length);
            rStream.Close();

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string result = reader.ReadToEnd();

            dataStream.Close();
            response.Close();
            return result;
        }

        #region //网页上http://localhost:8085/MesToFLKService.asmx?op=JBSC_SCGL_GDQX上显示的内容
        //        #region //网页上http://localhost:8085/MesToFLKService.asmx?op=JBSC_SCGL_GDQX上显示的内容
        //        SOAP 1.1
        //以下是 SOAP 1.2 请求和响应示例。所显示的占位符需替换为实际值。

        //POST /MesToFLKService.asmx HTTP/1.1
        //Host: localhost
        //Content-Type: text/xml; charset=utf-8
        //Content-Length: length
        //SOAPAction: "http://tempuri.org/transManufacturingFormula"

        //<?xml version = "1.0" encoding="utf-8"?>
        //<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:tns="http://tempuri.org/" xmlns:types="http://tempuri.org/encodedTypes" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
        //  <soap:Body soap:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
        //    <tns:JBSC_SCGL_GDQX>
        //      <reqXml xsi:type="xsd:string">string</reqXml>
        //    </tns:JBSC_SCGL_GDQX>
        //  </soap:Body>
        //</soap:Envelope>
        //HTTP/1.1 200 OK
        //Content-Type: text/xml; charset=utf-8
        //Content-Length: length

        //<?xml version="1.0" encoding="utf-8"?>
        //<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:tns="http://tempuri.org/" xmlns:types="http://tempuri.org/encodedTypes" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
        //  <soap:Body soap:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
        //    <tns:JBSC_SCGL_GDQXResponse>
        //      <JBSC_SCGL_GDQXResult xsi:type="xsd:string">string</JBSC_SCGL_GDQXResult>
        //    </tns:JBSC_SCGL_GDQXResponse>
        //  </soap:Body>
        //</soap:Envelope>
        //SOAP 1.2
        //以下是 SOAP 1.2 请求和响应示例。所显示的占位符需替换为实际值。

        //POST /MesToFLKService.asmx HTTP/1.1
        //Host: localhost
        //Content-Type: application/soap+xml; charset=utf-8
        //Content-Length: length

        //<?xml version="1.0" encoding="utf-8"?>
        //<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://www.w3.org/2003/05/soap-encoding" xmlns:tns="http://tempuri.org/" xmlns:types="http://tempuri.org/encodedTypes" xmlns:rpc="http://www.w3.org/2003/05/soap-rpc" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
        //  <soap12:Body soap12:encodingStyle="http://www.w3.org/2003/05/soap-encoding">
        //    <tns:JBSC_SCGL_GDQX>
        //      <reqXml xsi:type="xsd:string">string</reqXml>
        //    </tns:JBSC_SCGL_GDQX>
        //  </soap12:Body>
        //</soap12:Envelope>
        //HTTP/1.1 200 OK
        //Content-Type: application/soap+xml; charset=utf-8
        //Content-Length: length

        //<?xml version="1.0" encoding="utf-8"?>
        //<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://www.w3.org/2003/05/soap-encoding" xmlns:tns="http://tempuri.org/" xmlns:types="http://tempuri.org/encodedTypes" xmlns:rpc="http://www.w3.org/2003/05/soap-rpc" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
        //  <soap12:Body soap12:encodingStyle="http://www.w3.org/2003/05/soap-encoding">
        //    <tns:JBSC_SCGL_GDQXResponse>
        //      <rpc:result xmlns = "" > JBSC_SCGL_GDQXResult </ rpc:result>
        //      <JBSC_SCGL_GDQXResult xsi:type="xsd:string">string</JBSC_SCGL_GDQXResult>
        //    </tns:JBSC_SCGL_GDQXResponse>
        //  </soap12:Body>
        //</soap12:Envelope>
        //HTTP POST
        //以下是 HTTP POST 请求和响应示例。所显示的占位符需替换为实际值。

        //POST /MesToFLKService.asmx/JBSC_SCGL_GDQX HTTP/1.1
        //Host: localhost
        //Content-Type: application/x-www-form-urlencoded
        //Content-Length: length

        //reqXml = string
        //HTTP/1.1 200 OK
        //Content-Type: text/xml; charset=utf-8
        //Content-Length: length

        //<?xml version="1.0" encoding="utf-8"?>
        //<string xmlns = "http://tempuri.org/" > string </ string >
        //        #endregion
        #endregion

        #region 原先网络上的方法
        /// <summary>
        /// 获取数据(方法2) 兼容所有的(java soap 服务端和.net  soap 服务端)
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public byte[] getRequestDataALL(string methodName, Dictionary<string, string> param)
        {
            StringBuilder requestBuider = new StringBuilder();
            requestBuider.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:icc=\"http://pub.ccgb.so.itf.nc/ICCGBHAService\">");
            requestBuider.Append("<soapenv:Header/>");
            requestBuider.Append("<soapenv:Body>");
            requestBuider.Append("<icc:").Append(methodName).Append(">");
            foreach (KeyValuePair<string, string> item in param)
            {
                requestBuider.Append("<").Append(item.Key).Append(">");
                requestBuider.Append(item.Value);
                requestBuider.Append("</").Append(item.Key).Append(">");
            }
            requestBuider.Append("</icc:").Append(methodName).Append(">");
            requestBuider.Append("</soapenv:Body>");
            requestBuider.Append("</soapenv:Envelope>");
            string val = requestBuider.ToString();
            byte[] data = Encoding.UTF8.GetBytes(val);
            return data;
        }
        #endregion

    }
}
