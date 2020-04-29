using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatToken.Common
{
    public class ApiResultException : Exception
    {
        public ApiResultException(string message) : base(message)
        {
        }
        public ApiResultException(string message, Exception ex) : base(message,ex)
        {
        }
       
    }
}
