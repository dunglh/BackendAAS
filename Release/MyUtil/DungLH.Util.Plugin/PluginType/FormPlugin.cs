using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Plugin.PluginType
{
    public abstract class FormPlugin : IPlugin
    {
        protected string _pName;
        protected string _pDescription;
        
        public string PluginName
        {
            get { return _pName; }
            private set { _pName = value; }
        }

        public string PluginDescription
        {
            get { return _pDescription; }
            private set { _pDescription = value; }
        }

        public PType PluginType
        {
            get { return PType.FORM; }
        }

        public abstract object Run(object data);
    }
}
