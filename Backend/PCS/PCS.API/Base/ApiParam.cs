using DungLH.Util.Core;

namespace PCS.API.Base
{
    public class ApiParam<T>
    {
        public CommonParam CommonParam { get; set; }
        public T ApiData { get; set; }
    }
}