using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasModuleRole
{
    partial class AasModuleRoleUpdate : EntityBase
    {
        public AasModuleRoleUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ModuleRole>();
        }

        private BridgeDAO<ModuleRole> bridgeDAO;

        public bool Update(ModuleRole data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<ModuleRole> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
