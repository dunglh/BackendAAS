using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Repository;
using System;
using System.Collections.Generic;

namespace PCS.DAO.PcsEmployee
{
    public partial class PcsEmployeeDAO : EntityBase
    {
        private PcsEmployeeCreate CreateWorker
        {
            get
            {
                return (PcsEmployeeCreate)Worker.Get<PcsEmployeeCreate>();
            }
        }
        private PcsEmployeeUpdate UpdateWorker
        {
            get
            {
                return (PcsEmployeeUpdate)Worker.Get<PcsEmployeeUpdate>();
            }
        }
        private PcsEmployeeTruncate TruncateWorker
        {
            get
            {
                return (PcsEmployeeTruncate)Worker.Get<PcsEmployeeTruncate>();
            }
        }
        private PcsEmployeeGet GetWorker
        {
            get
            {
                return (PcsEmployeeGet)Worker.Get<PcsEmployeeGet>();
            }
        }
        private PcsEmployeeCheck CheckWorker
        {
            get
            {
                return (PcsEmployeeCheck)Worker.Get<PcsEmployeeCheck>();
            }
        }

        public bool Create(Employee data)
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

        public bool CreateList(List<Employee> listData)
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

        public bool Update(Employee data)
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

        public bool UpdateList(List<Employee> listData)
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

        public bool Truncate(Employee data)
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

        public bool TruncateList(List<Employee> listData)
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

        public List<Employee> Get(PcsEmployeeSO search, CommonParam param)
        {
            List<Employee> result = new List<Employee>();
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

        public Employee GetById(long id, PcsEmployeeSO search)
        {
            Employee result = null;
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

        public Employee GetByLoginname(string loginname, PcsEmployeeSO search)
        {
            Employee result = null;

            try
            {
                result = GetWorker.GetByLoginname(loginname, search);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }

            return result;
        }

        public bool ExistsLoginname(string code, long? id)
        {

            try
            {
                return CheckWorker.ExistsLoginname(code, id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw;
            }
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
