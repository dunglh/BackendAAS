using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace PCS.DAO.PcsEmployee
{
    partial class PcsEmployeeCreate : EntityBase
    {
        public PcsEmployeeCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Employee>();
        }

        private BridgeDAO<Employee> bridgeDAO;

        public bool Create(Employee data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Employee> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
