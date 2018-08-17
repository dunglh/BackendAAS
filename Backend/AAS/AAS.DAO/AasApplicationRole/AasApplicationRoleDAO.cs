using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasApplicationRole
{
    public partial class AasApplicationRoleDAO : EntityBase
    {
        private AasApplicationRoleCreate CreateWorker
        {
            get
            {
                return (AasApplicationRoleCreate)Worker.Get<AasApplicationRoleCreate>();
            }
        }
        private AasApplicationRoleUpdate UpdateWorker
        {
            get
            {
                return (AasApplicationRoleUpdate)Worker.Get<AasApplicationRoleUpdate>();
            }
        }
        private AasApplicationRoleTruncate TruncateWorker
        {
            get
            {
                return (AasApplicationRoleTruncate)Worker.Get<AasApplicationRoleTruncate>();
            }
        }
        private AasApplicationRoleGet GetWorker
        {
            get
            {
                return (AasApplicationRoleGet)Worker.Get<AasApplicationRoleGet>();
            }
        }
        private AasApplicationRoleCheck CheckWorker
        {
            get
            {
                return (AasApplicationRoleCheck)Worker.Get<AasApplicationRoleCheck>();
            }
        }

        public bool Create(ApplicationRole data)
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

        public bool CreateList(List<ApplicationRole> listData)
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

        public bool Update(ApplicationRole data)
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

        public bool UpdateList(List<ApplicationRole> listData)
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

        public bool Truncate(ApplicationRole data)
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

        public bool TruncateList(List<ApplicationRole> listData)
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

        public List<ApplicationRole> Get(AasApplicationRoleSO search, CommonParam param)
        {
            List<ApplicationRole> result = new List<ApplicationRole>();
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

        public ApplicationRole GetById(long id, AasApplicationRoleSO search)
        {
            ApplicationRole result = null;
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
