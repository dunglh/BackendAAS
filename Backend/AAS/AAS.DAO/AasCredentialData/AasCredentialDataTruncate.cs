using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasCredentialData
{
    partial class AasCredentialDataTruncate : EntityBase
    {
        public AasCredentialDataTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<CredentialData>();
        }

        private BridgeDAO<CredentialData> bridgeDAO;

        public bool Truncate(CredentialData data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<CredentialData> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
