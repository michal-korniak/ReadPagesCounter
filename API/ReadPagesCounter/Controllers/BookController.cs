using Microsoft.AspNetCore.Mvc;
using ReadPagesCounter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadPagesCounter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("ByQuery")]
        public async Task<ActionResult<IEnumerable<object>>> GetCollectionByQuery([FromQuery] string query)
        {
            var result=await _bookService.GetCollectionByQuery(query);
            return Ok(result);
        }
        [HttpGet("{id}/numberOfPages")]
        public async Task<ActionResult<int>> GetNumberOfPages([FromRoute] int id)
        {
            int result = await _bookService.GetNumberOfPages(id);
            return Ok(result);
        }

    }
}
