using AutoMapper;
using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Token.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace MyUtil.Token.Authenticate
{
    public class AuthenticateTokenManager
    {
        private GetValidUserData _GetValidUserData;
        private GetCredentialData _GetCredentialData;
        private IsGrantedUser _IsGrantedUser;
        private InsertCredentialData _InsertCredentialData;
        private UpdateUserPassword _UpdateUserPassword;
        private DeleteCredentialData _DeleteCredentialData;
        private DeleteAllCredentialData _DeleteAllCredentialData;

        public AuthenticateTokenManager(GetValidUserData getValidUserData, GetCredentialData getCredentialData, IsGrantedUser isGrantedUser, InsertCredentialData insertCredentialData, UpdateUserPassword updateUserPassword, DeleteCredentialData deleteCredentialData, DeleteAllCredentialData deleteAllCredentialData)
        {
            this._GetCredentialData = getCredentialData;
            this._GetValidUserData = getValidUserData;
            this._IsGrantedUser = isGrantedUser;
            this._InsertCredentialData = insertCredentialData;
            this._UpdateUserPassword = updateUserPassword;
            this._DeleteCredentialData = deleteCredentialData;
            this._DeleteAllCredentialData = deleteAllCredentialData;
        }

        public TokenData Login(HttpActionContext actionContext, CommonParam param)
        {
            TokenData result = null;
            try
            {
                var auth = actionContext.Request.Headers.Authorization;
                if (auth == null || auth.Scheme != HttpHeaderConstant.BASIC_AUTH_SCHEME || String.IsNullOrWhiteSpace(auth.Parameter))
                {
                    return null;
                }
                string authHeader = Encoding.Default.GetString(Convert.FromBase64String(auth.Parameter));
                string[] headerParams = authHeader.Split(':');
                if (headerParams.Length < 3)
                {
                    return null;
                }

                string applicationCode = headerParams[0];
                string loginname = headerParams[1];
                string password = headerParams[2];
                string machineName = string.Empty;
                if (headerParams.Length == 4)
                {
                    machineName = headerParams[3];
                }

                UserData userData = this._GetValidUserData(loginname, password, applicationCode, param);
                if (userData != null)
                {
                    result = this.CreateTokenData(actionContext, param, userData, machineName);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public bool Logout(HttpActionContext actionContext, CommonParam param)
        {
            bool result = false;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM))
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    string address = this.GetAddress(actionContext);
                    TokenData tokenData = this.GetTokenDataByCodeAndAddress(tokenCode, address);

                    if (tokenData == null || String.IsNullOrWhiteSpace(tokenData.TokenCode))
                    {
                        return false;
                    }
                    result = TokenStore.RemoveTokenData(tokenData.TokenCode);
                    if (result)
                    {
                        this._DeleteAllCredentialData(tokenData.TokenCode, param);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public bool ChangePassword(HttpActionContext actionContext, CommonParam param)
        {
            bool result = false;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM) && headers.Contains(HttpHeaderConstant.PASS_PARAM))
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    string passInfo = headers.GetValues(HttpHeaderConstant.PASS_PARAM).FirstOrDefault();
                    string address = this.GetAddress(actionContext);

                    TokenData tokenData = this.GetTokenDataByCodeAndAddress(tokenCode, address);
                    if (tokenData == null || tokenData.User == null || String.IsNullOrWhiteSpace(passInfo))
                    {
                        return false;
                    }

                    string changePassordInfo = Encoding.Default.GetString(Convert.FromBase64String(passInfo));
                    string[] passParams = changePassordInfo.Split(':');
                    if (passParams.Length != 2)
                    {
                        return false;
                    }

                    string oldPass = passParams[0];
                    string newPass = passParams[1];
                    result = this._UpdateUserPassword(tokenData.User.Loginname, oldPass, newPass, param);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public TokenData GetAuthenticatedByAddress(HttpActionContext actionContext, CommonParam param)
        {
            TokenData result = null;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM) && headers.Contains(HttpHeaderConstant.ADDRESS_PARAM))
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    string address = headers.GetValues(HttpHeaderConstant.ADDRESS_PARAM).FirstOrDefault();

                    if (String.IsNullOrWhiteSpace(tokenCode) || String.IsNullOrWhiteSpace(address))
                    {
                        return null;
                    }

                    ExtTokenData tokenData = this.GetTokenDataByCodeAndAddress(tokenCode, address);
                    if (tokenData != null && tokenData.User != null && !String.IsNullOrWhiteSpace(tokenData.ValidAddress))
                    {
                        List<string> validAddress = Regex.Split(tokenData.ValidAddress, Config.ADDRESS_SEPARATOR).ToList();
                        if (tokenData.ExpireTime < DateTime.Now)
                        {
                            return null;
                        }
                        string backendAddress = this.GetAddress(actionContext);
                        if (!validAddress.Contains(backendAddress))
                        {
                            validAddress.Add(backendAddress);
                            tokenData.ValidAddress = string.Join(Config.ADDRESS_SEPARATOR, validAddress);
                            TokenStore.AddTokenData(tokenData);
                        }
                        Mapper.CreateMap<ExtTokenData, TokenData>();
                        result = Mapper.Map<TokenData>(tokenData);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public CredentialData GetCredentialData(HttpActionContext actionContext, CommonParam param)
        {
            CredentialData result = null;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM) && headers.Contains(HttpHeaderConstant.DATA_KEY_PARAM) && headers.Contains(HttpHeaderConstant.BACKEND_CODE_PARAM))
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    string dataKey = headers.GetValues(HttpHeaderConstant.DATA_KEY_PARAM).FirstOrDefault();
                    string backendCode = headers.GetValues(HttpHeaderConstant.BACKEND_CODE_PARAM).FirstOrDefault();

                    ExtTokenData tokenData = this.GetTokenDataByCodeAndAddress(tokenCode, this.GetAddress(actionContext));
                    if (tokenData != null && tokenData.ExpireTime > DateTime.Now)
                    {
                        result = this._GetCredentialData(backendCode, tokenCode, dataKey, param);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public TokenData GetAuthenticated(HttpActionContext actionContext, CommonParam param)
        {
            TokenData result = null;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM) && headers.Contains(HttpHeaderConstant.APPLICATION_CODE_PARAM))
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    string clientAddress = this.GetAddress(actionContext);
                    TokenData tokenData = this.GetTokenDataByCodeAndAddress(tokenCode, clientAddress);
                    if (tokenData != null)
                    {
                        string applicationCode = headers.GetValues(HttpHeaderConstant.APPLICATION_CODE_PARAM).FirstOrDefault();
                        if (this._IsGrantedUser(tokenData.User.Loginname, applicationCode, param))
                        {
                            Mapper.CreateMap<ExtTokenData, TokenData>();
                            result = Mapper.Map<TokenData>(tokenData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public bool SetCredentialData(HttpActionContext actionContext, CredentialData credentialData, CommonParam param)
        {
            bool result = false;
            try
            {
                var headers = actionContext.ControllerContext.Request.Headers;
                if (headers.Contains(HttpHeaderConstant.TOKEN_PARAM) && credentialData != null)
                {
                    string tokenCode = headers.GetValues(HttpHeaderConstant.TOKEN_PARAM).FirstOrDefault();
                    ExtTokenData tokenData = this.GetTokenDataByCodeAndAddress(tokenCode, this.GetAddress(actionContext));
                    if (tokenData != null && tokenData.ExpireTime > DateTime.Now)
                    {
                        credentialData.TokenCode = tokenCode;
                        this._DeleteCredentialData(credentialData.BackendCode, tokenCode, credentialData.DataKey, param);
                        if (!String.IsNullOrWhiteSpace(credentialData.Data))
                        {
                            result = this._InsertCredentialData(credentialData, param);
                        }
                        else
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public List<ExtTokenData> GetTokenDataAlives(string applicationCode)
        {
            List<ExtTokenData> result = new List<ExtTokenData>();
            try
            {
                result = TokenStore.DicTokenData.Values.ToList();
                if (!String.IsNullOrWhiteSpace(applicationCode))
                {
                    result = result.Where(o => o.User.ApplicationCode == applicationCode).ToList();
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = new List<ExtTokenData>();
            }
            return result;
        }

        public bool SetTokenDataAlive(string tokenCode)
        {
            bool result = false;
            try
            {
                ExtTokenData tokenData = TokenStore.GetTokenData(tokenCode);
                if (tokenData != null)
                {
                    tokenData.LastAccessTime = DateTime.Now;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public string GenerateTokenCode(string loginname, string loginAddress)
        {
            if (!String.IsNullOrWhiteSpace(loginname) && !String.IsNullOrWhiteSpace(loginAddress))
            {
                string input = String.Format("{0}-{1}-{2}", loginname, Guid.NewGuid().ToString(), loginAddress);
                return this.HashTokenCode(input);
            }
            return null;
        }

        private TokenData CreateTokenData(HttpActionContext actionContext, CommonParam param, UserData userData, string machineName)
        {
            ExtTokenData result = new ExtTokenData();
            result.LoginTime = DateTime.Now;
            result.ExpireTime = result.LoginTime.AddMinutes(Config.TOKEN_TIMEOUT);
            result.LoginAddress = this.GetAddress(actionContext);
            result.ValidAddress = result.LoginAddress;
            result.LastAccessTime = DateTime.Now;
            result.MachineName = machineName;
            result.TokenCode = this.GenerateTokenCode(userData.Loginname, result.LoginAddress);
            result.User = userData;

            if (TokenStore.AddTokenData(result))
            {
                return result;
            }

            return null;
        }

        private ExtTokenData GetTokenDataByCodeAndAddress(string tokenCode, string address)
        {
            ExtTokenData result = null;
            if (!String.IsNullOrWhiteSpace(tokenCode) && !String.IsNullOrWhiteSpace(address))
            {
                ExtTokenData tokenData = TokenStore.GetTokenData(tokenCode);
                if (tokenData != null && tokenData.User != null && !String.IsNullOrWhiteSpace(tokenData.ValidAddress))
                {
                    List<string> validAddress = Regex.Split(tokenData.ValidAddress, Config.ADDRESS_SEPARATOR).ToList();
                    bool valid = tokenCode.Equals(tokenData.TokenCode);
                    if (Config.CHECK_ADDRESS.HasValue && Config.CHECK_ADDRESS.Value)
                    {
                        valid = valid && validAddress != null && validAddress.Contains(address);
                    }
                    if (valid)
                    {
                        result = tokenData;
                    }

                }
            }
            return result;
        }

        private string HashTokenCode(string input)
        {
            SHA512CryptoServiceProvider provider = new SHA512CryptoServiceProvider();
            byte[] buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(input + Config.HASH_TOKEN));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in buffer)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }

        private string GetAddress(HttpActionContext actionContext)
        {
            string result = null;
            try
            {
                var req = ((HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request;
                var ips = req.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrWhiteSpace(ips))
                {
                    string[] ipRange = ips.Split(',');
                    int index = ipRange.Length - 1;
                    result = ipRange[index];
                }
                else
                {
                    result = req.ServerVariables["REMOTE_ADDR"];
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }
    }
}
