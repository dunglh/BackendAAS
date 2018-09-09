using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsProject
{
    partial class PcsProjectUpdate : EntityBase
    {
        public PcsProjectUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Project>();
        }

        private BridgeDAO<Project> bridgeDAO;

        public bool Update(Project data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Project> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
