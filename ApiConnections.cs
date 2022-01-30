using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0
{
    internal class APIConnections
    {
        public static JObject GET(string url)
        {
            WebRequest requestObj = WebRequest.Create(url);
            requestObj.Method = "GET";
            HttpWebResponse responseObj = null;
            responseObj = (HttpWebResponse)requestObj.GetResponse();

            string strresult = null;
            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }

            JObject json = JObject.Parse(strresult);
            return json;
        }

        public static JObject POST(string url, string parameters)
        {
            WebRequest requestObj = WebRequest.Create(url);
            requestObj.Method = "POST";
            requestObj.ContentType = "application/json";

            string postData = parameters;
            string rtnResult = null;

            using (var streamWrite = new StreamWriter(requestObj.GetRequestStream()))
            {
                streamWrite.Write(postData);
                streamWrite.Flush();
                streamWrite.Close();

                var httpResponse = (HttpWebResponse)requestObj.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    rtnResult = streamReader.ReadToEnd();
                }
            }

            JObject json = JObject.Parse(rtnResult);
            return json;
        }
    }
}
