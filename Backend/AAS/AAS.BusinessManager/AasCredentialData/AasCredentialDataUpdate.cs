using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasCredentialData
{
    partial class AasCredentialDataUpdate : BusinessBase
    {
		private List<CredentialData> beforeUpdateAasCredentialDatas = new List<CredentialData>();
		
        internal AasCredentialDataUpdate()
            : base()
        {

        }

        internal AasCredentialDataUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(CredentialData data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasCredentialDataCheck checker = new AasCredentialDataCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                CredentialData raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {
					if (!DAOWorker.AasCredentialDataDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasCredentialData_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasCredentialData that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasCredentialDatas.Add(raw);
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

        internal bool UpdateList(List<CredentialData> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasCredentialDataCheck checker = new AasCredentialDataCheck(param);
                List<CredentialData> listRaw = new List<CredentialData>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.AasCredentialDataDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasCredentialData_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasCredentialData that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasCredentialDatas.AddRange(listRaw);
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
            if (IsNotNullOrEmpty(this.beforeUpdateAasCredentialDatas))
            {
                if (!DAOWorker.AasCredentialDataDAO.UpdateList(this.beforeUpdateAasCredentialDatas))
                {
                    LogSystem.Warn("Rollback du lieu AasCredentialData that bai, can kiem tra lai." + LogUtil.TraceData("AasCredentialDatas", this.beforeUpdateAasCredentialDatas));
                }
            }
        }
    }
}
