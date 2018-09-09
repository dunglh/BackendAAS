using PCS.DAO.Base;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Linq;

namespace PCS.DAO.PcsProject
{
    partial class PcsProjectCheck : EntityBase
    {
        public bool ExistsCode(string code, long? id)
        {
            bool result = false;
            try
            {
                code = (code == null ? "" : code);
                id = id.HasValue ? id.Value : -1;
                long count = 0;
                using (var ctx = new Base.AppContext())
                {
                    count = ctx.Projects.AsQueryable().Where(p => p.ProjectCode.Equals(code) && p.Id != id).Count();
                }
                result = (count > 0);
            }
            catch (Exception)
            {
                Logging(LogUtil.TraceData("code", code) + LogUtil.TraceData("id", id), LogType.Error);
                throw;
            }
            return result;
        }
    }
}
