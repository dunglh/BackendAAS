using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using AAS.Util;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace AAS.BusinessManager.AasModuleRole
{
    partial class AasModuleRoleLock : BusinessBase
    {
        internal AasModuleRoleLock()
            : base()
        {

        }

        internal AasModuleRoleLock(CommonParam paramLock)
            : base(paramLock)
        {

        }

        internal bool Lock(ModuleRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                ModuleRole raw = null;
                valid = valid && new AasModuleRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive != Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        throw new Exception("Du lieu dang bi khoa");
                    }

                    raw.IsActive = Constant.IS_FALSE;
                    result = DAOWorker.AasModuleRoleDAO.Update(raw);
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

        internal bool Unlock(ModuleRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                ModuleRole raw = null;
                valid = valid && new AasModuleRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive == Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangMoKhoa);
                        throw new Exception("Du lieu dang duoc mo khoa");
                    }

                    raw.IsActive = Constant.IS_TRUE;
                    result = DAOWorker.AasModuleRoleDAO.Update(raw);
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
