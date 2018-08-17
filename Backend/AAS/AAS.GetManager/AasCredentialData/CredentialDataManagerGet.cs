using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasCredentialData
{
    public class CredentialDataManagerGet : BusinessBase
    {
        public CredentialDataManagerGet()
            : base()
        {

        }

        public CredentialDataManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<CredentialData>> GetResult(CredentialDataFilterQuery filter)
        {
            ApiResultObject<List<CredentialData>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<CredentialData> resultData = null;
                if (valid)
                {
                    resultData = new CredentialDataGet(param).Get(filter);
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

        public List<CredentialData> Get(CredentialDataFilterQuery filter)
        {
            List<CredentialData> result = null;
            try
            {
                result = new CredentialDataGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public CredentialData GetById(long id)
        {
            CredentialData result = null;
            try
            {
                result = new CredentialDataGet(param).GetById(id);
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
