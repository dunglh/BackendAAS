using AAS.API.Base;
using AAS.BusinessManager.AasUserRole;
using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using AAS.Filter;
using AAS.GetManager.AasUserRole;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasUserRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<AasUserRoleViewFilter>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<AasUserRoleViewFilter> param)
        {
            try
            {
                ApiResultObject<List<ViewUserRole>> result = new ApiResultObject<List<ViewUserRole>>(null);
                if (param != null)
                {
                    UserRoleManagerGet mng = new UserRoleManagerGet(param.CommonParam);
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
