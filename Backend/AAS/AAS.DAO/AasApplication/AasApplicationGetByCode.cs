using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasApplication
{
    partial class AasApplicationGet : EntityBase
    {
        public Application GetByCode(string code, AasApplicationSO search)
        {
            Application result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNullOrEmpty(code);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Applications.AsQueryable().Where(p => p.ApplicationCode == code);
                        if (search.listApplicationExpression != null && search.listApplicationExpression.Count > 0)
                        {
                            foreach (var item in search.listApplicationExpression)
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
