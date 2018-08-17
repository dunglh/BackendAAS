using AAS.API.Base;
using AAS.BusinessManager.AasApplication;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasApplication;
using AOS.API.Base;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public class AasApplicationController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<ApplicationFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<ApplicationFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<Application>> result = new ApiResultObject<List<Application>>(null);
                if (param != null)
                {
                    ApplicationManagerGet mng = new ApplicationManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<Application> param)
        {
            try
            {
                ApiResultObject<Application> result = new ApiResultObject<Application>(null);
                if (param != null)
                {
                    AasApplicationManager mng = new AasApplicationManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<Application> param)
        {
            try
            {
                ApiResultObject<Application> result = new ApiResultObject<Application>(null);
                if (param != null)
                {
                    AasApplicationManager mng = new AasApplicationManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<Application> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasApplicationManager mng = new AasApplicationManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<Application> param)
        {
            try
            {
                ApiResultObject<Application> result = new ApiResultObject<Application>(null);
                if (param != null && param.ApiData != null)
                {
                    AasApplicationManager mng = new AasApplicationManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<Application> param)
        {
            try
            {
                ApiResultObject<Application> result = new ApiResultObject<Application>(null);
                if (param != null && param.ApiData != null)
                {
                    AasApplicationManager mng = new AasApplicationManager(param.CommonParam);
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
