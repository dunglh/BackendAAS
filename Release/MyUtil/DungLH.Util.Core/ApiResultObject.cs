using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Core
{
    public class ApiResultObject<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public CommonParam Param { get; set; }
        public ApiResultObject()
        {
        }

        public ApiResultObject(T data)
        {
            Data = data;
        }

        public ApiResultObject(T data, bool success)
        {
            Data = data;
            Success = success;
        }

        public void SetValue(T data, bool success, CommonParam param)
        {
            Data = data;
            Success = success;
            Param = param;
        }

        public ResultObject ConvertToResultObject()
        {
            ResultObject result = new ResultObject();
            try
            {
                result.Data = this.Data;
                result.Success = this.Success;
                result.Total = (Param != null ? Param.Count : 0);
            }
            catch (Exception ex)
            {
                DungLH.Util.CommonLogging.LogSystem.Error(ex);
                result = new ResultObject();
            }
            return result;
        }
    }
}
