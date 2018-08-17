using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using MyUtil.Repository;
using System;
using System.Collections.Generic;

namespace AAS.DAO.AasModule
{
    public partial class AasModuleDAO : EntityBase
    {
        private AasModuleCreate CreateWorker
        {
            get
            {
                return (AasModuleCreate)Worker.Get<AasModuleCreate>();
            }
        }
        private AasModuleUpdate UpdateWorker
        {
            get
            {
                return (AasModuleUpdate)Worker.Get<AasModuleUpdate>();
            }
        }
        private AasModuleTruncate TruncateWorker
        {
            get
            {
                return (AasModuleTruncate)Worker.Get<AasModuleTruncate>();
            }
        }
        private AasModuleGet GetWorker
        {
            get
            {
                return (AasModuleGet)Worker.Get<AasModuleGet>();
            }
        }
        private AasModuleCheck CheckWorker
        {
            get
            {
                return (AasModuleCheck)Worker.Get<AasModuleCheck>();
            }
        }

        public bool Create(Module data)
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

        public bool CreateList(List<Module> listData)
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

        public bool Update(Module data)
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

        public bool UpdateList(List<Module> listData)
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

        public bool Truncate(Module data)
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

        public bool TruncateList(List<Module> listData)
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

        public List<Module> Get(AasModuleSO search, CommonParam param)
        {
            List<Module> result = new List<Module>();
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

        public Module GetById(long id, AasModuleSO search)
        {
            Module result = null;
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
