using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System.Collections.Generic;

namespace PCS.DAO.PcsAddress
{
    partial class PcsAddressCreate : EntityBase
    {
        public PcsAddressCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<Address>();
        }

        private BridgeDAO<Address> bridgeDAO;

        public bool Create(Address data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<Address> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
