using AAS.API.Base;
using AAS.BusinessManager.Token;
using AAS.SDO;
using AOS.API.Base;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AAS.API.Controllers
{
    public class TokenController : BaseApiController
    {

        [AllowAnonymous]
        [HttpGet]
        [ActionName("Login")]
        public ApiResult Login()
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<DungLH.Util.Token.Core.TokenData> result = mng.Login(this.ActionContext);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetAuthenticated")]
        public ApiResult GetAuthenticated()
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<DungLH.Util.Token.Core.TokenData> result = mng.GetAuthenticated(this.ActionContext);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetAuthenticatedByAddress")]
        public ApiResult GetAuthenticatedByAddress()
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<DungLH.Util.Token.Core.TokenData> result = mng.GetAuthenticateByAddress(this.ActionContext);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetCredentialData")]
        public ApiResult GetCredentialData()
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<DungLH.Util.Token.Core.CredentialData> result = mng.GetCredentialData(this.ActionContext);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpGet]
        [ApiParamFilter(typeof(ApiParam<string>), "param")]
        [ActionName("GetCredentialSDO")]
        public ApiResult GetCredentialSDO(ApiParam<string> param)
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<List<AasCredentialSDO>> result = mng.GetTokenDataAlive(param.ApiData);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("SetCredentialData")]
        public ApiResult SetCredentialData(DungLH.Util.Token.Core.CredentialData credentialData)
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<bool> result = mng.SetCredentialData(this.ActionContext, credentialData);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("Logout")]
        public ApiResult Logout()
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<bool> result = mng.Logout(this.ActionContext);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }

        [HttpPost]
        [ActionName("ChangePassword")]
        public ApiResult ChangePassword()
        {
            try
            {
                TokenManager mng = new TokenManager();
                ApiResultObject<bool> result = mng.ChangePassword(this.ActionContext);
                return new ApiResult(result, this.ActionContext);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                return null;
            }
        }
    }
}