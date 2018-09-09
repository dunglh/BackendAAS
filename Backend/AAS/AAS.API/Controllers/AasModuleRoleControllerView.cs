using AAS.API.Base;
using AAS.BusinessManager.AasModuleRole;
using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using AAS.Filter;
using AAS.GetManager.AasModuleRole;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasModuleRoleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<AasModuleRoleViewFilter>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<AasModuleRoleViewFilter> param)
        {
            try
            {
                ApiResultObject<List<ViewModuleRole>> result = new ApiResultObject<List<ViewModuleRole>>(null);
                if (param != null)
                {
                    ModuleRoleManagerGet mng = new ModuleRoleManagerGet(param.CommonParam);
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
