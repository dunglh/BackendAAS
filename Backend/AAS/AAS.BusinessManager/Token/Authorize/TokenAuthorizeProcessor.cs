using AAS.BusinessManager.AasUser;
using AAS.BusinessManager.Base;
using AAS.EFMODEL.DataModels;
using AAS.GetManager.AasApplication;
using AAS.GetManager.AasApplicationRole;
using AAS.GetManager.AasUserRole;
using AAS.SDO;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.BusinessManager.Token.Authorize
{
    class TokenAuthorizeProcessor : BusinessBase
    {
        internal TokenAuthorizeProcessor()
            :base()
        {

        }

        internal TokenAuthorizeProcessor(CommonParam param)
            : base(param)
        {

        }

        internal bool Run(AasAuthorizeSDO data, ref User resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                User raw = null;
                Application application = null;
                TokenAuthorizeCheck checker = new TokenAuthorizeCheck(param);
                AasUserCheck userChecker = new AasUserCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && userChecker.VerifyLoginname(data.Loginname, ref raw);
                if (valid)
                {
                    application = new ApplicationManagerGet().GetByCode(data.ApplicationCode);
                    if (application == null)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common_UngDungChuaDuocDangKyTrenHeThong);
                        throw new Exception("ApplicationCode invalid: " + data.ApplicationCode);
                    }

                    List<ApplicationRole> appRoles = new ApplicationRoleManagerGet().GetByApplicationId(application.Id);
                    if (!IsNotNullOrEmpty(appRoles))
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common_TaiKhoanKhongCoQuyenTruyCapUngDung);
                        throw new Exception("Ung dung cua duc gan vao vao tro nao");
                    }

                    List<UserRole> userRoles = new UserRoleManagerGet().GetByUserId(raw.Id);
                    if (!IsNotNullOrEmpty(userRoles))
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common_TaiKhoanKhongCoQuyenTruyCapUngDung);
                        throw new Exception("Nguoi dung chua duc gan vai trong o cho naof");
                    }

                    List<long> userRoleIds = userRoles.Select(s => s.RoleId).ToList();
                    if (!appRoles.Exists(e => userRoleIds.Contains(e.RoleId)))
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common_TaiKhoanKhongCoQuyenTruyCapUngDung);
                        throw new Exception("Nguoi dung khong duoc phan quyen truy cap vao ung dung");
                    }
                    raw.Password = "";
                    resultData = raw;
                    result = true;
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
