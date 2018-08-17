using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasModuleRole
{
    partial class AasModuleRoleCreate : EntityBase
    {
        public AasModuleRoleCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ModuleRole>();
        }

        private BridgeDAO<ModuleRole> bridgeDAO;

        public bool Create(ModuleRole data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<ModuleRole> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
