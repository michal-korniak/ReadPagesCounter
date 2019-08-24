using System.Collections.Generic;
using System.Xml.Serialization;

namespace ReadPagesCounter.Models.GoodreadsResponse
{
    [XmlRoot("results")]
    public class Result
    {
        [XmlElement("work")]
        public List<Work> Works { get; set; }
    }
}