using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Backend.MANAGER
{
    public class BusinessBase : EntityBase
    {
        protected CommonParam param { get; set; }

        public BusinessBase()
            : base()
        {
            param = new CommonParam();
            try
            {
                UserName = DungLH.Util.Token.Backend.BackendTokenManager.GetLoginname();
            }
            catch (Exception)
            {
            }
        }

        public BusinessBase(CommonParam paramBusiness)
            : base()
        {
            param = (paramBusiness != null ? paramBusiness : new CommonParam());
            try
            {
                UserName = DungLH.Util.Token.Backend.BackendTokenManager.GetLoginname();
            }
            catch (Exception)
            {
            }
        }

        public bool HasException()
        {
            return param.HasException;
        }

        public void CopyCommonParamInfoGet(CommonParam paramSource)
        {
            try
            {
                param.Start = paramSource.Start;
                param.Limit = paramSource.Limit;
                param.Count = paramSource.Count;
                param.HasException = paramSource.HasException;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public void CopyCommonParamInfo(CommonParam paramSource)
        {
            try
            {
                if (paramSource.BugCodes != null && paramSource.BugCodes.Count > 0) param.BugCodes.AddRange(paramSource.BugCodes);
                if (paramSource.Messages != null && paramSource.Messages.Count > 0) param.Messages.AddRange(paramSource.Messages);
                param.Start = paramSource.Start;
                param.Limit = paramSource.Limit;
                param.Count = paramSource.Count;
                param.HasException = paramSource.HasException;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public void CopyCommonParamInfo(BusinessBase fromObject)
        {
            try
            {
                if (fromObject.param != null)
                {
                    if (fromObject.param.BugCodes != null && fromObject.param.BugCodes.Count > 0) param.BugCodes.AddRange(fromObject.param.BugCodes);
                    if (fromObject.param.Messages != null && fromObject.param.Messages.Count > 0) param.Messages.AddRange(fromObject.param.Messages);
                    param.Start = fromObject.param.Start;
                    param.Limit = fromObject.param.Limit;
                    param.Count = fromObject.param.Count;
                    param.HasException = fromObject.param.HasException;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        protected ApiResultObject<T> PackResult<T>(T resultData)
        {
            ApiResultObject<T> result = new ApiResultObject<T>();
            try
            {
                bool success = ResultUtil.DecisionApiResult(resultData);
                result.SetValue(resultData, success, param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                LogSystem.Error(LogUtil.TraceData("resultData", resultData));
                result = new ApiResultObject<T>(default(T), false);
            }
            return result;
        }

        protected void FailLog(bool success, object input, object output)
        {
            try
            {
                if (!success)
                {
                    try
                    {
                        if (String.IsNullOrEmpty(MethodName))
                        {
                            MethodName = string.Format("{0}", new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Error(ex);
                    }
                    string loginname = DungLH.Util.Token.Backend.BackendTokenManager.GetLoginname();

                    LogSystem.Error(String.Format("\n- Xu ly that bai: \n- Loginname: {0} \n- Class: {1} \n- Method: {2} \n- Input: {3} \n- Output: {4} \n- Param: {5}", loginname, ClassName, MethodName, JsonConvert.SerializeObject(input), JsonConvert.SerializeObject(output), Newtonsoft.Json.JsonConvert.SerializeObject(param)));
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
