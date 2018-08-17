using AAS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using MyUtil.Backend.MANAGER;
using MyUtil.Core;
using MyUtil.CommonLogging;
using AAS.GetManager.AasUserRole;
using AAS.Util;
using AAS.DAO.Base;
using AAS.BusinessManager.Base;

namespace AAS.BusinessManager.AasUserRole
{
    partial class AasUserRoleCheck : BusinessBase
    {
        internal AasUserRoleCheck()
            : base()
        {

        }

        internal AasUserRoleCheck(CommonParam paramCheck)
            : base(paramCheck)
        {

        }

        internal bool VerifyRequireField(UserRole data)
        {
            bool valid = true;
            try
            {
                if (data == null) throw new ArgumentNullException("data");
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

        /// <summary>
        /// Kiem tra su ton tai cua id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool VerifyId(long id)
        {
            bool valid = true;
            try
            {
                if (new UserRoleManagerGet().GetById(id) == null)
                {
                    BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                    Logging("Id invalid." + LogUtil.TraceData("id", id), LogType.Error);
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra su ton tai cua id dong thoi lay ve du lieu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool VerifyId(long id, ref UserRole data)
        {
            bool valid = true;
            try
            {
                data = new UserRoleManagerGet().GetById(id);
                if (data == null)
                {
                    BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                    Logging("Id invalid." + LogUtil.TraceData("id", id), LogType.Error);
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra su ton tai cua danh sach cac id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool VerifyIds(List<long> listId)
        {
            bool valid = true;
            try
            {
                if (listId != null && listId.Count > 0)
                {
                    UserRoleFilterQuery filter = new UserRoleFilterQuery();
                    filter.Ids = listId;
                    List<UserRole> listData = new UserRoleManagerGet().Get(filter);
                    if (listData == null || listId.Count != listData.Count)
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                        Logging("ListId invalid." + LogUtil.TraceData("listData", listData) + LogUtil.TraceData("listId", listId), LogType.Error);
                        valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra su ton tai cua danh sach cac id dong thoi lay ve du lieu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool VerifyIds(List<long> listId, List<UserRole> listObject)
        {
            bool valid = true;
            try
            {
                if (listId != null && listId.Count > 0)
                {
                    UserRoleFilterQuery filter = new UserRoleFilterQuery();
                    filter.Ids = listId;
                    List<UserRole> listData = new UserRoleManagerGet().Get(filter);
                    if (listData == null || listId.Count != listData.Count)
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__KXDDDuLieuCanXuLy);
                        Logging("ListId invalid." + LogUtil.TraceData("listData", listData) + LogUtil.TraceData("listId", listId), LogType.Error);
                        valid = false;
                    }
                    else
                    {
                        listObject.AddRange(listData);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra du lieu co o trang thai unlock (su dung doi tuong)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool IsUnLock(UserRole data)
        {
            bool valid = true;
            try
            {
                if (Constant.IS_TRUE != data.IsActive)
                {
                    valid = false;
                    MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra du lieu co o trang thai unlock (su dung id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool IsUnLock(long id)
        {
            bool valid = true;
            try
            {
                if (!DAOWorker.AasUserRoleDAO.IsUnLock(id))
                {
                    valid = false;
                    MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra du lieu co o trang thai unlock (su dung danh sach id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool IsUnLock(List<long> listId)
        {
            bool valid = true;
            try
            {
                if (listId != null && listId.Count > 0)
                {
                    UserRoleFilterQuery filter = new UserRoleFilterQuery();
                    filter.Ids = listId;
                    List<UserRole> listData = new UserRoleManagerGet().Get(filter);
                    if (listData != null && listData.Count > 0)
                    {
                        foreach (var data in listData)
                        {
                            if (Constant.IS_TRUE != data.IsActive)
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (!valid)
                        {
                            MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        /// <summary>
        /// Kiem tra du lieu co o trang thai unlock (su dung danh sach data)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool IsUnLock(List<UserRole> listData)
        {
            bool valid = true;
            try
            {
                if (listData != null && listData.Count > 0)
                {
                    foreach (var data in listData)
                    {
                        if (Constant.IS_TRUE != data.IsActive)
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__DuLieuDangBiKhoa);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        internal bool CheckConstraint(long id)
        {
            bool valid = true;
            try
            {
                //TODO
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
