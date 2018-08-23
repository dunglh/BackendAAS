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
    class CredentialDataProcessor
    {
        internal static CredentialData GetData(string tokenCode, string dataKey, CommonParam param)
        {
            CredentialData result = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(tokenCode) && !String.IsNullOrWhiteSpace(dataKey))
                {
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
                        client.DefaultRequestHeaders.Add(HttpHeaderConstant.BACKEND_CODE_PARAM, Config.BACKEND_CODE);
                        client.DefaultRequestHeaders.Add(HttpHeaderConstant.DATA_KEY_PARAM, dataKey);

                        HttpResponseMessage responseMessage = client.GetAsync(AAS.URI.AasToken.GET_CREDENTIAL_DATA).Result;
                        LogSystem.Debug(string.Format("Request URI: {0}{1}", Config.BASE_URI, AAS.URI.AasToken.GET_CREDENTIAL_DATA));
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                            LogSystem.Debug(string.Format("Response data: {0}", responseData));
                            ApiResultObject<CredentialData> data = JsonConvert.DeserializeObject<ApiResultObject<CredentialData>>(responseData);
                            if (data != null && data.Data != null && data.Success)
                            {
                                result = data.Data;
                            }
                            else
                            {
                                LogSystem.Info(String.Format("Khong lay duoc CredentialData. TokeCode = {0}, DataKey = {1}", tokenCode, dataKey));
                                if (data.Param != null && data.Param.Messages != null && data.Param.Messages.Count > 0)
                                    param.Messages.AddRange(data.Param.Messages);
                                if (data.Param != null && data.Param.BugCodes != null && data.Param.BugCodes.Count > 0)
                                    param.BugCodes.AddRange(data.Param.BugCodes);
                            }
                        }
                        else
                        {
                            throw new Exception(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", Config.BASE_URI, AAS.URI.AasToken.GET_CREDENTIAL_DATA, responseMessage.StatusCode.GetHashCode()));
                        }
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

        internal static bool Set(string tokenCode, string dataKey, string data, CommonParam param)
        {
            bool result = false;
            try
            {
                if (String.IsNullOrWhiteSpace(tokenCode) || String.IsNullOrWhiteSpace(dataKey) || String.IsNullOrWhiteSpace(dataKey))
                    return false;
                if (String.IsNullOrWhiteSpace(Config.BASE_URI))
                {
                    LogSystem.Warn("Khong co cau hinh dia chi AAS");
                    return false;
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Config.BASE_URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.Timeout = new TimeSpan(0, 0, Config.TIME_OUT);
                    client.DefaultRequestHeaders.Add(HttpHeaderConstant.TOKEN_PARAM, tokenCode);
                    CredentialData credentialData = new CredentialData(Config.BACKEND_CODE, tokenCode, dataKey, data);

                    HttpResponseMessage responseMessage = client.PostAsJsonAsync(AAS.URI.AasToken.SET_CREDENTIAL_DATA, credentialData).Result;
                    LogSystem.Debug(string.Format("Request URI: {0}{1}", Config.BASE_URI, AAS.URI.AasToken.SET_CREDENTIAL_DATA));
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        LogSystem.Debug(string.Format("Response data: {0}", responseData));
                        ApiResultObject<bool> dataRs = JsonConvert.DeserializeObject<ApiResultObject<bool>>(responseData);
                        if (dataRs != null && dataRs.Data)
                        {
                            result = dataRs.Data;
                        }
                        else
                        {
                            LogSystem.Info(String.Format("Khong set duoc CredentialData. TokeCode = {0}, DataKey = {1}, Data = {2}", tokenCode, dataKey, data));
                            if (dataRs.Param != null && dataRs.Param.Messages != null && dataRs.Param.Messages.Count > 0)
                                param.Messages.AddRange(dataRs.Param.Messages);
                            if (dataRs.Param != null && dataRs.Param.BugCodes != null && dataRs.Param.BugCodes.Count > 0)
                                param.BugCodes.AddRange(dataRs.Param.BugCodes);
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", Config.BASE_URI, AAS.URI.AasToken.SET_CREDENTIAL_DATA, responseMessage.StatusCode.GetHashCode()));
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
