using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasCredentialData
{
    partial class AasCredentialDataCreate : EntityBase
    {
        public AasCredentialDataCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<CredentialData>();
        }

        private BridgeDAO<CredentialData> bridgeDAO;

        public bool Create(CredentialData data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<CredentialData> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
