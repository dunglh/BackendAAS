using AAS.API.Base;
using AAS.BusinessManager.AasModuleRole;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasModuleRole;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasModuleRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ModuleRoleFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ModuleRoleFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<ModuleRole>> result = new ApiResultObject<List<ModuleRole>>(null);
                if (param != null)
                {
                    ModuleRoleManagerGet mng = new ModuleRoleManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<ModuleRole> param)
        {
            try
            {
                ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
                if (param != null)
                {
                    AasModuleRoleManager mng = new AasModuleRoleManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<ModuleRole> param)
        {
            try
            {
                ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
                if (param != null)
                {
                    AasModuleRoleManager mng = new AasModuleRoleManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<ModuleRole> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasModuleRoleManager mng = new AasModuleRoleManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<ModuleRole> param)
        {
            try
            {
                ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
                if (param != null && param.ApiData != null)
                {
                    AasModuleRoleManager mng = new AasModuleRoleManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<ModuleRole> param)
        {
            try
            {
                ApiResultObject<ModuleRole> result = new ApiResultObject<ModuleRole>(null);
                if (param != null && param.ApiData != null)
                {
                    AasModuleRoleManager mng = new AasModuleRoleManager(param.CommonParam);
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
