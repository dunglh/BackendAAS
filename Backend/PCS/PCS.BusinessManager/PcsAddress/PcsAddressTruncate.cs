using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using PCS.BusinessManager.PcsProject;

namespace PCS.BusinessManager.PcsAddress
{
    partial class PcsAddressTruncate : BusinessBase
    {
        internal PcsAddressTruncate()
            : base()
        {

        }

        internal PcsAddressTruncate(CommonParam paramTruncate)
            : base(paramTruncate)
        {

        }

        internal bool Truncate(Address data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                Address raw = null;
                Project project = null;
                PcsAddressCheck checker = new PcsAddressCheck(param);
                PcsProjectCheck projectChecker = new PcsProjectCheck(param);
                valid = valid && IsNotNull(data);                
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && projectChecker.VerifyId(data.ProjectId, ref project);
                valid = valid && projectChecker.IsUnLock(project);
                valid = valid && projectChecker.IsUnFinish(project);
                valid = valid && checker.CheckConstraint(data.Id);
                if (valid)
                {
                    result = DAOWorker.PcsAddressDAO.Truncate(data);
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

        internal bool TruncateList(List<Address> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                PcsAddressCheck checker = new PcsAddressCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && IsNotNull(data) && IsGreaterThanZero(data.Id);
                    valid = valid && checker.IsUnLock(data.Id);
                }
                if (valid)
                {
                    result = DAOWorker.PcsAddressDAO.TruncateList(listData);
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
