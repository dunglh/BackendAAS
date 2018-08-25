using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasApplication
{
    partial class AasApplicationCreate : EntityBase
    {
        public AasApplicationCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Application>();
        }

        private BridgeDAO<Application> bridgeDAO;

        public bool Create(Application data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Application> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
