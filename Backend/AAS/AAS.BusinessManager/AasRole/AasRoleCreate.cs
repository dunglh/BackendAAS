using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasRole
{
    partial class AasRoleCreate : BusinessBase
    {
		private List<Role> recentAasRoles = new List<Role>();
		
        internal AasRoleCreate()
            : base()
        {

        }

        internal AasRoleCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Role data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasRoleCheck checker = new AasRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.ExistsCode(data.RoleCode, null);
                if (valid)
                {
					if (!DAOWorker.AasRoleDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasRole_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasRole that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasRoles.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasRoles))
            {
                if (!new AasRoleTruncate(param).TruncateList(this.recentAasRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasRole that bai, can kiem tra lai." + LogUtil.TraceData("recentAasRoles", this.recentAasRoles));
                }
            }
        }
    }
}
