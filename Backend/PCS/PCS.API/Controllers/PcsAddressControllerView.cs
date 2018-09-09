using PCS.API.Base;
using PCS.BusinessManager.PcsAddress;
using PCS.EFMODEL.DataModels;
using PCS.EFMODEL.View;
using PCS.Filter;
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
        [ApiParamFilter(typeof(ApiParam<PcsAddressViewFilter>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<PcsAddressViewFilter> param)
        {
            try
            {
                ApiResultObject<List<ViewAddress>> result = new ApiResultObject<List<ViewAddress>>(null);
                if (param != null)
                {
                    PcsAddressManagerGet mng = new PcsAddressManagerGet(param.CommonParam);
                    result = mng.GetViewResult(param.ApiData);
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
