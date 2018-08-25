using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasUser
{
    partial class AasUserUpdate : BusinessBase
    {
		private List<User> beforeUpdateAasUsers = new List<User>();
		
        internal AasUserUpdate()
            : base()
        {

        }

        internal AasUserUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(User data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasUserCheck checker = new AasUserCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                User raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.ExistsLoginname(data.Loginname, data.Id);
                if (valid)
                {
					if (!DAOWorker.AasUserDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUser_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasUser that bai." + LogUtil.TraceData("data", data));
                    }

                    this.beforeUpdateAasUsers.Add(raw);
                    result = true;
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

        internal bool Update(User data, User before)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasUserCheck checker = new AasUserCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.IsUnLock(before);
                valid = valid && checker.ExistsLoginname(data.Loginname, data.Id);
                if (valid)
                {
                    if (!DAOWorker.AasUserDAO.Update(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUser_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasUser that bai." + LogUtil.TraceData("data", data));
                    }
                    this.beforeUpdateAasUsers.Add(before);
                    result = true;
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

        internal bool UpdateList(List<User> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasUserCheck checker = new AasUserCheck(param);
                List<User> listRaw = new List<User>();
                List<long> listId = listData.Select(o => o.Id).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                    valid = valid && checker.ExistsLoginname(data.Loginname, data.Id);
                }
                if (valid)
                {
					if (!DAOWorker.AasUserDAO.UpdateList(listData))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUser_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin AasUser that bai." + LogUtil.TraceData("listData", listData));
                    }
                    this.beforeUpdateAasUsers.AddRange(listRaw);
                    result = true;
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
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.beforeUpdateAasUsers))
            {
                if (!DAOWorker.AasUserDAO.UpdateList(this.beforeUpdateAasUsers))
                {
                    LogSystem.Warn("Rollback du lieu AasUser that bai, can kiem tra lai." + LogUtil.TraceData("AasUsers", this.beforeUpdateAasUsers));
                }
            }
        }
    }
}
