using AAS.API.Base;
using AAS.BusinessManager.AasUserRole;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasUserRole;
using AOS.API.Base;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public class AasUserRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<UserRoleFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<UserRoleFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<UserRole>> result = new ApiResultObject<List<UserRole>>(null);
                if (param != null)
                {
                    UserRoleManagerGet mng = new UserRoleManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<UserRole> param)
        {
            try
            {
                ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
                if (param != null)
                {
                    AasUserRoleManager mng = new AasUserRoleManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<UserRole> param)
        {
            try
            {
                ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
                if (param != null)
                {
                    AasUserRoleManager mng = new AasUserRoleManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<UserRole> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasUserRoleManager mng = new AasUserRoleManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<UserRole> param)
        {
            try
            {
                ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
                if (param != null && param.ApiData != null)
                {
                    AasUserRoleManager mng = new AasUserRoleManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<UserRole> param)
        {
            try
            {
                ApiResultObject<UserRole> result = new ApiResultObject<UserRole>(null);
                if (param != null && param.ApiData != null)
                {
                    AasUserRoleManager mng = new AasUserRoleManager(param.CommonParam);
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
