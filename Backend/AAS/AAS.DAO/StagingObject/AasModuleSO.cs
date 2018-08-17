using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasModuleSO : StagingObjectBase
    {
        public AasModuleSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Module, bool>>> listModuleExpression = new List<System.Linq.Expressions.Expression<Func<Module, bool>>>();
    }
}
