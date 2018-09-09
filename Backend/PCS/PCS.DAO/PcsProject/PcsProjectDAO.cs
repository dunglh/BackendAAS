using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Repository;
using System;
using System.Collections.Generic;

namespace PCS.DAO.PcsProject
{
    public partial class PcsProjectDAO : EntityBase
    {
        private PcsProjectCreate CreateWorker
        {
            get
            {
                return (PcsProjectCreate)Worker.Get<PcsProjectCreate>();
            }
        }
        private PcsProjectUpdate UpdateWorker
        {
            get
            {
                return (PcsProjectUpdate)Worker.Get<PcsProjectUpdate>();
            }
        }
        private PcsProjectTruncate TruncateWorker
        {
            get
            {
                return (PcsProjectTruncate)Worker.Get<PcsProjectTruncate>();
            }
        }
        private PcsProjectGet GetWorker
        {
            get
            {
                return (PcsProjectGet)Worker.Get<PcsProjectGet>();
            }
        }
        private PcsProjectCheck CheckWorker
        {
            get
            {
                return (PcsProjectCheck)Worker.Get<PcsProjectCheck>();
            }
        }

        public bool Create(Project data)
        {
            bool result = false;
            try
            {
                result = CreateWorker.Create(data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool CreateList(List<Project> listData)
        {
            bool result = false;
            try
            {
                result = CreateWorker.CreateList(listData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Update(Project data)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.Update(data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool UpdateList(List<Project> listData)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.UpdateList(listData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }        

        public bool Truncate(Project data)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.Truncate(data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool TruncateList(List<Project> listData)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.TruncateList(listData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public List<Project> Get(PcsProjectSO search, CommonParam param)
        {
            List<Project> result = new List<Project>();
            try
            {
                result = GetWorker.Get(search, param);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                LogSystem.Error(ex);
                result.Clear();
            }
            return result;
        }

        public Project GetById(long id, PcsProjectSO search)
        {
            Project result = null;
            try
            {
                result = GetWorker.GetById(id, search);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            try
            {
                return CheckWorker.IsUnLock(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw;
            }
        }
    }
}
