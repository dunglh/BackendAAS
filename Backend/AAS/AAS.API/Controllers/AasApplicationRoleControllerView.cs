using AAS.API.Base;
using AAS.BusinessManager.AasApplicationRole;
using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using AAS.Filter;
using AAS.GetManager.AasApplicationRole;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasApplicationRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<AasApplicationRoleViewFilter>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<AasApplicationRoleViewFilter> param)
        {
            try
            {
                ApiResultObject<List<ViewApplicationRole>> result = new ApiResultObject<List<ViewApplicationRole>>(null);
                if (param != null)
                {
                    ApplicationRoleManagerGet mng = new ApplicationRoleManagerGet(param.CommonParam);
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
