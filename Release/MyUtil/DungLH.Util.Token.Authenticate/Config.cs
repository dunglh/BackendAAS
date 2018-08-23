using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Token.Authenticate
{
    class Config
    {
        internal const string HASH_TOKEN = "!@#923abc)(*&^193%$#@!dunglh#@!xyz?><;||.,`~0979";
        internal const string ADDRESS_SEPARATOR = "%%%";

        private static bool? checkAddress;
        internal static bool? CHECK_ADDRESS
        {
            get
            {
                if (!checkAddress.HasValue)
                {
                    try
                    {
                        checkAddress = int.Parse(ConfigurationManager.AppSettings["DungLH.Util.Token.Authenticate.CheckAddress"]) == 1;
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                        checkAddress = true;
                    }
                }
                return checkAddress;
            }
        }


        private static double tokenTimeout = 0;
        internal static double TOKEN_TIMEOUT
        {
            get
            {
                if (tokenTimeout <= 0)
                {
                    try
                    {
                        tokenTimeout = double.Parse(ConfigurationManager.AppSettings["DungLH.Util.Token.Authenticate.TokenTimeout"]);
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                        tokenTimeout = 21600;
                    }
                }
                return tokenTimeout;
            }
        }
    }
}
