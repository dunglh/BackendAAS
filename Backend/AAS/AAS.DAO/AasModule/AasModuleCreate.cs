using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasModule
{
    partial class AasModuleCreate : EntityBase
    {
        public AasModuleCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Module>();
        }

        private BridgeDAO<Module> bridgeDAO;

        public bool Create(Module data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Module> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
