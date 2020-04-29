using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UIDP.UTILITY.JWTHelper;
using WeChatPlatform.API;
using WeChatPlatform.Config;

namespace WeChatToken
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            HttpRequest request = httpContext.Request;
            //if (request.Method.ToLower().Equals("get"))
            //{
                
                if(!request.Headers.TryGetValue("X-Token", out var apiKeyHeaderValues))
                {
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    var payload = JsonConvert.SerializeObject(new { code = "401", Message = "很抱歉,您无权访问本接口 "});
                    httpContext.Response.WriteAsync(payload);
                    return Task.FromResult(0);
                }
                else
                {
                    JWTHelper helper = new JWTHelper();
                    if (helper.Validate(apiKeyHeaderValues.ToString()))
                    {
                        request.EnableBuffering();
                        if (UserConfig.tokenInfo == null || DateTime.Now.AddMinutes(3) > UserConfig.tokenInfo.expireTime || !UserConfig.tokenInfo.IsValid)
                        {
                            Token.GetToken();
                        }
                    }
                    else
                    {
                        httpContext.Response.ContentType = "application/json";
                        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        var payload = JsonConvert.SerializeObject(new { code = "401", Message = "很抱歉,您访问本接口的Token无效，无权访问本接口" });
                        httpContext.Response.WriteAsync(payload);
                        return Task.FromResult(0);
                    }
                }               
            //}
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
