using PCS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.SDO
{
    public class PcsPostSDO
    {
        public long ProjectId { get; set; }
        public string Note { get; set; }
        public List<Post> Posts { get; set; }
    }
}
