using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Token.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DungLH.Util.Token.Backend
{
    public class BackendTokenManager
    {
        public static List<Credential> GetCredentials()
        {
            return CredentialStore.GetCredentials();
        }

        public static int CountCredential
        {
            get
            {
                return CredentialStore.Count;
            }
        }

        public static bool SetCredentialData(string key, object data)
        {
            bool result = false;
            try
            {
                TokenData tokenData = GetTokenData();
                if (tokenData != null && !String.IsNullOrWhiteSpace(tokenData.TokenCode))
                {
                    result = CredentialStore.SetCredentialData(key, data, tokenData.TokenCode);
                    CommonParam param = new CommonParam();
                    string jsonData = data != null ? JsonConvert.SerializeObject(data) : null;
                    if (!CredentialDataProcessor.Set(tokenData.TokenCode, key, jsonData, param)) ;
                    {
                        throw new Exception("Cap nhat CredentialData len AAS that bai " + LogUtil.TraceData("Param", param));
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public static T GetCredentialData<T>(string key)
        {
            T result = default(T);
            try
            {
                result = (T)CredentialStore.GetCredentialData(key);
                if (result == null)
                {
                    string tokenCode = GetTokenCode();
                    CredentialData credentialData = CredentialDataProcessor.GetData(tokenCode, key, new CommonParam());
                    if (credentialData != null && !String.IsNullOrWhiteSpace(credentialData.Data))
                    {
                        result = JsonConvert.DeserializeObject<T>(credentialData.Data);
                        if (result != null)
                        {
                            SetCredentialData(key, result);
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

        public static TokenData GetTokenData()
        {
            TokenData result = null;
            try
            {
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null &&
                    HttpContext.Current.User.Identity.GetType() == typeof(Credential))
                {
                    Credential credential = (Credential)HttpContext.Current.User.Identity;
                    if (credential != null)
                    {
                        result = credential.Token;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        public static string GetTokenCode()
        {
            TokenData tokenData = GetTokenData();
            return tokenData != null ? tokenData.TokenCode : null;
        }

        public static UserData GetUserData()
        {
            TokenData tokenData = GetTokenData();
            return tokenData != null ? tokenData.User : null;
        }

        public static string GetRequestAddress()
        {
            try
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        public static void ScanTimeoutCredentials()
        {
            CredentialStore.ScanTimeout();
        }

        public static string GetApplicationCode()
        {
            var headers = HttpContext.Current.Request.Headers;
            if (headers != null)
            {
                try
                {
                    return headers[HttpHeaderConstant.APPLICATION_CODE_PARAM];
                }
                catch (Exception ex)
                {
                    LogSystem.Error(ex);
                }
            }
            return null;
        }

        public static string GetLoginname()
        {
            UserData userData = GetUserData();
            return userData != null ? userData.Loginname : null;
        }

        public static string GetUsername()
        {
            UserData userData = GetUserData();
            return userData != null ? userData.Username : null;
        }

        public static string GetLoginAddress()
        {
            TokenData tokenData = GetTokenData();
            return tokenData != null ? tokenData.LoginAddress : null;
        }
    }
}
