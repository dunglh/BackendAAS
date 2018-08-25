using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasRole
{
    partial class AasRoleCheck : EntityBase
    {
        public AasRoleCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Role>();
        }

        private BridgeDAO<Role> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
