using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasUser
{
    public partial class AasUserDAO : EntityBase
    {
        public User GetByLoginname(string loginname, AasUserSO search)
        {
            User result = null;

            try
            {
                result = GetWorker.GetByLoginname(loginname, search);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }

            return result;
        }
        
        public bool ExistsLoginname(string loginname, long? id)
        {

            try
            {
                return CheckWorker.ExistsLoginname(loginname, id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw;
            }
        }
    }
}
