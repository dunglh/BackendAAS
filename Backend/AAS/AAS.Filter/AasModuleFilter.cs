
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasModuleFilter : FilterBase
    {
        public string ModuleCodeExact { get; set; }
        public long? ApplicationId { get; set; }

        public List<long> ApplicationIds { get; set; }

        public AasModuleFilter()
            : base()
        {
        }
    }
}
