using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasApplicationSO : StagingObjectBase
    {
        public AasApplicationSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Application, bool>>> listApplicationExpression = new List<System.Linq.Expressions.Expression<Func<Application, bool>>>();
    }
}
