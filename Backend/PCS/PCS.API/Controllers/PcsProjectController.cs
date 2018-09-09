using PCS.API.Base;
using PCS.BusinessManager.PcsProject;
using PCS.EFMODEL.DataModels;
using PCS.GetManager.PcsProject;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PCS.API.Controllers
{
    public class PcsProjectController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<PcsProjectFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<PcsProjectFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<Project>> result = new ApiResultObject<List<Project>>(null);
                if (param != null)
                {
                    PcsProjectManagerGet mng = new PcsProjectManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<Project> param)
        {
            try
            {
                ApiResultObject<Project> result = new ApiResultObject<Project>(null);
                if (param != null)
                {
                    PcsProjectManager mng = new PcsProjectManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<Project> param)
        {
            try
            {
                ApiResultObject<Project> result = new ApiResultObject<Project>(null);
                if (param != null)
                {
                    PcsProjectManager mng = new PcsProjectManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<Project> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    PcsProjectManager mng = new PcsProjectManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<Project> param)
        {
            try
            {
                ApiResultObject<Project> result = new ApiResultObject<Project>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsProjectManager mng = new PcsProjectManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<Project> param)
        {
            try
            {
                ApiResultObject<Project> result = new ApiResultObject<Project>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsProjectManager mng = new PcsProjectManager(param.CommonParam);
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
