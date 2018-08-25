using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasApplicationRole
{
    partial class AasApplicationRoleCheck : EntityBase
    {
        public AasApplicationRoleCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<ApplicationRole>();
        }

        private BridgeDAO<ApplicationRole> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
