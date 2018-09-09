using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;

namespace PCS.DAO.PcsProject
{
    public partial class PcsProjectDAO : EntityBase
    {
        public Project GetByCode(string code, PcsProjectSO search)
        {
            Project result = null;

            try
            {
                result = GetWorker.GetByCode(code, search);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }

            return result;
        }
        
        public bool ExistsCode(string code, long? id)
        {

            try
            {
                return CheckWorker.ExistsCode(code, id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw;
            }
        }
    }
}
