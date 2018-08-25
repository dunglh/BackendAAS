using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUserRole
{
    partial class AasUserRoleTruncate : EntityBase
    {
        public AasUserRoleTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<UserRole>();
        }

        private BridgeDAO<UserRole> bridgeDAO;

        public bool Truncate(UserRole data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<UserRole> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
