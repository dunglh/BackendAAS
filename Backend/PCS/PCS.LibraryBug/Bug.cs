﻿namespace PCS.LibraryBug
{
    public partial class Bug
    {
        public string code;
        public Enum enumBC;

        private static string defaultViMessage = "PCS000";

        public Bug(Enum en)
        {
            enumBC = en;
            code = GetCode(en);
        }
    }
}
