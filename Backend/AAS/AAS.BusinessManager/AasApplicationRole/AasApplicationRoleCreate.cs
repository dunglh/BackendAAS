using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasApplicationRole
{
    partial class AasApplicationRoleCreate : BusinessBase
    {
		private List<ApplicationRole> recentAasApplicationRoles = new List<ApplicationRole>();
		
        internal AasApplicationRoleCreate()
            : base()
        {

        }

        internal AasApplicationRoleCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(ApplicationRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasApplicationRoleCheck checker = new AasApplicationRoleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.AasApplicationRoleDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasApplicationRole_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasApplicationRole that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasApplicationRoles.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasApplicationRoles))
            {
                if (!new AasApplicationRoleTruncate(param).TruncateList(this.recentAasApplicationRoles))
                {
                    LogSystem.Warn("Rollback du lieu AasApplicationRole that bai, can kiem tra lai." + LogUtil.TraceData("recentAasApplicationRoles", this.recentAasApplicationRoles));
                }
            }
        }
    }
}
