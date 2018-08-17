using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasModuleRole
{
    public partial class AasModuleRoleManager : BusinessBase
    {
        public AasModuleRoleManager()
            : base()
        {

        }
        
        public AasModuleRoleManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<ModuleRole> Create(ModuleRole data)
        {
            ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ModuleRole resultData = null;
                if (valid && new AasModuleRoleCreate(param).Create(data))
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
		
        public ApiResultObject<ModuleRole> Update(ModuleRole data)
        {
            ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ModuleRole resultData = null;
                if (valid && new AasModuleRoleUpdate(param).Update(data))
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
        
        public ApiResultObject<ModuleRole> Lock(ModuleRole data)
        {
            ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ModuleRole resultData = null;
                if (valid && new AasModuleRoleLock(param).Lock(data))
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
        public ApiResultObject<ModuleRole> Unlock(ModuleRole data)
        {
            ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                ModuleRole resultData = null;
                if (valid && new AasModuleRoleLock(param).Unlock(data))
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


        public ApiResultObject<bool> Delete(ModuleRole data)
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
                    resultData = new AasModuleRoleTruncate(param).Truncate(data);
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
