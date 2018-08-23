using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Repository
{
    public static class Properties
    {
        private static Dictionary<Type, PropertyInfo[]> dic = new Dictionary<Type, PropertyInfo[]>();

        private static List<Type> listAllowType = new List<Type>() { typeof(string), typeof(long), typeof(Nullable<long>), typeof(decimal), typeof(Nullable<decimal>), typeof(short), typeof(Nullable<short>), typeof(bool), typeof(Nullable<bool>), typeof(int), typeof(Nullable<int>), typeof(double), typeof(Nullable<double>), typeof(float), typeof(Nullable<float>), typeof(DateTime), typeof(Nullable<DateTime>) };

        public static PropertyInfo[] Get<T>() where T : class
        {
            Type type = typeof(T);
            PropertyInfo[] result = null;
            if (!dic.TryGetValue(type, out result))
            {
                result = type.GetProperties();
                List<PropertyInfo> listTemp = new List<PropertyInfo>();
                foreach (var pi in result)
                {
                    if (listAllowType.Contains(pi.PropertyType))
                    {
                        listTemp.Add(pi);
                    }
                }
                result = listTemp.ToArray();
                dic.Add(type, result);
            }
            return result;
        }

        public static PropertyInfo[] Get(Type type)
        {
            PropertyInfo[] result = null;
            if (!dic.TryGetValue(type, out result))
            {
                result = type.GetProperties();
                List<PropertyInfo> listTemp = new List<PropertyInfo>();
                foreach (var pi in result)
                {
                    if (listAllowType.Contains(pi.PropertyType))
                    {
                        listTemp.Add(pi);
                    }
                }
                result = listTemp.ToArray();
                dic.Add(type, result);
            }
            return result;
        }
    }
}
