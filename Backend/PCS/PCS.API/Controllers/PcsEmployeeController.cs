using PCS.API.Base;
using PCS.BusinessManager.PcsEmployee;
using PCS.EFMODEL.DataModels;
using PCS.GetManager.PcsEmployee;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PCS.API.Controllers
{
    public class PcsEmployeeController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<PcsEmployeeFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<PcsEmployeeFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<Employee>> result = new ApiResultObject<List<Employee>>(null);
                if (param != null)
                {
                    PcsEmployeeManagerGet mng = new PcsEmployeeManagerGet(param.CommonParam);
                    result = mng.GetResult(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Create")]
        public ApiResult Create(ApiParam<Employee> param)
        {
            try
            {
                ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
                if (param != null)
                {
                    PcsEmployeeManager mng = new PcsEmployeeManager(param.CommonParam);
                    result = mng.Create(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Update")]
        public ApiResult Update(ApiParam<Employee> param)
        {
            try
            {
                ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
                if (param != null)
                {
                    PcsEmployeeManager mng = new PcsEmployeeManager(param.CommonParam);
                    result = mng.Update(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ApiResult Delete(ApiParam<Employee> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    PcsEmployeeManager mng = new PcsEmployeeManager(param.CommonParam);
                    result = mng.Delete(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
        
        [HttpPost]
        [ActionName("Lock")]
        public ApiResult Lock(ApiParam<Employee> param)
        {
            try
            {
                ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsEmployeeManager mng = new PcsEmployeeManager(param.CommonParam);
                    result = mng.Lock(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Unlock")]
        public ApiResult Unlock(ApiParam<Employee> param)
        {
            try
            {
                ApiResultObject<Employee> result = new ApiResultObject<Employee>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsEmployeeManager mng = new PcsEmployeeManager(param.CommonParam);
                    result = mng.Unlock(param.ApiData);
                }
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
