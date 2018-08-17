using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Core;
using System.Collections.Generic;

namespace AAS.DAO.AasUser
{
    partial class AasUserCreate : EntityBase
    {
        public AasUserCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<User>();
        }

        private BridgeDAO<User> bridgeDAO;

        public bool Create(User data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<User> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
