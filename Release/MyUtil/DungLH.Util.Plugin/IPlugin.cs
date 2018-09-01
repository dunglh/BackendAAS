using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Plugin
{
    public enum PType
    {
        FORM = 1,
        FORM_UC = 2,
        WPF_WINDOW = 3,
        WPF_UC = 4
    }
    public interface IPlugin
    {
        string PluginName { get;}
        string PluginDescription { get; }
        PType PluginType { get; }

        object Run(object data);
    }
}
