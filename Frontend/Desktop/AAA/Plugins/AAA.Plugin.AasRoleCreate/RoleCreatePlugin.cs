using AAA.Plugin.AasRoleCreate.View;
using DungLH.Util.CommonLogging;
using DungLH.Util.Plugin.PluginType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasRoleCreate
{
    class RoleCreatePlugin : WpfWindowPlugin
    {
        public RoleCreatePlugin()
        {
            this._pName = "AAA.Plugin.AasRoleCreate";
            this._pDescription = "Form Create Role (Authenticate Access System)";
        }

        public override object Run(object data)
        {
            try
            {
                return new RoleCreateView();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
