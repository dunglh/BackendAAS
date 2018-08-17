
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasModuleRoleFilter : FilterBase
    {
        public long? ModuleId { get; set; }
        public long? RoleId { get; set; }
        
        public List<long> ModuleIds { get; set; }
        public List<long> RoleIds { get; set; }

        public AasModuleRoleFilter()
            : base()
        {
        }
    }
}
