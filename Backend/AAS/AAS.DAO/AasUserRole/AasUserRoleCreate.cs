using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasUserRole
{
    partial class AasUserRoleCreate : EntityBase
    {
        public AasUserRoleCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<UserRole>();
        }

        private BridgeDAO<UserRole> bridgeDAO;

        public bool Create(UserRole data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<UserRole> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
