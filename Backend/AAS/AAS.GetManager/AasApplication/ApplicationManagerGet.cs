using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasApplication
{
    public class ApplicationManagerGet : BusinessBase
    {
        public ApplicationManagerGet()
            : base()
        {

        }

        public ApplicationManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Application>> GetResult(ApplicationFilterQuery filter)
        {
            ApiResultObject<List<Application>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Application> resultData = null;
                if (valid)
                {
                    resultData = new ApplicationGet(param).Get(filter);
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

        public List<Application> Get(ApplicationFilterQuery filter)
        {
            List<Application> result = null;
            try
            {
                result = new ApplicationGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Application GetById(long id)
        {
            Application result = null;
            try
            {
                result = new ApplicationGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Application GetByCode(string code)
        {
            Application result = null;
            try
            {
                result = new ApplicationGet(param).GetByCode(code);
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
