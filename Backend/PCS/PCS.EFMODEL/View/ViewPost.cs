using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.EFMODEL.View
{
    public class ViewPost
    {
        public long Id { get; set; }
        public Nullable<long> CreateTime { get; set; }
        public Nullable<long> ModifyTime { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public Nullable<short> IsActive { get; set; }
        public long ProjectId { get; set; }
        public string Title { get; set; }
        public Nullable<long> PostTime { get; set; }
        public string Status { get; set; }
        public string PostType { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public long AddressId { get; set; }
        public int PostSttId { get; set; }
        public string ApprovalLoginname { get; set; }
        public string ApprovalUsername { get; set; }
        public Nullable<long> ApprovalTime { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public long ProjectSttId { get; set; }
        public Nullable<long> FinishTime { get; set; }
        public string BaseUrl { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public Nullable<int> BlogId { get; set; }
    }
}
