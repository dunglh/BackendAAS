using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.BusinessManager.Base;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace PCS.BusinessManager.PcsProject
{
    partial class PcsProjectCreate : BusinessBase
    {
		private List<Project> recentPcsProjects = new List<Project>();
		
        internal PcsProjectCreate()
            : base()
        {

        }

        internal PcsProjectCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Project data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsProjectCheck checker = new PcsProjectCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.ExistsCode(data.ProjectCode, null);
                if (valid)
                {
					if (!DAOWorker.PcsProjectDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsProject_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin PcsProject that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentPcsProjects.Add(data);
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
            if (IsNotNullOrEmpty(this.recentPcsProjects))
            {
                if (!new PcsProjectTruncate(param).TruncateList(this.recentPcsProjects))
                {
                    LogSystem.Warn("Rollback du lieu PcsProject that bai, can kiem tra lai." + LogUtil.TraceData("recentPcsProjects", this.recentPcsProjects));
                }
            }
        }
    }
}
