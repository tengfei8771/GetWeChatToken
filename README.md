# 公共服务 获微信公众号token
一.如何使用
(1)本接口通过JWT方式进行认证，认证通过后返回数据。
(2).appsettings 文件中的appid为商户的appid,secret为微信端的秘钥。securityKey为认证访问本接口的秘钥。
(3)访问方式'get'
(4)访问时需将Token放到请求的header中,键为'X-Token',值为认证的token
二.返回格式
(1)访问失败
{code :"401", Message : "很抱歉,您无权访问本接口 "}//这是代表没有找到X-Token 认证失败
{ code : "401", Message : "很抱歉,您访问本接口的Token无效，无权访问本接口" }//代表Token已经过期了
(2)访问成功
new { code : "200", Message : "成功！",data:{
    token:----此为微信的Token,利用这个令牌可以对微信端进行操作
    expireTime: --此为过期时间，不必关注，服务会根据这个时间去判断Token是否过期，业务端不用关心
    isValid: --Token是否有效，业务端不必关心
}}