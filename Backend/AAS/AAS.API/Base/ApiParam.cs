using MyUtil.Core;

namespace AAS.API.Base
{
    public class ApiParam<T>
    {
        public CommonParam CommonParam { get; set; }
        public T ApiData { get; set; }
    }
}