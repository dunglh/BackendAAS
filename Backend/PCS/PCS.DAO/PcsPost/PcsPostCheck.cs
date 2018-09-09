using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace PCS.DAO.PcsPost
{
    partial class PcsPostCheck : EntityBase
    {
        public PcsPostCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Post>();
        }

        private BridgeDAO<Post> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
