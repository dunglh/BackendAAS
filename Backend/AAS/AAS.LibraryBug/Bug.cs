namespace AAS.LibraryBug
{
    public partial class Bug
    {
        public string code;
        public Enum enumBC;

        private static string defaultViMessage = "AAS000";

        public Bug(Enum en)
        {
            enumBC = en;
            code = GetCode(en);
        }
    }
}
