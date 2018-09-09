
using System.Collections.Generic;

namespace AAS.Filter
{
    public class AasModuleViewFilter : FilterBase
    {
        public string ModuleCodeExact { get; set; }
        public string ApplicationCodeExact { get; set; }
        public long? ApplicationId { get; set; }

        public List<long> ApplicationIds { get; set; }

        public AasModuleViewFilter()
            : base()
        {
        }
    }
}
