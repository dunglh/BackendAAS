using AAS.DAO.Base;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasUser
{
    partial class AasUserCheck : EntityBase
    {
        public bool ExistsLoginname(string loginname, long? id)
        {
            bool result = false;
            try
            {
                loginname = (loginname == null ? "" : loginname);
                id = id.HasValue ? id.Value : -1;
                long count = 0;
                using (var ctx = new Base.AppContext())
                {
                    count = ctx.Users.AsQueryable().Where(p => p.Loginname.Equals(loginname) && p.Id != id).Count();
                }
                result = (count > 0);
            }
            catch (Exception)
            {
                Logging(LogUtil.TraceData("loginname", loginname) + LogUtil.TraceData("id", id), LogType.Error);
                throw;
            }
            return result;
        }
    }
}
