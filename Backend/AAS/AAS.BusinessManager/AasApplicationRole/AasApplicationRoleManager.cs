using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasApplicationRole
{
    public partial class AasApplicationRoleManager : BusinessBase
    {
        public AasApplicationRoleManager()
            : base()
        {

        }
        
        public AasApplicationRoleManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<ApplicationRole> Create(ApplicationRole data)
        {
            ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ApplicationRole resultData = null;
                if (valid && new AasApplicationRoleCreate(param).Create(data))
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
		
        public ApiResultObject<ApplicationRole> Update(ApplicationRole data)
        {
            ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ApplicationRole resultData = null;
                if (valid && new AasApplicationRoleUpdate(param).Update(data))
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
        
        public ApiResultObject<ApplicationRole> Lock(ApplicationRole data)
        {
            ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ApplicationRole resultData = null;
                if (valid && new AasApplicationRoleLock(param).Lock(data))
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

        public ApiResultObject<ApplicationRole> Unlock(ApplicationRole data)
        {
            ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ApplicationRole resultData = null;
                if (valid && new AasApplicationRoleLock(param).Unlock(data))
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

        public ApiResultObject<bool> Delete(ApplicationRole data)
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
                    resultData = new AasApplicationRoleTruncate(param).Truncate(data);
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
    }
}
