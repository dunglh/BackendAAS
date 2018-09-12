using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.Filter
{
    public class PcsAddressFilter : FilterBase
    {
        public string LoginnameExact { get; set; }
        public int? BlogId { get; set; }
        public long? ProjectId { get; set; }

        public List<int> BlogIds { get; set; }
        public List<long> ProjectIds { get; set; }

        public PcsAddressFilter()
            :base()
        {

        }
    }
}
