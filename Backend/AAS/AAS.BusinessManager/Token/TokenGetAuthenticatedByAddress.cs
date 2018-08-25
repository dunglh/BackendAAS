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
    class TokenGetAuthenticatedByAddress : BusinessBase
    {
        private TokenManagerBase tokenManagerBase;
        private AuthenticateTokenManager authenTokenManager;

        internal TokenGetAuthenticatedByAddress()
            : base()
        {
            this.Init();
        }

        internal TokenGetAuthenticatedByAddress(CommonParam param)
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
                resultData = this.authenTokenManager.GetAuthenticatedByAddress(actionContext, param);
                if (resultData == null)
                {
                    DungLH.Util.CommonLogging.LogSystem.Error("GetAuthenticatedByAddress that bai");
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
