using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using AAS.Util;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace AAS.BusinessManager.AasApplicationRole
{
    partial class AasApplicationRoleLock : BusinessBase
    {
        internal AasApplicationRoleLock()
            : base()
        {

        }

        internal AasApplicationRoleLock(CommonParam paramLock)
            : base(paramLock)
        {

        }

        internal bool Lock(ApplicationRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                ApplicationRole raw = null;
                valid = valid && new AasApplicationRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive != Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        throw new Exception("Du lieu dang bi khoa");
                    }
                    raw.IsActive = Constant.IS_FALSE;
                    result = DAOWorker.AasApplicationRoleDAO.Update(raw);
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

        internal bool Unlock(ApplicationRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                ApplicationRole raw = null;
                valid = valid && new AasApplicationRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive == Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangMoKhoa);
                        throw new Exception("Du lieu dang duoc mo khoa");
                    }
                    raw.IsActive = Constant.IS_TRUE;
                    result = DAOWorker.AasApplicationRoleDAO.Update(raw);
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
