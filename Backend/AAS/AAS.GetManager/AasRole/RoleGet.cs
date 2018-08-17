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

namespace AAS.GetManager.AasRole
{
    class RoleGet : BusinessBase
    {
        internal RoleGet()
            :base()
        {

        }

        internal RoleGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<Role> Get(RoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasRoleDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Role GetById(long id)
        {
            try
            {
                return GetById(id, new RoleFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Role GetById(long id, RoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasRoleDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Role GetByCode(string code)
        {
            try
            {
                return GetByCode(code, new RoleFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Role GetByCode(string code, RoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasRoleDAO.GetByCode(code, filter.Query());
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
