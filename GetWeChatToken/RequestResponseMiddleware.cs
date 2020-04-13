using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatPlatform.API;
using WeChatPlatform.Config;

namespace GetWeChatToken
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;

        public RequestResponseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (request.Method.ToLower().Equals("post"))
            {
                request.EnableBuffering();
                if (UserConfig.tokenInfo == null|| DateTime.Now.AddMinutes(3) > UserConfig.tokenInfo.expireTime)
                {
                    Token.GetToken();
                }
            }
            await next(context);
        }
    }
}
