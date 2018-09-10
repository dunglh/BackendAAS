using PCS.DAO.Base;
using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.DAO.PcsEmployee
{
    partial class PcsEmployeeGet : EntityBase
    {
        public Employee GetByLoginname(string loginname, PcsEmployeeSO search)
        {
            Employee result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNullOrEmpty(loginname);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Employees.AsQueryable().Where(p => p.Loginname == loginname);
                        if (search.listEmployeeExpression != null && search.listEmployeeExpression.Count > 0)
                        {
                            foreach (var item in search.listEmployeeExpression)
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
                Logging(LogUtil.TraceData("loginname", loginname) + LogUtil.TraceData("search", search), LogType.Error);
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
