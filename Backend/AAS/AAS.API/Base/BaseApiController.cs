﻿using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AAS.API.Base
{
    [Authorize] //Comment neu ko co nhu cau xac thuc request
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [LicenseFilter]
    public class BaseApiController : ApiController
    {
        protected CommonParam commonParam;

        protected ApiResultObject<T> PackResult<T>(T resultData)
        {
            ApiResultObject<T> result = new ApiResultObject<T>();
            try
            {
                result.SetValue(resultData, Util.DecisionApiResult(resultData), commonParam);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                LogSystem.Error(LogUtil.TraceData("resultData", resultData));
                result = new ApiResultObject<T>(default(T), false);
            }
            return result;
        }
    }
}