using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasApplication
{
    partial class AasApplicationUpdate : BusinessBase
    {
		private List<Application> beforeUpdateAasApplications = new List<Application>();
		
        internal AasApplicationUpdate()
            : base()
        {

        }

        internal AasApplicationUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Application data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasApplicationCheck checker = new AasApplicationCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                Application raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.ExistsCode(data.ApplicationCode, data.Id);
                if (valid)
                {
					if (!DAOWorker.AasApplicationDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasApplication_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasApplication that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasApplications.Add(raw);
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

        internal bool UpdateList(List<Application> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasApplicationCheck checker = new AasApplicationCheck(param);
                List<Application> listRaw = new List<Application>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsCode(data.ApplicationCode, data.Id);
                }
                if (valid)
                {
					if (!DAOWorker.AasApplicationDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasApplication_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasApplication that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasApplications.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAasApplications))
            {
                if (!DAOWorker.AasApplicationDAO.UpdateList(this.beforeUpdateAasApplications))
                {
                    LogSystem.Warn("Rollback du lieu AasApplication that bai, can kiem tra lai." + LogUtil.TraceData("AasApplications", this.beforeUpdateAasApplications));
                }
            }
        }
    }
}
