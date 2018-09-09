using AAS.API.Base;
using AAS.BusinessManager.AasModule;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasModule;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasModuleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ModuleFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ModuleFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<Module>> result = new ApiResultObject<List<Module>>(null);
                if (param != null)
                {
                    ModuleManagerGet mng = new ModuleManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<Module> param)
        {
            try
            {
                ApiResultObject<Module> result = new ApiResultObject<Module>(null);
                if (param != null)
                {
                    AasModuleManager mng = new AasModuleManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<Module> param)
        {
            try
            {
                ApiResultObject<Module> result = new ApiResultObject<Module>(null);
                if (param != null)
                {
                    AasModuleManager mng = new AasModuleManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<Module> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasModuleManager mng = new AasModuleManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<Module> param)
        {
            try
            {
                ApiResultObject<Module> result = new ApiResultObject<Module>(null);
                if (param != null && param.ApiData != null)
                {
                    AasModuleManager mng = new AasModuleManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<Module> param)
        {
            try
            {
                ApiResultObject<Module> result = new ApiResultObject<Module>(null);
                if (param != null && param.ApiData != null)
                {
                    AasModuleManager mng = new AasModuleManager(param.CommonParam);
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
