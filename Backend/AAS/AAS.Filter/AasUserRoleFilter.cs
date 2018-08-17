
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasUserRoleFilter : FilterBase
    {
        public long? UserId { get; set; }
        public long? RoleId { get; set; }

        public List<long> UserIds { get; set; }
        public List<long> RoleIds { get; set; }

        public AasUserRoleFilter()
            : base()
        {
        }
    }
}
