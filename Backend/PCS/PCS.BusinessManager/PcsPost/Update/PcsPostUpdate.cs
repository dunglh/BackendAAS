using PCS.BusinessManager.Base;
using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.BusinessManager.PcsPost
{
    partial class PcsPostUpdate : BusinessBase
    {
		private List<Post> beforeUpdatePcsPosts = new List<Post>();
		
        internal PcsPostUpdate()
            : base()
        {

        }

        internal PcsPostUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(Post data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsPostCheck checker = new PcsPostCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                Post raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.CheckSttForDeleteOrUpdate(raw);
                if (valid)
                {
					if (!DAOWorker.PcsPostDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsPost_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsPost that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdatePcsPosts.Add(raw);
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

        internal bool UpdateList(List<Post> listData, List<Post> listBefore)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                PcsPostCheck checker = new PcsPostCheck(param);
                valid = valid && checker.IsUnLock(listBefore);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.PcsPostDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.PcsPost_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin PcsPost that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdatePcsPosts.AddRange(listBefore);
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
            if (IsNotNullOrEmpty(this.beforeUpdatePcsPosts))
            {
                if (!DAOWorker.PcsPostDAO.UpdateList(this.beforeUpdatePcsPosts))
                {
                    LogSystem.Warn("Rollback du lieu PcsPost that bai, can kiem tra lai." + LogUtil.TraceData("PcsPosts", this.beforeUpdatePcsPosts));
                }
            }
        }
    }
}
