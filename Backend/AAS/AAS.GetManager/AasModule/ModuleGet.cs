using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasModule
{
    partial class ModuleGet : BusinessBase
    {
        internal ModuleGet()
            :base()
        {

        }

        internal ModuleGet(CommonParam paramGet)
            : base(paramGet)
        {

        }        

        public List<Module> Get(ModuleFilterQuery filter)
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
