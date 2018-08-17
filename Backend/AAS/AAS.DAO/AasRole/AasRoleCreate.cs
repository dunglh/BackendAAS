using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasRole
{
    partial class AasRoleCreate : EntityBase
    {
        public AasRoleCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Role>();
        }

        private BridgeDAO<Role> bridgeDAO;

        public bool Create(Role data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Role> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
