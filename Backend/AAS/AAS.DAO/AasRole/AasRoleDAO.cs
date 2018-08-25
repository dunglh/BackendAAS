using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasRole
{
    public partial class AasRoleDAO : EntityBase
    {
        private AasRoleCreate CreateWorker
        {
            get
            {
                return (AasRoleCreate)Worker.Get<AasRoleCreate>();
            }
        }
        private AasRoleUpdate UpdateWorker
        {
            get
            {
                return (AasRoleUpdate)Worker.Get<AasRoleUpdate>();
            }
        }
        private AasRoleTruncate TruncateWorker
        {
            get
            {
                return (AasRoleTruncate)Worker.Get<AasRoleTruncate>();
            }
        }
        private AasRoleGet GetWorker
        {
            get
            {
                return (AasRoleGet)Worker.Get<AasRoleGet>();
            }
        }
        private AasRoleCheck CheckWorker
        {
            get
            {
                return (AasRoleCheck)Worker.Get<AasRoleCheck>();
            }
        }

        public bool Create(Role data)
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

        public bool CreateList(List<Role> listData)
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

        public bool Update(Role data)
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

        public bool UpdateList(List<Role> listData)
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

        public bool Truncate(Role data)
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

        public bool TruncateList(List<Role> listData)
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

        public List<Role> Get(AasRoleSO search, CommonParam param)
        {
            List<Role> result = new List<Role>();
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

        public Role GetById(long id, AasRoleSO search)
        {
            Role result = null;
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
