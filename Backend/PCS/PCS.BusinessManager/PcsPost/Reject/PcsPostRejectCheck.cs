using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using PCS.BusinessManager.Base;
using PCS.EFMODEL.DataModels;
using PCS.GetManager.PcsPost;
using PCS.SDO;
using PCS.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.BusinessManager.PcsPost.Reject
{
    class PcsPostRejectCheck : BusinessBase
    {
        internal PcsPostRejectCheck()
            : base()
        {

        }

        internal PcsPostRejectCheck(CommonParam param)
            : base(param)
        {

        }

        internal bool AllowReject(Post data)
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

        internal bool AllowReject(List<Post> listData)
        {
            bool valid = true;
            try
            {
                if (listData != null)
                {
                    foreach (Post data in listData)
                    {
                        valid = valid && this.AllowReject(data);
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

        internal bool ValidData(PcsPostSDO data, ref List<Post> listPost)
        {
            bool valid = true;
            try
            {
                List<Post> posts = new List<Post>();
                if (IsNotNullOrEmpty(data.Posts))
                {
                    valid = valid && new PcsPostCheck(param).VerifyIds(data.Posts.Select(s => s.Id).ToList(), posts);
                    if (valid)
                    {
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
                        return valid;
                    }
                }
                else
                {
                    PcsPostFilterQuery filterQuery = new PcsPostFilterQuery();
                    filterQuery.ProjectId = data.ProjectId;
                    filterQuery.PostSttId = PostSttConstant.POST_STT_ID__NOT_APPROVAL;
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

        internal bool ValidNote(PcsPostSDO data)
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
