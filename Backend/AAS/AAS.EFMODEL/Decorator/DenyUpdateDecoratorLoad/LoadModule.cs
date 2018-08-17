using AAS.EFMODEL.DataModels;
using System.Collections.Generic;

namespace AAS.EFMODEL.Decorator
{
    public partial class DenyUpdateDecorator
    {
        private static void LoadModule()
        {
            List<string> pies = new List<string>();
            pies.Add("Creator");
            pies.Add("CreateTime");

            properties[typeof(Module)] = pies;
        }
    }
}
