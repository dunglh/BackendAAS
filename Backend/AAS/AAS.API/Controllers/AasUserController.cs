using AAS.API.Base;
using AAS.BusinessManager.AasUser;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasUser;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public class AasUserController : BaseApiController
    {
        [HttpGet]        
        [ApiParamFilter(typeof(ApiParam<UserFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<UserFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<User>> result = new ApiResultObject<List<User>>(null);
                if (param != null)
                {
                    UserManagerGet mng = new UserManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<User> param)
        {
            try
            {
                ApiResultObject<User> result = new ApiResultObject<User>(null);
                if (param != null)
                {
                    AasUserManager mng = new AasUserManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<User> param)
        {
            try
            {
                ApiResultObject<User> result = new ApiResultObject<User>(null);
                if (param != null)
                {
                    AasUserManager mng = new AasUserManager(param.CommonParam);
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

        //[HttpPost]
        //[ActionName("Delete")]
        //public ApiResult Delete(ApiParam<User> param)
        //{
        //    try
        //    {
        //        ApiResultObject<bool> result = new ApiResultObject<bool>(false);
        //        if (param != null)
        //        {
        //            AasUserManager mng = new AasUserManager(param.CommonParam);
        //            result = mng.Delete(param.ApiData);
        //        }
        //        return new ApiResult(result, this.ActionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogSystem.Error(ex);
        //        return null;
        //    }
        //}
        
        [HttpPost]
        [ActionName("Lock")]
        public ApiResult Lock(ApiParam<User> param)
        {
            try
            {
                ApiResultObject<User> result = new ApiResultObject<User>(null);
                if (param != null && param.ApiData != null)
                {
                    AasUserManager mng = new AasUserManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<User> param)
        {
            try
            {
                ApiResultObject<User> result = new ApiResultObject<User>(null);
                if (param != null && param.ApiData != null)
                {
                    AasUserManager mng = new AasUserManager(param.CommonParam);
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
        [ActionName("ResetPassword")]
        public ApiResult ResetPassword(ApiParam<long> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    AasUserManager mng = new AasUserManager(param.CommonParam);
                    result = mng.ResetPassword(param.ApiData);
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
