using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.EFMODEL.View
{
    public class ViewUserRole
    {
        public long Id { get; set; }
        public Nullable<long> CreateTime { get; set; }
        public Nullable<long> ModifyTime { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<short> IsActive { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string Loginname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}
