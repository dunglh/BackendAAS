using DungLH.Util.Backend.MANAGER;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.BusinessManager.PcsPost.Reject
{
    class PcsPostReject : BusinessBase
    {
        private PcsPostUpdate pcsPostUpdate;

        internal PcsPostReject()
            :base()
        {
            this.pcsPostUpdate = new PcsPostUpdate(param);
        }

        internal PcsPostReject(CommonParam param)
            : base(param)
        {
            this.pcsPostUpdate = new PcsPostUpdate(param);
        }
    }
}
