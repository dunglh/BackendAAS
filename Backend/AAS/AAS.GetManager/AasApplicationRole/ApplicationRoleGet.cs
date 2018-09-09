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

namespace AAS.GetManager.AasApplicationRole
{
    partial class ApplicationRoleGet : BusinessBase
    {
        internal ApplicationRoleGet()
            :base()
        {

        }

        internal ApplicationRoleGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<ApplicationRole> Get(ApplicationRoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasApplicationRoleDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal ApplicationRole GetById(long id)
        {
            try
            {
                return GetById(id, new ApplicationRoleFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal ApplicationRole GetById(long id, ApplicationRoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasApplicationRoleDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal List<ApplicationRole> GetByApplicationId(long applicationId)
        {
            try
            {
                ApplicationRoleFilterQuery filterQuery = new ApplicationRoleFilterQuery();
                filterQuery.ApplicationId = applicationId;
                return this.Get(filterQuery);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal List<ApplicationRole> GetByRoleId(long roleId)
        {
            try
            {
                ApplicationRoleFilterQuery filterQuery = new ApplicationRoleFilterQuery();
                filterQuery.RoleId = roleId;
                return this.Get(filterQuery);
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
