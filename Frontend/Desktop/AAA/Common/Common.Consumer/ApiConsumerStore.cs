using DungLH.Util.WebApiConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Consumer
{
    public class ApiConsumerStore
    {
        private const string APP_CODE = "AAA";

        public void SetTokenCode(string tokenCode)
        {
            AasConsumer.SetTokenCode(tokenCode);
        }

        private static ApiConsumer aasConsumer;
        public static ApiConsumer AasConsumer
        {
            get
            {
                if (aasConsumer == null)
                {
                    aasConsumer = new ApiConsumer(BaseUri.AAS_BASE_URI, APP_CODE);
                }
                return aasConsumer;
            }
        }
    }
}
