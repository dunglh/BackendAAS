using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasApplication
{
    partial class AasApplicationTruncate : EntityBase
    {
        public AasApplicationTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Application>();
        }

        private BridgeDAO<Application> bridgeDAO;

        public bool Truncate(Application data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Application> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
