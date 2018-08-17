using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasModuleRoleSO : StagingObjectBase
    {
        public AasModuleRoleSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<ModuleRole, bool>>> listModuleRoleExpression = new List<System.Linq.Expressions.Expression<Func<ModuleRole, bool>>>();
    }
}
