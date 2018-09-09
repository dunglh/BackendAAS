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

namespace PCS.GetManager.PcsEmployee
{
    class PcsEmployeeGet : BusinessBase
    {
        internal PcsEmployeeGet()
            :base()
        {

        }

        internal PcsEmployeeGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<Employee> Get(PcsEmployeeFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsEmployeeDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Employee GetById(long id)
        {
            try
            {
                return GetById(id, new PcsEmployeeFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Employee GetById(long id, PcsEmployeeFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsEmployeeDAO.GetById(id, filter.Query());
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
