using PCS.BusinessManager.Base;
using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.BusinessManager.PcsEmployee
{
    partial class PcsEmployeeUpdate : BusinessBase
    {
		private List<Employee> beforeUpdatePcsEmployees = new List<Employee>();
		
        internal PcsEmployeeUpdate()
            : base()
        {

        }

        internal PcsEmployeeUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Employee data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsEmployeeCheck checker = new PcsEmployeeCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                Employee raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
					if (!DAOWorker.PcsEmployeeDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsEmployee_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsEmployee that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdatePcsEmployees.Add(raw);
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

        internal bool UpdateList(List<Employee> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                PcsEmployeeCheck checker = new PcsEmployeeCheck(param);
                List<Employee> listRaw = new List<Employee>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.PcsEmployeeDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsEmployee_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsEmployee that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdatePcsEmployees.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdatePcsEmployees))
            {
                if (!DAOWorker.PcsEmployeeDAO.UpdateList(this.beforeUpdatePcsEmployees))
                {
                    LogSystem.Warn("Rollback du lieu PcsEmployee that bai, can kiem tra lai." + LogUtil.TraceData("PcsEmployees", this.beforeUpdatePcsEmployees));
                }
            }
        }
    }
}
