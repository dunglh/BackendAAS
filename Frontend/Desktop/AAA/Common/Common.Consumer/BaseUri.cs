using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Consumer
{
    public class ConfigData
    {
        public List<BASE_URI> BASE_URI { get; set; }
    }

    public class BaseUri
    {
        private const string ConfigFile = "ConfigApplication.xml";
        private static List<BASE_URI> CONFIG_DATAs;

        private const string AAS_BASE_URI_KEY = "AAS_BASE_URI";

        private static string _aasBaseUri;
        public static string AAS_BASE_URI
        {
            get
            {
                return _aasBaseUri;
            }
            set
            {
                _aasBaseUri = value;
            }
        }

        public static void LoadConfig()
        {
            try
            {
                if (!File.Exists(ConfigFile))
                {
                    LogSystem.Error("Khong ton tai file cau hinh " + ConfigFile);
                    return;
                }

                using (var reader = new StreamReader(ConfigFile))
                {
                    var serializer = new XmlSerializer(typeof(APP_CONFIG));
                    APP_CONFIG config = serializer.Deserialize(reader) as APP_CONFIG;
                    CONFIG_DATAs = config.BASE_URI;
                }

                if (CONFIG_DATAs == null || CONFIG_DATAs.Count <= 0)
                {
                    LogSystem.Error("Khong tai duoc file cau hinh " + ConfigFile);
                    return;
                }

                BASE_URI aasBaseUri = CONFIG_DATAs.FirstOrDefault(o => o.KEY == AAS_BASE_URI_KEY);
                if (aasBaseUri != null)
                {
                    _aasBaseUri = aasBaseUri.VALUE;
                }
                else
                {
                    LogSystem.Error("Khong co cau hinh dia chi AAS; KEY: " + AAS_BASE_URI_KEY);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }
    }
}
