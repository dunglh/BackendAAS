using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUserRole
{
    partial class AasUserRoleUpdate : EntityBase
    {
        public AasUserRoleUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<UserRole>();
        }

        private BridgeDAO<UserRole> bridgeDAO;

        public bool Update(UserRole data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<UserRole> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
