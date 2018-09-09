using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsPost
{
    partial class PcsPostTruncate : EntityBase
    {
        public PcsPostTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Post>();
        }

        private BridgeDAO<Post> bridgeDAO;

        public bool Truncate(Post data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Post> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
