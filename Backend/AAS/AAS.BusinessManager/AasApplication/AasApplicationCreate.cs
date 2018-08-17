using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasApplication
{
    partial class AasApplicationCreate : BusinessBase
    {
		private List<Application> recentAasApplications = new List<Application>();
		
        internal AasApplicationCreate()
            : base()
        {

        }

        internal AasApplicationCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Application data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasApplicationCheck checker = new AasApplicationCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.ExistsCode(data.ApplicationCode, null);
                if (valid)
                {
					if (!DAOWorker.AasApplicationDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasApplication_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasApplication that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasApplications.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasApplications))
            {
                if (!new AasApplicationTruncate(param).TruncateList(this.recentAasApplications))
                {
                    LogSystem.Warn("Rollback du lieu AasApplication that bai, can kiem tra lai." + LogUtil.TraceData("recentAasApplications", this.recentAasApplications));
                }
            }
        }
    }
}
