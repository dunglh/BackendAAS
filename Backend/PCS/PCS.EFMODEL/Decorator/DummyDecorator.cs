using System;
using System.Collections.Generic;
using System.Reflection;

namespace PCS.EFMODEL.Decorator
{
    public partial class DummyDecorator
    {
        //Install-Package Npgsql -Version 3.2.5 via NuGet
        //Install-Package EntityFramework6.Npgsql -Version 3.1.1 via NuGet
        //Install Npgsql PostgreeSQL Integration 3.2.1 via Extensions and Updates

        private static Dictionary<Type, List<PropertyInfo>> properties = new Dictionary<Type, List<PropertyInfo>>();
        private static bool isLoaded = false;
        private static void Load()
        {
            try
            {
                if (!isLoaded)
                {

                    isLoaded = true;
                }
            }
            catch (Exception)
            {

            }
        }

        public static void Set<RAW>(RAW raw)
        {
            try
            {
                Load();
                if (properties.ContainsKey(typeof(RAW)))
                {
                    List<PropertyInfo> values = properties[typeof(RAW)];
                    if (values != null && values.Count > 0)
                    {
                        foreach (var property in values)
                        {
                            property.SetValue(raw, "");
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
