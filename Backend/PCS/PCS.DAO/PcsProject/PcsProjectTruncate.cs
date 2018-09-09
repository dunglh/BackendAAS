using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsProject
{
    partial class PcsProjectTruncate : EntityBase
    {
        public PcsProjectTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Project>();
        }

        private BridgeDAO<Project> bridgeDAO;

        public bool Truncate(Project data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Project> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
