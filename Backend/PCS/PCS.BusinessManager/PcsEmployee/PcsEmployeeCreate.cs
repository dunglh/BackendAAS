using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.BusinessManager.Base;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace PCS.BusinessManager.PcsEmployee
{
    partial class PcsEmployeeCreate : BusinessBase
    {
		private List<Employee> recentPcsEmployees = new List<Employee>();
		
        internal PcsEmployeeCreate()
            : base()
        {

        }

        internal PcsEmployeeCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Employee data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsEmployeeCheck checker = new PcsEmployeeCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.PcsEmployeeDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsEmployee_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin PcsEmployee that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentPcsEmployees.Add(data);
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
            if (IsNotNullOrEmpty(this.recentPcsEmployees))
            {
                if (!new PcsEmployeeTruncate(param).TruncateList(this.recentPcsEmployees))
                {
                    LogSystem.Warn("Rollback du lieu PcsEmployee that bai, can kiem tra lai." + LogUtil.TraceData("recentPcsEmployees", this.recentPcsEmployees));
                }
            }
        }
    }
}
