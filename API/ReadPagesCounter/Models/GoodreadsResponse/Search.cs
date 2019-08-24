using System.Collections.Generic;
using System.Xml.Serialization;

namespace ReadPagesCounter.Models.GoodreadsResponse
{
    [XmlRoot("search")]
    public class Search
    {
        [XmlElement("results")]
        public Result Result { get; set; }
    }
}