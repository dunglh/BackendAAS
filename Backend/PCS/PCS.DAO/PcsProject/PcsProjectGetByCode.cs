using PCS.DAO.Base;
using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsProject
{
    partial class PcsProjectGet : EntityBase
    {
        public Project GetByCode(string code, PcsProjectSO search)
        {
            Project result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNullOrEmpty(code);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Projects.AsQueryable().Where(p => p.ProjectCode == code);
                        if (search.listProjectExpression != null && search.listProjectExpression.Count > 0)
                        {
                            foreach (var item in search.listProjectExpression)
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
