using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace PCS.DAO.PcsEmployee
{
    partial class PcsEmployeeCheck : EntityBase
    {
        public PcsEmployeeCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Employee>();
        }

        private BridgeDAO<Employee> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
