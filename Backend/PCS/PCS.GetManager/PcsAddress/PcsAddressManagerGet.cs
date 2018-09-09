using PCS.EFMODEL.DataModels;
using PCS.Filter;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCS.EFMODEL.View;

namespace PCS.GetManager.PcsAddress
{
    public class PcsAddressManagerGet : BusinessBase
    {
        public PcsAddressManagerGet()
            : base()
        {

        }

        public PcsAddressManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Address>> GetResult(PcsAddressFilterQuery filter)
        {
            ApiResultObject<List<Address>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Address> resultData = null;
                if (valid)
                {
                    resultData = new PcsAddressGet(param).Get(filter);
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

        public List<Address> Get(PcsAddressFilterQuery filter)
        {
            List<Address> result = null;
            try
            {
                result = new PcsAddressGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Address GetById(long id)
        {
            Address result = null;
            try
            {
                result = new PcsAddressGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ApiResultObject<List<ViewAddress>> GetViewResult(PcsAddressViewFilter filter)
        {
            ApiResultObject<List<ViewAddress>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ViewAddress> resultData = null;
                if (valid)
                {
                    resultData = new PcsAddressGet(param).GetView(filter);
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

        public List<ViewAddress> GetView(PcsAddressViewFilter filter)
        {
            try
            {
                return new PcsAddressGet(param).GetView(filter);
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
