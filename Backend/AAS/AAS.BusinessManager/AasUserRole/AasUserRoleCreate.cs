using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasUserRole
{
    partial class AasUserRoleCreate : BusinessBase
    {
		private List<UserRole> recentAasUserRoles = new List<UserRole>();
		
        internal AasUserRoleCreate()
            : base()
        {

        }

        internal AasUserRoleCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(UserRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasUserRoleCheck checker = new AasUserRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.AasUserRoleDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUserRole_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasUserRole that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasUserRoles.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasUserRoles))
            {
                if (!new AasUserRoleTruncate(param).TruncateList(this.recentAasUserRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasUserRole that bai, can kiem tra lai." + LogUtil.TraceData("recentAasUserRoles", this.recentAasUserRoles));
                }
            }
        }
    }
}
