﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WeChatPlatform.Config;

namespace WeChatPlatform.API
{
    public class Token
    {
        public static string GetValidToken()
        {
            if (UserConfig.tokenInfo == null || !UserConfig.tokenInfo.IsValid ||
                DateTime.Now.AddMinutes(1.8) > UserConfig.tokenInfo.expireTime)
            {
                Token.GetToken();
            }
            return UserConfig.tokenInfo.Token;
        }

        /// <summary>
        /// 获取Token方法
        /// </summary>
        /// <returns>返回值</returns>
        public static string GetToken()
        {
            //string url = "https://" + UrlConfig.BaseApiURL + UrlConfig.TokenURL + "grant_type=client_credential&appid=" + UserConfig.appid + "&secret=" + UserConfig.secret;
            string url = "https://" + UrlConfig.BaseApiURL + UrlConfig.TokenURL + "grant_type=client_credential&appid=" + Until.GetJsonValue("appid") + "&secret=" + Until.GetJsonValue("secret");
            RequestHelper request = new RequestHelper();
            string response = request.GetResponseString(request.CreateGetHttpResponse(url));
            JObject obj = JObject.Parse(response);
            //UserConfig.token = obj["access_token"].ToString();
            //UserConfig.expireTime = Until.GetTimeSpan(119);
            if (response.Contains("errcode"))
            {
                string errmsg = obj["errmsg"].ToString();
                if(UserConfig.tokenInfo == null)
                {
                    UserConfig.tokenInfo = new TokenInfo();
                }
                UserConfig.tokenInfo.IsValid = false;
                return response;
            }
            UserConfig.tokenInfo = new TokenInfo()
            {
                Token = obj["access_token"].ToString(),
                expireTime = DateTime.Now.AddSeconds(7200),
                IsValid = true
            };
            return response;
        }


    }
}
