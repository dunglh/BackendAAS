using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Repository;
using System;
using System.Collections.Generic;

namespace PCS.DAO.PcsAddress
{
    public partial class PcsAddressDAO : EntityBase
    {
        private PcsAddressCreate CreateWorker
        {
            get
            {
                return (PcsAddressCreate)Worker.Get<PcsAddressCreate>();
            }
        }
        private PcsAddressUpdate UpdateWorker
        {
            get
            {
                return (PcsAddressUpdate)Worker.Get<PcsAddressUpdate>();
            }
        }
        private PcsAddressTruncate TruncateWorker
        {
            get
            {
                return (PcsAddressTruncate)Worker.Get<PcsAddressTruncate>();
            }
        }
        private PcsAddressGet GetWorker
        {
            get
            {
                return (PcsAddressGet)Worker.Get<PcsAddressGet>();
            }
        }
        private PcsAddressCheck CheckWorker
        {
            get
            {
                return (PcsAddressCheck)Worker.Get<PcsAddressCheck>();
            }
        }

        public bool Create(Address data)
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

        public bool CreateList(List<Address> listData)
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

        public bool Update(Address data)
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

        public bool UpdateList(List<Address> listData)
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

        public bool Truncate(Address data)
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

        public bool TruncateList(List<Address> listData)
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

        public List<Address> Get(PcsAddressSO search, CommonParam param)
        {
            List<Address> result = new List<Address>();
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

        public Address GetById(long id, PcsAddressSO search)
        {
            Address result = null;
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
