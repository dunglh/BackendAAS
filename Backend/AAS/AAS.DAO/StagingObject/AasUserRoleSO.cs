using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasUserRoleSO : StagingObjectBase
    {
        public AasUserRoleSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<UserRole, bool>>> listUserRoleExpression = new List<System.Linq.Expressions.Expression<Func<UserRole, bool>>>();
    }
}
