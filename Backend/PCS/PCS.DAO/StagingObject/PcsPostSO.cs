using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace PCS.DAO.StagingObject
{
    public class PcsPostSO : StagingObjectBase
    {
        public PcsPostSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<Post, bool>>> listPostExpression = new List<System.Linq.Expressions.Expression<Func<Post, bool>>>();
    }
}
