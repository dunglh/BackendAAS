using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using AAS.Filter;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasApplicationRole
{
    public class ApplicationRoleManagerGet : BusinessBase
    {
        public ApplicationRoleManagerGet()
            : base()
        {

        }

        public ApplicationRoleManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<ApplicationRole>> GetResult(ApplicationRoleFilterQuery filter)
        {
            ApiResultObject<List<ApplicationRole>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ApplicationRole> resultData = null;
                if (valid)
                {
                    resultData = new ApplicationRoleGet(param).Get(filter);
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

        public List<ApplicationRole> Get(ApplicationRoleFilterQuery filter)
        {
            List<ApplicationRole> result = null;
            try
            {
                result = new ApplicationRoleGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ApplicationRole GetById(long id)
        {
            ApplicationRole result = null;
            try
            {
                result = new ApplicationRoleGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public List<ApplicationRole> GetByApplicationId(long applicationId)
        {
            List<ApplicationRole> result = null;
            try
            {
                result = new ApplicationRoleGet(param).GetByApplicationId(applicationId);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public List<ApplicationRole> GetByRoleId(long roleId)
        {
            List<ApplicationRole> result = null;
            try
            {
                result = new ApplicationRoleGet(param).GetByRoleId(roleId);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ApiResultObject<List<ViewApplicationRole>> GetViewResult(AasApplicationRoleViewFilter filter)
        {
            ApiResultObject<List<ViewApplicationRole>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ViewApplicationRole> resultData = null;
                if (valid)
                {
                    resultData = new ApplicationRoleGet(param).GetView(filter);
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

        public List<ViewApplicationRole> GetView(AasApplicationRoleViewFilter filter)
        {
            try
            {
                return new ApplicationRoleGet(param).GetView(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
            }
            return null;
        }
    }
}
