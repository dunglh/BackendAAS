using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Consumer
{
    [Serializable, XmlRoot(ElementName = "APP_CONFIG"), XmlType("APP_CONFIG")]
    public class APP_CONFIG
    {
        [XmlElement(ElementName = "BASE_URI")]
        public List<BASE_URI> BASE_URI { get; set; }
    }
}
