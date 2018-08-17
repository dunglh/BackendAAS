using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasModule
{
    partial class AasModuleTruncate : EntityBase
    {
        public AasModuleTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Module>();
        }

        private BridgeDAO<Module> bridgeDAO;

        public bool Truncate(Module data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Module> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
