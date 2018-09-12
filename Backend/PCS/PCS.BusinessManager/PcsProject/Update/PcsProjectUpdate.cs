using PCS.BusinessManager.Base;
using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.BusinessManager.PcsProject
{
    partial class PcsProjectUpdate : BusinessBase
    {
		private List<Project> beforeUpdatePcsProjects = new List<Project>();
		
        internal PcsProjectUpdate()
            : base()
        {

        }

        internal PcsProjectUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Project data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsProjectCheck checker = new PcsProjectCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                Project raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.IsUnFinish(raw);
                valid = valid && checker.ExistsCode(data.ProjectCode, data.Id);
                if (valid)
                {
					if (!DAOWorker.PcsProjectDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsProject_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsProject that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdatePcsProjects.Add(raw);
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

        internal bool Update(Project data, Project before)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsProjectCheck checker = new PcsProjectCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.IsUnLock(before);
                valid = valid && checker.IsUnFinish(before);
                valid = valid && checker.ExistsCode(data.ProjectCode, data.Id);
                if (valid)
                {
                    if (!DAOWorker.PcsProjectDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsProject_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsProject that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdatePcsProjects.Add(before);
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

        internal bool UpdateList(List<Project> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                PcsProjectCheck checker = new PcsProjectCheck(param);
                List<Project> listRaw = new List<Project>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsCode(data.ProjectCode, data.Id);
                }
                if (valid)
                {
					if (!DAOWorker.PcsProjectDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsProject_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsProject that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdatePcsProjects.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdatePcsProjects))
            {
                if (!DAOWorker.PcsProjectDAO.UpdateList(this.beforeUpdatePcsProjects))
                {
                    LogSystem.Warn("Rollback du lieu PcsProject that bai, can kiem tra lai." + LogUtil.TraceData("PcsProjects", this.beforeUpdatePcsProjects));
                }
            }
        }
    }
}
