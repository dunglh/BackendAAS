using MyUtil.CommonLogging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Token.Client
{
    class Config
    {
        internal static string BASE_URI = ConfigurationManager.AppSettings["MyUtil.Token.Client.BaseUri"];

        private static int timeOut = 0;
        internal static int TIME_OUT
        {
            get
            {
                if (timeOut <= 0)
                {
                    try
                    {
                        timeOut = int.Parse(ConfigurationManager.AppSettings["MyUtil.Token.Client.Timeout"]);
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                    }
                }
                return timeOut;
            }
        }
    }
}
