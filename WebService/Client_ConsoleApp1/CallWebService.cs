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
        /// 调用接口
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="param">参数名称</param>
        /// <returns>返回值</returns>
        public string callWebService(string methodName, Dictionary<string, string> param)
        {

            ///获取请求数据
            byte[] data = getRequestData(methodName, param);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mUrl);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            string mSoapAction = "http://tempuri.org/" + methodName;
            request.Headers.Add("SOAPAction", mSoapAction);
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


        /// <summary>
        /// 获取请求内容(方法1) 适合 .Net
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public byte[] getRequestData(string methodName, Dictionary<string, string> param)
        {
            #region 以下是 SOAP 1.2 请求和响应示例。所显示的占位符需替换为实际值。HelloWorld()
            /*

             SOAP 1.1
以下是 SOAP 1.2 请求和响应示例。所显示的占位符需替换为实际值。

POST /WebService1.asmx HTTP/1.1
Host: localhost
Content-Type: text/xml; charset=utf-8
Content-Length: length
SOAPAction: "http://tempuri.org/HelloWorld"

<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <HelloWorld xmlns="http://tempuri.org/" />
  </soap:Body>
</soap:Envelope>
HTTP/1.1 200 OK
Content-Type: text/xml; charset=utf-8
Content-Length: length

<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <HelloWorldResponse xmlns="http://tempuri.org/">
      <HelloWorldResult>string</HelloWorldResult>
    </HelloWorldResponse>
  </soap:Body>
</soap:Envelope>
             */
            #endregion
            #region http://localhost:9090/WebService1.asmx?op=SayHello(string name)
            /*
SOAP 1.1
以下是 SOAP 1.2 请求和响应示例。所显示的占位符需替换为实际值。

POST /WebService1.asmx HTTP/1.1
Host: localhost
Content-Type: text/xml; charset=utf-8
Content-Length: length
SOAPAction: "http://tempuri.org/SayHello"

<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <SayHello xmlns="http://tempuri.org/">
      <name>string</name>
    </SayHello>
  </soap:Body>
</soap:Envelope>
HTTP/1.1 200 OK
Content-Type: text/xml; charset=utf-8
Content-Length: length

<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <SayHelloResponse xmlns="http://tempuri.org/">
      <SayHelloResult>string</SayHelloResult>
    </SayHelloResponse>
  </soap:Body>
</soap:Envelope>
             */
            #endregion
            StringBuilder requestData = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>")
              .Append("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">")
              .Append("  <soap:Body>")
              .Append("<").Append(methodName)
              .Append(" xmlns=\"http://tempuri.org/\">");
            foreach (KeyValuePair<string, string> item in param)
            {
                requestData.Append("<").Append(item.Key).Append(">")
                .Append(item.Value)
                .Append("</").Append(item.Key).Append(">");
            }
            requestData.Append("</").Append(methodName).Append(">")
            .Append("</soap:Body>")
            .Append("</soap:Envelope>");
            string val = requestData.ToString();
            byte[] data = Encoding.UTF8.GetBytes(val);
            return data;
        }

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
    }
}
