using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Consumer
{
    [XmlType("BASE_URI")]
    public class BASE_URI
    {
        [XmlElement(ElementName = "KEY")]
        public string KEY { get; set; }

        [XmlElement(ElementName = "VALUE")]
        public string VALUE { get; set; }
    }
}
