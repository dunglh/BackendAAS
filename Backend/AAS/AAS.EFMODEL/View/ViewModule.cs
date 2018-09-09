using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.EFMODEL.View
{
    public class ViewModule
    {
        public long Id { get; set; }
        public Nullable<long> CreateTime { get; set; }
        public Nullable<long> ModifyTime { get; set; }
        public Nullable<short> IsActive { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public long ApplicationId { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public string ApplicationCode { get; set; }
        public string ApplicationName { get; set; }
    }
}
