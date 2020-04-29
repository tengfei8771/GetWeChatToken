using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatToken.Common.Config
{
    public static class ConfigHelper
    {
        /// <summary>
        ///  读取json文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ParentKey">父级json节点</param>
        /// <param name="childrenKey">子级节点</param>
        /// <param name="path">appsettings.json</param>
        /// <returns></returns>
        public static string GetAppSettings(string parentKey, string childrenKey = null, string path = "appsettings.json")
        {
            string strInfo = string.Empty;
            var builder = new ConfigurationBuilder().AddJsonFile(path);
            var configuration = builder.Build();
            try
            {
                if (!string.IsNullOrWhiteSpace(childrenKey))
                {
                    strInfo = configuration.GetSection(parentKey).GetValue<string>(childrenKey);
                }
                else
                {
                    strInfo = configuration[parentKey].ToString();
                }
                return strInfo;
            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex.Message.ToString());
                return null;
            }
        }
    }
}
