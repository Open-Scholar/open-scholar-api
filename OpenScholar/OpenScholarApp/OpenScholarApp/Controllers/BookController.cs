using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;

namespace OpenScholarApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

            public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("addBook")]
        public async Task<IActionResult> AddBook([FromBody] BookDto book)
        {
            try
            {
                await _bookService.AddBook(book, 1);
                return StatusCode(StatusCodes.Status201Created, "New reminder was added");
            }
            catch (BookDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }



    }
}
