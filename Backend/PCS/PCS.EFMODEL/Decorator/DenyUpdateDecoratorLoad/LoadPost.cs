using PCS.EFMODEL.DataModels;
using System.Collections.Generic;
using System.Reflection;

namespace PCS.EFMODEL.Decorator
{
    public partial class DenyUpdateDecorator
    {
        private static void LoadPost()
        {
            List<string> pies = new List<string>();
            pies.Add("Creator");
            pies.Add("CreateTime");

            properties[typeof(Post)] = pies;
        }
    }
}
