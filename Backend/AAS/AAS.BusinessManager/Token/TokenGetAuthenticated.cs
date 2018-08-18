﻿using AAS.BusinessManager.Token.Common;
using MyUtil.Backend.MANAGER;
using MyUtil.Core;
using MyUtil.Token.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace AAS.BusinessManager.Token
{
    class TokenGetAuthenticated : BusinessBase
    {
        private TokenManagerBase tokenManagerBase;
        private AuthenticateTokenManager authenTokenManager;

        internal TokenGetAuthenticated()
            : base()
        {
            this.Init();
        }

        internal TokenGetAuthenticated(CommonParam param)
            : base(param)
        {
            this.Init();
        }

        private void Init()
        {
            this.tokenManagerBase = new TokenManagerBase();
            this.authenTokenManager = new AuthenticateTokenManager(this.tokenManagerBase.GetValidUserData, this.tokenManagerBase.GetCredentialData, this.tokenManagerBase.IsGrantedUser, this.tokenManagerBase.CreateCredentialData, this.tokenManagerBase.UpdateUserPassword, this.tokenManagerBase.DeleteCredentialData, this.tokenManagerBase.DeleteAllCredentialData);
        }

        internal bool Run(HttpActionContext actionContext, ref MyUtil.Token.Core.TokenData resultData)
        {
            bool result = false;
            try
            {
                resultData = this.authenTokenManager.GetAuthenticated(actionContext, param);
                if (resultData != null)
                {
                    if (!this.authenTokenManager.SetTokenDataAlive(resultData.TokenCode))
                    {
                        MyUtil.CommonLogging.LogSystem.Info("Set Alive cho Token that bai");
                    }
                }
                else
                {
                    MyUtil.CommonLogging.LogSystem.Error("GetAuthenticated that bai");
                }
            }
            catch (Exception ex)
            {
                MyUtil.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}