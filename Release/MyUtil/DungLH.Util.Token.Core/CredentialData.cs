using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Token.Core
{
    public class CredentialData
    {
        public string BackendCode { get; set; }
        public string TokenCode { get; set; }
        public string DataKey { get; set; }
        public string Data { get; set; }

        public CredentialData()
        {

        }

        public CredentialData(string backendCode, string tokenCode, string dataKey, string data)
        {
            this.BackendCode = backendCode;
            this.TokenCode = tokenCode;
            this.DataKey = dataKey;
            this.Data = data;
        }
    }
}
