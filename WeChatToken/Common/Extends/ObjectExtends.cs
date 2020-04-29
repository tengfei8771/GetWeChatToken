using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatToken.Common.Extends
{
    public static class DictionaryExtends
    {
        public static Dictionary<string, object> ToWxMsgTemplate(this Dictionary<string, object> obj, string color = "#173177") {
            var keys = new Dictionary<string, object>();
            foreach (var pro in obj)
            {
                var value = new { value = pro.Value, color };
                keys.Add(pro.Key,value);
            }
            return keys;
        }
    }
}
