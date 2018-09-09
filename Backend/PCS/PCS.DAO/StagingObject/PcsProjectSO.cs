using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace PCS.DAO.StagingObject
{
    public class PcsProjectSO : StagingObjectBase
    {
        public PcsProjectSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Project, bool>>> listProjectExpression = new List<System.Linq.Expressions.Expression<Func<Project, bool>>>();
    }
}
