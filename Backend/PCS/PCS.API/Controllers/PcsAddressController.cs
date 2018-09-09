using PCS.API.Base;
using PCS.BusinessManager.PcsAddress;
using PCS.EFMODEL.DataModels;
using PCS.GetManager.PcsAddress;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PCS.API.Controllers
{
    public partial class PcsAddressController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<PcsAddressFilterQuery>), "param")]
        [ActionName("Get")]
        public ApiResult Get(ApiParam<PcsAddressFilterQuery> param)
        {
            try
            {
                ApiResultObject<List<Address>> result = new ApiResultObject<List<Address>>(null);
                if (param != null)
                {
                    PcsAddressManagerGet mng = new PcsAddressManagerGet(param.CommonParam);
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
        public ApiResult Create(ApiParam<Address> param)
        {
            try
            {
                ApiResultObject<Address> result = new ApiResultObject<Address>(null);
                if (param != null)
                {
                    PcsAddressManager mng = new PcsAddressManager(param.CommonParam);
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
        public ApiResult Update(ApiParam<Address> param)
        {
            try
            {
                ApiResultObject<Address> result = new ApiResultObject<Address>(null);
                if (param != null)
                {
                    PcsAddressManager mng = new PcsAddressManager(param.CommonParam);
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
        public ApiResult Delete(ApiParam<Address> param)
        {
            try
            {
                ApiResultObject<bool> result = new ApiResultObject<bool>(false);
                if (param != null)
                {
                    PcsAddressManager mng = new PcsAddressManager(param.CommonParam);
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
        public ApiResult Lock(ApiParam<Address> param)
        {
            try
            {
                ApiResultObject<Address> result = new ApiResultObject<Address>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsAddressManager mng = new PcsAddressManager(param.CommonParam);
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
        public ApiResult Unlock(ApiParam<Address> param)
        {
            try
            {
                ApiResultObject<Address> result = new ApiResultObject<Address>(null);
                if (param != null && param.ApiData != null)
                {
                    PcsAddressManager mng = new PcsAddressManager(param.CommonParam);
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
