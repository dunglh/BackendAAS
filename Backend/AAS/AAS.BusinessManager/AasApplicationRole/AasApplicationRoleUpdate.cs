using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasApplicationRole
{
    partial class AasApplicationRoleUpdate : BusinessBase
    {
		private List<ApplicationRole> beforeUpdateAasApplicationRoles = new List<ApplicationRole>();
		
        internal AasApplicationRoleUpdate()
            : base()
        {

        }

        internal AasApplicationRoleUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(ApplicationRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasApplicationRoleCheck checker = new AasApplicationRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                ApplicationRole raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
					if (!DAOWorker.AasApplicationRoleDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasApplicationRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasApplicationRole that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasApplicationRoles.Add(raw);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        internal bool UpdateList(List<ApplicationRole> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasApplicationRoleCheck checker = new AasApplicationRoleCheck(param);
                List<ApplicationRole> listRaw = new List<ApplicationRole>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.AasApplicationRoleDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasApplicationRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasApplicationRole that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasApplicationRoles.AddRange(listRaw);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.beforeUpdateAasApplicationRoles))
            {
                if (!DAOWorker.AasApplicationRoleDAO.UpdateList(this.beforeUpdateAasApplicationRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasApplicationRole that bai, can kiem tra lai." + LogUtil.TraceData("AasApplicationRoles", this.beforeUpdateAasApplicationRoles));
                }
            }
        }
    }
}
