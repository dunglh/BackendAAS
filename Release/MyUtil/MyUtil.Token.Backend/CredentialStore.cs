using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Token.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace MyUtil.Token.Backend
{
    enum CredentialEnum
    {
        ADD,
        REMOVE
    }
    class CredentialStore
    {
        private static object lockObj = new object();
        private static Dictionary<string, Dictionary<string, object>> DIC_CREDENTIAL_DATA = new Dictionary<string, Dictionary<string, object>>();
        private static Dictionary<string, Credential> DIC_CREDENTIAL = new Dictionary<string, Credential>();

        internal static List<Credential> GetCredentials()
        {
            List<Credential> result = null;
            try
            {
                result = new List<Credential>();
                foreach (Credential item in DIC_CREDENTIAL.Values)
                {
                    Credential map = new Credential(item.Name);
                    map.Token = item.Token;
                    map.ApplicationCode = item.ApplicationCode;
                    result.Add(map);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        internal static int Count
        {
            get
            {
                return DIC_CREDENTIAL.Count;
            }
        }
        internal static bool SetCredentialData(string key, object data, string tokenCode)
        {
            bool result = false;
            try
            {
                Dictionary<string, object> dicData = null;
                if (DIC_CREDENTIAL_DATA.ContainsKey(tokenCode))
                {
                    dicData = DIC_CREDENTIAL_DATA[tokenCode];
                }
                else
                {
                    dicData = new Dictionary<string, object>();
                    DIC_CREDENTIAL_DATA[tokenCode] = dicData;
                }
                dicData[key] = data;
                result = true;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        internal static object GetCredentialData(string key)
        {
            object result = null;
            try
            {
                Credential credential = (Credential)HttpContext.Current.User.Identity;
                if (credential != null && credential.Token != null)
                {
                    if (DIC_CREDENTIAL_DATA.ContainsKey(credential.Token.TokenCode))
                    {
                        Dictionary<string, object> dicData = DIC_CREDENTIAL_DATA[credential.Token.TokenCode];
                        if (dicData != null && dicData.ContainsKey(key))
                        {
                            result = dicData[key];
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

        internal static void ScanTimeout()
        {
            try
            {
                List<string> tokenCodes = new List<string>(DIC_CREDENTIAL.Keys);
                foreach (string tokenCode in tokenCodes)
                {
                    try
                    {
                        if (IsTimeout(tokenCode) && !AddOrRemoveCredential(CredentialEnum.REMOVE, tokenCode, null))
                        {
                            LogSystem.Error("Khong remove duoc token timeout");
                        }
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        internal static Credential GetAuthenticated(string tokenCode, HttpActionContext actionContext)
        {
            Credential result = null;
            try
            {
                if (!DIC_CREDENTIAL.ContainsKey(tokenCode) || IsTimeout(tokenCode))
                {
                    string address = GetAddress(actionContext);
                    if (IsTimeout(tokenCode))
                    {
                        RemoveToken(tokenCode);

                    }
                    result = AddCredential(tokenCode, address);
                }
                else
                {
                    result = DIC_CREDENTIAL[tokenCode];
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        private static Credential AddCredential(string tokenCode, string address)
        {
            Credential result = null;
            try
            {
                CommonParam param = new CommonParam();
                TokenData tokenData = TokenProcessor.GetAuthenticated(tokenCode, address, param);
                if (tokenData != null)
                {
                    result = new Credential(tokenCode);
                    result.Token = tokenData;
                    if (!AddOrRemoveCredential(CredentialEnum.ADD, tokenCode, result))
                    {
                        result = null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        private static bool RemoveToken(string tokenCode)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(tokenCode) && DIC_CREDENTIAL != null && DIC_CREDENTIAL.ContainsKey(tokenCode))
                {
                    result = AddOrRemoveCredential(CredentialEnum.REMOVE, tokenCode, null);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        private static bool AddOrRemoveCredential(CredentialEnum credentialEnum, string tokenCode, Credential credential)
        {
            bool result = false;
            try
            {
                lock (lockObj)
                {
                    switch (credentialEnum)
                    {
                        case CredentialEnum.ADD:
                            if (DIC_CREDENTIAL.ContainsKey(tokenCode))
                            {
                                DIC_CREDENTIAL.Remove(tokenCode);
                            }
                            DIC_CREDENTIAL[tokenCode] = credential;
                            break;
                        case CredentialEnum.REMOVE:
                            if (DIC_CREDENTIAL.ContainsKey(tokenCode))
                            {
                                DIC_CREDENTIAL.Remove(tokenCode);
                            }
                            break;
                        default:
                            break;
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }

        private static string GetAddress(HttpActionContext actionContext)
        {
            string result = null;
            try
            {
                var req = ((System.Web.HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request;
                var ip = req.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrWhiteSpace(ip))
                {
                    string[] ipRange = ip.Split(',');
                    int index = ipRange.Length - 1;
                    ip = ipRange[index];
                }
                else
                {
                    ip = req.ServerVariables["REMOTE_ADDR"];
                }
                result = ip;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }

        private static bool IsTimeout(string tokenCode)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(tokenCode) && DIC_CREDENTIAL != null && DIC_CREDENTIAL.ContainsKey(tokenCode))
                {
                    Credential credential = DIC_CREDENTIAL[tokenCode];
                    result = credential == null || credential.Token.ExpireTime == null || credential.Token.ExpireTime < DateTime.Now;
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
