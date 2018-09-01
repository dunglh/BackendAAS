using DungLH.Util.CommonLogging;
using DungLH.Util.Plugin.PluginType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Plugin
{
    class PluginLoader
    {
        internal static ICollection<IPlugin> LoadPlugins(string path)
        {
            try
            {
                string[] dllFileNames = null;
                if (Directory.Exists(path))
                {
                    dllFileNames = Directory.GetFiles(path, "*.dll");
                    List<Assembly> assemblies = new List<Assembly>();
                    foreach (string fileName in dllFileNames)
                    {
                        AssemblyName assemblyName = AssemblyName.GetAssemblyName(fileName);
                        Assembly assembly = Assembly.Load(assemblyName);
                        assemblies.Add(assembly);
                    }

                    List<Type> pluginTypes = new List<Type>();
                    foreach (Assembly assembly in assemblies)
                    {
                        if (assembly == null)
                        {
                            continue;
                        }
                        Type[] types = assembly.GetTypes();
                        if (types == null || types.Length <= 0)
                        {
                            continue;
                        }

                        foreach (Type type in types)
                        {
                            if (type.IsAbstract || type.IsInterface)
                            {
                                continue;
                            }

                            if (type.IsSubclassOf(typeof(IPlugin)) &&
                                (type.IsSubclassOf(typeof(FormPlugin))
                                || type.IsSubclassOf(typeof(FormUcPlugin))
                                || type.IsSubclassOf(typeof(WpfWindowPlugin))
                                || type.IsSubclassOf(typeof(WpfUcPlugin)))
                                )
                            {
                                pluginTypes.Add(type);
                            }
                        }
                    }

                    List<IPlugin> plugins = new List<IPlugin>();
                    foreach (Type type in pluginTypes)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }
                    return plugins;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return null;
        }
    }
}
