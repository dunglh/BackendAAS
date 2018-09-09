using AAS.API.Base;
using AAS.BusinessManager.AasModule;
using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using AAS.Filter;
using AAS.GetManager.AasModule;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public partial class AasModuleController : BaseApiController
    {
        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<AasModuleViewFilter>), "param")]
        [ActionName("GetView")]
        public ApiResult GetView(ApiParam<AasModuleViewFilter> param)
        {
            try
            {
                ApiResultObject<List<ViewModule>> result = new ApiResultObject<List<ViewModule>>(null);
                if (param != null)
                {
                    ModuleManagerGet mng = new ModuleManagerGet(param.CommonParam);
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
