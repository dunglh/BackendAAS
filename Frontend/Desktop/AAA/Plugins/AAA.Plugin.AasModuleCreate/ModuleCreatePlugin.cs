using AAA.Plugin.AasModuleCreate.View;
using DungLH.Util.CommonLogging;
using DungLH.Util.Plugin.PluginType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasModuleCreate
{
    public class ModuleCreatePlugin : WpfWindowPlugin
    {
        public ModuleCreatePlugin()
        {
            this._pName = "AAA.Plugin.AasModuleCreate";
            this._pDescription = "Form Create Module (Authenticate Access System)";
        }

        public override object Run(object data)
        {
            try
            {
                return new ModuleCreateView();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
