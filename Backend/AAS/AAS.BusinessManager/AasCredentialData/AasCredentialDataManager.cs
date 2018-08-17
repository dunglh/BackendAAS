using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasCredentialData
{
    public partial class AasCredentialDataManager : BusinessBase
    {
        public AasCredentialDataManager()
            : base()
        {

        }
        
        public AasCredentialDataManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<CredentialData> Create(CredentialData data)
        {
            ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                CredentialData resultData = null;
                if (valid && new AasCredentialDataCreate(param).Create(data))
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
		
        public ApiResultObject<CredentialData> Update(CredentialData data)
        {
            ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                CredentialData resultData = null;
                if (valid && new AasCredentialDataUpdate(param).Update(data))
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
        
        public ApiResultObject<CredentialData> Lock(CredentialData data)
        {
            ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                CredentialData resultData = null;
                if (valid && new AasCredentialDataLock(param).Lock(data))
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
        public ApiResultObject<CredentialData> Unlock(CredentialData data)
        {
            ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                CredentialData resultData = null;
                if (valid && new AasCredentialDataLock(param).Unlock(data))
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


        public ApiResultObject<bool> Delete(CredentialData data)
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
                    resultData = new AasCredentialDataTruncate(param).Truncate(data);
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
