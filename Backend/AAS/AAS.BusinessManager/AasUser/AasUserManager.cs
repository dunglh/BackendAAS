using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasUser
{
    public partial class AasUserManager : BusinessBase
    {
        public AasUserManager()
            : base()
        {

        }
        
        public AasUserManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<User> Create(User data)
        {
            ApiResultObject<User> result = new ApiResultObject<User>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                User resultData = null;
                if (valid && new AasUserCreate(param).Create(data))
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
		
        public ApiResultObject<User> Update(User data)
        {
            ApiResultObject<User> result = new ApiResultObject<User>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                User resultData = null;
                if (valid && new AasUserUpdate(param).Update(data))
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
        
        public ApiResultObject<User> Lock(User data)
        {
            ApiResultObject<User> result = new ApiResultObject<User>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                User resultData = null;
                if (valid && new AasUserLock(param).Lock(data))
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

        public ApiResultObject<User> Unlock(User data)
        {
            ApiResultObject<User> result = new ApiResultObject<User>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                User resultData = null;
                if (valid && new AasUserLock(param).Unlock(data))
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

        public ApiResultObject<bool> Delete(User data)
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
                    resultData = new AasUserTruncate(param).Truncate(data);
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

        public ApiResultObject<bool> ResetPassword(long id)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsGreaterThanZero(id);
                bool resultData = false;
                if (valid)
                {
                    resultData =  new AasUserResetPassword(param).Run(id);
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
