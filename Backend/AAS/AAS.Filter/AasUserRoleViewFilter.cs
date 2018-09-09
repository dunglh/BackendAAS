
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasUserRoleViewFilter : FilterBase
    {
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
        public string LoginnameExact { get; set; }
        public string RoleCodeExact { get; set; }

        public List<long> UserIds { get; set; }
        public List<long> RoleIds { get; set; }

        public AasUserRoleViewFilter()
            : base()
        {
        }
    }
}
