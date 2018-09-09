using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasApplicationRoleSO : StagingObjectBase
    {
        public AasApplicationRoleSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<ApplicationRole, bool>>> listApplicationRoleExpression = new List<System.Linq.Expressions.Expression<Func<ApplicationRole, bool>>>();
        public List<System.Linq.Expressions.Expression<Func<ViewApplicationRole, bool>>> listViewApplicationRoleExpression = new List<System.Linq.Expressions.Expression<Func<ViewApplicationRole, bool>>>();
    }
}
