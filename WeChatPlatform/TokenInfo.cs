using System;
using System.Collections.Generic;
using System.Text;

namespace WeChatPlatform
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime expireTime { get; set; }

        public bool IsValid { get; set; }
    }
}
