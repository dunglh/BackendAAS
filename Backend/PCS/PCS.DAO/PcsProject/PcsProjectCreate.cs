using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace PCS.DAO.PcsProject
{
    partial class PcsProjectCreate : EntityBase
    {
        public PcsProjectCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Project>();
        }

        private BridgeDAO<Project> bridgeDAO;

        public bool Create(Project data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Project> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
