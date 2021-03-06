﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WeChatPlatform.API;
using WeChatPlatform.Config;

namespace WeChatPlatform
{
    public class Until
    {
        public static double GetTimeSpan(double Min = 0)
        {     
            TimeSpan ts = DateTime.Now.AddMinutes(Min).ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ts.TotalSeconds;
        }

        /// <summary>
        /// 拼接URL方法
        /// </summary>
        /// <param name="partUrl">发起请求的部分URL</param>
        /// <returns>拼接完成后的URL</returns>
        public static string CreateUrl(string partUrl)
        {
            //if (UserConfig.tokenInfo.Token == null || UserConfig.tokenInfo.Token == "")
            //{
            //    throw new Exception("未获取有效Token");
            //}
            //else if (!(Until.GetTimeSpan()<UserConfig.expireTime))
            //{
            //    Token.GetToken();
            //    return "https://" + UrlConfig.BaseApiURL + partUrl + UserConfig.token;
            //}
            //else
            //{
                return "https://" + UrlConfig.BaseApiURL + partUrl + Token.GetValidToken();
            //}
        }


        public static string GetJsonValue(string key)
        {
            using (System.IO.StreamReader file = System.IO.File.OpenText(System.IO.Directory.GetCurrentDirectory() + "\\appsettings.json"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    string value = o[key].ToString();
                    return value;
                }
            }
        }
    }
}
