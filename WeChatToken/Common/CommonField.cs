using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatToken.Common.Config;
using WeChatToken.Common.Sign;

namespace WeChatToken.Common
{
    public class CommonField
    {
        public static string AppId => ConfigHelper.GetAppSettings("appid");
        public static string Notice => ConfigHelper.GetAppSettings("template:notice");

        public static string PayTempmentId
        {
            get
            {
                return ConfigHelper.GetAppSettings("template:pay");
            }
        }

        #region 融连云通讯短信平台配置
        public static string RL_AccountSID => ConfigHelper.GetAppSettings("rongLianYunTongXun:accountSid");
        public static string RL_AccountAUTHTOKEN => ConfigHelper.GetAppSettings("rongLianYunTongXun:accountAuthToken");
        public static string RL_BaseUrl => ConfigHelper.GetAppSettings("rongLianYunTongXun:baseUrl");
        public static string RL_MsgParamUrl => ConfigHelper.GetAppSettings("rongLianYunTongXun:msgParamUrl");
        public static string RL_ApplicationID => ConfigHelper.GetAppSettings("rongLianYunTongXun:applicationID");
        /// <summary>
        /// 短信模板请求的Url
        /// </summary>
        public static string RL_MsgPostUrl()
        {
            string signParams = SignHelper.RongLianSignParamter(RL_AccountSID, RL_AccountAUTHTOKEN);
            return RL_BaseUrl + string.Format(RL_MsgParamUrl, RL_AccountSID, signParams);
        }
        /// <summary>
        /// 短信模板请求的Auth
        /// </summary>
        public static string RL_Authorization()
        {
            string signAuth = SignHelper.RongLianSignBase64(RL_AccountSID);
            return signAuth;
        }
        #endregion


        public static string WX_SMS_STATUS = "SMS_STATUS";
        public static string WX_MSG_STATUS = "WX_MSG_STATUS";
        public static string GetString(string key) => ConfigHelper.GetAppSettings(key);

    }
}
