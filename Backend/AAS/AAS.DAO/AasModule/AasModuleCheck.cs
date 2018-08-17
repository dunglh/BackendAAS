using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasModule
{
    partial class AasModuleCheck : EntityBase
    {
        public AasModuleCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Module>();
        }

        private BridgeDAO<Module> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
