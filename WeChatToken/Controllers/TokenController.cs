using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChatPlatform;
using WeChatPlatform.Config;

namespace WeChatToken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        [HttpGet("GetToken")]
        public TokenInfo GetToken() => UserConfig.tokenInfo;
    }
}