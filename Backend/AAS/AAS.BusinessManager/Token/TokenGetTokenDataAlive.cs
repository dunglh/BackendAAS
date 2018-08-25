using AAS.BusinessManager.Token.Common;
using AAS.SDO;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.Core;
using DungLH.Util.Token.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.BusinessManager.Token
{
    class TokenGetTokenDataAlive : BusinessBase
    {
        private TokenManagerBase tokenManagerBase;
        private AuthenticateTokenManager authenTokenManager;

        internal TokenGetTokenDataAlive()
            : base()
        {
            this.Init();
        }

        internal TokenGetTokenDataAlive(CommonParam param)
            : base(param)
        {
            this.Init();
        }

        private void Init()
        {
            this.tokenManagerBase = new TokenManagerBase();
            this.authenTokenManager = new AuthenticateTokenManager(this.tokenManagerBase.GetValidUserData, this.tokenManagerBase.GetCredentialData, this.tokenManagerBase.IsGrantedUser, this.tokenManagerBase.CreateCredentialData, this.tokenManagerBase.UpdateUserPassword, this.tokenManagerBase.DeleteCredentialData, this.tokenManagerBase.DeleteAllCredentialData);
        }

        internal bool Run(string applicationCode, ref List<AasCredentialSDO> resultData)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(applicationCode))
                {
                    List<ExtTokenData> extTokenDatas = this.authenTokenManager.GetTokenDataAlives(applicationCode);
                    if (IsNotNullOrEmpty(extTokenDatas))
                    {
                        resultData = new List<AasCredentialSDO>();
                        foreach (ExtTokenData data in extTokenDatas)
                        {
                            AasCredentialSDO sdo = new AasCredentialSDO();
                            sdo.ApplicationCode = data.User.ApplicationCode;
                            sdo.Email = data.User.Email;
                            sdo.ExpireTime = data.ExpireTime;
                            sdo.LastAccessTime = data.LastAccessTime;
                            sdo.LoginAddress = data.LoginAddress;
                            sdo.Loginname = data.User.Loginname;
                            sdo.MachineName = data.MachineName;
                            sdo.Mobile = data.User.Mobile;
                            sdo.TokenCode = data.TokenCode;
                            sdo.Username = data.User.Username;
                            sdo.ValidAddress = data.ValidAddress;
                            resultData.Add(sdo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                param.HasException = true;
                resultData = null;
                result = false;
            }
            return result;
        }
    }
}
