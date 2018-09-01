using AAA.Plugin.AasApplicationCreate.View;
using DungLH.Util.CommonLogging;
using DungLH.Util.Plugin.PluginType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasApplicationCreate
{
    class ApplicationCreatePlugin : WpfWindowPlugin
    {
        public ApplicationCreatePlugin()
        {
            this._pName = "AAA.Plugin.ApplicationCreatePlugin";
            this._pDescription = "Form Create Application (Authenticate Access System)";
        }

        public override object Run(object data)
        {
            try
            {
                return new ApplicationCreateView();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
