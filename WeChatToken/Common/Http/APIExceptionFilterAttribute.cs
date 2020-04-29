using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeChatToken.Common.Http
{
    /// <summary>
    /// 全局异常捕获
    /// </summary>
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //目前省略全局的异常处理信息
            var objectResult = context.Result as ObjectResult;
            ResultBase resultBase = null;
            if (context.Exception is ApiResultException)
            {
                ApiResultException apiResult = context.Exception as ApiResultException;
                //自定义异常处理
                resultBase = new ResultBase(ApiResultCodes.SCCUESS,apiResult.Message);
            }
            else
            {
                resultBase = new ResultBase(ApiResultCodes.INTERFACE_INNER_INVOKE_ERROR, context.Exception.Message);
            }
            context.Result = new OkObjectResult(resultBase);
            //LOG记录位置
        }
    }
}
