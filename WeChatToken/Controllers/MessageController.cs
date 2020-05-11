using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeChatPlatform.API;
using WeChatToken.Common;
using WeChatToken.Common.Extends;
using WeChatToken.Common.Filter;
using WeChatToken.Common.Model;
using WeChatToken.Controllers.Base;

namespace WeChatToken.Controllers
{
    [WXMSGFilter]
    [Route("api/msg")]
    public class MessageController : ApiControllerBase
    {
        private MsgAPI msg = new MsgAPI();

        // GET: api/Message
        [HttpPost]
        [Route("send")]
        public object SendMsg([FromBody] FormParam.ReuqestForm from)
        {
            try
            {
                return msg.SendTemplateMsg(from.openId, from.templateId,
                        from.getData(), from.appId, from.appurl, from.pagepath, from.color);
            }
            catch (Exception ex)
            {
                throw new ApiResultException(ex.Message,ex);
            }
        }

        [HttpPost]
        [Route("sends")]
        public void SendMsgs([FromBody] List<FormParam.ReuqestForm> froms)
        {
            try
            {
                froms.ForEach(from =>
                {
                    Task.Run(() =>
                    {
                        return msg.SendTemplateMsg(from.openId, from.templateId,
                        from.getData(), from.appId, from.appurl, from.pagepath, from.color);
                    });
                });
            }
            catch (Exception ex)
            {
                throw new ApiResultException(ex.Message, ex);
            }
        }

        [HttpPost]
        [Route("pay")]
        public object PayMsg([FromBody] FormParam.ReuqestForm request) {
            try
            {
                return msg.SendTemplateMsg(request.openId,PayTempId, request.getData());
            }
            catch (Exception ex)
            {
                throw new ApiResultException(ex.Message,ex);
            }
        }


        [HttpPost]
        [Route("notice")]
        public object NoticeMsg([FromBody] FormParam.ReuqestForm request)
        {
            try
            {
                return msg.SendTemplateMsg(request.openId, NoticeTemId, request.getData());
            }
            catch (Exception ex)
            {
                throw new ApiResultException(ex.Message, ex);
            }
        }


        [HttpGet]
        [Route("text")]
        public object Text()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new ApiResultException(ex.Message, ex);
            }
        }

    }
}
