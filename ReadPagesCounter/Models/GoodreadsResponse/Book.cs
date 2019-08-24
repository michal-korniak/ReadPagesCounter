using System.Xml.Serialization;

namespace ReadPagesCounter.Models.GoodreadsResponse
{
    [XmlRoot("best_book")]
    public class Book
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("author")]
        public Author Author { get; set; }
        [XmlElement("image_url")]
        public string ImageUrl { get; set; }
        [XmlElement("small_image_url")]
        public string SmallImageUrl { get; set; }
    }
}