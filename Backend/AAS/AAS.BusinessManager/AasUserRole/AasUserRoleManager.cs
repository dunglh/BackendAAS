using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasUserRole
{
    public partial class AasUserRoleManager : BusinessBase
    {
        public AasUserRoleManager()
            : base()
        {

        }
        
        public AasUserRoleManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<UserRole> Create(UserRole data)
        {
            ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                UserRole resultData = null;
                if (valid && new AasUserRoleCreate(param).Create(data))
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
		
        public ApiResultObject<UserRole> Update(UserRole data)
        {
            ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                UserRole resultData = null;
                if (valid && new AasUserRoleUpdate(param).Update(data))
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
        
        public ApiResultObject<UserRole> Lock(UserRole data)
        {
            ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                UserRole resultData = null;
                if (valid && new AasUserRoleLock(param).Lock(data))
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

        public ApiResultObject<UserRole> Unlock(UserRole data)
        {
            ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                UserRole resultData = null;
                if (valid && new AasUserRoleLock(param).Unlock(data))
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

        public ApiResultObject<bool> Delete(UserRole data)
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
                    resultData = new AasUserRoleTruncate(param).Truncate(data);
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
