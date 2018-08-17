using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasUserSO : StagingObjectBase
    {
        public AasUserSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<User, bool>>> listUserExpression = new List<System.Linq.Expressions.Expression<Func<User, bool>>>();
    }
}
