using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasRole
{
    partial class AasRoleUpdate : EntityBase
    {
        public AasRoleUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Role>();
        }

        private BridgeDAO<Role> bridgeDAO;

        public bool Update(Role data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Role> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
