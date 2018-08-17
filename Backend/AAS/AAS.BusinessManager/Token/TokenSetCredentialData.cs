using AAS.BusinessManager.Token.Common;
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
    class TokenSetCredentialData : BusinessBase
    {
        private TokenManagerBase tokenManagerBase;
        private AuthenticateTokenManager authenTokenManager;

        internal TokenSetCredentialData()
            : base()
        {
            this.Init();
        }

        internal TokenSetCredentialData(CommonParam param)
            : base(param)
        {
            this.Init();
        }

        private void Init()
        {
            this.tokenManagerBase = new TokenManagerBase();
            this.authenTokenManager = new AuthenticateTokenManager(this.tokenManagerBase.GetValidUserData, this.tokenManagerBase.GetCredentialData, this.tokenManagerBase.IsGrantedUser, this.tokenManagerBase.CreateCredentialData, this.tokenManagerBase.UpdateUserPassword, this.tokenManagerBase.DeleteCredentialData, this.tokenManagerBase.DeleteAllCredentialData);
        }

        internal bool Run(HttpActionContext actionContext, MyUtil.Token.Core.CredentialData credentialData)
        {
            bool result = false;
            try
            {
                result = this.authenTokenManager.SetCredentialData(actionContext, credentialData, param);
                if (!result)
                {
                    MyUtil.CommonLogging.LogSystem.Error("SetCredentialData that bai");
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
