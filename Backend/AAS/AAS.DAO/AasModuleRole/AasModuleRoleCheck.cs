using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasModuleRole
{
    partial class AasModuleRoleCheck : EntityBase
    {
        public AasModuleRoleCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<ModuleRole>();
        }

        private BridgeDAO<ModuleRole> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
