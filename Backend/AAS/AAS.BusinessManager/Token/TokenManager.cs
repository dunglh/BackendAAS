﻿using AAS.SDO;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.Core;
using DungLH.Util.Token.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace AAS.BusinessManager.Token
{
    public class TokenManager : BusinessBase
    {
        public TokenManager()
            : base()
        {

        }

        public TokenManager(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<DungLH.Util.Token.Core.TokenData> Login(HttpActionContext actionContext)
        {
            ApiResultObject<DungLH.Util.Token.Core.TokenData> result = new ApiResultObject<DungLH.Util.Token.Core.TokenData>(null, false);
            try
            {
                DungLH.Util.Token.Core.TokenData resultData = null;
                new TokenLogin(param).Run(actionContext, ref resultData);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<bool> Logout(HttpActionContext actionContext)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
            try
            {
                bool resultData = new TokenLogout(param).Run(actionContext);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<bool> ChangePassword(HttpActionContext actionContext)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
            try
            {
                bool resultData = new TokenChangePassword(param).Run(actionContext);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<DungLH.Util.Token.Core.TokenData> GetAuthenticated(HttpActionContext actionContext)
        {
            ApiResultObject<DungLH.Util.Token.Core.TokenData> result = new ApiResultObject<DungLH.Util.Token.Core.TokenData>(null, false);
            try
            {
                DungLH.Util.Token.Core.TokenData resultData = null;
                new TokenGetAuthenticated(param).Run(actionContext, ref resultData);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<DungLH.Util.Token.Core.TokenData> GetAuthenticateByAddress(HttpActionContext actionContext)
        {
            ApiResultObject<DungLH.Util.Token.Core.TokenData> result = new ApiResultObject<DungLH.Util.Token.Core.TokenData>(null, false);
            try
            {
                DungLH.Util.Token.Core.TokenData resultData = null;
                new TokenGetAuthenticatedByAddress(param).Run(actionContext, ref resultData);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<DungLH.Util.Token.Core.CredentialData> GetCredentialData(HttpActionContext actionContext)
        {
            ApiResultObject<DungLH.Util.Token.Core.CredentialData> result = new ApiResultObject<DungLH.Util.Token.Core.CredentialData>(null, false);
            try
            {
                DungLH.Util.Token.Core.CredentialData resultData = null;
                new TokenGetCredentialData(param).Run(actionContext, ref resultData);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

        public ApiResultObject<bool> SetCredentialData(HttpActionContext actionContext, DungLH.Util.Token.Core.CredentialData credentialData)
        {
            ApiResultObject<bool> result = new ApiResultObject<bool>(false, false);
            try
            {
                bool resultData = new TokenSetCredentialData(param).Run(actionContext, credentialData);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }
        public ApiResultObject<List<AasCredentialSDO>> GetTokenDataAlive(string applicationCode)
        {
            ApiResultObject<List<AasCredentialSDO>> result = new ApiResultObject<List<AasCredentialSDO>>(null, false);
            try
            {
                List<AasCredentialSDO> resultData = null;
                new TokenGetTokenDataAlive(param).Run(applicationCode, ref resultData);
                result = this.PackResult(resultData);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
            }
            return result;
        }

    }
}
