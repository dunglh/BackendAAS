using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasModule
{
    partial class AasModuleUpdate : EntityBase
    {
        public AasModuleUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Module>();
        }

        private BridgeDAO<Module> bridgeDAO;

        public bool Update(Module data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Module> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
