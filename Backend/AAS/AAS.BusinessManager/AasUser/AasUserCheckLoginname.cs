using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasUser
{
    partial class AasUserCheck : BusinessBase
    {
        /// <summary>
        /// Kiem tra ma da ton tai hay chua, id duoc su dung trong truong hop muon bo qua chinh ma cua minh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool ExistsLoginname(string loginname, long? id)
        {
            bool valid = true;
            try
            {
                if (DAOWorker.AasUserDAO.ExistsLoginname(loginname, id))
                {
                    MessageUtil.SetMessage(param, LibraryMessage.Message.Enum.Common__MaDaTonTaiTrenHeThong);
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
    }
}
