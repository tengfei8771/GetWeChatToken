using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatToken.Common.Http
{
    /// <summary>
    /// 统一响应处理
    /// </summary>
    public class APIResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            var ResultBase = new ResultBase(ApiResultCodes.SCCUESS, "运行结果：",
                objectResult.Value);
            context.Result = new OkObjectResult(ResultBase);
        }
    }
}
