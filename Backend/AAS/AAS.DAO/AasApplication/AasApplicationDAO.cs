using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasApplication
{
    public partial class AasApplicationDAO : EntityBase
    {
        private AasApplicationCreate CreateWorker
        {
            get
            {
                return (AasApplicationCreate)Worker.Get<AasApplicationCreate>();
            }
        }
        private AasApplicationUpdate UpdateWorker
        {
            get
            {
                return (AasApplicationUpdate)Worker.Get<AasApplicationUpdate>();
            }
        }
        private AasApplicationTruncate TruncateWorker
        {
            get
            {
                return (AasApplicationTruncate)Worker.Get<AasApplicationTruncate>();
            }
        }
        private AasApplicationGet GetWorker
        {
            get
            {
                return (AasApplicationGet)Worker.Get<AasApplicationGet>();
            }
        }
        private AasApplicationCheck CheckWorker
        {
            get
            {
                return (AasApplicationCheck)Worker.Get<AasApplicationCheck>();
            }
        }

        public bool Create(Application data)
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

        public bool CreateList(List<Application> listData)
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

        public bool Update(Application data)
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

        public bool UpdateList(List<Application> listData)
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

        public bool Truncate(Application data)
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

        public bool TruncateList(List<Application> listData)
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

        public List<Application> Get(AasApplicationSO search, CommonParam param)
        {
            List<Application> result = new List<Application>();
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

        public Application GetById(long id, AasApplicationSO search)
        {
            Application result = null;
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
