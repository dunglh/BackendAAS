using PCS.API.Base;
using PCS.BusinessManager.PcsPost;
using PCS.EFMODEL.DataModels;
using PCS.EFMODEL.View;
using PCS.Filter;
using PCS.GetManager.PcsPost;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PCS.API.Controllers
{
    public partial class PcsPostController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<PcsPostViewFilter>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<PcsPostViewFilter> param)
        {
            try
            {
                ApiResultObject<List<ViewPost>> result = new ApiResultObject<List<ViewPost>>(null);
                if (param != null)
                {
                    PcsPostManagerGet mng = new PcsPostManagerGet(param.CommonParam);
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
