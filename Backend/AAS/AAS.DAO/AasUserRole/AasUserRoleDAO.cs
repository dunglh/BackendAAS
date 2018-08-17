using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasUserRole
{
    public partial class AasUserRoleDAO : EntityBase
    {
        private AasUserRoleCreate CreateWorker
        {
            get
            {
                return (AasUserRoleCreate)Worker.Get<AasUserRoleCreate>();
            }
        }
        private AasUserRoleUpdate UpdateWorker
        {
            get
            {
                return (AasUserRoleUpdate)Worker.Get<AasUserRoleUpdate>();
            }
        }
        private AasUserRoleTruncate TruncateWorker
        {
            get
            {
                return (AasUserRoleTruncate)Worker.Get<AasUserRoleTruncate>();
            }
        }
        private AasUserRoleGet GetWorker
        {
            get
            {
                return (AasUserRoleGet)Worker.Get<AasUserRoleGet>();
            }
        }
        private AasUserRoleCheck CheckWorker
        {
            get
            {
                return (AasUserRoleCheck)Worker.Get<AasUserRoleCheck>();
            }
        }

        public bool Create(UserRole data)
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

        public bool CreateList(List<UserRole> listData)
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

        public bool Update(UserRole data)
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

        public bool UpdateList(List<UserRole> listData)
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

        public bool Truncate(UserRole data)
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

        public bool TruncateList(List<UserRole> listData)
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

        public List<UserRole> Get(AasUserRoleSO search, CommonParam param)
        {
            List<UserRole> result = new List<UserRole>();
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

        public UserRole GetById(long id, AasUserRoleSO search)
        {
            UserRole result = null;
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
