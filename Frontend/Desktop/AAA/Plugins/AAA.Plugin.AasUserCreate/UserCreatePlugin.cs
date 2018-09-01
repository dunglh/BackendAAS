using AAA.Plugin.AasUserCreate.View;
using DungLH.Util.CommonLogging;
using DungLH.Util.Plugin.PluginType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.AasUserCreate
{
    public class UserCreatePlugin : WpfWindowPlugin
    {
        public UserCreatePlugin()
        {
            this._pName = "AAA.Plugin.AasUserCreate";
            this._pDescription = "Form Create User (Authenticate Access System)";
        }

        public override object Run(object data)
        {
            try
            {
                return new UserCreateView();
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                return null;
            }
        }
    }
}
