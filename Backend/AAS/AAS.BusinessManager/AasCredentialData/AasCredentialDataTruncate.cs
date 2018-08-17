using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.BusinessManager.AasCredentialData
{
    partial class AasCredentialDataTruncate : BusinessBase
    {
        internal AasCredentialDataTruncate()
            : base()
        {

        }

        internal AasCredentialDataTruncate(CommonParam paramTruncate)
            : base(paramTruncate)
        {

        }

        internal bool Truncate(CredentialData data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                AasCredentialDataCheck checker = new AasCredentialDataCheck(param);
                valid = valid && IsNotNull(data);
                CredentialData raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.CheckConstraint(data.Id);
                if (valid)
                {
                    result = DAOWorker.AasCredentialDataDAO.Truncate(data);
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

        internal bool TruncateList(List<CredentialData> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                AasCredentialDataCheck checker = new AasCredentialDataCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && IsNotNull(data) && IsGreaterThanZero(data.Id);
                    valid = valid && checker.IsUnLock(data.Id);
                }
                if (valid)
                {
                    result = DAOWorker.AasCredentialDataDAO.TruncateList(listData);
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
