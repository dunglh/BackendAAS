using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace PCS.DAO.PcsPost
{
    partial class PcsPostCreate : EntityBase
    {
        public PcsPostCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Post>();
        }

        private BridgeDAO<Post> bridgeDAO;

        public bool Create(Post data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Post> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
