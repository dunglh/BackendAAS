using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Plugin
{
    public class PluginManager
    {
        private static object _LockObj = new object();

        private static Dictionary<string, IPlugin> _DIC_PLUGIN = new Dictionary<string, IPlugin>();

        public static void LoadPlugin(string path)
        {
            try
            {
                lock (_LockObj)
                {
                    _DIC_PLUGIN = new Dictionary<string, IPlugin>();
                    ICollection<IPlugin> plugins = PluginLoader.LoadPlugins(path);
                    if (plugins != null)
                    {
                        foreach (IPlugin plugin in plugins)
                        {
                            if (!_DIC_PLUGIN.ContainsKey(plugin.PluginName))
                            {
                                _DIC_PLUGIN[plugin.PluginName] = plugin;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                _DIC_PLUGIN = new Dictionary<string, IPlugin>();
            }
        }

        public static IPlugin GetPlugin(string name)
        {
            try
            {
                if (_DIC_PLUGIN.ContainsKey(name))
                {
                    return _DIC_PLUGIN[name];
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
