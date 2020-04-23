using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fusion.Infrastructure.Interface.Chinasoft.MES.V2.Utils
{
    public class WebServiceCallHelper
    {
        public static string mUrl = string.Empty;
        public WebServiceCallHelper(string url)
        {
            mUrl = url;
        }


        /// <summary>
        /// 使用SOAP 1.1访问WebService
        /// </summary>
        /// <param name="host">主机IP，可为localhost</param>
        /// <param name="soapMethodName">SOAPAction: "http://tempuri.org/transManufacturingFormula"中的transManufacturingFormula</param>
        /// <param name="methodName"></param>
        /// <param name="paramName">【methodName中的参数】</param>
        /// <param name="strReqXml"></param>
        /// <returns></returns>
        public string callWebServiceBySOAP11(string host, string soapMethodName, string methodName, string param1Name, string strReqXml)
        {
            ///获取请求数据
            StringBuilder requestData = new StringBuilder();
            requestData.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            requestData.Append("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"http://tempuri.org/\" xmlns:types=\"http://tempuri.org/encodedTypes\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            requestData.Append("  <soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            requestData.Append("    <tns:" + methodName + ">");
            requestData.Append("      <" + param1Name + " xsi:type=\"xsd:string\">" + strReqXml + "</" + param1Name + ">");
            requestData.Append("    </tns:" + methodName + ">");
            requestData.Append("  </soap:Body>");
            requestData.Append("</soap:Envelope>");
            
            byte[] data = Encoding.UTF8.GetBytes(requestData.ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrl);
            request.Method = "POST";
            request.Host = host;
            request.ContentType = "text/xml; charset=utf-8";
            string mSoapAction = "http://tempuri.org/" + soapMethodName;
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
        public string callWebServiceBySOAP12(string host, string soapMethodName, string methodName, string param1Name, string strReqXml)
        {
            ///获取请求数据
            StringBuilder requestData = new StringBuilder();
            requestData.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            requestData.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenc=\"http://www.w3.org/2003/05/soap-encoding\" xmlns:tns=\"http://tempuri.org/\" xmlns:types=\"http://tempuri.org/encodedTypes\" xmlns:rpc=\"http://www.w3.org/2003/05/soap-rpc\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
            requestData.Append("  <soap12:Body soap12:encodingStyle=\"http://www.w3.org/2003/05/soap-encoding\">");
            requestData.Append("    <tns:" + methodName + ">");
            requestData.Append("      <" + param1Name + " xsi:type=\"xsd:string\">" + strReqXml + "</" + param1Name + ">");
            requestData.Append("    </tns:" + methodName + ">");
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

        public string callWebServiceByHTTP(string host, string methodName, string param1Name, string strReqXml)
        {
            ///获取请求数据
            StringBuilder requestData = new StringBuilder();
            requestData.Append(param1Name + "=" + strReqXml);

            byte[] data = Encoding.UTF8.GetBytes(requestData.ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrl + "/" + methodName);
            request.Method = "POST";
            request.Host = host;
            request.ContentType = "application/x-www-form-urlencoded";
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

    }
}
