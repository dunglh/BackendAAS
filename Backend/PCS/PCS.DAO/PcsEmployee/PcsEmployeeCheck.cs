using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Core;
using System;
using System.Linq;
using DungLH.Util.CommonLogging;

namespace PCS.DAO.PcsEmployee
{
    partial class PcsEmployeeCheck : EntityBase
    {
        public PcsEmployeeCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<Employee>();
        }

        private BridgeDAO<Employee> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }

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
                    count = ctx.Employees.AsQueryable().Where(p => p.Loginname.Equals(loginname) && p.Id != id).Count();
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
