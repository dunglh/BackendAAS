using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasUserRole
{
    partial class AasUserRoleUpdate : BusinessBase
    {
		private List<UserRole> beforeUpdateAasUserRoles = new List<UserRole>();
		
        internal AasUserRoleUpdate()
            : base()
        {

        }

        internal AasUserRoleUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(UserRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasUserRoleCheck checker = new AasUserRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                UserRole raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
					if (!DAOWorker.AasUserRoleDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUserRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasUserRole that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasUserRoles.Add(raw);
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

        internal bool UpdateList(List<UserRole> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasUserRoleCheck checker = new AasUserRoleCheck(param);
                List<UserRole> listRaw = new List<UserRole>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.AasUserRoleDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUserRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasUserRole that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasUserRoles.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAasUserRoles))
            {
                if (!DAOWorker.AasUserRoleDAO.UpdateList(this.beforeUpdateAasUserRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasUserRole that bai, can kiem tra lai." + LogUtil.TraceData("AasUserRoles", this.beforeUpdateAasUserRoles));
                }
            }
        }
    }
}
