using ReadPagesCounter.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadPagesCounter.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetCollectionByQuery(string query);
        Task<int> GetNumberOfPages(int id);
    }
}
