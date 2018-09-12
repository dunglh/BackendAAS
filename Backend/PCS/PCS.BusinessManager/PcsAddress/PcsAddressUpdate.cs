using PCS.BusinessManager.Base;
using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using PCS.BusinessManager.PcsProject;

namespace PCS.BusinessManager.PcsAddress
{
    partial class PcsAddressUpdate : BusinessBase
    {
		private List<Address> beforeUpdatePcsAddresss = new List<Address>();
		
        internal PcsAddressUpdate()
            : base()
        {

        }

        internal PcsAddressUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Address data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Address raw = null;
                Project project = null;
                PcsAddressCheck checker = new PcsAddressCheck(param);
                PcsProjectCheck projectChecker = new PcsProjectCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && projectChecker.VerifyId(data.ProjectId, ref project);
                valid = valid && projectChecker.IsUnLock(project);
                valid = valid && projectChecker.IsUnFinish(project);
                if (valid)
                {
					if (!DAOWorker.PcsAddressDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsAddress_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsAddress that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdatePcsAddresss.Add(raw);
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

        internal bool UpdateList(List<Address> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                PcsAddressCheck checker = new PcsAddressCheck(param);
                List<Address> listRaw = new List<Address>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.PcsAddressDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsAddress_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsAddress that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdatePcsAddresss.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdatePcsAddresss))
            {
                if (!DAOWorker.PcsAddressDAO.UpdateList(this.beforeUpdatePcsAddresss))
                {
                    LogSystem.Warn("Rollback du lieu PcsAddress that bai, can kiem tra lai." + LogUtil.TraceData("PcsAddresss", this.beforeUpdatePcsAddresss));
                }
            }
        }
    }
}
