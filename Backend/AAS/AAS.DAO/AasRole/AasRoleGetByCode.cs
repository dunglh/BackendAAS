using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasRole
{
    partial class AasRoleGet : EntityBase
    {
        public Role GetByCode(string code, AasRoleSO search)
        {
            Role result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNullOrEmpty(code);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Roles.AsQueryable().Where(p => p.RoleCode == code);
                        if (search.listRoleExpression != null && search.listRoleExpression.Count > 0)
                        {
                            foreach (var item in search.listRoleExpression)
                            {
                                query = query.Where(item);
                            }
                        }
                        result = query.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging(LogUtil.TraceData("code", code) + LogUtil.TraceData("search", search), LogType.Error);
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
