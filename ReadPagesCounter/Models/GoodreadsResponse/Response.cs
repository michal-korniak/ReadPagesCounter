using System.Xml.Serialization;

namespace ReadPagesCounter.Models.GoodreadsResponse
{
    [XmlRoot("GoodreadsResponse")]
    public class Response
    {
        [XmlElement("search")]
        public Search Search { get; set; }
    }
}