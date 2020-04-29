using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatToken.Common;

namespace WeChatToken.Controllers.Base
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected string Token => WeChatPlatform.API.Token.GetValidToken();
        protected string AppId => CommonField.AppId;
        protected string PayTempId => CommonField.PayTempmentId;

        protected string NoticeTemId => CommonField.Notice;

    }
}
