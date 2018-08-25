using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using AAS.Util;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace AAS.BusinessManager.AasRole
{
    partial class AasRoleLock : BusinessBase
    {
        internal AasRoleLock()
            : base()
        {

        }

        internal AasRoleLock(CommonParam paramLock)
            : base(paramLock)
        {

        }

        internal bool Lock(Role data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Role raw = null;
                valid = valid && new AasRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive != Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        throw new Exception("Du lieu dang bi khoa");
                    }

                    raw.IsActive = Constant.IS_FALSE;
                    result = DAOWorker.AasRoleDAO.Update(raw);
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

        internal bool Unlock(Role data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Role raw = null;
                valid = valid && new AasRoleCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive == Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangMoKhoa);
                        throw new Exception("Du lieu dang duoc mo khoa");
                    }

                    raw.IsActive = Constant.IS_TRUE;
                    result = DAOWorker.AasRoleDAO.Update(raw);
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
