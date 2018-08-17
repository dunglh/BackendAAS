using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUser
{
    partial class AasUserUpdate : EntityBase
    {
        public AasUserUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<User>();
        }

        private BridgeDAO<User> bridgeDAO;

        public bool Update(User data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<User> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
