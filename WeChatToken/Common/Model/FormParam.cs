using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatToken.Common.Extends;

namespace WeChatToken.Common.Model
{
    public class FormParam
    {
        public class ReuqestForm
        {
            public string openId { get; set; }
            public Dictionary<string,object> data { get; set; }
            public string color { get; set; } = "#173177";
            public string templateId { get; set; }
            public string appurl { get; set; }
            public string appId { get; set; }
            public string pagepath { get; set; }

            /// <summary>
            /// 将data转换为模板消息
            /// </summary>
            /// <param name="color"></param>
            /// <returns></returns>
            public object getData(string color = "#173177") {
                return data.ToWxMsgTemplate(color);
            }
        }
    }
}
