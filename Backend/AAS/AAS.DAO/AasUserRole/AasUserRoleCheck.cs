using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasUserRole
{
    partial class AasUserRoleCheck : EntityBase
    {
        public AasUserRoleCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<UserRole>();
        }

        private BridgeDAO<UserRole> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
