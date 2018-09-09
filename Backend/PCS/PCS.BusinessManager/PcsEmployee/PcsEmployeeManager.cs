using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace PCS.BusinessManager.PcsEmployee
{
    public partial class PcsEmployeeManager : BusinessBase
    {
        public PcsEmployeeManager()
            : base()
        {

        }
        
        public PcsEmployeeManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<Employee> Create(Employee data)
        {
            ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Employee resultData = null;
                if (valid && new PcsEmployeeCreate(param).Create(data))
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
		
        public ApiResultObject<Employee> Update(Employee data)
        {
            ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Employee resultData = null;
                if (valid && new PcsEmployeeUpdate(param).Update(data))
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
        
        public ApiResultObject<Employee> Lock(Employee data)
        {
            ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Employee resultData = null;
                if (valid && new PcsEmployeeLock(param).Lock(data))
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
        public ApiResultObject<Employee> Unlock(Employee data)
        {
            ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(data);
                Employee resultData = null;
                if (valid && new PcsEmployeeLock(param).Unlock(data))
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


        public ApiResultObject<bool> Delete(Employee data)
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
                    resultData = new PcsEmployeeTruncate(param).Truncate(data);
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
