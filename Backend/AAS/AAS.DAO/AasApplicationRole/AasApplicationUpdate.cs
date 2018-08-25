using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasApplicationRole
{
    partial class AasApplicationRoleUpdate : EntityBase
    {
        public AasApplicationRoleUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ApplicationRole>();
        }

        private BridgeDAO<ApplicationRole> bridgeDAO;

        public bool Update(ApplicationRole data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<ApplicationRole> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
