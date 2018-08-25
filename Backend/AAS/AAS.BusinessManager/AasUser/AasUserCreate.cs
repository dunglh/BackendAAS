using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.BusinessManager.Base;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using DungLH.Util.Token.Password;

namespace AAS.BusinessManager.AasUser
{
    partial class AasUserCreate : BusinessBase
    {
        private List<User> recentAasUsers = new List<User>();

        internal AasUserCreate()
            : base()
        {

        }

        internal AasUserCreate(CommonParam paramCreate)
            : base(paramCreate)
        {

        }

        internal bool Create(User data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PasswordManager passwordManager = new PasswordManager();
                AasUserCheck checker = new AasUserCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                valid = valid && checker.ExistsLoginname(data.Loginname, null);
                if (valid)
                {
                    string password = "";
                    if (!String.IsNullOrWhiteSpace(data.Password))
                    {
                        password = data.Password;
                    }
                    else
                    {
                        password = data.Loginname;
                    }
                    data.Salt = passwordManager.GenerateSalt();
                    data.Password = passwordManager.HashPassword(password, data.Salt, data.Loginname);

                    if (!DAOWorker.AasUserDAO.Create(data))
                    {
                        BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.AasUser_ThemMoiThatBai);
                        throw new Exception("Them moi thong tin AasUser that bai." + LogUtil.TraceData("data", data));
                    }
                    data.Password = "";
                    data.Salt = "";
                    this.recentAasUsers.Add(data);
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
            if (IsNotNullOrEmpty(this.recentAasUsers))
            {
                if (!new AasUserTruncate(param).TruncateList(this.recentAasUsers))
                {
                    LogSystem.Warn("Rollback du lieu AasUser that bai, can kiem tra lai." + LogUtil.TraceData("recentAasUsers", this.recentAasUsers));
                }
            }
        }
    }
}
