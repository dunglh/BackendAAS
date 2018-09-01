using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.WebApiConsumer
{
    class ApiConfig
    {
        internal const string API_PARAM = "param";

        private static string config_TimeOut = ConfigurationManager.AppSettings["DungLH.Util.Common.WebApiConsumer.Timeout"];

        private static int? timeOut;
        internal static int TIME_OUT
        {
            get
            {
                if (!timeOut.HasValue)
                {
                    try
                    {
                        string num = String.IsNullOrWhiteSpace(config_TimeOut) ? "60" : config_TimeOut;
                        timeOut = Convert.ToInt32(num);
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                        timeOut = 60;
                    }
                }
                return timeOut.Value;
            }
        }
    }
}
