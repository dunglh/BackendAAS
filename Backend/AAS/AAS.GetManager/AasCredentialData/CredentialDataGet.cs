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

namespace AAS.GetManager.AasCredentialData
{
    class CredentialDataGet : BusinessBase
    {
        internal CredentialDataGet()
            :base()
        {

        }

        internal CredentialDataGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<CredentialData> Get(CredentialDataFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasCredentialDataDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal CredentialData GetById(long id)
        {
            try
            {
                return GetById(id, new CredentialDataFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal CredentialData GetById(long id, CredentialDataFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasCredentialDataDAO.GetById(id, filter.Query());
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
