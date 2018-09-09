using AAS.API.Base;
using AAS.BusinessManager.AasApplicationRole;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasApplicationRole;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasApplicationRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ApplicationRoleFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ApplicationRoleFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<ApplicationRole>> result = new ApiResultObject<List<ApplicationRole>>(null);
                if (param != null)
                {
                    ApplicationRoleManagerGet mng = new ApplicationRoleManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<ApplicationRole> param)
        {
            try
            {
                ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
                if (param != null)
                {
                    AasApplicationRoleManager mng = new AasApplicationRoleManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<ApplicationRole> param)
        {
            try
            {
                ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
                if (param != null)
                {
                    AasApplicationRoleManager mng = new AasApplicationRoleManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<ApplicationRole> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasApplicationRoleManager mng = new AasApplicationRoleManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<ApplicationRole> param)
        {
            try
            {
                ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
                if (param != null && param.ApiData != null)
                {
                    AasApplicationRoleManager mng = new AasApplicationRoleManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<ApplicationRole> param)
        {
            try
            {
                ApiResultObject<ApplicationRole> result = new ApiResultObject<ApplicationRole>(null);
                if (param != null && param.ApiData != null)
                {
                    AasApplicationRoleManager mng = new AasApplicationRoleManager(param.CommonParam);
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
