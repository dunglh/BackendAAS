using PCS.EFMODEL.DataModels;
using System.Collections.Generic;

namespace PCS.EFMODEL.Decorator
{
    public partial class DenyUpdateDecorator
    {
        private static void LoadEmployee()
        {
            List<string> pies = new List<string>();
            pies.Add("Creator");
            pies.Add("CreateTime");

            properties[typeof(Employee)] = pies;
        }
    }
}
