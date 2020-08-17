using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WindowsFormsApp1;

namespace Fusion.Desktop.GZTR.TV
{
    public class HttpUtil
    {
        private static string LEDURL = ConfigurationManager.AppSettings["LEDURL"];


        public static T HttpRequest<T>(string url)
        {
            Uri baseAddress = new Uri(LEDURL);
            Uri address = new Uri(baseAddress, url);

            HttpWebRequest request;
            HttpWebResponse response;

            request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = "get";

            response = (HttpWebResponse)request.GetResponse();
            StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();

            var result = JsonConvert.DeserializeObject<StandardDataModel<T>>(responseText);
            if (result.success)
            {
                return result.data;
            }
            else
            {
                throw new Exception(result.msg);
            }
        }
    }
}
