using DungLH.Util.Core;
using DungLH.Util.Token.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Token.Authenticate
{
    public delegate UserData GetValidUserData(string loginname, string password, string applicationCode, CommonParam param);

    public delegate CredentialData GetCredentialData(string backendCode, string tokenCode, string dataKey, CommonParam param);

    public delegate bool IsGrantedUser(string loginname, string applicationCode, CommonParam param);

    public delegate bool InsertCredentialData(CredentialData credentialData, CommonParam param);

    public delegate bool DeleteCredentialData(string backendCode, string tokenCode, string dataKey, CommonParam param);

    public delegate bool DeleteAllCredentialData(string tokenCode, CommonParam param);

    public delegate bool UpdateUserPassword(string loginname, string oldPassword, string newPassword, CommonParam param);
}
