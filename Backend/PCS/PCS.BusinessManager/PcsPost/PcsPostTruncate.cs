using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCS.BusinessManager.PcsPost
{
    partial class PcsPostTruncate : BusinessBase
    {
        internal PcsPostTruncate()
            : base()
        {

        }

        internal PcsPostTruncate(CommonParam paramTruncate)
            : base(paramTruncate)
        {

        }

        internal bool Truncate(Post data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                PcsPostCheck checker = new PcsPostCheck(param);
                valid = valid && IsNotNull(data);
                Post raw = null;
                valid = valid && checker.VerifyId(data.Id, ref raw);
                valid = valid && checker.IsUnLock(raw);
                valid = valid && checker.CheckConstraint(data.Id);
                if (valid)
                {
                    result = DAOWorker.PcsPostDAO.Truncate(data);
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

        internal bool TruncateList(List<Post> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                PcsPostCheck checker = new PcsPostCheck(param);
                foreach (var data in listData)
                {
                    valid = valid && IsNotNull(data) && IsGreaterThanZero(data.Id);
                    valid = valid && checker.IsUnLock(data.Id);
                }
                if (valid)
                {
                    result = DAOWorker.PcsPostDAO.TruncateList(listData);
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
