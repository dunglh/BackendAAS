using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace PCS.DAO.StagingObject
{
    public class PcsAddressSO : StagingObjectBase
    {
        public PcsAddressSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Address, bool>>> listAddressExpression = new List<System.Linq.Expressions.Expression<Func<Address, bool>>>();
    }
}
