using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.BusinessManager.Base;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace PCS.BusinessManager.PcsPost
{
    partial class PcsPostCreate : BusinessBase
    {
		private List<Post> recentPcsPosts = new List<Post>();
		
        internal PcsPostCreate()
            : base()
        {

        }

        internal PcsPostCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(Post data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsPostCheck checker = new PcsPostCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                if (valid)
                {
					if (!DAOWorker.PcsPostDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsPost_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin PcsPost that bai." + LogUtil.TraceData("data", data));
                    }
                    this.recentPcsPosts.Add(data);
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
            if (IsNotNullOrEmpty(this.recentPcsPosts))
            {
                if (!new PcsPostTruncate(param).TruncateList(this.recentPcsPosts))
                {
                    LogSystem.Warn("Rollback du lieu PcsPost that bai, can kiem tra lai." + LogUtil.TraceData("recentPcsPosts", this.recentPcsPosts));
                }
            }
        }
    }
}
