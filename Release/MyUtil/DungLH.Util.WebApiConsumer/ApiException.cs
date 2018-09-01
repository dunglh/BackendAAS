using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.WebApiConsumer
{
    public class ApiException : Exception
    {
        /// <summary>
        /// Ma HttpCode khi goi API
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
