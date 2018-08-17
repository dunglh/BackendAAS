using AAS.EFMODEL.DataModels;
using System.Collections.Generic;
using System.Reflection;

namespace AAS.EFMODEL.Decorator
{
    public partial class DenyUpdateDecorator
    {
        private static void LoadUser()
        {
            List<string> pies = new List<string>();
            pies.Add("Creator");
            pies.Add("CreateTime");
            pies.Add("Loginname");

            properties[typeof(User)] = pies;
        }
    }
}
