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

namespace AAS.GetManager.AasModule
{
    class ModuleGet : BusinessBase
    {
        internal ModuleGet()
            :base()
        {

        }

        internal ModuleGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<Module> GetResult(ModuleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasModuleDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        public List<Module> Get(ModuleFilterQuery filter)
        {
            List<Module> result = null;
            try
            {
                result = new ModuleGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        internal Module GetById(long id)
        {
            try
            {
                return GetById(id, new ModuleFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Module GetById(long id, ModuleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasModuleDAO.GetById(id, filter.Query());
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
