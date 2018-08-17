﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Repository
{
    public static class Worker
    {
        private static Dictionary<Type, object> dic = new Dictionary<Type, object>();
        private static Object thisLock = new Object();

        public static object Get<T>() where T : class
        {
            Type type = typeof(T);
            object result = null;
            lock (thisLock)
            {
                if (!dic.TryGetValue(type, out result))
                {
                    result = Activator.CreateInstance(type);
                    dic.Add(type, result);
                }
            }
            return result;
        }
    }
}
