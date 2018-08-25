using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUser
{
    partial class AasUserGet : EntityBase
    {
        public User GetByLoginname(string loginname, AasUserSO search)
        {
            User result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNullOrEmpty(loginname);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Users.AsQueryable().Where(p => p.Loginname == loginname);
                        if (search.listUserExpression != null && search.listUserExpression.Count > 0)
                        {
                            foreach (var item in search.listUserExpression)
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
                Logging(LogUtil.TraceData("code", loginname) + LogUtil.TraceData("search", search), LogType.Error);
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
