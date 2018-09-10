using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;
using DungLH.Util.CommonLogging;

namespace PCS.DAO.PcsAddress
{
    partial class PcsAddressCheck : EntityBase
    {
        public PcsAddressCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Address>();
        }

        private BridgeDAO<Address> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }

    }
}
