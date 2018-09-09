using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.EFMODEL.View
{
    public class ViewAddress
    {
        public long Id { get; set; }
        public Nullable<long> CreateTime { get; set; }
        public Nullable<long> ModifyTime { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<short> IsActive { get; set; }
        public string BaseUrl { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public Nullable<int> BlogId { get; set; }
        public long ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public long ProjectSttId { get; set; }
        public Nullable<long> FinishTime { get; set; }
    }
}
