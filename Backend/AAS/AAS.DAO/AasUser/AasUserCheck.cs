using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasUser
{
    partial class AasUserCheck : EntityBase
    {
        public AasUserCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<User>();
        }

        private BridgeDAO<User> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
