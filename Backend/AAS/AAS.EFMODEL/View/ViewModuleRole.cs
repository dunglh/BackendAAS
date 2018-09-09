using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.EFMODEL.View
{
    public class ViewModuleRole
    {
        public long Id { get; set; }
        public Nullable<long> CreateTime { get; set; }
        public Nullable<long> ModifyTime { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<short> IsActive { get; set; }
        public long ModuleId { get; set; }
        public long RoleId { get; set; }
        public Nullable<short> IsAllowCreate { get; set; }
        public Nullable<short> IsAllowUpdate { get; set; }
        public Nullable<short> IsAllowDelete { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public Nullable<long> ApplicationId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string ApplicationCode { get; set; }
        public string ApplicationName { get; set; }
    }
}
