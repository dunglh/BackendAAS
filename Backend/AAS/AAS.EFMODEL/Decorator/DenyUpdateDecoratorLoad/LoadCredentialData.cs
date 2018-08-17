using AAS.EFMODEL.DataModels;
using System.Collections.Generic;
using System.Reflection;

namespace AAS.EFMODEL.Decorator
{
    public partial class DenyUpdateDecorator
    {
        private static void LoadCredentialData()
        {
            List<string> pies = new List<string>();
            pies.Add("Creator");
            pies.Add("CreateTime");

            properties[typeof(CredentialData)] = pies;
        }
    }
}
