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

namespace AAS.GetManager.AasUserRole
{
    partial class UserRoleGet : BusinessBase
    {
        internal UserRoleGet()
            :base()
        {

        }

        internal UserRoleGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<UserRole> Get(UserRoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasUserRoleDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal UserRole GetById(long id)
        {
            try
            {
                return GetById(id, new UserRoleFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal UserRole GetById(long id, UserRoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasUserRoleDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal List<UserRole> GetByUserId(long userId)
        {
            try
            {
                UserRoleFilterQuery filterQuery = new UserRoleFilterQuery();
                filterQuery.UserId = userId;
                return this.Get(filterQuery);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal List<UserRole> GetByRoleId(long roleId)
        {
            try
            {
                UserRoleFilterQuery filterQuery = new UserRoleFilterQuery();
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
