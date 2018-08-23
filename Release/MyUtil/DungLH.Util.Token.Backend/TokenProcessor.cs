using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Token.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Token.Backend
{
    class TokenProcessor
    {
        internal static TokenData GetAuthenticated(string tokenCode, string address, CommonParam param)
        {
            TokenData result = null;
            try
            {
                if (String.IsNullOrWhiteSpace(tokenCode) || String.IsNullOrWhiteSpace(address))
                {
                    return null;
                }

                if (String.IsNullOrWhiteSpace(Config.BASE_URI))
                {
                    LogSystem.Warn("Khong co cau hinh dia chi AAS");
                    return null;
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Config.BASE_URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.Timeout = new TimeSpan(0, 0, Config.TIME_OUT);
                    client.DefaultRequestHeaders.Add(HttpHeaderConstant.TOKEN_PARAM, tokenCode);
                    client.DefaultRequestHeaders.Add(HttpHeaderConstant.ADDRESS_PARAM, address);

                    HttpResponseMessage respenseMessage = client.GetAsync(AAS.URI.AasToken.GET_AUTHENTICATED).Result;
                    LogSystem.Debug(string.Format("Request URI: {0}{1}", Config.BASE_URI, AAS.URI.AasToken.GET_AUTHENTICATED));
                    if (respenseMessage.IsSuccessStatusCode)
                    {
                        string responseData = respenseMessage.Content.ReadAsStringAsync().Result;
                        LogSystem.Debug(string.Format("Response data: {0}", responseData));
                        ApiResultObject<TokenData> data = JsonConvert.DeserializeObject<ApiResultObject<TokenData>>(responseData);
                        if (data != null && data.Data != null && data.Success)
                        {
                            result = data.Data;
                        }
                        else
                        {
                            LogSystem.Info(String.Format("Khong lay duoc TokenData. TokeCode = {0}, Address = {1}", tokenCode, address));
                            if (data.Param != null && data.Param.Messages != null && data.Param.Messages.Count > 0)
                                param.Messages.AddRange(data.Param.Messages);
                            if (data.Param != null && data.Param.BugCodes != null && data.Param.BugCodes.Count > 0)
                                param.BugCodes.AddRange(data.Param.BugCodes);
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", Config.BASE_URI, AAS.URI.AasToken.GET_AUTHENTICATED, respenseMessage.StatusCode.GetHashCode()));
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
