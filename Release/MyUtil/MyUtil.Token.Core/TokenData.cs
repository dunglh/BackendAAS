using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Token.Core
{
    public class TokenData
    {
        public string TokenCode { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime ExpireTime { get; set; }
        public string LoginAddress { get; set; }
        public string MachineName { get; set; }
        public DateTime LastAccessTime { get; set; }
        public UserData User { get; set; }
    }
}
