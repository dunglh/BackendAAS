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

namespace PCS.GetManager.PcsPost
{
    partial class PcsPostGet : BusinessBase
    {
        internal PcsPostGet()
            : base()
        {

        }

        internal PcsPostGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        public List<Post> Get(PcsPostFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsPostDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Post GetById(long id)
        {
            try
            {
                return GetById(id, new PcsPostFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal Post GetById(long id, PcsPostFilterQuery filter)
        {
            try
            {
                return DAOWorker.PcsPostDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal List<Post> GetByIds(List<long> ids)
        {
            try
            {
                if (ids != null)
                {
                    PcsPostFilterQuery filter = new PcsPostFilterQuery();
                    filter.Ids = ids;
                    return this.Get(filter);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }
            return null;
        }

        internal List<Post> GetByProjectId(long projectId)
        {
            try
            {
                PcsPostFilterQuery filter = new PcsPostFilterQuery();
                filter.ProjectId = projectId;
                return this.Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }
            return null;
        }
    }
}
