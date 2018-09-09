using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.GetManager.PcsProject
{
    class PcsProjectGet : BusinessBase
    {
        internal PcsProjectGet()
            :base()
        {

        }

        internal PcsProjectGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<Project> Get(PcsProjectFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsProjectDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Project GetById(long id)
        {
            try
            {
                return GetById(id, new PcsProjectFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Project GetById(long id, PcsProjectFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsProjectDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Project GetByCode(string code)
        {
            try
            {
                return GetByCode(code, new PcsProjectFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Project GetByCode(string code, PcsProjectFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsProjectDAO.GetByCode(code, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
