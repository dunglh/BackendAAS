using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Core
{
    public class ResultObject
    {
        public object Data { get; set; }
        public int? Total { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResultObject()
        {
        }

        public void SetValue(object resultData, string message, bool success, int? total)
        {
            Data = resultData;
            Message = message;
            Success = success;
            Total = total;
        }
    }
}
