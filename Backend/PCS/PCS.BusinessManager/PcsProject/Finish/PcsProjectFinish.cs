using AutoMapper;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using PCS.EFMODEL.DataModels;
using PCS.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.BusinessManager.PcsProject.Finish
{
    class PcsProjectFinish : BusinessBase
    {
        private PcsProjectUpdate pcsProjectUpdate;

        internal PcsProjectFinish()
            : base()
        {
            this.pcsProjectUpdate = new PcsProjectUpdate(param);
        }

        internal PcsProjectFinish(CommonParam param)
            : base(param)
        {
            this.pcsProjectUpdate = new PcsProjectUpdate(param);
        }

        internal bool Run(long id, ref Project resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Project raw = null;
                PcsProjectCheck checker = new PcsProjectCheck(param);
                valid = valid && IsGreaterThanZero(id);
                valid = valid && checker.VerifyId(id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.IsUnFinish(raw);
                if (valid)
                {
                    Mapper.CreateMap<Project, Project>();
                    Project before = Mapper.Map<Project>(raw);
                    raw.ProjectSttId = ProjectSttConstant.PROJECT_STT_ID__FINISH;
                    raw.FinishTime = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    if (!this.pcsProjectUpdate.Update(raw, before))
                    {
                        throw new Exception("pcsProjectUpdate. Ket thuc nghiep vu. Rollback du lieu");
                    }

                    resultData = raw;
                    result = true;
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
                this.pcsProjectUpdate.RollbackData();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
