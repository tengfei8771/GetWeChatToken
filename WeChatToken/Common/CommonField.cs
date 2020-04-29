using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatToken.Common.Config;

namespace WeChatToken.Common
{
    public class CommonField
    {
        public static string AppId => ConfigHelper.GetAppSettings("appid");
        public static string Notice => ConfigHelper.GetAppSettings("template:notice");

        public static string PayTempmentId{
            get
            {
                return ConfigHelper.GetAppSettings("template:pay");
            }
        }
        public static string GetString(string key) => ConfigHelper.GetAppSettings(key);

    }
}
