using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeChatPlatform.Config;

namespace GetWeChatToken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        [HttpGet("GetToken")]
        public IActionResult GetToken() => Ok(new { code = "200", Message = "成功！",data=UserConfig.tokenInfo });
    }
}