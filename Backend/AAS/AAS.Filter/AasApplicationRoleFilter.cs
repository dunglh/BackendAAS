
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasApplicationRoleFilter : FilterBase
    {
        public long? ApplicationId { get; set; }
        public long? RoleId { get; set; }

        public List<long> ApplicationIds { get; set; }
        public List<long> RoleIds { get; set; }

        public AasApplicationRoleFilter()
            : base()
        {
        }
    }
}
