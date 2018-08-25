using AAS.API.Base;
using AAS.BusinessManager.AasCredentialData;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasCredentialData;
using AOS.API.Base;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public class AasCredentialDataController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<CredentialDataFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<CredentialDataFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<CredentialData>> result = new ApiResultObject<List<CredentialData>>(null);
                if (param != null)
                {
                    CredentialDataManagerGet mng = new CredentialDataManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<CredentialData> param)
        {
            try
            {
                ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
                if (param != null)
                {
                    AasCredentialDataManager mng = new AasCredentialDataManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<CredentialData> param)
        {
            try
            {
                ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
                if (param != null)
                {
                    AasCredentialDataManager mng = new AasCredentialDataManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<CredentialData> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasCredentialDataManager mng = new AasCredentialDataManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<CredentialData> param)
        {
            try
            {
                ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
                if (param != null && param.ApiData != null)
                {
                    AasCredentialDataManager mng = new AasCredentialDataManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<CredentialData> param)
        {
            try
            {
                ApiResultObject<CredentialData> result = new ApiResultObject<CredentialData>(null);
                if (param != null && param.ApiData != null)
                {
                    AasCredentialDataManager mng = new AasCredentialDataManager(param.CommonParam);
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
