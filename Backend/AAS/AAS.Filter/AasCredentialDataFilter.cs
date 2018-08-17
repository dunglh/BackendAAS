
namespace AAS.Filter
{
    public class AasCredentialDataFilter : FilterBase
    {
        public string BackendCodeExact { get; set; }
        public string TokenCodeExact { get; set; }
        public string DataKeyExact { get; set; }
        public AasCredentialDataFilter()
            : base()
        {
        }
    }
}
