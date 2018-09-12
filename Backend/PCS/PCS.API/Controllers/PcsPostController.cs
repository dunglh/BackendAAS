using PCS.API.Base;
using PCS.BusinessManager.PcsPost;
using PCS.EFMODEL.DataModels;
using PCS.GetManager.PcsPost;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;
using PCS.SDO;

namespace PCS.API.Controllers
{
    public partial class PcsPostController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<PcsPostFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<PcsPostFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<Post>> result = new ApiResultObject<List<Post>>(null);
                if (param != null)
                {
                    PcsPostManagerGet mng = new PcsPostManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<Post> param)
        {
            try
            {
                ApiResultObject<Post> result = new ApiResultObject<Post>(null);
                if (param != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<Post> param)
        {
            try
            {
                ApiResultObject<Post> result = new ApiResultObject<Post>(null);
                if (param != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<Post> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<Post> param)
        {
            try
            {
                ApiResultObject<Post> result = new ApiResultObject<Post>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<Post> param)
        {
            try
            {
                ApiResultObject<Post> result = new ApiResultObject<Post>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
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

        [HttpPost]
        [ActionName("Approve")]
        public ApiResult Approve(ApiParam<PcsPostSDO> param)
        {
            try
            {
                ApiResultObject<List<Post>> result = new ApiResultObject<List<Post>>(null, false);
                if (param != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
                    result = mng.Approve(param.ApiData);
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
        [ActionName("Reject")]
        public ApiResult Reject(ApiParam<PcsPostSDO> param)
        {
            try
            {
                ApiResultObject<List<Post>> result = new ApiResultObject<List<Post>>(null, false);
                if (param != null)
                {
                    PcsPostManager mng = new PcsPostManager(param.CommonParam);
                    result = mng.Reject(param.ApiData);
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
