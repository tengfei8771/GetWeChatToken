using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatToken.Common.Http
{
    /// <summary>
    /// 统一处理返回的Model
    /// </summary>
    public class ResultBase
    {
        public ResultBase(ApiResultCodes code, string message = null,
            object result = null, ReturnStatus returnStatus = ReturnStatus.Success)
        {
            this.Code = code;
            this.Result = result;
            this.Message = code.Description() + " \r\n " + message;
            this.ReturnStatus = returnStatus;
        }
        //请求Code
        public ApiResultCodes Code { get; set; }
        //消息
        public string Message { get; set; }
        //结果
        public object Result { get; set; }
        //结果状态
        public ReturnStatus ReturnStatus { get; set; }
    }

    //返回状态
    public enum ReturnStatus
    {
        Success = 1, // 成功
        Fail = 0, //失败
        ConfirmIsContinue = 2, //确认继续
        Error = 3 //系统错误
    }

}
