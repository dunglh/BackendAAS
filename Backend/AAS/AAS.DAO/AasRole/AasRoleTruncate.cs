using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasRole
{
    partial class AasRoleTruncate : EntityBase
    {
        public AasRoleTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Role>();
        }

        private BridgeDAO<Role> bridgeDAO;

        public bool Truncate(Role data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Role> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
