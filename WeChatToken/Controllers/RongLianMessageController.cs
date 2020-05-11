using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeChatToken.Common;
using WeChatToken.Common.Model;
using WeChatToken.Common.RongLianCloudMsg;
using WeChatToken.Controllers.Base;

namespace WeChatToken.Controllers
{
    [WeChatToken.Common.Filter.SMSFilter]
    [Route("api/rlmsg")]
    public class RongLianMessageController : ApiControllerBase
    {
        [Route("send")]
        [HttpPost]
        public string SendMsg([FromBody] FormParam.SMSFrom from)
        {
            return RLCloudHelper.SendSMS(from.to,from.datas,from.appId,from.templateId);
        }

        #region 测试数据
        //[Route("test")]
        //public string SendTest()
        //{
        //    return RLCloudHelper.SendTest();
        //}
        [Route("test")]
        public string SendTest()
        {
            return "YES";
        }
        #endregion
    }
}