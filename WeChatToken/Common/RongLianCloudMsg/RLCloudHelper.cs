using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatToken.Common.Http;

namespace WeChatToken.Common.RongLianCloudMsg
{
    public class RLCloudHelper
    {
        public static string SendSMS(string to,string[] datas,string appId, string templateId)
        {
            if (string.IsNullOrEmpty(appId))
            {
                appId = CommonField.RL_ApplicationID;
            }
            var Template = new
            {
                to, //发送的手机号码
                appId, //应用ID
                templateId,//【云通讯】您使用的是云通讯短信模板，您的验证码是{1}，请于{2}分钟内正确输入
                datas, //外层变量
                //subAppend = "", //扩展码
                //reqId = "" // 第三方自定义消息id，最大支持32位，同账号下同一自然天内不允许重复。
            };
            string jsonData = JsonConvert.SerializeObject(Template);
            return HttpHelper.PostJson(CommonField.RL_MsgPostUrl(), jsonData, CommonField.RL_Authorization());
        }

        //public static string SendTest()
        //{
        //    var content = new string[] { "888", "5" };
        //    return Send("18766139925", content, "113752");
        //}


    }
}
