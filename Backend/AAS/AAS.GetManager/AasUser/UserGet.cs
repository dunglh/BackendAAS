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

namespace AAS.GetManager.AasUser
{
    class UserGet : BusinessBase
    {
        internal UserGet()
            :base()
        {

        }

        internal UserGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<User> Get(UserFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasUserDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal User GetById(long id)
        {
            try
            {
                return GetById(id, new UserFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal User GetById(long id, UserFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasUserDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal User GetByLoginname(string loginname,UserFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasUserDAO.GetByLoginname(loginname, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal User GetByLoginname(string loginname)
        {
            try
            {
                return GetByLoginname(loginname, new UserFilterQuery());
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
