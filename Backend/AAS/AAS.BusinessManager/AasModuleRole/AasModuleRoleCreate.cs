using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasModuleRole
{
    partial class AasModuleRoleCreate : BusinessBase
    {
		private List<ModuleRole> recentAasModuleRoles = new List<ModuleRole>();
		
        internal AasModuleRoleCreate()
            : base()
        {

        }

        internal AasModuleRoleCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(ModuleRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasModuleRoleCheck checker = new AasModuleRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.AasModuleRoleDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasModuleRole_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasModuleRole that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasModuleRoles.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasModuleRoles))
            {
                if (!new AasModuleRoleTruncate(param).TruncateList(this.recentAasModuleRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasModuleRole that bai, can kiem tra lai." + LogUtil.TraceData("recentAasModuleRoles", this.recentAasModuleRoles));
                }
            }
        }
    }
}
