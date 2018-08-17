using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasModuleRole
{
    public partial class AasModuleRoleDAO : EntityBase
    {
        private AasModuleRoleCreate CreateWorker
        {
            get
            {
                return (AasModuleRoleCreate)Worker.Get<AasModuleRoleCreate>();
            }
        }
        private AasModuleRoleUpdate UpdateWorker
        {
            get
            {
                return (AasModuleRoleUpdate)Worker.Get<AasModuleRoleUpdate>();
            }
        }
        private AasModuleRoleTruncate TruncateWorker
        {
            get
            {
                return (AasModuleRoleTruncate)Worker.Get<AasModuleRoleTruncate>();
            }
        }
        private AasModuleRoleGet GetWorker
        {
            get
            {
                return (AasModuleRoleGet)Worker.Get<AasModuleRoleGet>();
            }
        }
        private AasModuleRoleCheck CheckWorker
        {
            get
            {
                return (AasModuleRoleCheck)Worker.Get<AasModuleRoleCheck>();
            }
        }

        public bool Create(ModuleRole data)
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

        public bool CreateList(List<ModuleRole> listData)
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

        public bool Update(ModuleRole data)
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

        public bool UpdateList(List<ModuleRole> listData)
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

        public bool Truncate(ModuleRole data)
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

        public bool TruncateList(List<ModuleRole> listData)
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

        public List<ModuleRole> Get(AasModuleRoleSO search, CommonParam param)
        {
            List<ModuleRole> result = new List<ModuleRole>();
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

        public ModuleRole GetById(long id, AasModuleRoleSO search)
        {
            ModuleRole result = null;
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
