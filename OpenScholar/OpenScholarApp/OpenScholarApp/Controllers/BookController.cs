using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.BookException;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookController(IBookService bookService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _bookService = bookService;
        }

        [HttpPost("addBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto book)
        {
            try
            {
                //var userId = GetAuthorizedUserId();
                var user = await _userManager.GetUserAsync(User);
             if (user == null) { throw new UserNotFoundException($"User with id {user.Id} doesnt exist"); }
                await _bookService.Add(book, user.Id.ToString());
                return StatusCode(StatusCodes.Status201Created, "New Book was added");
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

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                await _bookService.GetAll();
                return StatusCode(StatusCodes.Status201Created, "New Book was added");
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

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?
                .Value, out var userId))
            {
                string? name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new UserNotFoundException(
                    "Name identifier claim does not exist!");
            }
            return userId;
        }

    }
}
