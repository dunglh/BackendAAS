using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasUserRole
{
    partial class AasUserRoleTruncate : BusinessBase
    {
        internal AasUserRoleTruncate()
            : base()
        {

        }

        internal AasUserRoleTruncate(CommonParam paramTruncate)
            : base(paramTruncate)
        {

        }

        internal bool Truncate(UserRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasUserRoleCheck checker = new AasUserRoleCheck(param);
                valid = valid && IsNotNull(data);
                UserRole raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.CheckConstraint(data.Id);
                if (valid)
                {
                    result = DAOWorker.AasUserRoleDAO.Truncate(data);
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

        internal bool TruncateList(List<UserRole> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasUserRoleCheck checker = new AasUserRoleCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && IsNotNull(data) && IsGreaterThanZero(data.Id);
                    valid = valid && checker.IsUnLock(data.Id);
                }
                if (valid)
                {
                    result = DAOWorker.AasUserRoleDAO.TruncateList(listData);
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
