using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasApplicationRole
{
    partial class AasApplicationRoleTruncate : BusinessBase
    {
        internal AasApplicationRoleTruncate()
            : base()
        {

        }

        internal AasApplicationRoleTruncate(CommonParam paramTruncate)
            : base(paramTruncate)
        {

        }

        internal bool Truncate(ApplicationRole data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasApplicationRoleCheck checker = new AasApplicationRoleCheck(param);
                valid = valid && IsNotNull(data);
                ApplicationRole raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.CheckConstraint(data.Id);
                if (valid)
                {
                    result = DAOWorker.AasApplicationRoleDAO.Truncate(data);
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

        internal bool TruncateList(List<ApplicationRole> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasApplicationRoleCheck checker = new AasApplicationRoleCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && IsNotNull(data) && IsGreaterThanZero(data.Id);
                    valid = valid && checker.IsUnLock(data.Id);
                }
                if (valid)
                {
                    result = DAOWorker.AasApplicationRoleDAO.TruncateList(listData);
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