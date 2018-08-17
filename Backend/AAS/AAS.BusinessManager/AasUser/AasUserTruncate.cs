using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasUser
{
    partial class AasUserTruncate : BusinessBase
    {
        internal AasUserTruncate()
            : base()
        {

        }

        internal AasUserTruncate(CommonParam paramTruncate)
            : base(paramTruncate)
        {

        }

        internal bool Truncate(User data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasUserCheck checker = new AasUserCheck(param);
                valid = valid && IsNotNull(data);
                User raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.CheckConstraint(data.Id);
                if (valid)
                {
                    result = DAOWorker.AasUserDAO.Truncate(data);
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

        internal bool TruncateList(List<User> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasUserCheck checker = new AasUserCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && IsNotNull(data) && IsGreaterThanZero(data.Id);
                    valid = valid && checker.IsUnLock(data.Id);
                }
                if (valid)
                {
                    result = DAOWorker.AasUserDAO.TruncateList(listData);
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
