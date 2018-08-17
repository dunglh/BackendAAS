using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Token.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Token.Client
{
    public class ClientTokenManager
    {
        private TokenData tokenData;
        private string baseUri;
        private string applicationCode;

        public ClientTokenManager(string appCode)
        {
            this.applicationCode = appCode;
            this.baseUri = Config.BASE_URI;
        }

        public ClientTokenManager(string appCode, string baseuri)
        {
            this.applicationCode = appCode;
            this.baseUri = baseuri;
        }

        public TokenData Login(string loginname, string password, CommonParam param)
        {
            TokenData result = null;
            try
            {
                string authenData = String.Format("{0}:{1}:{2}", this.applicationCode, loginname, password);
                authenData = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(authenData));
                result = this.ProcessRequest<TokenData>(HttpMethod.Get, AAS.URI.AasToken.LOGIN, param, HttpHeaderConstant.BASIC_AUTH_HEADER, String.Format("{0} {1}", HttpHeaderConstant.BASIC_AUTH_SCHEME, authenData));
                if (result != null)
                {
                    this.tokenData = result;

                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public bool Logout(CommonParam param)
        {
            bool result = false;
            try
            {
                if (tokenData == null)
                {
                    LogSystem.Warn("TokenData is null");
                    return false;
                }
                result = this.ProcessRequest<bool>(HttpMethod.Post, AAS.URI.AasToken.LOGOUT, param, HttpHeaderConstant.TOKEN_PARAM, this.tokenData.TokenCode);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool ChangePassword(string oldPassword, string newPassword, CommonParam param)
        {
            bool result = false;
            try
            {
                if (this.tokenData != null && this.tokenData.ExpireTime >= DateTime.Now)
                {
                    string passwordData = String.Format("{0}:{1}", oldPassword, newPassword);
                    passwordData = Convert.ToBase64String(Encoding.Default.GetBytes(passwordData));
                    result = this.ProcessRequest<bool>(HttpMethod.Post, AAS.URI.AasToken.CHANGE_PASSWORD, param, HttpHeaderConstant.TOKEN_PARAM, this.tokenData.TokenCode, HttpHeaderConstant.PASS_PARAM, passwordData);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public TokenData GetTokenData()
        {
            return this.tokenData;
        }

        public UserData GetUserData()
        {
            return this.tokenData != null ? this.tokenData.User : null;
        }

        public string GetLoginname()
        {
            UserData userData = this.GetUserData();
            return userData != null ? userData.Loginname : null;
        }

        public string GetUsername()
        {
            UserData userData = this.GetUserData();
            return userData != null ? userData.Username : null;
        }

        private string GetLoginAddress()
        {
            return this.tokenData != null ? this.tokenData.LoginAddress : null;
        }

        private T ProcessRequest<T>(HttpMethod method, string reqUri, CommonParam param, params string[] headerParams)
        {
            T result = default(T);
            try
            {
                if (String.IsNullOrWhiteSpace(this.baseUri))
                {
                    LogSystem.Error("Khong co dia chi server AAS");
                    return result;
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    if (headerParams != null)
                    {
                        if (headerParams.Length % 2 == 0)
                        {
                            for (int i = 0; i < headerParams.Length;)
                            {
                                client.DefaultRequestHeaders.Add(headerParams[i], headerParams[i + 1]);
                                i = i + 2;
                            }
                        }
                        else
                        {
                            throw new Exception("So luong headerParams phai chan");
                        }
                    }

                    param = param != null ? param : new CommonParam();

                    HttpResponseMessage responseMessage = null;
                    if (method == HttpMethod.Get)
                    {
                        responseMessage = client.GetAsync(reqUri).Result;
                    }
                    else if (method == HttpMethod.Post)
                    {
                        responseMessage = client.PostAsJsonAsync(reqUri, "").Result;
                    }

                    if (responseMessage == null || !responseMessage.IsSuccessStatusCode)
                    {
                        string statusCode = responseMessage != null ? responseMessage.StatusCode.GetHashCode() + "" : null;
                        throw new Exception(String.Format("Goi api that bai. uri = {0}, StatusCode = {1}", baseUri + reqUri, statusCode));
                    }

                    string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    ApiResultObject<T> data = JsonConvert.DeserializeObject<ApiResultObject<T>>(responseData);
                    if (data != null && data.Data != null && data.Success)
                    {
                        result = data.Data;
                    }
                    else
                    {
                        string statusCode = responseMessage != null ? responseMessage.StatusCode.GetHashCode() + "" : null;

                        if (data.Param != null && data.Param.Messages != null && data.Param.Messages.Count > 0)
                            param.Messages.AddRange(data.Param.Messages);
                        if (data.Param != null && data.Param.BugCodes != null && data.Param.BugCodes.Count > 0)
                            param.BugCodes.AddRange(data.Param.BugCodes);
                        throw new Exception(String.Format("Goi api that bai. uri = {0}, StatusCode = {1}", baseUri + reqUri, statusCode));
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }
    }
}
