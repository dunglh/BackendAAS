using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasUser
{
    public class UserManagerGet : BusinessBase
    {
        public UserManagerGet()
            : base()
        {

        }

        public UserManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<User>> GetResult(UserFilterQuery filter)
        {
            ApiResultObject<List<User>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<User> resultData = null;
                if (valid)
                {
                    resultData = new UserGet(param).Get(filter);
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

        public List<User> Get(UserFilterQuery filter)
        {
            List<User> result = null;
            try
            {
                result = new UserGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public User GetById(long id)
        {
            User result = null;
            try
            {
                result = new UserGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public User GetByLoginname(string loginname)
        {
            User result = null;
            try
            {
                result = new UserGet(param).GetByLoginname(loginname);
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
