using Data.MSSQL;
using Data.MSSQL.Model.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatToken.Common.Http;

namespace WeChatToken.Common.Filter
{
    public class WXMSGFilterAttribute : Attribute, IActionFilter
    {
        private IDataConfig _db = new DataConfig();

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool result = false;
            using (var db = this._db.Db())
            {
                var configValue = db.Queryable<ts_uidp_config>().First(c => c.CONF_CODE == CommonField.WX_SMS_STATUS);
                var value = configValue?.CONF_VALUE;
                result = string.IsNullOrEmpty(value) ? false : value.ToLower() == "true";
            }
            if (!result)
            {
                var httpContext = context.HttpContext;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                var payload = JsonConvert.SerializeObject(new ResultBase(ApiResultCodes.INTERFACE_FORBIDDEN));
                httpContext.Response.WriteAsync(payload);
                return;
            }
        }
    }
}
