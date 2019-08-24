using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadPagesCounter.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int? PublicationYear { get; set; }
        public decimal AverageRating { get; set; }
        public int RatingsCount { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
    }
}
