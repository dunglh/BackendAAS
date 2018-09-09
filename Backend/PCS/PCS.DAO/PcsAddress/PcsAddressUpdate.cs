using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsAddress
{
    partial class PcsAddressUpdate : EntityBase
    {
        public PcsAddressUpdate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Address>();
        }

        private BridgeDAO<Address> bridgeDAO;

        public bool Update(Address data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Update(data);
        }

        public bool UpdateList(List<Address> listData)
        {
            return IsNotNull(listData) && bridgeDAO.UpdateList(listData);
        }
    }
}
