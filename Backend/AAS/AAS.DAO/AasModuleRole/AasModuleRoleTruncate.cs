using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasModuleRole
{
    partial class AasModuleRoleTruncate : EntityBase
    {
        public AasModuleRoleTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ModuleRole>();
        }

        private BridgeDAO<ModuleRole> bridgeDAO;

        public bool Truncate(ModuleRole data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<ModuleRole> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
