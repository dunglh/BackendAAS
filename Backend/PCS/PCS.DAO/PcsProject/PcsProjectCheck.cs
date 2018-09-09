using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace PCS.DAO.PcsProject
{
    partial class PcsProjectCheck : EntityBase
    {
        public PcsProjectCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Project>();
        }

        private BridgeDAO<Project> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
