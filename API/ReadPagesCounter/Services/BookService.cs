using HtmlAgilityPack;
using ReadPagesCounter.DTO;
using ReadPagesCounter.Extensions;
using ReadPagesCounter.Models.GoodreadsResponse;
using ReadPagesCounter.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReadPagesCounter.Services
{
    public class BookService : IBookService
    {
        public async Task<IEnumerable<BookDto>> GetCollectionByQuery(string query)
        {
            Stream contentStream = null;
            using (var httpClient = new HttpClient())
            {
                string key = "je5UJo64v6sMy5fB88cSbA";
                var responseMessage = await httpClient.GetAsync($"https://www.goodreads.com/search/index.xml?key={key}&q={query}");
                contentStream = await responseMessage.Content.ReadAsStreamAsync();
            }
            var responseSerializer = new XmlSerializer(typeof(Response));
            var response = (Response)responseSerializer.Deserialize(contentStream);

            return response.Search.Result.Works.Select(x => new BookDto()
            {
                Id = x.Id,
                Title = x.BestBook.Title,
                AuthorName = x.BestBook.Author.Name,
                AverageRating = x.AverageRating,
                PublicationYear = !string.IsNullOrEmpty(x.OriginalPublicationYear) ? int.Parse(x.OriginalPublicationYear) : (int?)null,
                ImageUrl = x.BestBook.ImageUrl,
                SmallImageUrl = x.BestBook.SmallImageUrl,
                RatingsCount = x.RatingsCount,
                BestEditionId = x.BestBook.Id
            });
        }

        public async Task<int> GetNumberOfPages(int id)
        {
            string htmlContent = null;
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync($"https://www.goodreads.com/work/editions/{id}");
                htmlContent = await responseMessage.Content.ReadAsStringAsync();
            }
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);
            var allElementsWithClassEditionData = doc.DocumentNode.SelectNodes("//div[@class='editionData']");
            double? medianNumberOfPages = allElementsWithClassEditionData
                .SelectMany(x => x.ChildNodes)
                .Where(x => x.InnerText.Contains("pages"))
                .Select(x => Regex.Match(x.InnerText, @"\b\d[\d,.]*\b pages"))
                .Where(x => x.Success)
                .Select(x => x.Groups[0].Value.Replace(" pages", string.Empty).Replace(",", string.Empty))
                .Select(x => int.Parse(x))
                .Median();

            if (medianNumberOfPages == null)
            {
                throw new System.Exception($"Calculated median is null for id: ${id}");
            }

            return (int)medianNumberOfPages;
        }
    }
}

