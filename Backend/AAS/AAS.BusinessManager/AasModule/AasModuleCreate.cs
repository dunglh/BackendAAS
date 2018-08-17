using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasModule
{
    partial class AasModuleCreate : BusinessBase
    {
		private List<Module> recentAasModules = new List<Module>();
		
        internal AasModuleCreate()
            : base()
        {

        }

        internal AasModuleCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Module data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasModuleCheck checker = new AasModuleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.AasModuleDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasModule_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasModule that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasModules.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasModules))
            {
                if (!new AasModuleTruncate(param).TruncateList(this.recentAasModules))
                {
                    LogSystem.Warn("Rollback du lieu AasModule that bai, can kiem tra lai." + LogUtil.TraceData("recentAasModules", this.recentAasModules));
                }
            }
        }
    }
}
