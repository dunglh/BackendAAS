using PCS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.Core;
using DungLH.Util.CommonLogging;
using PCS.GetManager.PcsPost;
using PCS.UTILITY;
using PCS.DAO.Base;
using PCS.BusinessManager.Base;
using PCS.SDO;
using PCS.GetManager.PcsProject;
using System.Linq;
using PCS.GetManager.PcsAddress;

namespace PCS.BusinessManager.PcsPost
{
    partial class PcsPostCheck : BusinessBase
    {
        internal PcsPostCheck()
            : base()
        {

        }

        internal PcsPostCheck(CommonParam paramCheck)
            : base(paramCheck)
        {

        }

        internal bool VerifyRequireField(Post data)
        {
            bool valid = true;
            try
            {
                if (data == null) throw new ArgumentNullException("data");
                if (String.IsNullOrWhiteSpace(data.Content)) throw new ArgumentNullException("data.Content");
                if (String.IsNullOrWhiteSpace(data.Title)) throw new ArgumentNullException("data.Title");
                if (data.AddressId <= 0) throw new ArgumentNullException("data.AddressId");
                if (data.PostSttId <= 0 || data.PostSttId > 5) throw new ArgumentNullException("data.PostSttId");
                if (data.ProjectId <= 0) throw new ArgumentNullException("data.ProjectId");
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
                if (new PcsPostManagerGet().GetById(id) == null)
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
        internal bool VerifyId(long id, ref Post data)
        {
            bool valid = true;
            try
            {
                data = new PcsPostManagerGet().GetById(id);
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
                    PcsPostFilterQuery filter = new PcsPostFilterQuery();
                    filter.Ids = listId;
                    List<Post> listData = new PcsPostManagerGet().Get(filter);
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
        internal bool VerifyIds(List<long> listId, List<Post> listObject)
        {
            bool valid = true;
            try
            {
                if (listId != null && listId.Count > 0)
                {
                    PcsPostFilterQuery filter = new PcsPostFilterQuery();
                    filter.Ids = listId;
                    List<Post> listData = new PcsPostManagerGet().Get(filter);
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
        internal bool IsUnLock(Post data)
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
                if (!DAOWorker.PcsPostDAO.IsUnLock(id))
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
                    PcsPostFilterQuery filter = new PcsPostFilterQuery();
                    filter.Ids = listId;
                    List<Post> listData = new PcsPostManagerGet().Get(filter);
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
        internal bool IsUnLock(List<Post> listData)
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

        internal bool AllowApproveOrReject(Post data)
        {
            bool valid = true;
            try
            {
                if (data.PostSttId != PostSttConstant.POST_STT_ID__NOT_APPROVAL)
                {
                    MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.PcsPost__TrangThaiBaiDangKhongHopLe);
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
            }
            return valid;
        }

        internal bool AllowApproveOrReject(List<Post> listData)
        {
            bool valid = true;
            try
            {
                if (listData != null)
                {
                    foreach (Post data in listData)
                    {
                        valid = valid && this.AllowApproveOrReject(data);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
            }
            return valid;
        }

        internal bool ValidData(PcsPostSDO data, int postSttId, ref List<Post> listPost)
        {
            bool valid = true;
            try
            {
                List<Post> posts = new List<Post>();
                if (IsNotNullOrEmpty(data.Posts))
                {
                    this.VerifyIds(data.Posts.Select(s => s.Id).ToList(), posts);
                    if (!IsNotNullOrEmpty(posts))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__DuLieuDauVaoKhongChinhXac);
                        throw new Exception("PostIds invalid");
                    }

                    if (posts.Exists(e => e.ProjectId != data.ProjectId))
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.PcsPost__TonTaiBaiDangKhongThuocDuAn);
                        throw new Exception("Ton tai bai dang khong thuoc du an");
                    }
                }
                else
                {
                    PcsPostFilterQuery filterQuery = new PcsPostFilterQuery();
                    filterQuery.ProjectId = data.ProjectId;
                    filterQuery.PostSttId = postSttId;
                    posts = new PcsPostManagerGet().Get(filterQuery);
                    if (!IsNotNullOrEmpty(posts))
                    {
                        MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.PcsPost__DuAnKhongCoBaiDangNaoHopLe);
                        throw new Exception("Project Khong co bai dang nao hop le");
                    }
                }
                listPost = posts;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = false;
                param.HasException = true;
            }
            return valid;
        }

        internal bool ValidRejectNote(PcsPostSDO data)
        {
            bool valid = true;
            try
            {
                if (IsNotNullOrEmpty(data.Posts))
                {
                    valid = valid && (!data.Posts.Exists(e => String.IsNullOrWhiteSpace(e.ApprovalNote)) && String.IsNullOrWhiteSpace(data.Note));
                }
                else
                {
                    valid = valid && String.IsNullOrWhiteSpace(data.Note);
                }
                if (!valid)
                {
                    MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.PcsPost__ThieuThongTinLyDoTuChoiDuyet);
                }

            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                valid = true;
            }
            return valid;
        }
    }
}
