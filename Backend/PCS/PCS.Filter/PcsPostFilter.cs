using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.Filter
{
    public class PcsPostFilter : FilterBase
    {
        public long? ProjectId { get; set; }       
        public long? AddressId { get; set; }
        public int? PostSttId { get; set; }

        public List<long> ProjectIds { get; set; }
        public List<long> AddressIds { get; set; }
        public List<int> PostSttIds { get; set; }

        public long? PostTimeFrom { get; set; }
        public long? PostTimeTo { get; set; }
        public long? ApprovalTimeFrom { get; set; }
        public long? ApprovalTimeTo { get; set; }

        public string ApprovalLoginnameExact { get; set; }

        public PcsPostFilter()
            :base()
        {

        }
    }
}
