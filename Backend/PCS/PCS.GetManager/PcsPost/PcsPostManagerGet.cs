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

namespace PCS.GetManager.PcsPost
{
    public class PcsPostManagerGet : BusinessBase
    {
        public PcsPostManagerGet()
            : base()
        {

        }

        public PcsPostManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Post>> GetResult(PcsPostFilterQuery filter)
        {
            ApiResultObject<List<Post>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Post> resultData = null;
                if (valid)
                {
                    resultData = new PcsPostGet(param).Get(filter);
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

        public List<Post> Get(PcsPostFilterQuery filter)
        {
            List<Post> result = null;
            try
            {
                result = new PcsPostGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Post GetById(long id)
        {
            Post result = null;
            try
            {
                result = new PcsPostGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ApiResultObject<List<ViewPost>> GetViewResult(PcsPostViewFilter filter)
        {
            ApiResultObject<List<ViewPost>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ViewPost> resultData = null;
                if (valid)
                {
                    resultData = new PcsPostGet(param).GetView(filter);
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

        public List<ViewPost> GetView(PcsPostViewFilter filter)
        {
            List<ViewPost> result = null;
            try
            {
                result = new PcsPostGet(param).GetView(filter);
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
