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

namespace AAS.GetManager.AasUserRole
{
    public class UserRoleManagerGet : BusinessBase
    {
        public UserRoleManagerGet()
            : base()
        {

        }

        public UserRoleManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<UserRole>> GetResult(UserRoleFilterQuery filter)
        {
            ApiResultObject<List<UserRole>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<UserRole> resultData = null;
                if (valid)
                {
                    resultData = new UserRoleGet(param).Get(filter);
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

        public List<UserRole> Get(UserRoleFilterQuery filter)
        {
            List<UserRole> result = null;
            try
            {
                result = new UserRoleGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public UserRole GetById(long id)
        {
            UserRole result = null;
            try
            {
                result = new UserRoleGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public List<UserRole> GetByUserId(long userId)
        {
            List<UserRole> result = null;
            try
            {
                result = new UserRoleGet(param).GetByUserId(userId);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public List<UserRole> GetByRoleId(long roleId)
        {
            List<UserRole> result = null;
            try
            {
                result = new UserRoleGet(param).GetByRoleId(roleId);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ApiResultObject<List<ViewUserRole>> GetViewResult(AasUserRoleViewFilter filter)
        {
            ApiResultObject<List<ViewUserRole>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ViewUserRole> resultData = null;
                if (valid)
                {
                    resultData = new UserRoleGet(param).GetView(filter);
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

        public List<ViewUserRole> GetView(AasUserRoleViewFilter filter)
        {
            List<ViewUserRole> result = null;
            try
            {
                result = new UserRoleGet(param).GetView(filter);
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
