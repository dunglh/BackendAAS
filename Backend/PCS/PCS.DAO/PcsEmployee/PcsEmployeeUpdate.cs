using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsEmployee
{
    partial class PcsEmployeeUpdate : EntityBase
    {
        public PcsEmployeeUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Employee>();
        }

        private BridgeDAO<Employee> bridgeDAO;

        public bool Update(Employee data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Employee> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
