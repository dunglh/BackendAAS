using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasRole
{
    partial class AasRoleUpdate : BusinessBase
    {
		private List<Role> beforeUpdateAasRoles = new List<Role>();
		
        internal AasRoleUpdate()
            : base()
        {

        }

        internal AasRoleUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Role data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasRoleCheck checker = new AasRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                Role raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.ExistsCode(data.RoleCode, data.Id);
                if (valid)
                {
					if (!DAOWorker.AasRoleDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasRole that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasRoles.Add(raw);
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

        internal bool UpdateList(List<Role> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasRoleCheck checker = new AasRoleCheck(param);
                List<Role> listRaw = new List<Role>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsCode(data.RoleCode, data.Id);
                }
                if (valid)
                {
					if (!DAOWorker.AasRoleDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasRole that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasRoles.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAasRoles))
            {
                if (!DAOWorker.AasRoleDAO.UpdateList(this.beforeUpdateAasRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasRole that bai, can kiem tra lai." + LogUtil.TraceData("AasRoles", this.beforeUpdateAasRoles));
                }
            }
        }
    }
}
