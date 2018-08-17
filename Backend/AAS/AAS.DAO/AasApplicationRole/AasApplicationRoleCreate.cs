using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasApplicationRole
{
    partial class AasApplicationRoleCreate : EntityBase
    {
        public AasApplicationRoleCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ApplicationRole>();
        }

        private BridgeDAO<ApplicationRole> bridgeDAO;

        public bool Create(ApplicationRole data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<ApplicationRole> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
