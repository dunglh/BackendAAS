using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using PCS.BusinessManager.PcsProject.Finish;

namespace PCS.BusinessManager.PcsProject
{
    public partial class PcsProjectManager : BusinessBase
    {
        public PcsProjectManager()
            : base()
        {

        }

        public PcsProjectManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<Project> Create(Project data)
        {
            ApiResultObject<Project> result = new ApiResultObject<Project>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Project resultData = null;
                if (valid && new PcsProjectCreate(param).Create(data))
                {
                    resultData = data;
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, data, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }
            return result;
        }

        public ApiResultObject<Project> Update(Project data)
        {
            ApiResultObject<Project> result = new ApiResultObject<Project>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Project resultData = null;
                if (valid && new PcsProjectUpdate(param).Update(data))
                {
                    resultData = data;
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, data, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

        public ApiResultObject<Project> Lock(Project data)
        {
            ApiResultObject<Project> result = new ApiResultObject<Project>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Project resultData = null;
                if (valid && new PcsProjectLock(param).Lock(data))
                {
                    resultData = data;
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, data, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

        public ApiResultObject<Project> Unlock(Project data)
        {
            ApiResultObject<Project> result = new ApiResultObject<Project>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Project resultData = null;
                if (valid && new PcsProjectLock(param).Unlock(data))
                {
                    resultData = data;
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, data, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

        public ApiResultObject<bool> Delete(Project data)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);

            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                bool resultData = false;
                if (valid)
                {
                    resultData = new PcsProjectTruncate(param).Truncate(data);
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, data, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

        public ApiResultObject<Project> Finish(long id)
        {
            ApiResultObject<Project> result = new ApiResultObject<Project>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsGreaterThanZero(id);
                Project resultData = null;
                if (valid)
                {
                    new PcsProjectFinish(param).Run(id, ref resultData);
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, id, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }

            return result;
        }

    }
}
