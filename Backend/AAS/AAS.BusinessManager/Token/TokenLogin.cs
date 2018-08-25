using AAS.BusinessManager.Token.Common;
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
    class TokenLogin : BusinessBase
    {
        private AuthenticateTokenManager authenTokenManager;
        private TokenManagerBase tokenManagerBase;

        internal TokenLogin()
            : base()
        {
            this.Init();
        }

        internal TokenLogin(CommonParam param)
            : base(param)
        {
            this.Init();
        }

        private void Init()
        {
            this.tokenManagerBase = new TokenManagerBase();
            this.authenTokenManager = new AuthenticateTokenManager(this.tokenManagerBase.GetValidUserData, this.tokenManagerBase.GetCredentialData, this.tokenManagerBase.IsGrantedUser, this.tokenManagerBase.CreateCredentialData, this.tokenManagerBase.UpdateUserPassword, this.tokenManagerBase.DeleteCredentialData, this.tokenManagerBase.DeleteAllCredentialData);
        }

        internal bool Run(HttpActionContext actionContext, ref DungLH.Util.Token.Core.TokenData resultData)
        {
            bool result = false;
            try
            {
                resultData = this.authenTokenManager.Login(actionContext, param);
                if (resultData == null)
                {
                    DungLH.Util.CommonLogging.LogSystem.Error("Dang nhap that bai");
                }
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
