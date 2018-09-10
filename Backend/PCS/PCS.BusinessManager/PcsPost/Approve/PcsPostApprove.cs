using AutoMapper;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using PCS.BusinessManager.PcsEmployee;
using PCS.BusinessManager.PcsProject;
using PCS.EFMODEL.DataModels;
using PCS.SDO;
using PCS.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.BusinessManager.PcsPost.Approve
{
    class PcsPostApprove : BusinessBase
    {
        private PcsPostUpdate pcsPostUpdate;

        internal PcsPostApprove()
            : base()
        {
            this.pcsPostUpdate = new PcsPostUpdate(param);
        }

        internal PcsPostApprove(CommonParam param)
            : base(param)
        {
            this.pcsPostUpdate = new PcsPostUpdate(param);
        }

        internal bool Run(PcsPostSDO data, ref List<Post> resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Project project = null;
                List<Post> listRaw = null;
                string loginname = DungLH.Util.Token.Backend.BackendTokenManager.GetLoginname();
                string username = DungLH.Util.Token.Backend.BackendTokenManager.GetUsername();
                PcsPostCheck checker = new PcsPostCheck(param);
                PcsProjectCheck projectChecker = new PcsProjectCheck(param);
                PcsEmployeeCheck employeeChecker = new PcsEmployeeCheck(param);
                valid = valid && IsNotNull(data);
                valid = valid && IsGreaterThanZero(data.ProjectId);
                valid = valid && projectChecker.VerifyId(data.ProjectId, ref project);
                valid = valid && checker.ValidData(data, PostSttConstant.POST_STT_ID__NOT_APPROVAL, ref listRaw);
                valid = valid && projectChecker.IsUnFinish(project);
                valid = valid && checker.AllowApproveOrReject(listRaw);
                valid = valid && employeeChecker.CheckRoleApproveOrReject(loginname);
                if (valid)
                {
                    Mapper.CreateMap<Post, Post>();
                    List<Post> befores = Mapper.Map<List<Post>>(listRaw);
                    long approveTime = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    foreach (Post raw in listRaw)
                    {
                        raw.PostSttId = PostSttConstant.POST_STT_ID__APPROVAL;
                        raw.ApprovalLoginname = loginname;
                        raw.ApprovalTime = approveTime;
                        raw.ApprovalUsername = username;
                    }

                    if (!this.pcsPostUpdate.UpdateList(listRaw, befores))
                    {
                        throw new Exception("pcsPostUpdate. Ket thuc nghiep vu. Rollback du lieu");
                    }
                    result = true;
                    resultData = listRaw;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                this.Rollback();
                result = false;
            }
            return result;
        }

        private void Rollback()
        {
            try
            {
                this.pcsPostUpdate.RollbackData();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
