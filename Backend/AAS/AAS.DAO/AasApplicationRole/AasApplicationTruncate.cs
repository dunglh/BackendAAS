using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasApplicationRole
{
    partial class AasApplicationRoleTruncate : EntityBase
    {
        public AasApplicationRoleTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ApplicationRole>();
        }

        private BridgeDAO<ApplicationRole> bridgeDAO;

        public bool Truncate(ApplicationRole data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<ApplicationRole> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
