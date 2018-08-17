using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasApplication
{
    class ApplicationGet : BusinessBase
    {
        internal ApplicationGet()
            :base()
        {

        }

        internal ApplicationGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<Application> Get(ApplicationFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasApplicationDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Application GetById(long id)
        {
            try
            {
                return GetById(id, new ApplicationFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Application GetById(long id, ApplicationFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasApplicationDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Application GetByCode(string code)
        {
            try
            {
                return GetByCode(code, new ApplicationFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Application GetByCode(string code, ApplicationFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasApplicationDAO.GetByCode(code, filter.Query());
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
