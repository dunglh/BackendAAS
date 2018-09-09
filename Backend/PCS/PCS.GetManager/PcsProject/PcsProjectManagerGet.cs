using PCS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.GetManager.PcsProject
{
    public class PcsProjectManagerGet : BusinessBase
    {
        public PcsProjectManagerGet()
            : base()
        {

        }

        public PcsProjectManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Project>> GetResult(PcsProjectFilterQuery filter)
        {
            ApiResultObject<List<Project>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Project> resultData = null;
                if (valid)
                {
                    resultData = new PcsProjectGet(param).Get(filter);
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

        public List<Project> Get(PcsProjectFilterQuery filter)
        {
            List<Project> result = null;
            try
            {
                result = new PcsProjectGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Project GetById(long id)
        {
            Project result = null;
            try
            {
                result = new PcsProjectGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Project GetByCode(string code)
        {
            Project result = null;
            try
            {
                result = new PcsProjectGet(param).GetByCode(code);
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
