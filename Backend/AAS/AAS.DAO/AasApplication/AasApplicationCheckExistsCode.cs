using AAS.DAO.Base;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Linq;

namespace AAS.DAO.AasApplication
{
    partial class AasApplicationCheck : EntityBase
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
                    count = ctx.Applications.AsQueryable().Where(p => p.ApplicationCode.Equals(code) && p.Id != id).Count();
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
