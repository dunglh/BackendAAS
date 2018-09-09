
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasModuleRoleViewFilter : FilterBase
    {
        public long? ModuleId { get; set; }
        public long? RoleId { get; set; }
        public long? ApplicationId { get; set; }
        public string ModuleCodeExact { get; set; }
        public string RoleCodeExact { get; set; }
        public string ApplicationCodeExact { get; set; }

        public List<long> ModuleIds { get; set; }
        public List<long> RoleIds { get; set; }
        public List<long> ApplicationIds { get; set; }

        public AasModuleRoleViewFilter()
            : base()
        {
        }
    }
}
