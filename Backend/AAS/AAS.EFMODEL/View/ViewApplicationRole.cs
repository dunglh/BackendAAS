using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.EFMODEL.View
{
    public class ViewApplicationRole
    {
        [Key]
        public long Id { get; set; }
        public Nullable<long> CreateTime { get; set; }
        public Nullable<long> ModifyTime { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<short> IsActive { get; set; }
        public long ApplicationId { get; set; }
        public long RoleId { get; set; }
        public string ApplicationCode { get; set; }
        public string ApplicationName { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}
