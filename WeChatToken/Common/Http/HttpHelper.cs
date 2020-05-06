using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeChatToken.Common.Http
{
    public class HttpHelper
    {
        /*
         *  url:POST请求地址
         *  postData:json格式的请求报文,例如：{"key1":"value1","key2":"value2"}
         */
        public static string PostJson(string url, string postData = null,string headerAuth = null)
        {
            return PostJsonSync(url, postData,headerAuth).Result;
        }
        public static async Task<string> PostJsonSync(string url, string postData = null,string headerAuth = null)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = 5000;//设置请求超时时间，单位为毫秒
            req.Accept = "application/json";
            req.ContentType = "application/json;charset=utf-8";
            if (!string.IsNullOrEmpty(headerAuth))
            {
                req.Headers.Add("Authorization",headerAuth);
            }
            if (!string.IsNullOrEmpty(postData))
            {
                byte[] data = Encoding.UTF8.GetBytes(postData);
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
            }
            Task<WebResponse> resp = req.GetResponseAsync();
            Stream stream = resp.GetAwaiter().GetResult().GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

    }
}
