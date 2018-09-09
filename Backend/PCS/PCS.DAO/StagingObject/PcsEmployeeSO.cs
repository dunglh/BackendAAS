using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace PCS.DAO.StagingObject
{
    public class PcsEmployeeSO : StagingObjectBase
    {
        public PcsEmployeeSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Employee, bool>>> listEmployeeExpression = new List<System.Linq.Expressions.Expression<Func<Employee, bool>>>();
    }
}
