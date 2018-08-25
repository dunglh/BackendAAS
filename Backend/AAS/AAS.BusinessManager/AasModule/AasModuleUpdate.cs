using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasModule
{
    partial class AasModuleUpdate : BusinessBase
    {
		private List<Module> beforeUpdateAasModules = new List<Module>();
		
        internal AasModuleUpdate()
            : base()
        {

        }

        internal AasModuleUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Module data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasModuleCheck checker = new AasModuleCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                Module raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
					if (!DAOWorker.AasModuleDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasModule_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasModule that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasModules.Add(raw);
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

        internal bool UpdateList(List<Module> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasModuleCheck checker = new AasModuleCheck(param);
                List<Module> listRaw = new List<Module>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.AasModuleDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasModule_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasModule that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasModules.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAasModules))
            {
                if (!DAOWorker.AasModuleDAO.UpdateList(this.beforeUpdateAasModules))
                {
                    LogSystem.Warn("Rollback du lieu AasModule that bai, can kiem tra lai." + LogUtil.TraceData("AasModules", this.beforeUpdateAasModules));
                }
            }
        }
    }
}
