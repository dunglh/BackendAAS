using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasApplication
{
    partial class AasApplicationUpdate : EntityBase
    {
        public AasApplicationUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Application>();
        }

        private BridgeDAO<Application> bridgeDAO;

        public bool Update(Application data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Application> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
