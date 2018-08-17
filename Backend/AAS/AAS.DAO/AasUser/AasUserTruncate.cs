using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUser
{
    partial class AasUserTruncate : EntityBase
    {
        public AasUserTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<User>();
        }

        private BridgeDAO<User> bridgeDAO;

        public bool Truncate(User data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<User> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
