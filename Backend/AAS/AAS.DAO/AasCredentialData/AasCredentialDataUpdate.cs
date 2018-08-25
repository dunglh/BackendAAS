using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasCredentialData
{
    partial class AasCredentialDataUpdate : EntityBase
    {
        public AasCredentialDataUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<CredentialData>();
        }

        private BridgeDAO<CredentialData> bridgeDAO;

        public bool Update(CredentialData data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<CredentialData> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
