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

namespace PCS.GetManager.PcsAddress
{
    partial class PcsAddressGet : BusinessBase
    {
        internal PcsAddressGet()
            :base()
        {

        }

        internal PcsAddressGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<Address> Get(PcsAddressFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsAddressDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Address GetById(long id)
        {
            try
            {
                return GetById(id, new PcsAddressFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Address GetById(long id, PcsAddressFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsAddressDAO.GetById(id, filter.Query());
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
