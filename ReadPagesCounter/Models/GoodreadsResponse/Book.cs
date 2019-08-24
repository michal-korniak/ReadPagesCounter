namespace ReadPagesCounter.Models.GoodreadsResponse
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
    }
}