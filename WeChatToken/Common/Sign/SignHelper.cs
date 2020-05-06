using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeChatToken.Common.Sign
{
    public class SignHelper
    {
        public static string Md5(string str)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(str);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static string RongLianSignParamter(string accountSid,string accountAuthToken)
        {
            string ParamStr = $"{accountSid}{accountAuthToken}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            return Md5(ParamStr).ToUpper();
        }

        public static string RongLianSignBase64(string accountSID)
        {
            return EncodeBase64(accountSID + ":"+ DateTime.Now.ToString("yyyyMMddHHmmss"));
        }

        #region Base64
        ///编码
        public static string EncodeBase64(string code, string code_type = "utf-8")
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
        ///解码
        public static string DecodeBase64(string code, string code_type = "utf-8")
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }
        #endregion

    }
}
