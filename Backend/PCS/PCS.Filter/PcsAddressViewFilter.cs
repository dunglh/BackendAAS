using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.Filter
{
    public class PcsAddressViewFilter:FilterBase
    {
        public long? ProjectId { get; set; }
        public long? ProjectSttId { get; set; }
        public int? BlogId { get; set; }
        public string LoginnameExact { get; set; }
        public string ProjectCodeExact { get; set; }

        public List<long> ProjectIds { get; set; }
        public List<long> ProjectSttIds { get; set; }

        public long? FinishTimeFrom { get; set; }
        public long? FinishTimeTo { get; set; }

        public PcsAddressViewFilter()
            :base()
        {

        }
    }
}
