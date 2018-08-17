using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace AAS.DAO.StagingObject
{
    public class AasCredentialDataSO : StagingObjectBase
    {
        public AasCredentialDataSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<CredentialData, bool>>> listCredentialDataExpression = new List<System.Linq.Expressions.Expression<Func<CredentialData, bool>>>();
    }
}
