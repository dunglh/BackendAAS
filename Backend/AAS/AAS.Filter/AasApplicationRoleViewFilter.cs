
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasApplicationRoleViewFilter : FilterBase
    {
        public long? ApplicationId { get; set; }
        public long? RoleId { get; set; }

        public List<long> ApplicationIds { get; set; }
        public List<long> RoleIds { get; set; }

        public string ApplicationCodeExact { get; set; }
        public string RoleCodeExact { get; set; }

        public AasApplicationRoleViewFilter()
            : base()
        {
        }
    }
}
