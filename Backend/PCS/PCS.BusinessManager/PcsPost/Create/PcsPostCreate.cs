using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.BusinessManager.Base;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using PCS.BusinessManager.PcsProject;
using PCS.UTILITY;

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
                Project project = null;
                PcsPostCheck checker = new PcsPostCheck(param);
                PcsProjectCheck projectChecker = new PcsProjectCheck(param);
                valid = valid && IsNotNull(data);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && projectChecker.VerifyId(data.ProjectId, ref project);
                valid = valid && projectChecker.IsUnFinish(project);
                if (valid)
                {
                    data.PostSttId = PostSttConstant.POST_STT_ID__NOT_APPROVAL;
                    if (String.IsNullOrWhiteSpace(data.PostType)) data.PostType = "post";
                    if (String.IsNullOrWhiteSpace(data.Status)) data.Status = "publish";
                    data.ApprovalLoginname = null;
                    data.ApprovalTime = null;
                    data.ApprovalUsername = null;
                    data.PostTime = null;
                    data.ApprovalNote = null;

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
