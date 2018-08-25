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

namespace AAS.BusinessManager.Token.Login
{
    class TokenLoginProcessor : BusinessBase
    {
        internal TokenLoginProcessor()
            : base()
        {

        }

        internal TokenLoginProcessor(CommonParam param)
            : base(param)
        {

        }

        internal bool Run(AasLoginSDO data, ref User resultData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                User raw = null;
                Application application = null;
                TokenLoginCheck checker = new TokenLoginCheck(param);
                AasUserCheck userChecker = new AasUserCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && userChecker.VerifyLoginname(data.Loginname, ref raw);
                valid = valid && userChecker.IsUnLock(raw);
                if (valid)
                {
                    if (!new DungLH.Util.Token.Password.PasswordManager().CheckPassword(raw.Password, data.Password, raw.Salt, data.Loginname))
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common_TaiKhoanHoacMatKhauKhongChinhXac);
                        throw new Exception("Tai khoa hoac mat khau khong chinh xac");
                    }

                    application = new ApplicationManagerGet().GetByCode(data.ApplicationCode);
                    if (application == null)
                    {
                        MessageUtil.SetMessage(param,
                        LibraryMessage.Message.Enum.Common_UngDungChuaDuocDangKyTrenHeThong);
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
