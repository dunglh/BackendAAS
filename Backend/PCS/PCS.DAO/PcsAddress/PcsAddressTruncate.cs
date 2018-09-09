using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsAddress
{
    partial class PcsAddressTruncate : EntityBase
    {
        public PcsAddressTruncate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Address>();
        }

        private BridgeDAO<Address> bridgeDAO;

        public bool Truncate(Address data)
        {
            return IsNotNull(data) && IsGreaterThanZero(data.Id) && bridgeDAO.Truncate(data.Id);
        }

        public bool TruncateList(List<Address> listData)
        {
            return IsNotNullOrEmpty(listData) && bridgeDAO.TruncateListRaw(listData);
        }
    }
}
