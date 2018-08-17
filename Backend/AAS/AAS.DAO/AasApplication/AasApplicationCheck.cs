using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasApplication
{
    partial class AasApplicationCheck : EntityBase
    {
        public AasApplicationCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Application>();
        }

        private BridgeDAO<Application> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
