using AAS.BusinessManager.Base;
using AAS.SDO;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.BusinessManager.Token.Login
{
    class TokenLoginCheck : BusinessBase
    {
        internal TokenLoginCheck()
            : base()
        {

        }

        internal TokenLoginCheck(CommonParam paramCheck)
            : base(paramCheck)
        {

        }

        internal bool VerifyRequireField(AasLoginSDO data)
        {
            bool valid = true;
            try
            {
                if (data == null) throw new ArgumentNullException("data");
                if (String.IsNullOrWhiteSpace(data.ApplicationCode)) throw new ArgumentNullException("data.ApplicationCode");
                if (String.IsNullOrWhiteSpace(data.Loginname)) throw new ArgumentNullException("data.Loginname");
                if (String.IsNullOrWhiteSpace(data.Password)) throw new ArgumentNullException("data.Password");
                data.Loginname = data.Loginname.ToLower().Trim();
            }
            catch (ArgumentNullException ex)
            {
                BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__ThieuThongTinBatBuoc);
                LogSystem.Error(ex);
                valid = false;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }
    }
}
