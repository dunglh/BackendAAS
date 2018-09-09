using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsPost
{
    partial class PcsPostUpdate : EntityBase
    {
        public PcsPostUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Post>();
        }

        private BridgeDAO<Post> bridgeDAO;

        public bool Update(Post data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Post> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
