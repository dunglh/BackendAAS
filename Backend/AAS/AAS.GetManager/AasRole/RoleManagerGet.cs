using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasRole
{
    public class RoleManagerGet : BusinessBase
    {
        public RoleManagerGet()
            : base()
        {

        }

        public RoleManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Role>> GetResult(RoleFilterQuery filter)
        {
            ApiResultObject<List<Role>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Role> resultData = null;
                if (valid)
                {
                    resultData = new RoleGet(param).Get(filter);
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

        public List<Role> Get(RoleFilterQuery filter)
        {
            List<Role> result = null;
            try
            {
                result = new RoleGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Role GetById(long id)
        {
            Role result = null;
            try
            {
                result = new RoleGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Role GetByCode(string code)
        {
            Role result = null;
            try
            {
                result = new RoleGet(param).GetByCode(code);
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
