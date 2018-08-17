using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasCredentialData
{
    partial class AasCredentialDataCheck : EntityBase
    {
        public AasCredentialDataCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<CredentialData>();
        }

        private BridgeDAO<CredentialData> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
