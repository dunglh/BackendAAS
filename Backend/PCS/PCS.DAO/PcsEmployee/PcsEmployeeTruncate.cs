using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsEmployee
{
    partial class PcsEmployeeTruncate : EntityBase
    {
        public PcsEmployeeTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Employee>();
        }

        private BridgeDAO<Employee> bridgeDAO;

        public bool Truncate(Employee data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Employee> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
