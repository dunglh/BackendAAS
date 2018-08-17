using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using AAS.Util;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;

namespace AAS.BusinessManager.AasUserRole
{
    partial class AasUserRoleLock : BusinessBase
    {
        internal AasUserRoleLock()
            : base()
        {

        }

        internal AasUserRoleLock(CommonParam paramLock)
            : base(paramLock)
        {

        }

        internal bool Lock(UserRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                UserRole raw = null;
                valid = valid && new AasUserRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive != Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        throw new Exception("Du lieu dang bi khoa");
                    }

                    raw.IsActive = Constant.IS_FALSE;
                    result = DAOWorker.AasUserRoleDAO.Update(raw);
                    if (result) data.IsActive = raw.IsActive;
                }
                else
                {
                    BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        internal bool Unlock(UserRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                UserRole raw = null;
                valid = valid && new AasUserRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive == Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangMoKhoa);
                        throw new Exception("Du lieu dang duoc mo khoa");
                    }

                    raw.IsActive = Constant.IS_TRUE;
                    result = DAOWorker.AasUserRoleDAO.Update(raw);
                    if (result) data.IsActive = raw.IsActive;
                }
                else
                {
                    BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
    }
}
