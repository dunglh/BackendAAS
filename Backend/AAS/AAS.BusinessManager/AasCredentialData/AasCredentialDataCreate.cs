using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasCredentialData
{
    partial class AasCredentialDataCreate : BusinessBase
    {
		private List<CredentialData> recentAasCredentialDatas = new List<CredentialData>();
		
        internal AasCredentialDataCreate()
            : base()
        {

        }

        internal AasCredentialDataCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(CredentialData data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasCredentialDataCheck checker = new AasCredentialDataCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.AasCredentialDataDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasCredentialData_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasCredentialData that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentAasCredentialDatas.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasCredentialDatas))
            {
                if (!new AasCredentialDataTruncate(param).TruncateList(this.recentAasCredentialDatas))
                {
                    LogSystem.Warn("Rollback du lieu AasCredentialData that bai, can kiem tra lai." + LogUtil.TraceData("recentAasCredentialDatas", this.recentAasCredentialDatas));
                }
            }
        }
    }
}
