using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.BusinessManager.Base;
using PCS.UTILITY;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace PCS.BusinessManager.PcsEmployee
{
    partial class PcsEmployeeLock : BusinessBase
    {
        internal PcsEmployeeLock()
            : base()
        {

        }

        internal PcsEmployeeLock(CommonParam paramLock)
            : base(paramLock)
        {

        }

        internal bool Lock(Employee data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Employee raw = null;
                valid = valid && new PcsEmployeeCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive != Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        throw new Exception("Du lieu dang bi khoa");
                    }
                    raw.IsActive = Constant.IS_FALSE;
                    result = DAOWorker.PcsEmployeeDAO.Update(raw);
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

        internal bool Unlock(Employee data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Employee raw = null;
                valid = valid && new PcsEmployeeCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive == Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangMoKhoa);
                        throw new Exception("Du lieu dang duoc mo khoa");
                    }
                    raw.IsActive = Constant.IS_TRUE;
                    result = DAOWorker.PcsEmployeeDAO.Update(raw);
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
