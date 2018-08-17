using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasModuleRole
{
    partial class AasModuleRoleUpdate : BusinessBase
    {
		private List<ModuleRole> beforeUpdateAasModuleRoles = new List<ModuleRole>();
		
        internal AasModuleRoleUpdate()
            : base()
        {

        }

        internal AasModuleRoleUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(ModuleRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasModuleRoleCheck checker = new AasModuleRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                ModuleRole raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
					if (!DAOWorker.AasModuleRoleDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasModuleRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasModuleRole that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasModuleRoles.Add(raw);
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

        internal bool UpdateList(List<ModuleRole> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasModuleRoleCheck checker = new AasModuleRoleCheck(param);
                List<ModuleRole> listRaw = new List<ModuleRole>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.AasModuleRoleDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasModuleRole_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasModuleRole that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasModuleRoles.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAasModuleRoles))
            {
                if (!DAOWorker.AasModuleRoleDAO.UpdateList(this.beforeUpdateAasModuleRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasModuleRole that bai, can kiem tra lai." + LogUtil.TraceData("AasModuleRoles", this.beforeUpdateAasModuleRoles));
                }
            }
        }
    }
}
