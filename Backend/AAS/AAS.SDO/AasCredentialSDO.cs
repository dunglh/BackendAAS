using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.SDO
{
    public class AasCredentialSDO
    {
        public string ValidAddress { get; set; }
        public DateTime ExpireTime { get; set; }
        public string LoginAddress { get; set; }
        public DateTime LoginTime { get; set; }
        public string TokenCode { get; set; }
        public string ApplicationCode { get; set; }
        public string Email { get; set; }
        public string Loginname { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        
        public string MachineName { get; set; }
        public DateTime LastAccessTime { get; set; }
    }
}
