using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasCredentialData
{
    public partial class AasCredentialDataDAO : EntityBase
    {
        private AasCredentialDataCreate CreateWorker
        {
            get
            {
                return (AasCredentialDataCreate)Worker.Get<AasCredentialDataCreate>();
            }
        }
        private AasCredentialDataUpdate UpdateWorker
        {
            get
            {
                return (AasCredentialDataUpdate)Worker.Get<AasCredentialDataUpdate>();
            }
        }
        private AasCredentialDataTruncate TruncateWorker
        {
            get
            {
                return (AasCredentialDataTruncate)Worker.Get<AasCredentialDataTruncate>();
            }
        }
        private AasCredentialDataGet GetWorker
        {
            get
            {
                return (AasCredentialDataGet)Worker.Get<AasCredentialDataGet>();
            }
        }
        private AasCredentialDataCheck CheckWorker
        {
            get
            {
                return (AasCredentialDataCheck)Worker.Get<AasCredentialDataCheck>();
            }
        }

        public bool Create(CredentialData data)
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

        public bool CreateList(List<CredentialData> listData)
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

        public bool Update(CredentialData data)
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

        public bool UpdateList(List<CredentialData> listData)
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

        public bool Truncate(CredentialData data)
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

        public bool TruncateList(List<CredentialData> listData)
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

        public List<CredentialData> Get(AasCredentialDataSO search, CommonParam param)
        {
            List<CredentialData> result = new List<CredentialData>();
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

        public CredentialData GetById(long id, AasCredentialDataSO search)
        {
            CredentialData result = null;
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
