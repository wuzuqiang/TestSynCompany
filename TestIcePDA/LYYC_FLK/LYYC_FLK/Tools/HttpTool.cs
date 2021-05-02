using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Fusion.LYYC.PDA.Scanner.Tools
{
    public class HttpTool
    {
        public static int TIMEOUT = 10 * 100000;
        public static string HttpPost(string Url, string postDataStr)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postDataStr); //转化

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            request.Timeout = TIMEOUT;
            request.ReadWriteTimeout = TIMEOUT;
            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(byteArray, 0, byteArray.Length);//写入参数

            myRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();



            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.Timeout = TIMEOUT;
            request.ReadWriteTimeout = TIMEOUT;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}
