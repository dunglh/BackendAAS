using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Token.Authenticate
{
    enum TokenEnum
    {
        ADD,
        REMOVE
    }
    class TokenStore
    {
        private static object lockObj = new object();
        private static Dictionary<string, ExtTokenData> DIC_TOKEN_DATA = new Dictionary<string, ExtTokenData>();
        internal static Dictionary<string,ExtTokenData> DicTokenData
        {
            get
            {
                return DIC_TOKEN_DATA;
            }
        }

        internal static ExtTokenData GetTokenData(string tokenCode)
        {
            return (!String.IsNullOrEmpty(tokenCode) && DIC_TOKEN_DATA.ContainsKey(tokenCode)) ? DIC_TOKEN_DATA[tokenCode] : null;
        }

        internal static bool AddTokenData(ExtTokenData tokenData)
        {
            return tokenData != null ? UpdateTokenData(TokenEnum.ADD, tokenData.TokenCode, tokenData) : false;
        }

        internal static bool RemoveTokenData(string tokenCode)
        {
            return UpdateTokenData(TokenEnum.REMOVE, tokenCode, null);
        }

        private static bool UpdateTokenData(TokenEnum tokenEnum, string tokenCode, ExtTokenData data)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(tokenCode))
                {
                    switch (tokenEnum)
                    {
                        case TokenEnum.ADD:
                            if (DIC_TOKEN_DATA.ContainsKey(tokenCode))
                            {
                                DIC_TOKEN_DATA.Remove(tokenCode);
                            }
                            DIC_TOKEN_DATA[tokenCode] = data;
                            break;
                        case TokenEnum.REMOVE:
                            if (DIC_TOKEN_DATA.ContainsKey(tokenCode))
                            {
                                DIC_TOKEN_DATA.Remove(tokenCode);
                            }
                            break;
                        default:
                            break;
                    }
                    result = true;
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
