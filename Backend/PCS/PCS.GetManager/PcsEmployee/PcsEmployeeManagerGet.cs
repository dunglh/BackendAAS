using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.GetManager.PcsEmployee
{
    public class PcsEmployeeManagerGet : BusinessBase
    {
        public PcsEmployeeManagerGet()
            : base()
        {

        }

        public PcsEmployeeManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Employee>> GetResult(PcsEmployeeFilterQuery filter)
        {
            ApiResultObject<List<Employee>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Employee> resultData = null;
                if (valid)
                {
                    resultData = new PcsEmployeeGet(param).Get(filter);
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, filter, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public List<Employee> Get(PcsEmployeeFilterQuery filter)
        {
            List<Employee> result = null;
            try
            {
                result = new PcsEmployeeGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Employee GetById(long id)
        {
            Employee result = null;
            try
            {
                result = new PcsEmployeeGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Employee GetByLoginname(string loginname)
        {
            Employee result = null;
            try
            {
                result = new PcsEmployeeGet(param).GetByLoginname(loginname);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

    }
}
