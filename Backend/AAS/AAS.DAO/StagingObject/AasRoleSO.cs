using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasRoleSO : StagingObjectBase
    {
        public AasRoleSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Role, bool>>> listRoleExpression = new List<System.Linq.Expressions.Expression<Func<Role, bool>>>();
    }
}
