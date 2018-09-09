using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.BusinessManager.Base;
using PCS.UTILITY;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace PCS.BusinessManager.PcsAddress
{
    partial class PcsAddressLock : BusinessBase
    {
        internal PcsAddressLock()
            : base()
        {

        }

        internal PcsAddressLock(CommonParam paramLock)
            : base(paramLock)
        {

        }

        internal bool Lock(Address data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Address raw = null;
                valid = valid && new PcsAddressCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive != Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        throw new Exception("Du lieu dang bi khoa");
                    }
                    raw.IsActive = Constant.IS_FALSE;
                    result = DAOWorker.PcsAddressDAO.Update(raw);
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

        internal bool Unlock(Address data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Address raw = null;
                valid = valid && new PcsAddressCheck().VerifyId(data.Id, ref raw);
                if (valid && raw != null)
                {
                    if (raw.IsActive == Constant.IS_TRUE)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangMoKhoa);
                        throw new Exception("Du lieu dang duoc mo khoa");
                    }
                    raw.IsActive = Constant.IS_TRUE;
                    result = DAOWorker.PcsAddressDAO.Update(raw);
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
