using AAS.BusinessManager.Base;
using AAS.DAO.Base;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using System;
using System.Collections.Generic;

namespace AAS.BusinessManager.AasApplication
{
    partial class AasApplicationCheck : BusinessBase
    {
        /// <summary>
        /// Kiem tra ma da ton tai hay chua, id duoc su dung trong truong hop muon bo qua chinh ma cua minh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        internal bool ExistsCode(string code, long? id)
        {
            bool valid = true;
            try
            {
                if (DAOWorker.AasApplicationDAO.ExistsCode(code, id))
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
