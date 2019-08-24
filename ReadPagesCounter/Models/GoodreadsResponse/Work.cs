using System.Xml.Serialization;

namespace ReadPagesCounter.Models.GoodreadsResponse
{
    [XmlRoot("work")]
    public class Work
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("books_count")]
        public int BooksCount { get; set; }
        [XmlElement("ratings_count")]
        public int RatingsCount { get; set; }
        [XmlElement("text_reviews_count")]
        public int TextReviewsCount { get; set; }
        [XmlElement("original_publication_year")]
        public int OriginalPublicationYear { get; set; }
        [XmlElement("average_rating")]
        //public decimal AverageRating { get; set; }
        //[XmlElement("best_book")]
        public Book BestBook { get; set; }
    }
}