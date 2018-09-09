using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.Filter
{
    public class PcsPostViewFilter :FilterBase
    {
        public long? ProjectId { get; set; }
        public long? ProjectSttId { get; set; }
        public long? AddressId { get; set; }
        public int? PostSttId { get; set; }
        public int? BlogId { get; set; }

        public List<long> ProjectIds { get; set; }
        public List<long> ProjectSttIds { get; set; }
        public List<long> AddressIds { get; set; }

        public string LoginnameExact { get; set; }
        public string ApprovalLoginnameExact { get; set; }
        public string ProjectCodeExact { get; set; }

        public long? ApprovalTimeFrom { get; set; }
        public long? ApprovalTimeTo { get; set; }
        public long? FinishTimeFrom { get; set; }
        public long? FinishTimeTo { get; set; }
        public long? PostTimeFrom { get; set; }
        public long? PostTimeTo { get; set; }

        public PcsPostViewFilter()
            :base()
        {

        }
    }
}
